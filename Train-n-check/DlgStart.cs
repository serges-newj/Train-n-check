using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TestData;
using System.IO;

namespace Train_n_check
{
    public partial class DlgStart : Form
    {
        public struct Parameters
        {
            public QuestionSet qs;
            public bool trainMode;
            public int fragLimit;
            public int timeLimit;
        	public bool randomize;

            public Parameters(int frags, int times)
            {
                qs = null;
                trainMode = false;
                fragLimit = frags;
                timeLimit = times;
            	randomize = true;
            }
        }

        private Parameters startParams;
        private QuestionSet qs;

        public DlgStart(Parameters InParams)
        {
            InitializeComponent();
            startParams = InParams;
        }

        public Parameters OutParams
        {
            get 
            {
                foreach (object item in lbCategorySet.Items)
                {
                    qs.SelectCategory(item.ToString(), lbCategorySet.CheckedItems.Contains(item.ToString()));
                }
                foreach (object item in lbSourceSet.Items)
                {
                    qs.SelectSource(item.ToString(), lbSourceSet.CheckedItems.Contains(item.ToString()));
                }

                startParams.qs = this.qs;
                startParams.trainMode = rbTraining.Checked;
                startParams.fragLimit = (int)dfFragLimit.Value;
                startParams.timeLimit = (int)dfTimeLimit.Value;
            	startParams.randomize = cbRandomize.Checked;

                return startParams;
            }
        }

        private void DlgStart_Load(object sender, EventArgs e)
        {
            int idx = 0;
            DirectoryInfo di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\DATA");
            foreach (FileInfo fi in di.GetFiles())
            {
                cbQuestionSet.Items.Add(fi.Name);
                if (startParams.qs != null && startParams.qs.FileName == "DATA\\" + fi.Name)
                {
                    idx = cbQuestionSet.Items.Count - 1;
                }
            }
            if (cbQuestionSet.Items.Count > 0)
            {
                cbQuestionSet.SelectedIndex = idx;
            }

            rbChecking.Checked = true; //!startParams.trainMode;
        	cbRandomize.Checked = true;
            dfFragLimit.Value = startParams.fragLimit;
            dfTimeLimit.Value = startParams.timeLimit;
            checkStartAvail();
        }

        private void cbQuestionSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                qs = QuestionSet.LoadFromXML("DATA\\" + cbQuestionSet.Text);
            }
            catch
            {
                qs = new QuestionSet();
            }
            FileInfo fi = new FileInfo("DATA\\" + cbQuestionSet.Text);
            lblStats.Text = String.Format("Вопросов: {0}  Дата последней модификации: {1}", qs.Count, fi.LastWriteTime);

            lbCategorySet.Items.Clear();
            int item = 0;
            foreach (string cat in qs.Categories)
            {
                item = lbCategorySet.Items.Add(cat);
                if (startParams.qs != null && startParams.qs.FileName == qs.FileName)
                {
                    if (startParams.qs.IsCategorySelected(cat))
                    {
                        lbCategorySet.SetItemChecked(item, true);
                    }
                }
            }
            lbCategorySet.Sorted = true;

            lbSourceSet.Items.Clear();
            item = 0;
            foreach (string src in qs.Sources)
            {
                item = lbSourceSet.Items.Add(src);
                if (startParams.qs != null && startParams.qs.FileName == qs.FileName)
                {
                    if (startParams.qs.IsSourceSelected(src))
                    {
                        lbSourceSet.SetItemChecked(item, true);
                    }
                }
            }
            checkStartAvail();
        }

        private void pbSelCatAll_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < lbCategorySet.Items.Count; i++)
            {
                lbCategorySet.SetItemChecked(i, true);
            }
            checkStartAvail();
        }

        private void pbSelSrcAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbSourceSet.Items.Count; i++)
            {
                lbSourceSet.SetItemChecked(i, true);
            }
            checkStartAvail();
        }

        private void checkStartAvail()
        {
            pbStart.Enabled = (lbCategorySet.CheckedItems.Count > 0 && lbSourceSet.CheckedItems.Count > 0);
        }

        private void lb_SelectedValueChanged(object sender, EventArgs e)
        {
            checkStartAvail();
        }
    }
}