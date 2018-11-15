/**
 * Program Name: Hand.java
 * Purpose: a subclass of CardSet which holds an empty hand of cards,
 * 			draws cards, finds the best value for an Ace, totals a hand 
 * Coder: Erica Kim
 * Date: Jun 18,2018
 */
import java.util.*;

public class Hand extends CardSet{
	
	private String userName;
	
	public Hand(String userName){
		this.userName = userName;
	}
	
	public String getUserName() {
		return userName;
	}

	public void SetUserName(String userName) {
		this.userName = userName;
	}
	
	public void hit(Card card) {
		this.cards.add(card);		
	}
	
	public int getCardValue(Card card) {
		return card.getRank();
	}
	
	/*Method Name: totalHand
	 *Purpose: find the total value of cards. if a card is ace add it in list
	 *check the total value and calculate the result total hand
	 *Returns: int result
	 **/
	public int totalHand() {
		ArrayList<Card> aces = new ArrayList<>();
		int withoutAcesTotal = 0;
		
		for (int i = 0; i < this.cards.size();i++){
			Card card = this.cards.get(i);
			
			if (card.getRank() == 1) {
				aces.add(card);
			}
			else {
				withoutAcesTotal += card.getRank();
			}
		}
		
		int result = withoutAcesTotal;
		
		for(int i =0; i< aces.size(); i++) {
			if (result + 11 > 21) {
				result += 1;
			}
			else {
				result += 11;
			}
		}
		return result;		
	}
	
	public int totalVisibleHand() {
		int result = 0;

		for (int i = 0; i < this.cards.size(); i++) {
			Card card = this.cards.get(i);

			result += card.getRank();
		}

		return result;
	}
	
	/*Method Name: hasBlackjack
	 *Purpose: if total value is 21 and the card size is 2 return true
	 *Accepts:
	 *Returns: boolean
	 **/
	public Boolean hasBlackjack() {
		if (this.cards.size() == 2 && totalHand() == 21) {
			return true;
		}

		return false;
	}
	
	public void emptyHand() {
		this.cards.clear();
	}
	
	public void displayCards(int start) {
		for (int i = 0; i < cards.size(); i++) {
			if(i < start) {
				System.out.println("");
			}
			else {
				System.out.println((i+1) + ") " + cards.get(i).toString());
			}
		}
	}
	
	public void displayAllCards() {
		displayCards(0);		
	}


	public void displayVisibleCards() {
		displayCards(1);		
	}

}//end class
