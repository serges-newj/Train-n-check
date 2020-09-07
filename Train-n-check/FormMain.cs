using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TestData;
using System.Security.Cryptography;

namespace Train_n_check
{
    public partial class frmMain : Form
    {
        private struct timerState
        {
            public static TimeSpan span;
            public static int growthUp;
            public static DateTime lastStart;
            public static bool suspended = false;
        }

        private DlgStart.Parameters startParams = new DlgStart.Parameters(10, 0);
        private QuestionSet openQS = null;
        private QuestionSet testQS = null;

        private QView qView = null;
        private QEdit qEdit = null;

        private Question currQ
        {
            get
            {
                Question q = null;
                if (testQS != null)
                {
                    if (tvQuestionList.SelectedNode != null)
                    {
                        if (tvQuestionList.SelectedNode.Tag != null)
                        {
                            q = testQS[(int)tvQuestionList.SelectedNode.Tag];
                        }
                    }
                }
                return q;
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            panelTest.Hide();
            qView = qViewCtl;
            qView.AnswerCheckedChanged += Answer_CheckedChanged;
        }

        private void miStart_Click(object sender, EventArgs e)
        {
            SuspendTimer();
            if (EnsureSaveQuestionSet(true))
            {
                DlgStart dlgStart = new DlgStart(startParams);
                if (dlgStart.ShowDialog() == DialogResult.OK)
                {
                    startParams = dlgStart.OutParams;
                    openQS = startParams.qs;

					testQS = openQS.GenererateTest(startParams.fragLimit, startParams.randomize);
                    if (testQS.Count == 0)
                    {
                        return;
                    }
                    miEditMode.Checked = false;

                    tvQuestionList.BeginUpdate();
                    tvQuestionList.Nodes.Clear();
                    for (int i = 0; i < testQS.Count; i++)
                    {
                        addTreeViewItem(i);
                    }
                    {
                        int i = 0;
                        foreach (TreeNode root in tvQuestionList.Nodes)
                            foreach (TreeNode node in root.Nodes)
                                node.Text = string.Format("Вопрос {0}", ++i);
                    }
                    tvQuestionList.EndUpdate();
                    tvQuestionList.Select();
                    tvQuestionList.SelectedNode = tvQuestionList.Nodes[0].Nodes[0];

                    pbFinish.Show();
                    panelTest.Show();

                    lblTimer.Text = "";
                    timerState.span = new TimeSpan(0, startParams.timeLimit, 0);
                    timerState.growthUp = (timerState.span.Ticks == 0) ? 1 : -1;
                    timerState.lastStart = DateTime.Now;
                    timerState.suspended = false;
                    timer1.Start();
                }
            }
            ResumeTimer();
        }

        private void addTreeViewItem(int i)
        {
            Question q = testQS[i];
            string category = q.Categories[0];
            TreeNode root = tvQuestionList.Nodes[category];
            if (root == null)
            {
                root = tvQuestionList.Nodes.Add(category, category);
            }
            TreeNode node = root.Nodes.Add(string.Format("Вопрос ID {0}", q.ID));
            node.Tag = i;
            node.StateImageIndex = 0;
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (qEdit != null && !qEdit.EnsureSaveChanges(true))
            {
                e.Cancel = true;
            }
            if (!EnsureSaveQuestionSet(true))
            {
                e.Cancel = true;
            }
        }

        private void tvQuestionList_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = tvQuestionList.SelectedNode;
            if (node != null)
            {
                node.ForeColor = tvQuestionList.ForeColor;
                if (miEditMode.Checked)
                {
                    qEdit.EnsureSaveChanges(false);
                    qEdit.Clear();
                }
                else
                {
                    qView.Clear();
                }
                if (!testQS.IsChecked)
                {
                    lblQuestionNumber.Text = "";
                }
                node.NodeFont = tvQuestionList.Font;
            }
        }

        private void tvQuestionList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Tag != null)
                {
                    Question q = testQS[(int)e.Node.Tag];
                    if (miEditMode.Checked)
                    {
                        qEdit.ShowQuestion(openQS, q);
                    }
                    else
                    {
                        qView.ShowQuestion(q, testQS.IsChecked);
                    }
                    if (!testQS.IsChecked)
                    {
                        lblQuestionNumber.Text = string.Format("{0} из {1}", e.Node.Text, testQS.Count);
                    }
                    cbMarkQuestion.Checked = (q.State == Question.States.Delayed) ? true : false;
                }
                else
                {
                    cbMarkQuestion.Checked = false;
                }
                e.Node.ForeColor = Color.Blue;
                e.Node.NodeFont = new Font(tvQuestionList.Font, FontStyle.Bold);

