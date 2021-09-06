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
        private const int k_UiBoardDiff = 1;
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
                m_ButtonsColumns[i].Click += columnButtons_Click;
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

        private void disableColIfNeeded(Point moveMade, Player currentPlayer, int columnChoose, Button senderButton)
        {
            m_ButtonsBoardChars[moveMade.Y, moveMade.X].Text = currentPlayer.Sign.ToString();
            if (m_FourInARowGameManager.GameBoard.IsColumnFull(columnChoose - k_UiBoardDiff))
            {
                senderButton.Enabled = false;
            }
        }

        private Button getButtonByID(string i_buttonText)
        {
            Button desiredButton=null;
            foreach(var button in this.Controls.OfType<Button>())
            {
                if(button.Text.Equals(i_buttonText))
                {
                    desiredButton = button;
                    break;
                }
            }
            return desiredButton;
        }
        private void columnButtons_Click(object sender, EventArgs e)
        {
            Player currentPlayer = m_FourInARowGameManager.CurrentPlayer;
            if (!currentPlayer.IsBot)
            {
                Button senderButton;
                int columnChoose;
                senderButton = sender as Button;
                columnChoose = int.Parse(senderButton.Text);
                manageTurn(currentPlayer, columnChoose, senderButton);
                m_FourInARowGameManager.SwitchCurrentPlayer();
                currentPlayer = m_FourInARowGameManager.CurrentPlayer;
                if (currentPlayer.IsBot)
                {
                    playBotTurn();
                }
            }
        }

        private void playBotTurn()
        {
            Player currentPlayer = m_FourInARowGameManager.CurrentPlayer;
            Random randomNum = new Random();
            int columnChoose;
            Button senderButton;
            do
            {
                columnChoose = randomNum.Next(1, m_FourInARowGameManager.GameBoard.Cols + 1);
                senderButton = getButtonByID(columnChoose.ToString());
            }
            while(!senderButton.Enabled);
            manageTurn(currentPlayer, columnChoose, senderButton);
            m_FourInARowGameManager.SwitchCurrentPlayer();
        }
        private void manageTurn(Player currentPlayer,int columnChoose, Button senderButton)
        {
            Point moveMade = m_FourInARowGameManager.AddShapeToBoard(currentPlayer, columnChoose - k_UiBoardDiff);
            disableColIfNeeded(moveMade, currentPlayer, columnChoose, senderButton);
            manageWinning(currentPlayer, columnChoose);
        }
        private bool showResultAndAskForAnotherRound(string i_MsgToShow,string i_WindowTitle)
        {
            string message = i_MsgToShow;
            string title = "Form Closing";
            bool anotherRound = false;

            var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                anotherRound = true;
            }

            return anotherRound;
        }

        private void manageWinning(Player currentPlayer, int columnChoose)
        {
            bool playerWonTheGame = false;
            bool wantRematch = false;
            bool gameHasEnded = false;
            Label currentPlayerPoints = currentPlayer.Number == 1 ? m_LabelPlayerOnePoints : m_LabelPlayerTwoPoints;
            string currentPlayerName = currentPlayer.Number == 1 ? m_LabelPlayerOneName.Text : m_LabelPlayerTwoName.Text;


            playerWonTheGame = m_FourInARowGameManager.GameBoard.DidPlayerMakeFourInARow(
    currentPlayer,
    columnChoose - k_UiBoardDiff);
            if (playerWonTheGame)
            {
                string isTheWinner = string.Format(
                    @"{0} Won!
Another Round?",
                    currentPlayerName);
                m_FourInARowGameManager.AddPoint(currentPlayer.Number);
                currentPlayerPoints.Text = currentPlayer.Points.ToString();
                wantRematch = showResultAndAskForAnotherRound(isTheWinner, "A Win!");
                gameHasEnded = true;
            }
            else if (m_FourInARowGameManager.GameBoard.IsBoardFull())
            {
                string isTheWinner = string.Format(
                    @"It's a Tie!
Another Round?",
                    currentPlayerName);
                m_FourInARowGameManager.AddPoint(1);
                m_FourInARowGameManager.AddPoint(2);
                m_LabelPlayerOnePoints.Text = m_FourInARowGameManager.Player1.Points.ToString();
                m_LabelPlayerTwoPoints.Text = m_FourInARowGameManager.Player2.Points.ToString();
                wantRematch = showResultAndAskForAnotherRound(isTheWinner, "A Tie!");
                gameHasEnded = true;
            }

            if (gameHasEnded)
            {
                if (wantRematch)
                {
                    m_FourInARowGameManager.ResetBoard();
                    for (int i = 0; i < m_FourInARowGameManager.GameBoard.Cols; i++)
                    {
                        m_ButtonsColumns[i].Enabled = true;
                        for (int j = 0; j < m_FourInARowGameManager.GameBoard.Rows; j++)
                        {
                            m_ButtonsBoardChars[j, i].Text = "";
                        }
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }

    }
}
