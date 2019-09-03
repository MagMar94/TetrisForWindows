using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tetris
{
    /// <summary>
    /// Magnus Marthinsen
    /// 822116289
    /// 11/30/2017
    /// </summary>
    class FileManager
    {

        /// <summary>
        /// Saves the game to the file.
        /// </summary>
        /// <param name="filePathAndName"></param>
        /// <param name="game"></param>
        public static void SaveGameToFile(string filePathAndName, Tetris game)
        {
            Gamefile file = new Gamefile(game.Fieldgrid, game.Score, game.Level, game.RowsRemovedInTotal, game.RowsRemovedAtCurrentLevel);
            string gameFile = file.SerializeGame();
            try
            {
                System.IO.File.WriteAllText(filePathAndName, $"{gameFile}\n");
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (System.IO.DirectoryNotFoundException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Could not find directory.");
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (System.IO.IOException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Something went wrong.");
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (UnauthorizedAccessException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Unauthorized access.");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (System.Security.SecurityException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Sevurity Error.");
            }
        }

        /// <summary>
        /// Loads a game from file.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Tetris LoadGameFromFile(string filename)
        {
            try
            {
                string file = System.IO.File.ReadAllText(filename);
                Gamefile gameDeserialized = JsonConvert.DeserializeObject<Gamefile>(file);
                Tetris loadedGame = new Tetris(gameDeserialized.Board, gameDeserialized.Level, gameDeserialized.Score, gameDeserialized.RowsRemovedInTotal, gameDeserialized.RowsRemovedAtCurrentLevel);
                if (GameIsValid(loadedGame))
                {
                    return loadedGame;
                } else
                {
                    return null;
                }
                
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (System.IO.DirectoryNotFoundException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Could not find directory.");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (System.IO.IOException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Something went wrong.");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (UnauthorizedAccessException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Unauthorized access.");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (System.Security.SecurityException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Sevurity Error.");
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (JsonReaderException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                //Could not interprate file as game
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (JsonSerializationException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                //Could not interprate file as game
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (JsonWriterException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                //Could not interprate file as game
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                //Other exceptions that might occurr
            }
            return null;
        }

        /// <summary>
        /// Makes an effort to validate the game.
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        private static bool GameIsValid(Tetris game)
        {
            if(game.Level < 0)
            {
                return false;
            }
            if(game.RowsRemovedAtCurrentLevel < 0)
            {
                return false;
            }
            if(game.RowsRemovedInTotal < 0)
            {
                return false;
            }
            if(game.Fieldgrid == null)
            {
                return false;
            } else
            {
                if (game.Fieldgrid.Field.GetLength(0) == Grid.GRIDHEIGHT && game.Fieldgrid.Field.GetLength(1) == Grid.GRIDWIDTH)
                {
                    bool allValuesAreValid = true;
                    for (int row = 0; row < Grid.GRIDHEIGHT && allValuesAreValid; ++row)
                    {
                        for (int column = 0; column < Grid.GRIDWIDTH && allValuesAreValid; ++column)
                        {
                            if (game.Fieldgrid.Field[row, column] < 0 || game.Fieldgrid.Field[row, column] > 7)
                            {
                                return false;
                            }
                        }
                    }
                } else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Saves the highscore to a file.
        /// </summary>
        /// <param name="score"></param>
        public static void SaveHighscore(int score)
        {
            try
            {
                System.IO.File.WriteAllText(@"highscore.txt", $"{score}");
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (System.IO.IOException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                //Could not save score
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (UnauthorizedAccessException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                //Dont have access, cant use the high score.
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (System.Security.SecurityException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                //oh no, a security error! high score is not that important...
            }
            
        }

        /// <summary>
        /// Loads the high score.
        /// </summary>
        /// <returns></returns>
        public static int LoadHighScore()
        {
            try
            {
                string fileContent = System.IO.File.ReadAllText(@"highscore.txt");
                return int.Parse(fileContent);
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (System.IO.FileNotFoundException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                //File not found, maybe first time the game is played.
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (System.IO.DirectoryNotFoundException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                //could not find directory
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (FormatException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                //the file has been tampered with
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (OverflowException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                //the file has been tampered with, or the high score is inhumanly large.
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (ArgumentNullException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                //oops
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                //General catch to get other exceptions
            }
            return 0;
        }
    }
}
