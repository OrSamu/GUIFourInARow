using System;
using System.Windows.Forms;
using Ex05.FourInARow.Logic;

namespace Ex05.FourInARow.UserInterface
{
    public class UIManager
    {
        private readonly FormGameSettings r_FormFourInARowGameSettings = new FormGameSettings();

        private GameManager m_FourInARowGame;

        private FormGameBoard m_GraphicBoard;

        public UIManager()
        {
            Application.EnableVisualStyles();
        }

        public void StartGame()
        {
            int numOfPlayers = 1;
            int rows, cols;
            string playerOneName, playerTwoName = "Computer";

            r_FormFourInARowGameSettings.ShowDialog();
            if(r_FormFourInARowGameSettings.DialogResult == DialogResult.OK)
            {
                playerOneName = r_FormFourInARowGameSettings.PlayerOneUserName;
                rows = int.Parse(r_FormFourInARowGameSettings.Rows);
                cols = int.Parse(r_FormFourInARowGameSettings.Columns);

                if(r_FormFourInARowGameSettings.VsAnotherPlayer)
                {
                    numOfPlayers = 2;
                    playerOneName = r_FormFourInARowGameSettings.PlayerTwoUserName;
                }

                m_FourInARowGame = new GameManager(rows, cols, numOfPlayers);

                m_GraphicBoard = new FormGameBoard(rows, cols, playerOneName, playerTwoName, ref m_FourInARowGame);

                m_GraphicBoard.ShowDialog();
            }
        }
    }
}