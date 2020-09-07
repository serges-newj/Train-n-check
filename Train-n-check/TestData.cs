using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace TestData
{
	public class QuestionSet
	{
		private string name;
		private string fileName = null;
		private readonly Dictionary<int, Question> questions = new Dictionary<int, Question>();
		private readonly Dictionary<string, List<int>> categoryIndex = new Dictionary<string, List<int>>();
		private readonly List<string> selectedCategories = new List<string>();
		private readonly Dictionary<string, int> sourceIndex = new Dictionary<string, int>();
		private readonly List<string> selectedSources = new List<string>();
		private bool isChecked = false;
		private bool isModified = false;

		public QuestionSet()
		{
		}

		public QuestionSet(string name)
		{
			this.name = name;
		}

		public QuestionSet(string name, Dictionary<int, Question> questions)
			: this(name)
		{
			this.questions = questions;
		}

		public static QuestionSet LoadFromXML(string fileName)
		{
			QuestionSet qs = null;
			Stream zip =
				new DeflateStream(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read),
								  CompressionMode.Decompress, false);
			XmlReader xReader = null;
			try
			{
				xReader = XmlReader.Create(zip);
			}
			catch
			{
				xReader = XmlReader.Create(fileName);
			}

			using (xReader)
			{
				Question q = null;
				xReader.Read();
				while (!xReader.EOF)
				{
					switch (xReader.NodeType)
					{
						case XmlNodeType.Element:
							switch (xReader.Name)
							{
								case "Questions":
									qs = new QuestionSet(xReader["Name"]);
									xReader.Read();
									break;
								case "Question":
									if (q != null)
									{
										if (qs != null)
										{
											qs[q.ID] = q;
										}
									}
									q = new Question(Convert.ToInt32(xReader["ID"]));
									xReader.Read();
									break;
								case "Category":
									if (q != null) q.Categories.Add(xReader.ReadElementContentAsString());
									break;
								case "Source":
									if (q != null) q.Source = xReader.ReadElementContentAsString();
									break;
								case "Text":
									if (q != null)
									{
										Question.TextSectionFormat fmt = Question.TextSectionFormat.None;
										if (xReader.HasAttributes)
										{
											fmt = (Question.TextSectionFormat)
												Enum.Parse(typeof(Question.TextSectionFormat), xReader["Format"]);
										}
										q.AppendTextSection(fmt, xReader.ReadElementContentAsString().Replace("\n", "\r\n"));
									}
									else
									{
										xReader.Read();
									}
									break;
								case "Answer":
									if (q != null)
									{
										bool valid = Convert.ToBoolean(xReader["Valid"]);
										q.Answer.Variants.Add(new Variant(xReader.ReadElementContentAsString().Replace("\n", "\r\n"), valid));
									}
									else
									{
										xReader.Read();
									}
									break;
								default:
									xReader.Read();
									break;
							}
							break;
						default:
							xReader.Read();
							break;
					}
				}
				if (q != null)
				{
					if (qs != null)
					{
						qs[q.ID] = q;
					}
				}
			}
			qs.fileName = fileName;
			qs.isModified = false;
			return qs;
		}

		public void SaveToXML()
		{
			SaveToXML(this.fileName);
		}

		public void SaveToXML(string fileName)
		{
			bool bZip = !(fileName.Substring(fileName.Length - 4).ToLower() == ".xml");
			XmlDocument xdoc = new XmlDocument();
			XmlElement rootNode = xdoc.CreateElement("Questions");
			rootNode.Attributes.Append(xdoc.CreateAttribute("Name"));
			rootNode.Attributes["Name"].Value = this.name;
			int[] sortedKeys = new int[questions.Count];
			questions.Keys.CopyTo(sortedKeys, 0);
			Array.Sort(sortedKeys);

			foreach (int idx in sortedKeys)
			{
				Question q = questions[idx];
				XmlElement qEl = xdoc.CreateElement("Question");
				qEl.Attributes.Append(xdoc.CreateAttribute("ID"));
				qEl.Attributes["ID"].Value = q.ID.ToString();
				//
				if (q.Source != String.Empty)
				{
					XmlElement src = xdoc.CreateElement("Source");
					src.AppendChild(xdoc.CreateTextNode(q.Source));
					qEl.AppendChild(src);
				}
				//
				XmlElement qCat = xdoc.CreateElement("Categories");
				foreach (string category in q.Categories)
				{
					XmlElement cat = xdoc.CreateElement("Category");
					cat.AppendChild(xdoc.CreateTextNode(category));
					qCat.AppendChild(cat);
				}
				qEl.AppendChild(qCat);
				//
				foreach (Question.TextSection ts in q.Sections)
				{
					XmlElement qText = xdoc.CreateElement("Text");
					if (ts.fmt != Question.TextSectionFormat.None)
					{
						qText.Attributes.Append(xdoc.CreateAttribute("Format")).Value =
							Enum.GetName(typeof(Question.TextSectionFormat), ts.fmt);
					}
					qText.AppendChild(xdoc.CreateCDataSection(ts.text));
					qEl.AppendChild(qText);
				}
				//
				XmlElement qAns = xdoc.CreateElement("Answers");
				foreach (Variant variant in q.Answer.Variants)
				{
					XmlElement ans = xdoc.CreateElement("Answer");
					ans.AppendChild(xdoc.CreateTextNode(variant.Text));
					ans.Attributes.Append(xdoc.CreateAttribute("Valid"));
					ans.Attributes["Valid"].Value = variant.Valid.ToString();
					qAns.AppendChild(ans);
				}
				qEl.AppendChild(qAns);
				//
				rootNode.AppendChild(qEl);
			}
			xdoc.AppendChild(rootNode);
			Stream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			if (bZip)
			{
				fs = new DeflateStream(fs, CompressionMode.Compress, false);
			}
			xdoc.Save(fs);
			fs.Close();
			this.fileName = fileName;
			isModified = false;
		}

		public string Name
		{
			get { return name; }
		}

		public string FileName
		{
			get { return fileName; }
		}

		public int Count
		{
			get { return questions.Count; }
		}

		public bool ContainsQuestion(int id)
		{
			return questions.ContainsKey(id);
		}

		public Question this[int index]
		{
			get { return questions[index]; }
			set
			{
				isModified = true;
				if (value == null)
				{
					if (questions.ContainsKey(index))
					{
						Question question = questions[index];
						foreach (string category in question.Categories)
						{
							removeCategoryIndex(index, category);
						}
						//
						if (--sourceIndex[question.Source] == 0)
						{
							sourceIndex.Remove(question.Source);
						}
						questions.Remove(index);
					}
				}
				else
				{
					if (questions.ContainsKey(index))
					{
						if (value.ID == questions[index].ID)
						{
							foreach (string category in value.Categories)
							{
								questions[index].Categories.Add(category);
							}
						}
					}
					else
					{
						questions.Add(index, value);
					}
					if (value.Categories.Count == 0)
					{
						value.Categories.Add("Без категории");
					}
					foreach (string category in value.Categories)
					{
						updateCategoryIndex(index, category);
					}
					//
					if (!sourceIndex.ContainsKey(value.Source))
						sourceIndex.Add(value.Source, 1);
					else
						sourceIndex[value.Source]++;
				}
			}
		}

		public IList<string> Categories
		{
			get { return new List<string>(categoryIndex.Keys); }
		}

		public bool IsCategorySelected(string cat)
		{
			return selectedCategories.Contains(cat);
		}

		public void SelectCategory(string categoryIndex, bool bSelect)
		{
			if (bSelect)
			{
				selectedCategories.Add(categoryIndex);
			}
			else
			{
				selectedCategories.Remove(categoryIndex);
			}
		}

		public IList<string> Sources
		{
			get { return new List<string>(sourceIndex.Keys); }
		}

		public bool IsSourceSelected(string src)
		{
			return selectedSources.Contains(src);
		}

		public void SelectSource(string src, bool bSelect)
		{
			if (bSelect)
			{
				selectedSources.Add(src);
			}
			else
			{
				selectedSources.Remove(src);
			}
		}

		public QuestionSet GenererateTest(int maxCount)
		{
			return GenererateTest(maxCount, true);
		}
		public QuestionSet GenererateTest(int maxCount, bool isRandomize)
		{
			byte[] rndBuf = new byte[sizeof(int)];
			RNGCryptoServiceProvider rndGen = new RNGCryptoServiceProvider();
			QuestionSet qs = new QuestionSet(name + ".Test");
			List<int> rndKeys = new List<int>();
			Dictionary<int, int> questionPool = new Dictionary<int, int>();
			//Dictionary<int, int> questionIndex = new Dictionary<int, int>();

			rndGen.GetBytes(rndBuf);
			foreach (string s in selectedCategories)
			{
				if (categoryIndex.ContainsKey(s))
				{
					foreach (int qID in categoryIndex[s])
					{
						if (!questionPool.ContainsValue(qID))
						{
							if (selectedSources.Contains(questions[qID].Source))
							{
								rndGen.GetBytes(rndBuf);
								int rndKey = isRandomize ? BitConverter.ToInt32(rndBuf, 0) : qID;
								questionPool.Add(rndKey, qID);
								rndKeys.Add(rndKey);
							}
						}
					}
				}
			}
			rndKeys.Sort();
			if (maxCount > rndKeys.Count)
			{
				maxCount = rndKeys.Count;
			}
			for (int i = 0; i < maxCount; i++)
			{
				Question q = this.questions[questionPool[rndKeys[i]]].Copy(isRandomize);
				if (q.Categories.Count > 1)
				{
					string cat = "";
					do
					{
						rndGen.GetBytes(rndBuf);
						int rndKey = Math.Abs(BitConverter.ToInt32(rndBuf, 0)) % q.Categories.Count;
						cat = q.Categories[rndKey];
					} while (!IsCategorySelected(cat));
					q.Categories.Clear();
					q.Categories.Add(cat);
				}
				qs[i] = q;
			}
			return qs;
		}

		public void Check()
		{
			foreach (Question q in questions.Values)
			{
				if (q.Answer.UserRang == 1)
				{
					q.State = Question.States.Right;
				}
				else if (q.Answer.UserRang == (decimal)0)
				{
					q.State = Question.States.Wrong;
				}
				else
				{
					q.State = Question.States.Partial;
				}
			}
			isChecked = true;
		}

		public bool IsChecked
		{
			get { return isChecked; }
		}

		public bool IsModified
		{
			get { return isModified; }
		}

		public decimal Result
		{
			get
			{
				decimal result = 0;
				foreach (Question q in questions.Values)
				{
					result += q.Answer.UserRang;
				}
				return result / questions.Count;
			}
		}

		public string DetailedResult
		{
			get
			{
				Dictionary<string, decimal[]> categoryResult = new Dictionary<string, decimal[]>();
				foreach (Question q in questions.Values)
				{
					string cat = q.Categories[0];
					if (!categoryResult.ContainsKey(cat))
					{
						categoryResult.Add(cat, new decimal[] { 0, 0 });
					}
					categoryResult[cat][0]++;
					categoryResult[cat][1] += q.Answer.UserRang;
				}
				string result = "";
				foreach (string cat in categoryResult.Keys)
				{
					result += string.Format("{0}:  {1:P}\r\n", cat, categoryResult[cat][1] / categoryResult[cat][0]);
				}

				return result;
			}
		}

		#region private

		private void updateCategoryIndex(int question, string category)
		{
			List<int> listQuestions;
			try
			{
				listQuestions = categoryIndex[category];
			}
			catch (KeyNotFoundException)
			{
				listQuestions = new List<int>();
				categoryIndex[category] = listQuestions;
			}
			int index = listQuestions.BinarySearch(question);
			if (index < 0)
			{
				listQuestions.Insert(-(index + 1), question);
			}
		}

		private void removeCategoryIndex(int question, string category)
		{
			List<int> listQuestions = categoryIndex[category];
			if (listQuestions != null)
			{
				listQuestions.Remove(question);
				if (listQuestions.Count == 0)
				{
					categoryIndex.Remove(category);
				}
			}
		}

		#endregion private
	}

	public class Question
	{
		public enum States
		{
			None = 0,
			Seen,
			Completed,
			Delayed,
			Right,
			Partial,
			Wrong
		}

		public enum TextSectionFormat
		{
			None,
			Code
		}

		public struct TextSection
		{
			public TextSectionFormat fmt;
			public string text;
		}

		public readonly List<string> Categories = new List<string>();
		public readonly List<TextSection> Sections = new List<TextSection>();
		public readonly Answer Answer;
		public string Source = String.Empty;
		private States state = States.None;
		public readonly int ID;

		public Question Copy(bool isRandomize)
		{
			Question q = new Question(this.ID);
			foreach (string s in Categories)
			{
				q.Categories.Add(s);
			}
			foreach (TextSection ts in Sections)
			{
				q.Sections.Add(ts);
			}
			Random r = new Random(Guid.NewGuid().GetHashCode());
			foreach (Variant variant in Answer.Variants)
			{
				q.Answer.Variants.Insert(isRandomize ? r.Next(0, q.Answer.Variants.Count+1) : q.Answer.Variants.Count, new Variant(variant.Text, variant.Valid));
			}
			return q;
		}

		public Question(int id)
		{
			this.ID = id;
			Answer = new Answer();
		}

		public Question(string group, string text, int id, Answer answer)
		{
			this.Categories.Add(group);
			this.ID = id;
			Answer = answer;
			this.Text = text;
		}

		public void AppendTextSection(TextSectionFormat fmt, string text)
		{
			TextSection ts;
			ts.fmt = fmt;
			ts.text = text;
			Sections.Add(ts);
		}

		public string Text
		{
			get
			{
				string text = String.Empty;
				foreach (TextSection ts in Sections)
				{
					switch (ts.fmt)
					{
						case TextSectionFormat.None:
						case TextSectionFormat.Code:
							text = text + ts.text + "\r\n";
							break;
					}
				}
				return text;
			}
			set
			{
				Sections.Clear();
				TextSection ts;
				ts.fmt = TextSectionFormat.None;
				ts.text = value;
				Sections.Add(ts);
			}
		}

		public string Rtf
		{
			get
			{
				string text =
					"{\\rtf1\\ansi\\ansicpg1251\\deff0\\deflang1049" +
					"{\\fonttbl " +
						"{\\f0\\fnil\\fcharset204{\\*\\fname Microsoft Sans Serif;}MS Sans Serif;}" +
						"{\\f1\\fmodern\\fprq1\\fcharset204{\\*\\fname Courier New;}Courier New Cyr;}" +
					"}" +
					"\\uc1\\pard\\lang1033\\ulnone\\f0\\fs18";
				foreach (TextSection ts in Sections)
				{
					switch (ts.fmt)
					{
						case TextSectionFormat.None:
							text = text + "\\f0\\b " + ts.text.Replace("\r\n", "\\par ") + "\\b0\\par";
							break;
						case TextSectionFormat.Code:
							text = text + "{\\pard\\li250\\par\\f1 " + ts.text.Replace("\r\n", "\\par ") + "\\par}";
							break;
					}
				}
				return text + "}";
			}
		}

		public States State
		{
			get { return state; }
			set
			{
				state = value;
			}
		}
	}

	public class Answer
	{
		public Answer()
		{
		}

		public readonly List<Variant> Variants = new List<Variant>();

		public int ValidCount
		{
			get
			{
				int i = 0;
				foreach (Variant variant in Variants)
				{
					if (variant.Valid)
					{
						i++;
					}
				}
				return i;
			}
		}

		public bool IsTouched
		{
			get
			{
				foreach (Variant variant in Variants)
				{
					if (variant.UserCheck)
					{
						return true;
					}
				}
				return false;
			}
		}

		public decimal UserRang
		{
			get
			{
				decimal rang = 0;
				if (IsTouched)
				{
					if (ValidCount == 1)
					{
						foreach (Variant variant in Variants)
						{
							if (variant.Valid && variant.UserCheck == variant.Valid)
							{
								rang = 1;
								break;
							}
						}
					}
					else
					{
						foreach (Variant variant in Variants)
						{
							rang += (variant.UserCheck == variant.Valid) ? 1 : -1;
						}
						rang = rang / Variants.Count;
						if (rang < 0)
						{
							rang = 0;
						}
					}
				}
				return rang;
			}
		}
	}

	public class Variant
	{
		public readonly string Text;
		public readonly bool Valid;
		private bool userCheck;

		public Variant(string text, bool valid)
		{
			UserCheck = false;
			Valid = valid;
			Text = text;
		}

		public bool UserCheck
		{
			get { return userCheck; }
			set { userCheck = value; }
		}
	}
}