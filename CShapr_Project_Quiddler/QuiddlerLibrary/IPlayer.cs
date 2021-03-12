/*
 * Program:         QuiddlerLibrary.dll
 * Author:          E. Kim & N. Uddin
 * Date:            February 10, 2020
 * Description:     Quiddler Score Game for INFO-5060 Project 1.
 *                  This is a class library that implements all features of IPlayer interface.
 */
using System;

namespace QuiddlerLibrary
{
    public interface IPlayer : IDisposable
    {
        int CardCount { get; }

        int TotalPoints { get; }

        string DrawTopCard();

        bool DropDiscard(string letter);

        string PickupDiscard();

        int PlayWord(string candidate);

        int TestWord(string candidate);

        string ToString();
    }
}
