/*
 * Program:         QuiddlerLibrary.dll
 * Module:          Player.cs
 * Author:          E. Kim & N. Uddin
 * Date:            February 10, 2020
 * Description:     Quiddler Score Game for INFO-5060 Project 1.
 *                  This is a class library that implements all features of Player class.
 */
using System;
using System.Collections.Generic;

namespace QuiddlerLibrary
{
    public class Player : IPlayer
    {
        //Cards there are in the player’s hand
        private List<string> playerHand = new List<string>();
        private int totalPoints = 0;

        //Application class for com object
        private Application newApp = null;

        //Indicates how many cards there are in the player’s hand
        public int CardCount
        {
            get => playerHand.Count;
        }

        //Indicates how many points in total have been scored by the player
        public int TotalPoints 
        { 
            get => totalPoints; 
        }

        //Constructor       
        public Player(List<string> cards)
        {
            playerHand = cards;
            newApp = new Application();
        }

        //Removes the top card from the deck
        public string DrawTopCard()
        {
            string topCard = Deck.cardDeck[0];     
            playerHand.Add(topCard);
            Deck.cardDeck.RemoveAt(0);

            return topCard;
        }

        //Accepts a card as a string, verifies that the card is in the player’s hand
        //Removes it from the hand and makes that card the top card on the discard pile
        public bool DropDiscard(string letter)
        {
            string lowerLetter = letter.ToLower();
            if (playerHand.Contains(lowerLetter))
            {
                playerHand.Remove(lowerLetter);
                Deck.discard = lowerLetter;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Takes the top card in the discard pile and adds it to the player’s hand
        public string PickupDiscard()
        {
            string tempDiscard = Deck.discard;
            playerHand.Add(tempDiscard);
            Deck.discard = "";

            return tempDiscard;
        }

        //Accepts a string containing a candidate word and then calls TestWord and add total points
        public int PlayWord(string candidate)
        {
            string lowerCandidate = candidate.ToLower().TrimEnd(' ');
            int wordPoints = TestWord(lowerCandidate);
            if (wordPoints > 0)
            {
                string[] letters = lowerCandidate.Split(' ');
                foreach (var letter in letters)
                {
                    if (playerHand.Contains(letter))
                    {
                        playerHand.Remove(letter);
                    }
                }
            }
            totalPoints += wordPoints;
            return wordPoints;
        }

        //Accepts a string containing a candidate word and returns its point value
        public int TestWord(string candidate)
        {
            string lowerCandidate = candidate.ToLower().TrimEnd(' ');

            //1.Check the candidate letter are in the player's hand
            bool isCandidateContained = false;
            string[] letters = lowerCandidate.Split(' ');
            foreach(string letter in letters)
            {
                if (playerHand.Contains(letter))
                {
                    isCandidateContained = true;
                }
                else
                {
                    isCandidateContained = false;
                    break;
                }
            }

            //2.Spelling check using the Applcation object's checkspelling()
            bool isCandidateValid = newApp.CheckSpelling(lowerCandidate.Replace(" ", ""));

            if (isCandidateContained && isCandidateValid)
            {
                return CalculateWordPoint(lowerCandidate);
            }
            else
            {
                return 0;
            }   
        }

        //Override ToString method
        public override string ToString()
        {
            string handCardValues = "";
            foreach(string cardValue in playerHand)
            {
                handCardValues += cardValue + ' ';
            }
            handCardValues = handCardValues.TrimEnd(' ');
            return handCardValues;
        }

        //Calculate the candidate's word point
        private int CalculateWordPoint(string candidate)
        {
            int wordPoint = 0;
            int totalWordPoint = 0;

            string[] letters = candidate.Split(' ');
            foreach (string letter in letters)
            {
                Deck.pointOfCards.TryGetValue(letter, out wordPoint);
                totalWordPoint += wordPoint;                
            }
            return totalWordPoint;
        }
        
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                if (newApp != null)
                {
                    newApp.Quit();
                }                    
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~Player()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
