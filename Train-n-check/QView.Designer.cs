namespace Train_n_check
{
    partial class QView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rtbQuestion = new System.Windows.Forms.RichTextBox();
            this.panelAnswer = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rtbQuestion, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelAnswer, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.37982F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.62018F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(562, 347);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // rtbQuestion
            // 
            this.rtbQuestion.BackColor = System.Drawing.SystemColors.Window;
            this.rtbQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbQuestion.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbQuestion.Location = new System.Drawing.Point(3, 3);
            this.rtbQuestion.Name = "rtbQuestion";
            this.rtbQuestion.ReadOnly = true;
            this.rtbQuestion.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbQuestion.Size = new System.Drawing.Size(556, 189);
            this.rtbQuestion.TabIndex = 2;
            this.rtbQuestion.Text = "Текст вопроса";
            // 
            // panelAnswer
            // 
            this.panelAnswer.AutoScroll = true;
            this.panelAnswer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnswer.Location = new System.Drawing.Point(3, 198);
            this.panelAnswer.Name = "panelAnswer";
            this.panelAnswer.Size = new System.Drawing.Size(556, 146);
            this.panelAnswer.TabIndex = 4;
            this.panelAnswer.Layout += new System.Windows.Forms.LayoutEventHandler(this.panelAnswer_Layout);
            // 
            // QView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "QView";
            this.Size = new System.Drawing.Size(562, 347);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox rtbQuestion;
        private System.Windows.Forms.Panel panelAnswer;
    }
}
