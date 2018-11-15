/**
 * Class Name: DenominatorOfZeroException.java 
 * Purpose: A class of DenominatorOfZeroException. This exception method
	 		will be thrown and caught if user enters a fraction with a deniminator of zero.
 * Coder:	Sungok Kim	
 * Date: August 4, 2018
 */

public class DenominatorOfZeroException extends Exception {
	
	DenominatorOfZeroException()
	{
		super("Warning: the denominator cannot be zero.");
	}

}//end of class

