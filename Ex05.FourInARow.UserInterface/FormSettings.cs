using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace Ex05.FourInARow.UserInterface
{
    public class FormSettings : Form
    {
        private Label m_LabelPlayersTitle = new Label();
        private Label m_LabelPlayerOne = new Label();
        private Label m_LabelPlayerTwo = new Label();
        private Label m_LabelBoardSize = new Label();
        private Label m_LabelRows = new Label();
        private Label m_LabelCols = new Label();
        private CheckBox m_CheckBoxVsAnotherPlayer = new CheckBox();
        private TextBox m_TextBoxPlayerOneName = new TextBox();
        private TextBox m_TextBoxPlayerTwoName = new TextBox();
        private NumericUpDown m_NumericUpDownRows = new NumericUpDown();
        private NumericUpDown m_NumericUpDownCols = new NumericUpDown();

        public FormSettings()
        {
            this.Size = new Size(400, 400);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitControls();
        }

        private void InitControls()
        {
            m_LabelPlayersTitle.Text = "Players: ";
            m_LabelPlayersTitle.Location = new Point(10, 20);
            m_LabelPlayersTitle.AutoSize = true;
            m_LabelPlayersTitle.BackColor = Color.AliceBlue;

            m_LabelPlayerOne.Text = "Player 1:";
            m_LabelPlayerOne.Location = new Point(20, 50);
            m_LabelPlayerOne.AutoSize = true;
            m_LabelPlayerOne.BackColor= Color.AliceBlue;

            int playerOneTextBoxTop = m_LabelPlayerOne.Top;
            int playerOneTextBoxLeft = m_LabelPlayerOne.Left + m_LabelPlayerOne.Width;
            m_TextBoxPlayerOneName.Left = playerOneTextBoxLeft-20;
            m_TextBoxPlayerOneName.Top = playerOneTextBoxTop;
                //m_TextBoxPlayerOneName.Location = new Point(playerOneTextBoxLeft, playerOneTextBoxTop);

            m_CheckBoxVsAnotherPlayer.Checked = false;
            m_CheckBoxVsAnotherPlayer.Location = new Point(25, 80);
            m_CheckBoxVsAnotherPlayer.AutoSize = true;

            m_LabelPlayerTwo.Text = "Player 2:";
            int playerTwoLabelTop = m_CheckBoxVsAnotherPlayer.Top;
            int playerTwoLabelLeft = m_CheckBoxVsAnotherPlayer.Left + m_CheckBoxVsAnotherPlayer.Width / 2;
            m_LabelPlayerTwo.Left = playerTwoLabelLeft;
            m_LabelPlayerTwo.Top = playerTwoLabelTop;
            //m_LabelPlayerTwo.Location = new Point(playerTwoLabelLeft, playerTwoLabelTop);
            m_LabelPlayerTwo.AutoSize = true;
            m_LabelPlayerTwo.BackColor = Color.AliceBlue;


            int playerTwoTextBoxTop = m_LabelPlayerOne.Top;
            int playerTwoTextBoxLeft = m_LabelPlayerOne.Left + m_LabelPlayerOne.Width;



            this.Controls.AddRange(new Control[] {m_LabelPlayersTitle,m_LabelPlayerOne, m_TextBoxPlayerOneName, m_CheckBoxVsAnotherPlayer, m_LabelPlayerTwo });
            /*int textBoxTop = m_LabelUserName.Top + m_LabelUserName.Height / 2;
            textBoxTop -= m_TextboxUsername.Height / 2;

            m_TextboxUsername.Location = new Point(m_LabelUserName.Right + 8,
                textBoxTop);

            int textBoxPasswordTop = m_LabelPassword.Top + m_LabelPassword.Height / 2;
            textBoxPasswordTop -= m_TextboxPassword.Height / 2;

            m_TextboxPassword.Location = new Point(m_LabelPassword.Right + 8,
                textBoxPasswordTop);

            this.Width = m_TextboxPassword.Right + 16;

            m_ButtonCancel.Text = "Cancel";
            m_ButtonCancel.Location = new Point(this.ClientSize.Width - m_ButtonCancel.Width - 8,
                this.ClientSize.Height - m_ButtonCancel.Height - 8);

            m_ButtonOK.Text = "OK";
            m_ButtonOK.Location = new Point(m_ButtonCancel.Left - m_ButtonOK.Width - 8,
                this.ClientSize.Height - m_ButtonOK.Height - 8);


            this.Controls.AddRange(new Control[] { m_LabelPassword, m_LabelUserName, m_TextboxPassword, m_TextboxUsername, m_ButtonOK, m_ButtonCancel });

            this.m_ButtonCancel.Click += new EventHandler(m_ButtonCancel_Click);
            this.m_ButtonOK.Click += new EventHandler(m_ButtonOK_Click);*/
        }

        public string PlayerOneUserName
        {
            get { return m_LabelPlayerOne.Text; }
            set { m_LabelPlayerOne.Text = value; }
        }

        public string PlayerTwoUserName
        {
            get { return m_LabelPlayerTwo.Text; }
            set { m_LabelPlayerTwo.Text = value; }
        }
    }
}