                pbNext.Enabled = (e.Node.NextNode != null || e.Node.FirstNode != null
                    || (e.Node.Parent != null && e.Node.Parent.NextNode != null));
                pbPrev.Enabled = (e.Node.PrevNode != null
                    || (e.Node.Parent != null && e.Node.Parent.PrevNode != null));

                UpdateQuestionStatus();
            }
        }

        private void CheckResult()
        {
            timer1.Stop();
            testQS.Check();
            foreach (TreeNode root in tvQuestionList.Nodes)
                foreach (TreeNode node in root.Nodes)
                    node.StateImageIndex = (int)testQS[(int)node.Tag].State;
            MessageBox.Show(String.Format("Ваш результат - {0:P}", testQS.Result) + "\r\n\r\n" + testQS.DetailedResult);
            pbFinish.Hide();
            tvQuestionList.SelectedNode = tvQuestionList.Nodes[0].FirstNode;
            lblQuestionNumber.Text = string.Format("Вопросов {0} (результат - {1:P})", testQS.Count, testQS.Result);
        }

        private void pbFinish_Click(object sender, EventArgs e)
        {
            CheckResult();
        }

        private void pbPrev_Click(object sender, EventArgs e)
        {
            TreeNode node = tvQuestionList.SelectedNode;
            if (node != null)
            {
                if (node.PrevNode != null)
                {
                    tvQuestionList.SelectedNode = node.PrevNode;
                }
                else if (node.Parent != null && node.Parent.PrevNode != null)
                {
                    tvQuestionList.SelectedNode = node.Parent.PrevNode.LastNode;
                }
            }
        }

        private void pbNext_Click(object sender, EventArgs e)
        {
            TreeNode node = tvQuestionList.SelectedNode;
            if (node != null)
            {
                if (node.FirstNode != null)
                {
                    tvQuestionList.SelectedNode = node.FirstNode;
                }
                else if (node.NextNode != null)
                {
                    tvQuestionList.SelectedNode = node.NextNode;
                }
                else if (node.Parent != null && node.Parent.NextNode != null)
                {
                    tvQuestionList.SelectedNode = node.Parent.NextNode.FirstNode;
                }
            }
        }

        private void cbMarkQuestion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateQuestionStatus();
        }

        private void Answer_CheckedChanged(object sender, EventArgs e)
        {
            if (!testQS.IsChecked)
            {
                bool check = false;
                if (sender is RadioButton)
                {
                    check = (sender as RadioButton).Checked;
                }
                else if (sender is CheckBox)
                {
                    check = (sender as CheckBox).Checked;
                }
                ((sender as Control).Tag as Variant).UserCheck = check;
                UpdateQuestionStatus();
            }
        }

        private void UpdateQuestionStatus()
        {
            if (!testQS.IsChecked)
            {
                if (tvQuestionList.SelectedNode != null && tvQuestionList.SelectedNode.Tag != null)
                {
                    Question q = testQS[(int)tvQuestionList.SelectedNode.Tag];
                    if (cbMarkQuestion.Checked)
                    {
                        q.State = Question.States.Delayed;
                    }
                    else if (q.Answer.IsTouched)
                    {
                        q.State = Question.States.Completed;
                    }
                    else
                    {
                        q.State = Question.States.Seen;
                    }
                    tvQuestionList.SelectedNode.StateImageIndex = (int)q.State;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long ticks = 0;
            ticks = timerState.span.Ticks + (DateTime.Now - timerState.lastStart).Ticks*timerState.growthUp;
            if (ticks < 0)
            {
                timer1.Stop();
                lblTimer.Text = "0:00:00";
                if (MessageBox.Show("Проверить результат?", "Ваше время истекло", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    CheckResult();
                }
            }
            else
            {
                lblTimer.Text = String.Format("{0:T}", new DateTime(ticks));
            }
        }

        private void SuspendTimer()
        {
            if (timer1.Enabled && !timerState.suspended)
            {
                timer1.Stop();
                timerState.suspended = true;
                if (timerState.growthUp > 0)
                {
                    timerState.span += (DateTime.Now - timerState.lastStart);
                }
                else
                {
                    timerState.span -= (DateTime.Now - timerState.lastStart);
                }
                panelTest.Hide();
            }
        }

        private void ResumeTimer()
        {
            if (timerState.suspended)
            {
                panelTest.Show();
                timerState.lastStart = DateTime.Now;
                timerState.suspended = false;
                timer1.Start();
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                SuspendTimer();
            }
            else
            {
                ResumeTimer();
            }
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Версия 1.21" +
                "\r\n" +
                "\r\nПоследняя версия доступна здесь: " +
                "\r\n\\\\SERGES\\Train-n-check\\",
                "О программе ...", MessageBoxButtons.OK);
        }

        private void menuStripMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Right)
            {
                miEdit.Visible = true;
                miEditMode.Enabled = true;
            }
        }

        private void miEditMode_CheckedChanged(object sender, EventArgs e)
        {
            if (miEditMode.Checked)
            {
                if (qEdit == null)
                {
                    qEdit = new QEdit();
                    qEdit.Visible = false;
                    qEdit.Location = qView.Location;
                    qEdit.Size = qView.Size;
                    qEdit.Anchor = qView.Anchor;
                    qEdit.QuestionEdited += OnQuestionEdited;
                    qEdit.QuestionDeleted += OnQuestionDeleted;
                    split1.Panel2.Controls.Add(qEdit);
                }
                if (qView.Visible)
                {
                    qEdit.ShowQuestion(openQS, currQ);
                    qEdit.Visible = true;
                    qView.Visible = false;
                    qView.Clear();
                }
            }
            else
            {
                if (qEdit.Visible)
                {
                    if (qEdit.EnsureSaveChanges(true))
                    {
                        qView.ShowQuestion(currQ, testQS.IsChecked);
                        qView.Visible = true;
                        qEdit.Visible = false;
                        qEdit.Clear();
                    }
                    else
                    {
                        miEditMode.Checked = true;
                    }
                }
            }
        }

        private void OnQuestionEdited(object sender, Question q)
        {
            if (testQS != null)
            {
                int i;
                for (i = 0; i < testQS.Count; i++)
                {
                    if (testQS[i].ID == q.ID)
                    {
                        testQS[i] = null;
                        testQS[i] = q.Copy(false);
                        UpdateQuestionStatus();
                        break;
                    }
                }
                if (i >= testQS.Count)
                {
                    // не нашли - добавляем
                    Question tq = q.Copy(false);
                    tq.Categories.Clear();
                    tq.Categories.Add("Правка");
                    testQS[i] = tq;
                    addTreeViewItem(i);
                    UpdateQuestionStatus();
                }
            }
        }

        private void OnQuestionDeleted(object sender, Question q)
        {
            if (testQS != null)
            {
                // TODO: удалить вопрос из списка, встать на существующий вопрос
            }
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            if (miEditMode.Checked)
            {
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Filter = "XML files (*.xml)|*.xml|Compressed|*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    openQS.SaveToXML(fileName);
                }
            }
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if (miEditMode.Checked)
            {
                openQS.SaveToXML();
            }
        }

        private void miNewQuestion_Click(object sender, EventArgs e)
        {
            if (miEditMode.Checked && qEdit != null)
            {
                qEdit.NewQuestion("");
            }
        }

        private void miDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (miEditMode.Checked && qEdit != null)
            {
                qEdit.DeleteQuestion();
            }
        }

        private bool EnsureSaveQuestionSet(bool bCanCancel)
        {
            bool bCancel = false;
            if (openQS != null && openQS.IsModified)
            {
                MessageBoxButtons btns = bCanCancel ? MessageBoxButtons.YesNoCancel : MessageBoxButtons.YesNo;
                DialogResult res = MessageBox.Show("Сохранить изменения в текущем наборе вопросов?",
                    "Подтверждение", btns, MessageBoxIcon.Question);
                switch (res)
                {
                    case DialogResult.Yes:
                        openQS.SaveToXML();
                        break;
                    case DialogResult.Cancel:
                        bCancel = true;
                        break;
                }
            }
            return !bCancel;
        }
    }
}