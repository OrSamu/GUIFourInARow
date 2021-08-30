using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ex05.FourInARow.UserInterface
{
    public partial class FormGameSettings : Form
    {
        public FormGameSettings()
        {
            InitializeComponent();
        }
        public string PlayerOneUserName
        {
            get { return textBoxPlayerOneName.Text; }
        }

        public string PlayerTwoUserName
        {
            get { return textBoxPlayerTwoName.Text; }
        }

        public bool VsAnotherPlayer
        {
            get { return checkBoxPlayerTwo.Checked; }
        }

        public string Rows
        {
            get { return numericUpDownRows.Text; }
        }

        public string Columns
        {
            get { return numericUpDownCols.Text; }
        }

        private void checkBoxPlayerTwo_CheckedChanged(object sender, EventArgs e)
        {
            if(!checkBoxPlayerTwo.Checked)
            {
                textBoxPlayerTwoName.Text = "[Computer]";
                textBoxPlayerTwoName.Enabled = false;
            }
            else
            {
                textBoxPlayerTwoName.Text = "";
                textBoxPlayerTwoName.Enabled = true;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string errorMsg = isPlayerNamesValid();

            if (errorMsg.Equals(""))
            {
                this.Close();
            }
            else
            {
                showErrorMsgForStrings(errorMsg);
            }
        }

        private string isPlayerNamesValid()
        {
            string errorMsg = "";

            if (textBoxPlayerOneName.Text.Equals("") && textBoxPlayerTwoName.Text.Equals(""))
            {
                errorMsg = "Please fill usernames";
            }
            else if (textBoxPlayerOneName.Text.Equals(""))
            {
                errorMsg = "Please fill player 1 username";
            }
            else if (textBoxPlayerTwoName.Text.Equals(""))
            {
                errorMsg = "Please fill player 2 username";
            }
            else if (textBoxPlayerOneName.Text == textBoxPlayerTwoName.Text)
            {
                errorMsg = "Username is already taken";
            }

            return errorMsg;
        }

        private void showErrorMsgForStrings(string i_ErrorMsgToShow)
        {
            FormInputError formErrorMsgBecauseOfPlayerNames = new FormInputError();
            formErrorMsgBecauseOfPlayerNames.ErrorMsg = i_ErrorMsgToShow;
            formErrorMsgBecauseOfPlayerNames.ShowDialog();
        }
    }
}
