namespace Train_n_check
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Вопрос 1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Вопрос 2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Вопрос 3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Вопрос 4");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Вопрос 5");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Вопрос 6");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Категория", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.miMain = new System.Windows.Forms.ToolStripMenuItem();
            this.miStart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditMode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miNewQuestion = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteQuestion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.miQuestion = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTest = new System.Windows.Forms.Panel();
            this.imageListQuestState = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.split1 = new System.Windows.Forms.SplitContainer();
            this.lblTimer = new System.Windows.Forms.Label();
            this.cbMarkQuestion = new System.Windows.Forms.CheckBox();
            this.pbNext = new System.Windows.Forms.Button();
            this.pbPrev = new System.Windows.Forms.Button();
            this.pbFinish = new System.Windows.Forms.Button();
            this.lblQuestionNumber = new System.Windows.Forms.Label();
            this.tvQuestionList = new System.Windows.Forms.TreeView();
            this.qViewCtl = new Train_n_check.QView();
            this.menuStripMain.SuspendLayout();
            this.panelTest.SuspendLayout();
            this.split1.Panel1.SuspendLayout();
            this.split1.Panel2.SuspendLayout();
            this.split1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMain,
            this.miEdit,
            this.miQuestion});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(852, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menu";
            this.menuStripMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.menuStripMain_MouseDoubleClick);
            // 
            // miMain
            // 
            this.miMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miStart,
            this.toolStripSeparator1,
            this.miExit});
            this.miMain.Name = "miMain";
            this.miMain.Size = new System.Drawing.Size(43, 20);
            this.miMain.Text = "&Тест";
            // 
            // miStart
            // 
            this.miStart.Name = "miStart";
            this.miStart.Size = new System.Drawing.Size(116, 22);
            this.miStart.Text = "&Новый";
            this.miStart.Click += new System.EventHandler(this.miStart_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(116, 22);
            this.miExit.Text = "Выход";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // miEdit
            // 
            this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEditMode,
            this.toolStripSeparator2,
            this.miNewQuestion,
            this.miDeleteQuestion,
            this.toolStripSeparator3,
            this.miSave,
            this.miSaveAs});
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(58, 20);
            this.miEdit.Text = "Правка";
            this.miEdit.Visible = false;
            // 
            // miEditMode
            // 
            this.miEditMode.CheckOnClick = true;
            this.miEditMode.Enabled = false;
            this.miEditMode.Name = "miEditMode";
            this.miEditMode.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.miEditMode.Size = new System.Drawing.Size(198, 22);
            this.miEditMode.Text = "Режим правки";
            this.miEditMode.CheckedChanged += new System.EventHandler(this.miEditMode_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
            // 
            // miNewQuestion
            // 
            this.miNewQuestion.Name = "miNewQuestion";
            this.miNewQuestion.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.miNewQuestion.Size = new System.Drawing.Size(198, 22);
            this.miNewQuestion.Text = "Новый вопрос";
            this.miNewQuestion.Click += new System.EventHandler(this.miNewQuestion_Click);
            // 
            // miDeleteQuestion
            // 
            this.miDeleteQuestion.Name = "miDeleteQuestion";
            this.miDeleteQuestion.Size = new System.Drawing.Size(198, 22);
            this.miDeleteQuestion.Text = "Удалить вопрос";
            this.miDeleteQuestion.Click += new System.EventHandler(this.miDeleteQuestion_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(195, 6);
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.miSave.Size = new System.Drawing.Size(198, 22);
            this.miSave.Text = "Сохранить";
            this.miSave.Click += new System.EventHandler(this.miSave_Click);
            // 
            // miSaveAs
            // 
            this.miSaveAs.Name = "miSaveAs";
            this.miSaveAs.Size = new System.Drawing.Size(198, 22);
            this.miSaveAs.Text = "Сохранить как...";
            this.miSaveAs.Click += new System.EventHandler(this.miSaveAs_Click);
            // 
            // miQuestion
            // 
            this.miQuestion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAbout});
            this.miQuestion.Name = "miQuestion";
            this.miQuestion.Size = new System.Drawing.Size(25, 20);
            this.miQuestion.Text = "?";
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(162, 22);
            this.miAbout.Text = "О программе ...";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // panelTest
            // 
            this.panelTest.Controls.Add(this.split1);
            this.panelTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTest.Location = new System.Drawing.Point(0, 24);
            this.panelTest.Name = "panelTest";
            this.panelTest.Size = new System.Drawing.Size(852, 526);
            this.panelTest.TabIndex = 1;
            // 
            // imageListQuestState
            // 
            this.imageListQuestState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListQuestState.ImageStream")));
            this.imageListQuestState.TransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(252)))));
            this.imageListQuestState.Images.SetKeyName(0, "q1.bmp");
            this.imageListQuestState.Images.SetKeyName(1, "seen.bmp");
            this.imageListQuestState.Images.SetKeyName(2, "q2.bmp");
            this.imageListQuestState.Images.SetKeyName(3, "q3.bmp");
            this.imageListQuestState.Images.SetKeyName(4, "check.gif");
            this.imageListQuestState.Images.SetKeyName(5, "question.gif");
            this.imageListQuestState.Images.SetKeyName(6, "ex.gif");
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // split1
            // 
            this.split1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split1.Location = new System.Drawing.Point(0, 0);
            this.split1.Name = "split1";
            // 
            // split1.Panel1
            // 
            this.split1.Panel1.Controls.Add(this.tvQuestionList);
            // 
            // split1.Panel2
            // 
            this.split1.Panel2.Controls.Add(this.qViewCtl);
            this.split1.Panel2.Controls.Add(this.lblTimer);
            this.split1.Panel2.Controls.Add(this.cbMarkQuestion);
            this.split1.Panel2.Controls.Add(this.pbNext);
            this.split1.Panel2.Controls.Add(this.pbPrev);
            this.split1.Panel2.Controls.Add(this.pbFinish);
            this.split1.Panel2.Controls.Add(this.lblQuestionNumber);
            this.split1.Size = new System.Drawing.Size(852, 526);
            this.split1.SplitterDistance = 166;
            this.split1.TabIndex = 0;
            // 
            // lblTimer
            // 
            this.lblTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimer.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimer.Location = new System.Drawing.Point(547, 9);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(124, 23);
            this.lblTimer.TabIndex = 23;
            this.lblTimer.Text = "0:00:01";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbMarkQuestion
            // 
            this.cbMarkQuestion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbMarkQuestion.AutoSize = true;
            this.cbMarkQuestion.Location = new System.Drawing.Point(39, 495);
            this.cbMarkQuestion.Name = "cbMarkQuestion";
            this.cbMarkQuestion.Size = new System.Drawing.Size(112, 17);
            this.cbMarkQuestion.TabIndex = 22;
            this.cbMarkQuestion.Text = "отметить вопрос";
            this.cbMarkQuestion.UseVisualStyleBackColor = true;
            this.cbMarkQuestion.CheckedChanged += new System.EventHandler(this.cbMarkQuestion_CheckedChanged);
            // 
            // pbNext
            // 
            this.pbNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbNext.Location = new System.Drawing.Point(349, 490);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(123, 26);
            this.pbNext.TabIndex = 21;
            this.pbNext.Text = "Следующий    ->";
            this.pbNext.UseVisualStyleBackColor = true;
            this.pbNext.Click += new System.EventHandler(this.pbNext_Click);
            // 
            // pbPrev
            // 
            this.pbPrev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbPrev.Location = new System.Drawing.Point(201, 490);
            this.pbPrev.Name = "pbPrev";
            this.pbPrev.Size = new System.Drawing.Size(131, 26);
            this.pbPrev.TabIndex = 20;
            this.pbPrev.Text = "<-    Предыдущий";
            this.pbPrev.UseVisualStyleBackColor = true;
            this.pbPrev.Click += new System.EventHandler(this.pbPrev_Click);
            // 
            // pbFinish
            // 
            this.pbFinish.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbFinish.Location = new System.Drawing.Point(528, 489);
            this.pbFinish.Name = "pbFinish";
            this.pbFinish.Size = new System.Drawing.Size(124, 27);
            this.pbFinish.TabIndex = 19;
            this.pbFinish.Text = "Проверить";
            this.pbFinish.UseVisualStyleBackColor = true;
            this.pbFinish.Click += new System.EventHandler(this.pbFinish_Click);
            // 
            // lblQuestionNumber
            // 
            this.lblQuestionNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuestionNumber.ForeColor = System.Drawing.Color.Blue;
            this.lblQuestionNumber.Location = new System.Drawing.Point(12, 9);
            this.lblQuestionNumber.Name = "lblQuestionNumber";
            this.lblQuestionNumber.Size = new System.Drawing.Size(330, 18);
            this.lblQuestionNumber.TabIndex = 18;
            this.lblQuestionNumber.Text = "Вопрос 1 из 10";
            // 
            // tvQuestionList
            // 
            this.tvQuestionList.BackColor = System.Drawing.SystemColors.Control;
            this.tvQuestionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvQuestionList.FullRowSelect = true;
            this.tvQuestionList.Location = new System.Drawing.Point(0, 0);
            this.tvQuestionList.Name = "tvQuestionList";
            treeNode1.Name = "Node2";
            treeNode1.StateImageIndex = 0;
            treeNode1.Text = "Вопрос 1";
            treeNode2.Name = "Node3";
            treeNode2.StateImageIndex = 1;
            treeNode2.Text = "Вопрос 2";
            treeNode3.Name = "Node4";
            treeNode3.StateImageIndex = 2;
            treeNode3.Text = "Вопрос 3";
            treeNode4.Name = "Node5";
            treeNode4.StateImageIndex = 3;
            treeNode4.Text = "Вопрос 4";
            treeNode5.Name = "Node6";
            treeNode5.StateImageIndex = 4;
            treeNode5.Text = "Вопрос 5";
            treeNode6.Name = "Node7";
            treeNode6.StateImageIndex = 5;
            treeNode6.Text = "Вопрос 6";
            treeNode7.Name = "Node0";
            treeNode7.Text = "Категория";
            this.tvQuestionList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.tvQuestionList.Size = new System.Drawing.Size(166, 526);
            this.tvQuestionList.StateImageList = this.imageListQuestState;
            this.tvQuestionList.TabIndex = 12;
            this.tvQuestionList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvQuestionList_AfterSelect);
            this.tvQuestionList.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvQuestionList_BeforeSelect);
            // 
            // qViewCtl
            // 
            this.qViewCtl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.qViewCtl.Location = new System.Drawing.Point(12, 33);
            this.qViewCtl.Name = "qViewCtl";
            this.qViewCtl.Size = new System.Drawing.Size(659, 439);
            this.qViewCtl.TabIndex = 24;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 550);
            this.Controls.Add(this.panelTest);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "frmMain";
            this.Text = "Train-n-check";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.panelTest.ResumeLayout(false);
            this.split1.Panel1.ResumeLayout(false);
            this.split1.Panel2.ResumeLayout(false);
            this.split1.Panel2.PerformLayout();
            this.split1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem miMain;
        private System.Windows.Forms.ToolStripMenuItem miStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miQuestion;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.Panel panelTest;
        private System.Windows.Forms.ImageList imageListQuestState;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miEditMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripMenuItem miSaveAs;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem miNewQuestion;
        private System.Windows.Forms.ToolStripMenuItem miDeleteQuestion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.SplitContainer split1;
        private QView qViewCtl;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.CheckBox cbMarkQuestion;
        private System.Windows.Forms.Button pbNext;
        private System.Windows.Forms.Button pbPrev;
        private System.Windows.Forms.Button pbFinish;
        private System.Windows.Forms.Label lblQuestionNumber;
        private System.Windows.Forms.TreeView tvQuestionList;
    }
}

