namespace Train_n_check
{
    partial class DlgStart
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbQuestionSet = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCategorySet = new System.Windows.Forms.CheckedListBox();
            this.rbTraining = new System.Windows.Forms.RadioButton();
            this.rbChecking = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dfTimeLimit = new System.Windows.Forms.NumericUpDown();
            this.dfFragLimit = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbCancel = new System.Windows.Forms.Button();
            this.pbStart = new System.Windows.Forms.Button();
            this.pbSelCatAll = new System.Windows.Forms.Button();
            this.lblStats = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbSourceSet = new System.Windows.Forms.CheckedListBox();
            this.pbSelSrcAll = new System.Windows.Forms.Button();
            this.cbRandomize = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dfTimeLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dfFragLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "База вопросов";
            // 
            // cbQuestionSet
            // 
            this.cbQuestionSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbQuestionSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuestionSet.FormattingEnabled = true;
            this.cbQuestionSet.Location = new System.Drawing.Point(22, 31);
            this.cbQuestionSet.Name = "cbQuestionSet";
            this.cbQuestionSet.Size = new System.Drawing.Size(417, 21);
            this.cbQuestionSet.TabIndex = 1;
            this.cbQuestionSet.SelectedIndexChanged += new System.EventHandler(this.cbQuestionSet_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Список категорий";
            // 
            // lbCategorySet
            // 
            this.lbCategorySet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCategorySet.CheckOnClick = true;
            this.lbCategorySet.FormattingEnabled = true;
            this.lbCategorySet.Location = new System.Drawing.Point(22, 96);
            this.lbCategorySet.Name = "lbCategorySet";
            this.lbCategorySet.Size = new System.Drawing.Size(238, 274);
            this.lbCategorySet.TabIndex = 2;
            this.lbCategorySet.SelectedValueChanged += new System.EventHandler(this.lb_SelectedValueChanged);
            // 
            // rbTraining
            // 
            this.rbTraining.AutoSize = true;
            this.rbTraining.Enabled = false;
            this.rbTraining.Location = new System.Drawing.Point(14, 16);
            this.rbTraining.Name = "rbTraining";
            this.rbTraining.Size = new System.Drawing.Size(108, 17);
            this.rbTraining.TabIndex = 3;
            this.rbTraining.TabStop = true;
            this.rbTraining.Text = "Режим обучения";
            this.rbTraining.UseVisualStyleBackColor = true;
            // 
            // rbChecking
            // 
            this.rbChecking.AutoSize = true;
            this.rbChecking.Location = new System.Drawing.Point(14, 53);
            this.rbChecking.Name = "rbChecking";
            this.rbChecking.Size = new System.Drawing.Size(108, 17);
            this.rbChecking.TabIndex = 3;
            this.rbChecking.TabStop = true;
            this.rbChecking.Text = "Режим проверки";
            this.rbChecking.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
	this.panel1.Controls.Add(this.cbRandomize);
            this.panel1.Controls.Add(this.dfTimeLimit);
            this.panel1.Controls.Add(this.dfFragLimit);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rbChecking);
            this.panel1.Controls.Add(this.rbTraining);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(454, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 295);
            this.panel1.TabIndex = 4;
            // 
            // dfTimeLimit
            // 
            this.dfTimeLimit.Location = new System.Drawing.Point(47, 159);
            this.dfTimeLimit.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.dfTimeLimit.Name = "dfTimeLimit";
            this.dfTimeLimit.Size = new System.Drawing.Size(49, 20);
            this.dfTimeLimit.TabIndex = 6;
            // 
            // dfFragLimit
            // 
            this.dfFragLimit.Location = new System.Drawing.Point(47, 104);
            this.dfFragLimit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.dfFragLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dfFragLimit.Name = "dfFragLimit";
            this.dfFragLimit.Size = new System.Drawing.Size(49, 20);
            this.dfFragLimit.TabIndex = 6;
            this.dfFragLimit.ThousandsSeparator = true;
            this.dfFragLimit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(44, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 29);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ограничение по времени (мин.)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Количество вопросов";
            // 
            // pbCancel
            // 
            this.pbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.pbCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pbCancel.Location = new System.Drawing.Point(545, 396);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(105, 28);
            this.pbCancel.TabIndex = 5;
            this.pbCancel.Text = "Отмена";
            this.pbCancel.UseVisualStyleBackColor = true;
            // 
            // pbStart
            // 
            this.pbStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.pbStart.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.pbStart.Location = new System.Drawing.Point(434, 397);
            this.pbStart.Name = "pbStart";
            this.pbStart.Size = new System.Drawing.Size(105, 28);
            this.pbStart.TabIndex = 5;
            this.pbStart.Text = "Начать";
            this.pbStart.UseVisualStyleBackColor = true;
            // 
            // pbSelCatAll
            // 
            this.pbSelCatAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbSelCatAll.Location = new System.Drawing.Point(22, 376);
            this.pbSelCatAll.Name = "pbSelCatAll";
            this.pbSelCatAll.Size = new System.Drawing.Size(96, 23);
            this.pbSelCatAll.TabIndex = 6;
            this.pbSelCatAll.Text = "Выбрать все";
            this.pbSelCatAll.UseVisualStyleBackColor = true;
            this.pbSelCatAll.Click += new System.EventHandler(this.pbSelCatAll_Click);
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblStats.Location = new System.Drawing.Point(25, 58);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(108, 13);
            this.lblStats.TabIndex = 7;
            this.lblStats.Text = "Статистика по базе";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Список источников";
            // 
            // lbSourceSet
            // 
            this.lbSourceSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSourceSet.CheckOnClick = true;
            this.lbSourceSet.FormattingEnabled = true;
            this.lbSourceSet.Location = new System.Drawing.Point(266, 96);
            this.lbSourceSet.Name = "lbSourceSet";
            this.lbSourceSet.Size = new System.Drawing.Size(173, 274);
            this.lbSourceSet.TabIndex = 2;
            this.lbSourceSet.SelectedValueChanged += new System.EventHandler(this.lb_SelectedValueChanged);
            // 
            // pbSelSrcAll
            // 
            this.pbSelSrcAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSelSrcAll.Location = new System.Drawing.Point(266, 376);
            this.pbSelSrcAll.Name = "pbSelSrcAll";
            this.pbSelSrcAll.Size = new System.Drawing.Size(96, 23);
            this.pbSelSrcAll.TabIndex = 6;
            this.pbSelSrcAll.Text = "Выбрать все";
            this.pbSelSrcAll.UseVisualStyleBackColor = true;
            this.pbSelSrcAll.Click += new System.EventHandler(this.pbSelSrcAll_Click);
			// 
			// cbRandomize
			// 
			this.cbRandomize.AutoSize = true;
			this.cbRandomize.Location = new System.Drawing.Point(14, 185);
			this.cbRandomize.Name = "cbRandomize";
			this.cbRandomize.Size = new System.Drawing.Size(129, 17);
			this.cbRandomize.TabIndex = 7;
			this.cbRandomize.Text = "Случайный порядок";
			this.cbRandomize.UseVisualStyleBackColor = true;
            // 
            // DlgStart
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.pbCancel;
            this.ClientSize = new System.Drawing.Size(664, 437);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.pbSelSrcAll);
            this.Controls.Add(this.pbSelCatAll);
            this.Controls.Add(this.pbStart);
            this.Controls.Add(this.pbCancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbSourceSet);
            this.Controls.Add(this.lbCategorySet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbQuestionSet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(588, 392);
            this.Name = "DlgStart";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Старт";
            this.Load += new System.EventHandler(this.DlgStart_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dfTimeLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dfFragLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbQuestionSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox lbCategorySet;
        private System.Windows.Forms.RadioButton rbTraining;
        private System.Windows.Forms.RadioButton rbChecking;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button pbCancel;
        private System.Windows.Forms.Button pbStart;
        private System.Windows.Forms.NumericUpDown dfTimeLimit;
        private System.Windows.Forms.NumericUpDown dfFragLimit;
        private System.Windows.Forms.Button pbSelCatAll;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox lbSourceSet;
        private System.Windows.Forms.Button pbSelSrcAll;
	private System.Windows.Forms.CheckBox cbRandomize;
    }
}