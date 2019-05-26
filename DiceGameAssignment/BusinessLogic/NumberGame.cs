using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameAssignment.BusinessLogic
{
    /// <summary>
    /// Game consists of rounds, result, list of random numebrs and score
    /// </summary>
    class NumberGame
    {
        int _rounds;
        GameResult _gameResult;
        NumberList _numberList;
        int _score;

        /// <summary>
        /// default constructor which initiaizes numberlist, rounds and score 
        /// </summary>
        public NumberGame()
        {
            _numberList = new NumberList(5);
            _rounds = 0;
            _score = 0;
        }

        /// <summary>
        /// Method to start new game which sets rounds and score to 0
        /// </summary>
        public void StartNewGame()
        {
            _rounds = 0;
            _score = 0;
        }

        /// <summary>
        /// Method to play a round fills the array with random numbers and increments rounds
        /// 
        /// </summary>
    
        public void PlayRound()
        {
            _numberList.FillNumberList();
            _rounds++;


        }


        /// <summary>
        /// Getter for rounds 
        /// </summary>
        /// <returns>_rounds</returns>
        public int GetRounds()
        {
            return _rounds;
        }

        /// <summary>
        /// Getter to get index of the number list 
        /// </summary>
        /// <param name="i"></param>
        /// <returns>Value of the index at i </returns>
        public int GetIndex(int i)
        {
            return _numberList.GetNumberAt(i);
        }

        /// <summary>
        /// Getter for to get score 
        /// </summary>
        /// <returns>_score</returns>
        public int GetScore()
        {
            return _score;
        }
        /// <summary>
        ///Calculates round score by the frequency of occurence of each numbers in numberlist 
        ///then adds the score each time frequency of each number and retuns the frequency of each numbers in 
        ///the number list 
        /// 
        /// </summary>
        /// <returns>Frequency of the numbers </returns>
        public int CalculateRoundScore()
        {
            int RoundScore = _numberList.CalculateFrequency();
            UpdateScore(RoundScore);
            return _numberList.CalculateFrequency();




        }

        /// <summary>
        /// Method to update score depends on the score and round score. Each time you get same numbers the old score
        /// is added to the current round score.
        /// </summary>
        /// <param name="RoundScore"></param>
        private void UpdateScore(int RoundScore)
        {

            _score = _score + RoundScore;
        }

        /// <summary>
        /// method that gives result of the game 
        /// </summary>
        /// <returns>_gameResult</returns>
        public GameResult GetGameResult() 
        {
            return _gameResult;
        }

        /// <summary>
        /// Method to set game result after 5 rounds includes logic for win, lost and draw depend on the score, 
        /// for example if score is less than 90 then it is lost, and if its above 90 its a win and
        /// if it inbetween 90 and 100 then its a draw.
        /// 
        /// </summary>
        public void SetGameResult()    
        {
            if (_score < 90)
            {
                _gameResult = GameResult.PLAYER_LOST;
            }

            else if (_score >= 90 && _score < 100)
            {
                _gameResult = GameResult.GAME_DRAW;
            }

            else
                _gameResult = GameResult.PLAYER_WON;
        }

    }

}
       
   

