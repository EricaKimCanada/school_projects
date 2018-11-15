/**
 * Class Name: EmptyOperandException.java 
 * Purpose: A class of EmptyOperandException. If the user has failed to enter 
	        a value in either the numerator or  denominator text field, 
	        a dialog box will advise user to enter data in empty box.
 * Coder: Sungok Kim		
 * Date: August 4, 2018
 */

public class EmptyOperandException extends Exception {
	
	EmptyOperandException()
	{
		super("Warning: numerator or denominator box has been left empty.");
	}

}//end of class
