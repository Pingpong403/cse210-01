// Josh Hamilton
// CSE210-01: Tic-Tac-Toe

using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Generate and display board.
            List<string> grid = new List<string>{"1", "2", "3", "4", "5", "6", "7", "8", "9"};
            Console.WriteLine($"\n\n{GenerateBoard(grid)}\n");

            // A turn of 1 means it's X's turn and 2 means O.
            int turn = 1;
            bool gameWon = false;
            do
            {
                string place = "filler";
                // X's turn
                if (turn == 1)
                {
                    bool validSpot = false;
                    while (!validSpot)
                    {
                        Console.Write("X's turn. Pick a space: ");
                        place = Console.ReadLine();
                        if (grid[int.Parse(place) - 1] == "X"||grid[int.Parse(place) - 1] == "O")
                        {
                            Console.WriteLine("That spot is filled. Please pick an empty spot.");
                        }
                        else
                        {
                            validSpot = true;
                        }
                    }
                }
                // O's turn
                else
                {
                    bool validSpot = false;
                    while (!validSpot)
                    {
                        Console.Write("O's turn. Pick a space: ");
                        place = Console.ReadLine();
                        if (grid[int.Parse(place) - 1] == "X"||grid[int.Parse(place) - 1] == "O")
                        {
                            Console.WriteLine("That spot is filled. Please pick an empty spot.");
                        }
                        else
                        {
                            validSpot = true;
                        }
                    }
                }
                // Update grid & display board
                int placeIndex = int.Parse(place) - 1;
                if (turn == 1)
                {
                    grid[placeIndex] = "X";
                }
                else
                {
                    grid[placeIndex] = "O";
                }
                Console.WriteLine($"\n{GenerateBoard(grid)}\n");

                // Check for winner
                if (CheckWin(grid) == "X")
                {
                    Console.WriteLine("X wins!");
                    gameWon = true;
                }
                else if (CheckWin(grid) == "O")
                {
                    Console.WriteLine("O wins!");
                    gameWon = true;
                }
                else if (CheckWin(grid) == "Tie")
                {
                    Console.WriteLine("Tie!");
                    gameWon = true;
                }
                else
                {
                    if (turn == 1)
                    {
                        turn += 1;
                    }
                    else
                    {
                        turn -= 1;
                    }
                }
            }while (gameWon != true);
        }
        static string GenerateBoard(List<string> grid)
        {
            string board = $@"{grid[0]}|{grid[1]}|{grid[2]}
-+-+-
{grid[3]}|{grid[4]}|{grid[5]}
-+-+-
{grid[6]}|{grid[7]}|{grid[8]}";
            return board;
        }
        static string CheckWin(List<string> grid)
        {
            // Set result to nothing.
            string result = "none";
            // Check if the entire board is full
            if ((grid[0] == "X"||grid[0] == "O")&&(grid[1] == "X"||grid[1] == "O")&&(grid[2] == "X"||grid[2] == "O"))
            {
                if ((grid[3] == "X"||grid[3] == "O")&&(grid[4] == "X"||grid[4] == "O")&&(grid[5] == "X"||grid[5] == "O"))
                {
                    if ((grid[6] == "X"||grid[6] == "O")&&(grid[7] == "X"||grid[7] == "O")&&(grid[8] == "X"||grid[8] == "O"))
                    {
                        result = "Tie";
                    }
                }
            }
            // Check if either player has won
            List<string> players = new List<string>{"X", "O"};
            foreach (string player in players)
            {
                if (grid[0] == player && grid[1] == player && grid[2] == player)
                {
                    result = player;
                }
                if (grid[3] == player && grid[4] == player && grid[5] == player)
                {
                    result = player;
                }
                if (grid[6] == player && grid[7] == player && grid[8] == player)
                {
                    result = player;
                }
                if (grid[0] == player && grid[3] == player && grid[6] == player)
                {
                    result = player;
                }
                if (grid[1] == player && grid[4] == player && grid[7] == player)
                {
                    result = player;
                }
                if (grid[2] == player && grid[5] == player && grid[8] == player)
                {
                    result = player;
                }
                if (grid[0] == player && grid[4] == player && grid[8] == player)
                {
                    result = player;
                }
                if (grid[2] == player && grid[4] == player && grid[6] == player)
                {
                    result = player;
                }
            }
            return result;
        }
    }
}