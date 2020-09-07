using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TestData;

namespace Train_n_check
{
    public partial class QEdit : UserControl
    {
        public delegate void QuestionEditedEventHandler(object sender, Question q);
        public event QuestionEditedEventHandler QuestionEdited;
        public event QuestionEditedEventHandler QuestionDeleted;

        private QuestionSet qs;
        private Question q;
        private bool isModified = false;

        public QEdit()
        {
            InitializeComponent();
            colFormat.Items.AddRange(Enum.GetNames(typeof(Question.TextSectionFormat)));
            SwitchNewCategoryField();
            Clear();
        }

        public void Clear()
        {
            tbID.Text = String.Empty;
            lbCategorySet.Items.Clear();
            cbSource.Items.Clear();
            cbSource.Text = "";
            dataGridTextSections.Rows.Clear();
            dataGridVariants.Rows.Clear();
            q = null;
            isModified = false;
            tlpMain.Enabled = false;
        }

        public bool ShowQuestion(QuestionSet qs, Question q)
        {
            if (EnsureSaveChanges(true))
            {
                Clear();
                this.qs = qs;
                if (q != null)
                {
                    return SetQuestion(q.ID);
                }
                return true;
            }
            return false;
        }

        public bool SetQuestion(int index)
        {
            if (EnsureSaveChanges(true))
            {
                Clear();
                q = qs[index];
                tbID.Text = q.ID.ToString();

                int item;
                foreach (string cat in qs.Categories)
                {
                    item = lbCategorySet.Items.Add(cat);
                    if (q.Categories.Contains(cat))
                    {
                        lbCategorySet.SetItemChecked(item, true);
                    }
                }

                foreach (string src in qs.Sources)
                {
                    cbSource.Items.Add(src);
                }
                cbSource.Text = q.Source;

                foreach (Question.TextSection ts in q.Sections)
                {
                    dataGridTextSections.Rows.Add(Enum.GetName(ts.fmt.GetType(), ts.fmt), ts.text);
                }

                foreach (Variant v in q.Answer.Variants)
                {
                    dataGridVariants.Rows.Add(v.Valid, v.Text);
                }
                isModified = false;
                tlpMain.Enabled = true;

                return true;
            }
            return false;
        }

        public bool NewQuestion(string id)
        {
            if (EnsureSaveChanges(true))
            {
                Clear();
                foreach (string cat in qs.Categories)
                {
                    lbCategorySet.Items.Add(cat);
                }
                foreach (string src in qs.Sources)
                {
                    cbSource.Items.Add(src);
                }

                dataGridTextSections.Rows.Add(Enum.GetName(typeof(Question.TextSectionFormat), Question.TextSectionFormat.None), null);
                tbID.Text = id;
                tbID.Focus();
                tlpMain.Enabled = true;
                return true;
            }
            return false;
        }

        public void DeleteQuestion()
        {
            if (q != null)
            {
                if (DialogResult.Yes == MessageBox.Show("Удалить текущий вопрос из базы вопросов?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    qs[q.ID] = null;
                    Clear();
                    QuestionDeleted(this, q);
                }
            }
        }

        public bool EnsureSaveChanges(bool bCanCancel)
        {
            tbID.Focus();
            bool bCancel = false;
            if (isModified)
            {
                MessageBoxButtons btns = bCanCancel ? MessageBoxButtons.YesNoCancel : MessageBoxButtons.YesNo;
                DialogResult res = MessageBox.Show("Текущий вопрос был изменен. Сохранить?",
                    "Подтверждение", btns, MessageBoxIcon.Question);
                switch (res)
                {
                    case DialogResult.Yes:
                        ApplyChanges();
                        break;
                    case DialogResult.Cancel:
                        bCancel = true;
                        break;
                }
            }
            return !bCancel;
        }

        private void pbCancel_Click(object sender, EventArgs e)
        {
            if (isModified && DialogResult.Yes == MessageBox.Show("Отменить сделанные изменения?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                isModified = false;
                if (qs != null && q != null)
                {
                    SetQuestion(q.ID);
                }
                else
                {
                    Clear();
                }
            }
        }

        private void pbApply_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }

        private void ApplyChanges()
        {
            if (!isModified)
                return;
            if (tbID.Text == String.Empty)
            {
                MessageBox.Show("Не указан номер вопроса");
                return;
            }
            if (dataGridTextSections.Rows.Count - 1 == 0)
            {
                MessageBox.Show("Не задан текст вопроса");
                return;
            }
            if (dataGridVariants.Rows.Count - 1 < 2)
            {
                MessageBox.Show("Должно быть не менее двух вариантов ответа");
                return;
            }
            int validCnt = 0;
            foreach (DataGridViewRow row in dataGridVariants.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells[0].Value == null) row.Cells[0].Value = false;
                validCnt += (bool)row.Cells[0].Value ? 1 : 0;
            }
            if (validCnt == 0)
            {
                MessageBox.Show("Не указан правильный ответ");
                return;
            }
            if (lbCategorySet.CheckedItems.Count == 0)
            {
                MessageBox.Show("Не задана ни одна категория");
                return;
            }

            int id = int.Parse(tbID.Text);
            if (q != null)
            {
                qs[q.ID] = null;
                q.Categories.Clear();
                q.Sections.Clear();
                q.Answer.Variants.Clear();
            }
            else if (q == null && !qs.ContainsQuestion(id))
            {
                q = new Question(id);
            }
            else
            {
                MessageBox.Show("Неправильный номер вопроса");
                return;
            }

            foreach (string cat in lbCategorySet.CheckedItems)
            {
                q.Categories.Add(cat);
            }
            q.Source = cbSource.Text;

            foreach (DataGridViewRow row in dataGridTextSections.Rows)
            {
                if (row.IsNewRow) continue;
                q.AppendTextSection(
                    (Question.TextSectionFormat)Enum.Parse(typeof(Question.TextSectionFormat), (string)row.Cells[0].Value),
                    (string)row.Cells[1].Value);
            }

            foreach (DataGridViewRow row in dataGridVariants.Rows)
            {
                if (row.IsNewRow) continue;
                q.Answer.Variants.Add(new Variant(
                    (string)row.Cells[1].Value,
                    (bool)row.Cells[0].Value));
            }
            qs[q.ID] = q;
            isModified = false;

            QuestionEdited(this, q);
        }

