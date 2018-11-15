/**
 * Class Name: LongOperandException.java 
 * Purpose: A class of LongOperandException will throw an exception if either the 
 *          numerator or denominator exceeds the maximum value for the int data type.
 * Coder:	Sungok Kim
 * Date: August 4, 2018
 */

public class LongOperandException extends Exception {
	
	LongOperandException()
	{
		super("Warning: operand entered exceeds int capacity.");
	}

}//end of class
