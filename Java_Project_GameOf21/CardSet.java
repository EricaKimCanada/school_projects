/**
 * Program Name: CardSet.java
 * Purpose: an abstract superclass, which creates a deck of Card objects
 * Coder: Erica Kim
 * Date: Jun 18,2018
 */

import java.util.ArrayList;

abstract public class CardSet {
	
	protected ArrayList<Card> cards;
	
	public CardSet(){
		cards = new ArrayList<>();
	}
	
	public CardSet(int numberOfCards){
		cards = new ArrayList<>(numberOfCards);
	}
	
	abstract public void displayAllCards();
	
	abstract public void displayVisibleCards();

}//end class