        private void SwitchNewCategoryField()
        {
            if (tbNewCategory.Visible)
            {
                lbCategorySet.Height += (lbCategorySet.Top - tbNewCategory.Top);
                lbCategorySet.Top = tbNewCategory.Top;
                tbNewCategory.Visible = false;
            }
            else
            {
                tbNewCategory.Visible = true;
                lbCategorySet.Top = tbNewCategory.Top + tbNewCategory.Height + 5;
                lbCategorySet.Height -= (tbNewCategory.Height + 5);
            }
        }

        private void pbAddCategory_Click(object sender, EventArgs e)
        {
            SwitchNewCategoryField();
        }

        private void tbNewCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (tbNewCategory.Text.Trim() != String.Empty)
                {
                    lbCategorySet.Items.Add(tbNewCategory.Text.Trim(), true);
                    isModified = true;
                }
            }
        }

        private void tbID_Validating(object sender, CancelEventArgs e)
        {
            if (qs != null)
            {
                if (tbID.Text == String.Empty)
                {
                    tlpMain.Enabled = false;
                }
                else
                {
                    int id = int.Parse(tbID.Text);
                    if (q != null)
                    {
                        if (q.ID != id)
                        {
                            if (qs.ContainsQuestion(id))
                            {
                                SetQuestion(id);
                            }
                            else
                            {
                                if (MessageBox.Show("Вопроса с таким номером не существует.\r\nСоздать?",
                                    "", MessageBoxButtons.YesNo) == DialogResult.No)
                                {
                                    e.Cancel = true;
                                }
                                else
                                {
                                    e.Cancel = !NewQuestion(tbID.Text);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (qs.ContainsQuestion(id))
                        {
                            if (MessageBox.Show("Вопрос с таким номером уже существует.\r\nПравить его?",
                                "", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                e.Cancel = true;
                            }
                            else
                            {
                                e.Cancel = !SetQuestion(id);
                            }
                        }
                    }
                }
            }
        }

        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            isModified = true;
        }

        private void dataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            isModified = true;
        }

        private void dataGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            isModified = true;
        }

        private void lbCategorySet_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            isModified = true;
        }

        private void cbSource_TextUpdate(object sender, EventArgs e)
        {
            isModified = true;
        }

        private void dataGridVariants_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (e.Control && e.KeyCode == Keys.C)
            {
                DataObject d = grid.GetClipboardContent();
                Clipboard.SetDataObject(d);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int row = grid.CurrentCell.RowIndex;
                int col = grid.CurrentCell.ColumnIndex;
                if (grid.RowCount <= row + lines.GetLength(0))
                {
                    grid.Rows.Add(row + lines.GetLength(0) + 1 - grid.RowCount);
                }
                for (int i = 0; i < lines.GetLength(0); i++)
                {
                    string[] cells = lines[i].Replace("\r", "").Split('\t');
                    int cellsSelected = cells.Length;
                    for (int j = 0; j < cellsSelected; j++)
                    {
                        grid[col+j, row+i].Value = cells[j];
                    }
                }
            }
        }
    }
}
