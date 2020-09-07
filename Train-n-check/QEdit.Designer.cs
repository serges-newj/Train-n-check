namespace Train_n_check
{
    partial class QEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblID = new System.Windows.Forms.Label();
            this.lblCategories = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.MaskedTextBox();
            this.lbCategorySet = new System.Windows.Forms.CheckedListBox();
            this.pbAddCategory = new System.Windows.Forms.Button();
            this.dataGridVariants = new System.Windows.Forms.DataGridView();
            this.colValid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colVariant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridTextSections = new System.Windows.Forms.DataGridView();
            this.colFormat = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbApply = new System.Windows.Forms.Button();
            this.pbCancel = new System.Windows.Forms.Button();
            this.tbNewCategory = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVariants)).BeginInit();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTextSections)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(6, 15);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Location = new System.Drawing.Point(7, 47);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(60, 13);
            this.lblCategories.TabIndex = 2;
            this.lblCategories.Text = "Категории";
            // 
            // tbID
            // 
            this.tbID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbID.Location = new System.Drawing.Point(31, 12);
            this.tbID.Mask = "0000000000";
            this.tbID.Name = "tbID";
            this.tbID.PromptChar = ' ';
            this.tbID.Size = new System.Drawing.Size(106, 20);
            this.tbID.TabIndex = 3;
            this.tbID.Validating += new System.ComponentModel.CancelEventHandler(this.tbID_Validating);
            // 
            // lbCategorySet
            // 
            this.lbCategorySet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCategorySet.CheckOnClick = true;
            this.lbCategorySet.FormattingEnabled = true;
            this.lbCategorySet.IntegralHeight = false;
            this.lbCategorySet.Location = new System.Drawing.Point(10, 90);
            this.lbCategorySet.Name = "lbCategorySet";
            this.lbCategorySet.Size = new System.Drawing.Size(127, 204);
            this.lbCategorySet.TabIndex = 4;
            this.lbCategorySet.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lbCategorySet_ItemCheck);
            // 
            // pbAddCategory
            // 
            this.pbAddCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAddCategory.Location = new System.Drawing.Point(117, 42);
            this.pbAddCategory.Name = "pbAddCategory";
            this.pbAddCategory.Size = new System.Drawing.Size(20, 22);
            this.pbAddCategory.TabIndex = 5;
            this.pbAddCategory.Text = "+";
            this.pbAddCategory.UseVisualStyleBackColor = true;
            this.pbAddCategory.Click += new System.EventHandler(this.pbAddCategory_Click);
            // 
            // dataGridVariants
            // 
            this.dataGridVariants.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridVariants.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridVariants.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridVariants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridVariants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colValid,
            this.colVariant});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridVariants.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridVariants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridVariants.Location = new System.Drawing.Point(3, 282);
            this.dataGridVariants.Name = "dataGridVariants";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridVariants.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridVariants.RowHeadersWidth = 25;
            this.dataGridVariants.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridVariants.Size = new System.Drawing.Size(462, 142);
            this.dataGridVariants.TabIndex = 7;
            this.dataGridVariants.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellValueChanged);
            this.dataGridVariants.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGrid_RowsAdded);
            this.dataGridVariants.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridVariants_KeyDown);
            this.dataGridVariants.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGrid_RowsRemoved);
            // 
            // colValid
            // 
            this.colValid.Frozen = true;
            this.colValid.HeaderText = "*";
            this.colValid.Name = "colValid";
            this.colValid.Width = 20;
            // 
            // colVariant
            // 
            this.colVariant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colVariant.DefaultCellStyle = dataGridViewCellStyle2;
            this.colVariant.HeaderText = "Варианты ответа";
            this.colVariant.Name = "colVariant";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.dataGridVariants, 0, 1);
            this.tlpMain.Controls.Add(this.dataGridTextSections, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.37468F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.62532F));
            this.tlpMain.Size = new System.Drawing.Size(468, 427);
            this.tlpMain.TabIndex = 8;
            // 
            // dataGridTextSections
            // 
            this.dataGridTextSections.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridTextSections.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridTextSections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridTextSections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFormat,
            this.colText});
            this.dataGridTextSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridTextSections.Location = new System.Drawing.Point(3, 3);
            this.dataGridTextSections.Name = "dataGridTextSections";
            this.dataGridTextSections.RowHeadersWidth = 25;
            this.dataGridTextSections.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridTextSections.Size = new System.Drawing.Size(462, 273);
            this.dataGridTextSections.TabIndex = 8;
            this.dataGridTextSections.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellValueChanged);
            this.dataGridTextSections.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGrid_RowsAdded);
            this.dataGridTextSections.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGrid_RowsRemoved);
            // 
            // colFormat
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.colFormat.DefaultCellStyle = dataGridViewCellStyle5;
            this.colFormat.Frozen = true;
            this.colFormat.HeaderText = "Формат";
            this.colFormat.Name = "colFormat";
            // 
            // colText
            // 
            this.colText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colText.DefaultCellStyle = dataGridViewCellStyle6;
            this.colText.HeaderText = "Текст";
            this.colText.Name = "colText";
            // 
            // pbApply
            // 
            this.pbApply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbApply.Location = new System.Drawing.Point(10, 352);
            this.pbApply.Name = "pbApply";
            this.pbApply.Size = new System.Drawing.Size(127, 23);
            this.pbApply.TabIndex = 9;
            this.pbApply.Text = "Применить";
            this.pbApply.UseVisualStyleBackColor = true;
            this.pbApply.Click += new System.EventHandler(this.pbApply_Click);
            // 
            // pbCancel
            // 
            this.pbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCancel.Location = new System.Drawing.Point(10, 381);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(127, 23);
            this.pbCancel.TabIndex = 9;
            this.pbCancel.Text = "Отменить";
            this.pbCancel.UseVisualStyleBackColor = true;
            this.pbCancel.Click += new System.EventHandler(this.pbCancel_Click);
            // 
            // tbNewCategory
            // 
            this.tbNewCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNewCategory.Location = new System.Drawing.Point(10, 64);
            this.tbNewCategory.Name = "tbNewCategory";
            this.tbNewCategory.Size = new System.Drawing.Size(127, 20);
            this.tbNewCategory.TabIndex = 10;
            this.tbNewCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNewCategory_KeyPress);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tlpMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cbSource);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.lbCategorySet);
            this.splitContainer1.Panel2.Controls.Add(this.tbNewCategory);
            this.splitContainer1.Panel2.Controls.Add(this.lblID);
            this.splitContainer1.Panel2.Controls.Add(this.pbCancel);
            this.splitContainer1.Panel2.Controls.Add(this.lblCategories);
            this.splitContainer1.Panel2.Controls.Add(this.pbApply);
            this.splitContainer1.Panel2.Controls.Add(this.tbID);
            this.splitContainer1.Panel2.Controls.Add(this.pbAddCategory);
            this.splitContainer1.Size = new System.Drawing.Size(622, 427);
            this.splitContainer1.SplitterDistance = 468;
            this.splitContainer1.TabIndex = 11;
            // 
            // cbSource
            // 
            this.cbSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSource.FormattingEnabled = true;
            this.cbSource.Location = new System.Drawing.Point(10, 314);
            this.cbSource.Name = "cbSource";
            this.cbSource.Size = new System.Drawing.Size(127, 21);
            this.cbSource.Sorted = true;
            this.cbSource.TabIndex = 12;
            this.cbSource.SelectedIndexChanged += new System.EventHandler(this.cbSource_TextUpdate);
            this.cbSource.TextUpdate += new System.EventHandler(this.cbSource_TextUpdate);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Источник";
            // 
            // QEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "QEdit";
            this.Size = new System.Drawing.Size(622, 427);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVariants)).EndInit();
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTextSections)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.MaskedTextBox tbID;
        private System.Windows.Forms.CheckedListBox lbCategorySet;
        private System.Windows.Forms.Button pbAddCategory;
        private System.Windows.Forms.DataGridView dataGridVariants;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.DataGridView dataGridTextSections;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colValid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariant;
        private System.Windows.Forms.DataGridViewComboBoxColumn colFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colText;
        private System.Windows.Forms.Button pbApply;
        private System.Windows.Forms.Button pbCancel;
        private System.Windows.Forms.TextBox tbNewCategory;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cbSource;
        private System.Windows.Forms.Label label1;
    }
}
