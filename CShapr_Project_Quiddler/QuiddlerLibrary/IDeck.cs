/*
 * Program:         QuiddlerLibrary.dll
 * Author:          E. Kim & N. Uddin
 * Date:            February 10, 2020
 * Description:     Quiddler Score Game for INFO-5060 Project 1.
 *                  This is a class library that implements all features of IDeck interface.
 */

namespace QuiddlerLibrary
{
    public interface IDeck
    {
        string About { get; }

        int CardCount { get; }

        int CardsPerPlayer { get; set; }

        string Discard { get; }

        IPlayer NewPlayer();
    }
}
