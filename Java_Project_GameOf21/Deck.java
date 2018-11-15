/**
 * Program Name: Deck.java
 * Purpose: a subclass of CardSet which populates and shuffles 
 * Coder: Erica Kim
 * Date: Jun 18,2018
 */

import java.util.*;

public class Deck extends CardSet {
	
	private static int size = 52;
	
	public Deck(){
		super(size);
		populateDeck();
		shuffle();		
	}
	
	/*Method Name: populateDeck
	 *Purpose: create Card object made up of suits and each with 13 ranks
	 *Accepts:
	 *Returns:
	 */
	public void populateDeck(){
		for (Suit suit : Suit.values()) {
			for(int i = 1; i <= 13; i++) {
				cards.add(new Card(suit,i));
			}
		}		
	}
	
	/*Method Name: shuffle
	 *Purpose: shuffle cards randomly
	 *Accepts:
	 *Returns:
	 */
	public void shuffle() {
		Collections.shuffle(cards);		
	}
	
	/*Method Name: draw
	 *Purpose: removes the top(index 0) card from the deck and return
	 *Accepts:
	 *Returns: cards object
	 */
	public Card draw() {
		return cards.remove(0);
	}
	
	public int size() {
		return cards.size();
	}
	
	public void displayCards(int start) {
		for (int i = start; i < cards.size(); i++) {
			System.out.println(cards.get(i).toString());
		}
	}

	public void displayAllCards() {
		displayCards(0);		
	}


	public void displayVisibleCards() {
		displayCards(1);		
	}

}//end class
