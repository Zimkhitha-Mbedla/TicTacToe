using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{
    public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;
        private int[] _boardPositions = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        private int _rounds;
        private int arrayPos;
        private int rowNumber;
        private int columnNumber;

        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10, 6);
            _boardRenderer.Render();
        }

        // I really don't like this int design decision we made.  int doesn't look good.  Next class we can change to an enum
        private void PlayMove(PlayerEnum player)
        {

            // This method needs error handling as it accepts incorrect input from user
            // We can revist this also in the Exception Handling class and gracefully recover from errors.


            // ask user for row and column
            bool inputValid = false;

            while (!inputValid)
            {


                Console.SetCursorPosition(2, 19);

                // change to enum
                if (player == PlayerEnum.X)
                    Console.Write("Player X");
                else
                    Console.Write("Player O");

                Console.SetCursorPosition(2, 20);

                Console.Write("Please Enter Row: ");
                var row = Console.ReadLine();

                Console.SetCursorPosition(2, 22);


                Console.Write("Please Enter Column: ");
                var column = Console.ReadLine();
                try
                {


                    // store move in array
                    int rowNumber = int.Parse(row);
                    int columnNumber = int.Parse(column);
                    int arrayPos = (rowNumber * 3) + columnNumber;

                    if (_boardPositions[arrayPos] == -1)
                    {
                        _boardPositions[arrayPos] = (int)player;
                        _boardRenderer.AddMove(rowNumber, columnNumber, player, true);
                    }

                    else
                    {
                        throw new DuplicatePlayException("Player has already played this position");
                    }

                    inputValid = true;
                    Console.SetCursorPosition(2, 29);
                    Console.WriteLine("               ");

                }

                catch (FormatException exception)
                {
                    Console.SetCursorPosition(2, 29);
                    Console.WriteLine("Please enter row and columns as numbers only." + exception.Message);
                    inputValid = false;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.SetCursorPosition(2, 29);
                    Console.WriteLine("Please enter numbers between 0 and 2 for row and column");
                    inputValid = false;
                }
                catch (DuplicatePlayException exception)
                {
                    Console.SetCursorPosition(2, 29);
                    Console.WriteLine(exception.Message);

                }
            }

            //  add move to the board
            if (_boardPositions[arrayPos] == 1)
            {
                _boardPositions[arrayPos] = (int)player;
                _boardRenderer.AddMove(rowNumber, columnNumber, player, true);
            }

            else
            {
                throw new DuplicatePlayException("Player has already played this position");
            }

        }


        // I really don't like this int design decision we made.  int doesn't look good.  Next class we can change to an enum
        public bool CheckIfPlayerWins(int playerEnum)
        {
            if ((_boardPositions[0] == playerEnum) && (_boardPositions[1] == playerEnum) && (_boardPositions[2] == playerEnum))
                return true;

            if ((_boardPositions[3] == playerEnum) && (_boardPositions[4] == playerEnum) && (_boardPositions[5] == playerEnum))
                return true;

            if ((_boardPositions[6] == playerEnum) && (_boardPositions[7] == playerEnum) && (_boardPositions[8] == playerEnum))
                return true;

            if ((_boardPositions[0] == playerEnum) && (_boardPositions[3] == playerEnum) && (_boardPositions[6] == playerEnum))
                return true;

            if ((_boardPositions[1] == playerEnum) && (_boardPositions[4] == playerEnum) && (_boardPositions[7] == playerEnum))
                return true;

            if ((_boardPositions[2] == playerEnum) && (_boardPositions[5] == playerEnum) && (_boardPositions[8] == playerEnum))
                return true;

            if ((_boardPositions[0] == playerEnum) && (_boardPositions[4] == playerEnum) && (_boardPositions[8] == playerEnum))
                return true;

            if ((_boardPositions[2] == playerEnum) && (_boardPositions[4] == playerEnum) && (_boardPositions[6] == playerEnum))
                return true;

            // DO OTHER 7 Checks                


            // Leave this here as it will be false if all states above are false
            return false;
        }

        public void Run()
        {
            _rounds = 0;
            bool playerXWins = false;
            bool playerOWins = false;

            while (_rounds < 4)
            {

                //Change to Enum

                PlayMove(PlayerEnum.X);

                //Change to Enum

                playerXWins = CheckIfPlayerWins(PlayerEnum.X);

                if (playerXWins)
                {
                    Console.WriteLine("Player X Wins!!!");

                    break;

                }


                // play o

                //Change to Enum

                PlayMove(PlayerEnum.O);
                //Change to Enum

                playerOWins = CheckIfPlayerWins(PlayerEnum.O);

                if (playerOWins)
                {
                    Console.WriteLine("Player O Wins!!!");

                    break;
                }
                // checkif x won

                // if x won, exit

                // check if o won 

                // if o won exit

                _rounds++;
            }

            if (!playerXWins && !playerOWins)
                Console.WriteLine("The game is draw!");
        }

        private bool CheckIfPlayerWins(PlayerEnum O)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]

    internal class DuplicatePlayerException : Exception
    {
        public DuplicatePlayerException()
        {
        }

        public DuplicatePlayerException(string message) : base(message)
        {
        }

        public DuplicatePlayerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicatePlayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

}
    //done