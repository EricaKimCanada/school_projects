/**
 * Program Name: Card.java
 * Purpose: an object class for a playing card and an aggregate class for CardSet
 * Coder: Erica Kim
 * Date: Jun 18,2018
 */

public class Card {
	
	private Suit suit;
	private int rank;
	
	public Card(){		
		this.suit = Suit.CLUBS;
		this.rank = 1;
	}
	
	public Card(Suit suit){
		this.suit = suit;
		this.rank = 1;		
	}
	
	public Card(Suit suit, int rank){
		this.suit = suit;
		this.rank = rank;
	}

	public Suit getSuit() {
		return suit;
	}

	public void setSuit(Suit suit) {
		this.suit = suit;
	}

	public int getRank() {
		return rank;
	}

	public void setRank(int rank) {
		this.rank = rank;
	}
	
	/*Method Name: findFaceValue
	 *Purpose: check the rank of the card and return the face values
	 *Accepts:
	 *Returns: String faceValue
	 **/
	public String findFaceValue() {
		
		String faceValue;
		
		switch (rank) {
			case 1: faceValue = "Ace";
				    break;
			case 2: faceValue = "Two";
			 		break;
			case 3: faceValue = "Three";
	 				break;		 	
			case 4: faceValue = "Four";
	 				break;		 
			case 5: faceValue = "Five";
	 				break;
			case 6: faceValue = "Six";
	 				break; 		
			case 7: faceValue = "Seven";
	 				break; 		
			case 8: faceValue = "Eight";
	 				break;		
			case 9: faceValue = "Nine";
	 				break;
			case 10: faceValue = "Ten";
	 				break; 		
			case 11: faceValue = "Jack";
	 				break; 		
			case 12: faceValue = "Queen";
	 				break;
			case 13: faceValue = "King";
	 				break; 		
	 		default: faceValue = "Invaild value";
	 				break;
		}		
		return faceValue;		
	}
	
	/*Method Name: toString
	 *Purpose: print out the face value of card rank
	 *Accepts:
	 *Returns: String
	 **/
	public String toString() {
		return findFaceValue() + " of " + this.suit.name();
	}	
	
}//end class
