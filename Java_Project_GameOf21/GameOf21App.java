/**
 * Program Name: GameOf21App.java
 * Purpose: a tester class which allows a user to play the Game of 21
 * Coder: Erica Kim
 * Date: Jun 18,2018
 */
import java.util.Scanner;
public class GameOf21App {

	public static void main(String[] args) {
		Scanner scanner = null;
		
		scanner = new Scanner(System.in);

		System.out.println("------------------------------------------");
		System.out.println("This application allows a player to play the Game of 21 against the computer.");
		System.out.println("------------------------------------------");

		String player = null;

		while (player == null || player.isEmpty()) {
			System.out.println("Enter your name:");
			player = scanner.next();
		}

		System.out.println(player + " Good Luck!");

		GameOf21 game = new GameOf21(player);
		game.setIn(scanner);

		game.printTitle();
		game.printInstructions();
		game.playGame();

	}

}//end class
