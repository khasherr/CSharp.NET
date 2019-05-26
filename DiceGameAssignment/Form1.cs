using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiceGameAssignment.BusinessLogic;

namespace DiceGameAssignment
{
    public partial class Form1 : Form
    {    
        /// <summary>
        /// Created instance of game and made it global so that user can multiple click 
        /// </summary>
        NumberGame game = new NumberGame(); 
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Start button starts new game 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            game.StartNewGame();
        }

        /// <summary>
        /// Next move button initializes a round, toString method to convert the integer into string 
        /// and generates random numbers . Also includes logic for state of the game 
        /// Win, lost and draw depends on how much points you get. Each round the score is updated and added to the
        /// total score. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextMove_Click(object sender, EventArgs e)
        {
            game.PlayRound();
            Rounds.Text = game.GetRounds().ToString();
            int r = game.GetRounds();
            if (r <= 5)
            {
                RoundScore.Text = game.CalculateRoundScore().ToString();
                Number1.Text = game.GetIndex(0).ToString();
                Number2.Text = game.GetIndex(1).ToString();
                Number3.Text = game.GetIndex(2).ToString();
                Number4.Text = game.GetIndex(3).ToString();
                Number5.Text = game.GetIndex(4).ToString();
                TotalScore.Text = game.GetScore().ToString();
            }

            else
            {
                game.SetGameResult();
                if(game.GetGameResult() == GameResult.PLAYER_WON)
                {
                    MessageBox.Show("You won !");
                }

                if(game.GetGameResult() == GameResult.PLAYER_LOST)
                {
                    MessageBox.Show("You Lost :("); 
                }

                if (game.GetGameResult() == GameResult.GAME_DRAW)
                {
                    MessageBox.Show("You Draw !"); 
                }
            }
                
            
        }

        private void Number1_Click(object sender, EventArgs e)
        {

        }

        private void Number1_Click_1(object sender, EventArgs e)
        {

        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void RoundScore_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Reset_Click(object sender, EventArgs e)
        {

        }
    }
}
