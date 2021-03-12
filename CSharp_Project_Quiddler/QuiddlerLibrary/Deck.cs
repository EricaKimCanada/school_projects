/*
 * Program:         QuiddlerLibrary.dll
 * Module:          Deck.cs
 * Author:          E. Kim & N. Uddin
 * Date:            February 10, 2020
 * Description:     Quiddler Score Game for INFO-5060 Project 1.
 *                  This is a class library that implements all features of Deck class.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuiddlerLibrary
{
    public class Deck : IDeck
    {
        //The container which has card point value information
        public static Dictionary<string, int> pointOfCards = new Dictionary<string, int>()
        {
            {"a",2},{"e",2},{"i",2},{"o",2},{"l",3},{"s",3},{"t",3},{"u",4},{"y",4},{"d",5},
            {"m",5},{"n",5},{"r",5},{"f",6},{"g",6},{"p",6},{"h",7},{"er",7},{"in",7},{"b",8},
            {"c",8},{"k",8},{"qu",9},{"th",9},{"w",10},{"cl",10},{"v",11},{"x",12},{"j",13},{"z",14},{"q",15}
        };

        //The container which has the number of cards in the deck
        private Dictionary<string, int> numberOfCards = new Dictionary<string, int>()
        {
            {"b",2},{"c",2},{"f",2},{"h",2},{"j",2},{"k",2},{"m",2},{"p",2},{"q",2},{"v",2},
            {"w",2},{"x",2},{"z",2},{"cl",2},{"er",2},{"in",2},{"qu",2},{"th",2},{"d",4},{"g",4},
            {"l",4},{"s",4},{"y",4},{"n",6},{"r",6},{"t",6},{"u",6},{"i",8},{"o",8},{"a",10},{"e",12}
        };

        //Cards per player
        private int cardsPerPlayer;

        //The card deck list
        public static List<string> cardDeck;        

        //The discard pile
        public static string discard;

        //Default constructor
        public Deck()
        {
            cardDeck = new List<string>();
            discard = "";

            foreach(KeyValuePair<string, int> card in numberOfCards)
            {
                for(int i = 0; i < card.Value; i++)
                {
                    cardDeck.Add(card.Key);
                }
            }
            Shuffle();
            FirstDiscard();
        }

        //Provides the name of the library’s developer
        public string About
        {
            get => "Test Client for QuiddlerLibrary (TM) Library, (c) 2020     E.Kim & N.Uddin\n";
        }

        //Indicates how many undealt cards remain in the deck
        public int CardCount
        {
            get => cardDeck.Count;
        }

        //Cards initially dealt to each player
        public int CardsPerPlayer {
            get => cardsPerPlayer;
            set
            {
                if(value >= 3 && value <= 10)
                {
                    cardsPerPlayer = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The number of cards is out of range 3-10"); 
                }
            }
        }

        //Returns the top card on the discard pile
        public string Discard
        {
            get => discard;
        }

        //Returns an IPlayer interface reference for a new player object
        public IPlayer NewPlayer()
        {
            List<string> playerHandCards = new List<string>();
            for(int i = 0; i < this.CardsPerPlayer; i++)
            {
                playerHandCards.Add(cardDeck[i]);
                cardDeck.RemoveAt(i);
            }

            IPlayer player = new Player(playerHandCards);
            return player;
        }

        //Shuffle the card deck
        private void Shuffle()
        {
            Random rng = new Random();
            cardDeck = cardDeck.OrderBy(card => rng.Next()).ToList();
        }

        //A first card from deck to discard pile
        private void FirstDiscard()
        {
            discard = cardDeck.First();
            cardDeck.RemoveAt(0);
        }
    }
}
