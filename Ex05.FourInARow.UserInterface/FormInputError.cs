using System;
using System.Windows.Forms;
using System.Drawing;

namespace Ex05.FourInARow.UserInterface
{
    public class FormInputError : Form
    {
        private Label m_LabelErrorText = new Label();
        private Button m_ButtonOk = new Button();

        public FormInputError()
        {
            this.Size = new Size(150, 100);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Error";
        }

        public string ErrorMsg
        {
            set { m_LabelErrorText.Text = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initControls();
        }

        private void initControls()
        {
            int labelErrorTextTop=10;
            int labelErrorTextLeft = this.Width / 2 - m_LabelErrorText.Width / 2;
            m_LabelErrorText.Location = new Point(labelErrorTextLeft,labelErrorTextTop);
            m_LabelErrorText.TextAlign = ContentAlignment.MiddleCenter;

            m_ButtonOk.Width = 50;
            int okButtonTop = m_LabelErrorText.Bottom + 10;
            int okButtonLeft = this.Width/2-m_ButtonOk.Width/2;
            m_ButtonOk.Location = new Point(okButtonLeft, okButtonTop);
            m_ButtonOk.Text = "OK";
            m_ButtonOk.TextAlign = ContentAlignment.MiddleCenter;
            m_ButtonOk.Click += buttonOk_Click;

            this.Controls.AddRange(new Control[] { m_LabelErrorText, m_ButtonOk });
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}