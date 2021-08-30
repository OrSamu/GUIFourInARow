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
    public partial class FormGameBoard : Form
    {
        private const int k_GapForOneRow = 30;
        private const int k_GapForOneColumn = 30;

        private Button[,] m_ButtonsBoardChars;
        private Button[] m_ButtonsColumns;

        public FormGameBoard(int i_Rows, int i_Columns)
        {
            int boardWidth = k_GapForOneColumn * (i_Columns + 1);
            int boardHeight = k_GapForOneRow * (i_Rows + 1);

            this.Size = new Size(boardWidth, boardHeight);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Four In A Row - Game";

            m_ButtonsBoardChars = new Button[i_Rows, i_Columns];
            m_ButtonsColumns = new Button[i_Columns];
            initializeBoard(i_Rows, i_Columns);
            InitializeComponent();
        }

        private void initializeBoard(int i_Rows, int i_Columns)
        {
            int buttonColumnLeft;
            int buttonColumnTop;
            for (int i = 0; i < i_Columns; i++)
            {
                buttonColumnLeft = k_GapForOneColumn * i + k_GapForOneColumn / 2;
                m_ButtonsColumns[i] = new Button();
                m_ButtonsColumns[i].Text = string.Format(@"{0}", i + 1);
                m_ButtonsColumns[i].Width = 30;
                m_ButtonsColumns[i].Height = 30;
                m_ButtonsColumns[i].TextAlign = ContentAlignment.MiddleCenter;
                m_ButtonsColumns[i].Location = new Point(buttonColumnLeft,k_GapForOneRow/2);
                this.Controls.Add(m_ButtonsColumns[i]);
                
                for (int j = 0; j < i_Rows; j++)
                {
                    buttonColumnTop = k_GapForOneColumn * j + k_GapForOneColumn / 2;
                    m_ButtonsBoardChars[j, i] = new Button();
                    m_ButtonsBoardChars[j, i].Text = "";
                    m_ButtonsBoardChars[j, i].TextAlign = ContentAlignment.MiddleCenter;
                    m_ButtonsBoardChars[j, i].Text = "";
                    m_ButtonsBoardChars[j, i].Width = 30;
                    m_ButtonsBoardChars[j, i].Height = 30;
                    m_ButtonsBoardChars[j, i].TextAlign = ContentAlignment.MiddleCenter;
                    m_ButtonsBoardChars[j, i].Location = new Point(buttonColumnLeft, buttonColumnTop);
                    this.Controls.Add(m_ButtonsBoardChars[j, i]);
                }
            }
        }

        /*private void resetBoard(int i_Rows, int i_Columns)
        {
            for (int i = 0; i < i_Columns; i++)
            {
                for (int j = 0; j < i_Rows; j++)
                {
                    m_ButtonsBoardChars[j, i].Text = "";
                }
            }
        }*/


    }
}
