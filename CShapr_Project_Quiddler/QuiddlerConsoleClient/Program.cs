/*
 * Program:     QuiddlerConsoleClient.exe
 * Module:      Program.cs
 * Author:      E. Kim & N. Uddin
 * Date:        February 10, 2020
 * Description: A basic console client that tests the services of the QuiddlerLibrary.dll component.
 */
using System;
using System.Collections.Generic;
using QuiddlerLibrary;

namespace QuiddlerConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IDeck deck = new Deck();
                Console.WriteLine(deck.About);
                Console.WriteLine("The deck is initialized with {0} cards.\n", deck.CardCount + 1);

                //User input the number of players and dealt cards
                Console.Write("How many players are there? (1-8): ");
                int numberOfPlayer = InputNumber(1, 8);

                Console.Write("How many cards will be dealt to each player? (3-10): ");
                deck.CardsPerPlayer = InputNumber(3, 10);

                List<IPlayer> players = new List<IPlayer>();
                for (int i = 0; i < numberOfPlayer; i++)
                {
                    players.Add(deck.NewPlayer());
                }

                Console.WriteLine("\nCards were dealt to {0} player(s).", players.Count);
                Console.WriteLine("The top card which was '{0}' was moved to the discard pile.", deck.Discard);
                Console.WriteLine("The deck now contains {0} cards.\n", deck.CardCount);

                bool isDone = false;
                while (!isDone)
                {
                    int playerCount = 1;
                    foreach (IPlayer player in players)
                    {
                        //Show the number of players and draw cards
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine("Player " + playerCount);
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine("Your cards are [{0}]. ", player.ToString());

                        Console.Write("Do you want the top card in the discard pile which is '{0}'? (y/n): ", deck.Discard);
                        string topCardYesOrNo = Console.ReadLine().ToLower();
                        if (topCardYesOrNo == "y")
                        {
                            player.PickupDiscard();
                        }
                        else
                        {
                            Console.WriteLine("The dealer dealt '{0}' to you from the deck.", player.DrawTopCard());
                            Console.WriteLine("The deck contains {0} cards.", deck.CardCount);
                        }

                        Console.WriteLine("Your cards are [{0}]. ", player.ToString());

                        //Test words and play words
                        bool isPointNonZero = false;
                        while (!isPointNonZero)
                        {
                            Console.Write("Test a word for its points value? (y/n): ");
                            string testWordYesOrNo = Console.ReadLine().ToLower();
                            if (testWordYesOrNo == "y")
                            {
                                Console.Write("Enter a word using [{0}] leaving a space between cards: ", player.ToString());
                                string inputWord = Console.ReadLine();

                                int wordPoint = player.PlayWord(inputWord);
                                Console.WriteLine("The word [{0}] is worth {1} points.", inputWord, wordPoint);

                                if (wordPoint != 0)
                                {
                                    Console.Write("Do you want to play the word [{0}]? (y/n): ", inputWord);
                                    string playWordYesOrNo = Console.ReadLine().ToLower();
                                    if (playWordYesOrNo == "y")
                                    {
                                        Console.WriteLine("Your cards are [{0}] and you have {1} points", player.ToString(), player.TotalPoints);
                                    }

                                    isPointNonZero = true;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        //Discard pile 
                        if (player.CardCount <= 1)
                        {
                            Console.WriteLine("Dropping '{0}' on the discard pile.\n", player.ToString());
                            Console.WriteLine("*****  Player {0} is out! Game over!!  *****", playerCount);
                            isDone = true;
                            break;
                        }
                        else
                        {
                            bool isNext = false;
                            while (!isNext)
                            {
                                Console.Write("Enter a card from your hand to drop on the discard pile: ");
                                string inputDropCard = Console.ReadLine();
                                bool isValidDropCard = player.DropDiscard(inputDropCard);

                                if (isValidDropCard)
                                {
                                    Console.WriteLine("Your cards are [{0}].\n", player.ToString());
                                    isNext = true;
                                }
                                else
                                {
                                    Console.WriteLine("ERROR: Your answer must be one of [{0}].", player.ToString());
                                }
                            }
                        }

                        playerCount++;
                    } //end foreach (whole game)
                } //end While(isDone)               
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Helper method
        //Check the number of user input and return if it is valid
        public static int InputNumber(int minNum, int maxNum)
        {
            int returnNumber = 0;
            bool isValid = false;

            while (!isValid)
            {
                string inputNumber = Console.ReadLine();
                bool isValidNumber = Int32.TryParse(inputNumber, out returnNumber);

                while (!isValidNumber)
                {
                    Console.Write("Not a number, please try again: ");
                    inputNumber = Console.ReadLine();
                    isValidNumber = Int32.TryParse(inputNumber, out returnNumber);
                }

                if (returnNumber >= minNum && returnNumber <= maxNum)
                {
                    isValid = true;
                }
                else
                {
                    Console.Write("Out of range({0}-{1}) , please try again: ", minNum, maxNum);
                    isValid = false;
                }
            }

            return returnNumber;
        }
    }
}
