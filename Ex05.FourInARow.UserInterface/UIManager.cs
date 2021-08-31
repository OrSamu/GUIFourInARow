using System;
using System.Windows.Forms;
using Ex05.FourInARow.Logic;

namespace Ex05.FourInARow.UserInterface
{
    public class UIManager
    {
        private FormGameSettings m_FormFourInARowGameSettings = new FormGameSettings();

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
            int gameFormWidth, gameFormHeight;
            string playerOneName, playerTwoName = "Computer";

            m_FormFourInARowGameSettings.ShowDialog();
            if(m_FormFourInARowGameSettings.DialogResult != DialogResult.Cancel)
            {
                playerOneName = m_FormFourInARowGameSettings.PlayerOneUserName;
                rows = int.Parse(m_FormFourInARowGameSettings.Rows);
                cols = int.Parse(m_FormFourInARowGameSettings.Columns);

                if(m_FormFourInARowGameSettings.VsAnotherPlayer)
                {
                    numOfPlayers = 2;
                    playerOneName = m_FormFourInARowGameSettings.PlayerTwoUserName;
                }

                m_FourInARowGame = new GameManager(rows, cols, numOfPlayers);

                m_GraphicBoard = new FormGameBoard(rows, cols, playerOneName, playerTwoName, m_FourInARowGame);

                m_GraphicBoard.ShowDialog();
            }


            //create form using gameformheight and width

            //play game
            //byebye
        }
    }
}