/**
 * Program Name: GameOf21.java
 * Purpose: a class which uses a Deck object and Hand objects
 * Coder: Erica Kim
 * Date: Jun 18,2018
 */
import java.util.Scanner;

public class GameOf21 {
	
	private Deck deck;
	private Hand user;
	private Hand computer;	
	private Scanner in;
	
	GameOf21(String player){
		this.user = new Hand(player);
		this.computer = new Hand("Computer");
		this.deck = new Deck();
	}
	
	
	/*Method Name:playGame()
	 *Purpose: display deck's current size and call playhand method
	 *if they has not blackjack call display method to print the cards number and shit
	 *and then call print printWinner and playagain method
	 *Accepts:
	 *Returns:
	 */
	public void playGame() {
		System.out.println("Deck contains " + this.deck.size() + " cards.");
		
		playHand();
		
		if (!this.user.hasBlackjack() && !this.computer.hasBlackjack()) {
			System.out.println("***********************" + this.user.getUserName() + "*******************");
			this.user.displayAllCards();

			System.out.println("***********************" + this.computer.getUserName() + "*******************");
			this.computer.displayVisibleCards();

			userDraws();
			computerDraws();
		}
		printWinner();
		playAgain();
	}

	/*Method Name:playHand()
	 *Purpose:call hit and draw methods
	 *Accepts:
	 *Returns:
	 */
	public void playHand() {
		this.user.hit(this.deck.draw());
		this.user.hit(this.deck.draw());

		this.computer.hit(this.deck.draw());
		this.computer.hit(this.deck.draw());		
	}
	
	/*Method Name:playAgain
	 *Purpose:if deck size is more than 6 it return. 
	 *prompts the user to play again and gets the user's responce
	 *Accepts:
	 *Returns:
	 */
	public void playAgain() {
		if (this.deck.size() < 6) {
			System.out.println("Deck must contains at least 6 cards. Thank you for playing. Bye.");
			return;
		}

		System.out.print("Do you want to play again(Y/N)?");

		String answer = this.in.next();

		if ("Y".equals(answer)) {
			this.user.emptyHand();
			this.computer.emptyHand();
			playGame();

		} else if ("N".equals(answer)) {
			System.out.println("Thank you for playing. Bye.");

		} else {
			System.out.println("Invalid Input.");
			playAgain();
		}		
	}
	
	/*Method Name:userDraws
	 *Purpose:if the user wants to play again draw the cards
	 *Accepts:
	 *Returns:
	 */
	public void userDraws() {
		System.out.println("Do you want another card (Y/N)?");

		String answer = this.in.next();

		if ("Y".equals(answer)) {
			this.user.hit(this.deck.draw());

			System.out.println(this.user.getUserName() + " draws card.");
			System.out.println("***********************" + this.user.getUserName() + "*******************");
			this.user.displayAllCards();

			userDraws();

		} else if ("N".equals(answer)) {
			// do nothing

		} else {
			System.out.println("Invalid Input.");
			userDraws();
		}		
	}
	
	/*Method Name:computerDraws
	 *Purpose:draws the computer's cards
	 *Accepts:
	 *Returns:
	 */
	public void computerDraws() {
		if (this.user.totalVisibleHand() <= 21) {
			while (this.computer.totalHand() < 17) {
				this.computer.hit(this.deck.draw());
			}
		}
		System.out.println("***********************" + this.computer.getUserName() + "*******************");
		this.computer.displayAllCards();
	}
	
	/*Method Name:printWinner
	 *Purpose:calculate and show the final score and a winner
	 *Accepts:
	 *Returns:
	 */
	public void printWinner() {
		System.out.println("--------------------------------");
		System.out.println("Game of 21 - Final Score");
		System.out.println("--------------------------------");

		final int userPoints = this.user.totalHand();
		final int computerPoints = this.computer.totalHand();

		System.out.println(this.user.getUserName() + " points:" + userPoints);
		System.out.println(this.computer.getUserName() + " points:" + computerPoints);

		Hand winner = this.computer;

		if (userPoints == 21 && computerPoints != 21) {
			winner = this.user;

		} else if (userPoints < 21 && computerPoints < 21 && userPoints > computerPoints) {
			winner = this.user;

		} else if (userPoints < 21 && computerPoints > 21) {
			winner = this.user;

		} else if (userPoints > 21 && computerPoints > 21 && userPoints > computerPoints) {
			winner = this.user;
		}

		System.out.println(winner.getUserName() + " Wins!");
	}
	
	/*Method Name:printTitle
	 *Purpose:print the title 
	 *Accepts:
	 *Returns:
	 */
	public void printTitle() {
		System.out.println("------------------------------------------");
		System.out.println("Welcome to the Game of 21!");
		System.out.println("------------------------------------------");
	}
	
	/*Method Name:printInstructions
	 *Purpose:print the instruction
	 *Accepts:
	 *Returns:
	 */
	public void printInstructions() {
		System.out.println("------------------------------------------");
		System.out.println("HOW TO PLAY:");
		System.out.println("------------------------------------------");
		System.out.println("The objective of the game is get the closest to 21 without going over. "
				+ "The player and the computer are dealt 2 cards. "
				+ "The player is allowed to draw additional cards to improve his hand, without going over 21. "
				+ "The computer can then choose to draw cards; though the computer will not draw if the player has busted");
		System.out.println("Face cards have a value of 10. "
				+ "Aces can be high or low (that is, 11 points or 1 point) "
				+ "depending on which is the best value which achieves the closest score to 21 without going over.");
		System.out.println(
				"After cards have been drawn by the player and the computer, the score is totaled and a winner is declared.");
	}

	public Deck getDeck() {
		return deck;
	}

	public void setDeck(Deck deck) {
		this.deck = deck;
	}

	public Hand getUser() {
		return user;
	}

	public void setUser(Hand user) {
		this.user = user;
	}

	public Hand getComputer() {
		return computer;
	}

	public void setComputer(Hand computer) {
		this.computer = computer;
	}
	
	public Scanner getIn() {
		return in;
	}

	public void setIn(Scanner in) {
		this.in = in;
	}
}//end class
