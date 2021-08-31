using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ex05.FourInARow.Logic;

namespace Ex05.FourInARow.UserInterface
{
    public partial class FormGameBoard : Form
    {
        private const int k_FirstRowGap = 20;
        private const int k_FirstColumnGap = 10;
        private const int k_ColumnsButtonWidth = 30;
        private const int k_ColumnsButtonHeight = 20;
        private const int k_ColumnBoardWidthAndHeight = 30;

        private Button[,] m_ButtonsBoardChars;
        private Button[] m_ButtonsColumns;
        private Label m_LabelPlayerOneName = new Label();
        private Label m_LabelPlayerTwoName = new Label();
        private Label m_LabelPlayerOnePoints = new Label();
        private Label m_LabelPlayerTwoPoints = new Label();

        private GameManager m_FourInARowGameManager;

        public FormGameBoard(int i_Rows, int i_Columns,string i_PlayerOneName,
                             string i_PlayerTwoName,ref GameManager io_FourInARowGameManager)
        {
            int boardWidth = (k_ColumnBoardWidthAndHeight * i_Columns) + (k_FirstColumnGap * (i_Columns + 3));
            int boardHeight = (k_ColumnBoardWidthAndHeight * (i_Rows+1)) + (k_FirstRowGap * (i_Rows + 4));
            int stringX, stringY;
            
            this.Size = new Size(boardWidth, boardHeight);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Text = "Four In A Row - Game";

            m_ButtonsBoardChars = new Button[i_Rows, i_Columns];
            m_ButtonsColumns = new Button[i_Columns];
            m_FourInARowGameManager = io_FourInARowGameManager;
            initializeBoard(i_Rows, i_Columns);
            
            m_LabelPlayerOneName.Text = string.Format(@"{0}:",i_PlayerOneName);
            m_LabelPlayerTwoName.Text = string.Format(@"{0}:", i_PlayerTwoName);
            m_LabelPlayerOnePoints.Text = string.Format(@"{0}", m_FourInARowGameManager.GetPoint(1));
            m_LabelPlayerTwoPoints.Text = string.Format(@"{0}", m_FourInARowGameManager.GetPoint(2));

            stringX = this.Width / 4 - 15;
            stringY = this.Bottom - 60;
            m_LabelPlayerOneName.Location = new Point(stringX, stringY);
            m_LabelPlayerOneName.AutoSize = true;
            this.Controls.Add(m_LabelPlayerOneName);
            stringX = m_LabelPlayerOneName.Right;
            m_LabelPlayerOnePoints.Location = new Point(stringX, stringY);
            m_LabelPlayerOnePoints.AutoSize = true;
            this.Controls.Add(m_LabelPlayerOnePoints);
            
            stringX = boardWidth / 2;
            m_LabelPlayerTwoName.Location = new Point(stringX, stringY);
            m_LabelPlayerTwoName.AutoSize = true;
            this.Controls.Add(m_LabelPlayerTwoName);
            stringX = m_LabelPlayerTwoName.Right;
            m_LabelPlayerTwoPoints.Location = new Point(stringX, stringY);
            m_LabelPlayerTwoPoints.AutoSize = true;
            this.Controls.Add(m_LabelPlayerTwoPoints);
        }

        private void initializeBoard(int i_Rows, int i_Columns)
        {
            int buttonColumnLeft = 10;
            int buttonColumnTop = k_FirstRowGap;

            for(int i = 0; i < i_Columns; i++)
            {
                m_ButtonsColumns[i] = new Button();
                m_ButtonsColumns[i].Text = string.Format(@"{0}", i + 1);
                m_ButtonsColumns[i].Location = new Point(buttonColumnLeft, buttonColumnTop);
                m_ButtonsColumns[i].Width = k_ColumnsButtonWidth;
                m_ButtonsColumns[i].Height = k_ColumnsButtonHeight;
                m_ButtonsColumns[i].TextAlign = ContentAlignment.MiddleCenter;
                buttonColumnLeft += k_FirstColumnGap + m_ButtonsColumns[i].Width;
                this.Controls.Add(m_ButtonsColumns[i]);
            }

            buttonColumnTop = m_ButtonsColumns[0].Bottom;
            for (int i = 0; i < i_Rows; i++)
            {
                buttonColumnTop += k_FirstRowGap;
                for(int j = 0; j < i_Columns; j++)
                {
                    buttonColumnLeft = m_ButtonsColumns[j].Left;
                    m_ButtonsBoardChars[i, j] = new Button();
                    m_ButtonsBoardChars[i, j].Text = "";
                    m_ButtonsBoardChars[i, j].Location = new Point(buttonColumnLeft, buttonColumnTop);
                    m_ButtonsBoardChars[i, j].Width = k_ColumnBoardWidthAndHeight;
                    m_ButtonsBoardChars[i, j].Height = k_ColumnBoardWidthAndHeight;
                    m_ButtonsBoardChars[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(m_ButtonsBoardChars[i, j]);
                }

                buttonColumnTop += 30;
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

        private void columnButton_Click(object sender, EventArgs e)
        {
            int columnChoose = int.Parse(this.Text);
            bool playerWonTheGame = false;

            m_FourInARowGameManager.AddShapeToBoard(m_FourInARowGameManager.CurrentPlayer, columnChoose);
            //updateGraphicBoard

            if(m_FourInARowGameManager.GameBoard.IsColumnFull(columnChoose))
            {
                this.Enabled = false;
            }

            playerWonTheGame = m_FourInARowGameManager.GameBoard.DidPlayerMakeFourInARow(
                m_FourInARowGameManager.CurrentPlayer,
                columnChoose);
            if (playerWonTheGame)
            {
                m_FourInARowGameManager.AddPoint(m_FourInARowGameManager.CurrentPlayer.Number);
                //show message
            }
            else if(m_FourInARowGameManager.GameBoard.IsBoardFull())
            {
                m_FourInARowGameManager.AddPoint(1);
                m_FourInARowGameManager.AddPoint(2);
                //show message
            }
            m_FourInARowGameManager.SwitchCurrentPlayer();
        }


    }
}
