using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TestData;
using System.Windows.Forms.VisualStyles;

namespace Train_n_check
{
    public partial class QView : UserControl
    {
        public event EventHandler AnswerCheckedChanged;

        public QView()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            rtbQuestion.Text = "";
            panelAnswer.Controls.Clear();
        }

        public void ShowQuestion( Question q, bool bShowAnswers )
        {
            rtbQuestion.Rtf = q.Rtf;
            panelAnswer.SuspendLayout();
            panelAnswer.Controls.Clear();
            //int top = 0;
			//Пришлось сделать, иначе варианты ответов появляются в обратном порядке
        	List<Variant> variants = q.Answer.Variants.GetRange(0, q.Answer.Variants.Count);
        	variants.Reverse();

            foreach (Variant v in variants)
            {
                ButtonBase ctl = null;
                if (q.Answer.ValidCount == 1)
                {
                    ctl = new RadioButton();
                }
                else
                {
                    ctl = new CheckBox();
                }
                ctl.Tag = v;
                ctl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                //ctl.AutoSize = true;
                ctl.Dock = DockStyle.Top;
                ctl.Text = v.Text;
                //ctl.Top = top;
                if (ctl is RadioButton)
                {
                    (ctl as RadioButton).Checked = v.UserCheck;
                    if (!bShowAnswers)
                    {
                        (ctl as RadioButton).CheckedChanged += new System.EventHandler(this.Answer_CheckedChanged);
                    }
                }
                else if (ctl is CheckBox)
                {
                    (ctl as CheckBox).Checked = v.UserCheck;
                    if (!bShowAnswers)
                    {
                        (ctl as CheckBox).CheckedChanged += new System.EventHandler(this.Answer_CheckedChanged);
                    }
                }
                if (bShowAnswers)
                {
                    if (v.Valid)
                    {
                        ctl.ForeColor = Color.Green;
                    }
                }
                panelAnswer.Controls.Add(ctl);
                //top += ctl.Height + 7;
            }

            panelAnswer.ResumeLayout();
            panelAnswer.PerformLayout();
        }

        private void Answer_CheckedChanged(object sender, EventArgs e)
        {
            AnswerCheckedChanged(sender, e);
        }

        private void panelAnswer_Layout(object sender, LayoutEventArgs e)
        {
            using (Graphics g = panelAnswer.CreateGraphics())
            {
                int width = panelAnswer.ClientSize.Width;
                width -= CheckBoxRenderer.GetGlyphSize(g, CheckBoxState.UncheckedNormal).Width;

                foreach (Control ctl in panelAnswer.Controls)
                {
                    ctl.Height = g.MeasureString(ctl.Text, ctl.Font, width).ToSize().Height + 10;
                }
            }
        }
    }
}
