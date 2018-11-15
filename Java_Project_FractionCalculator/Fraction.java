/**
 * Class Name:	  	Fraction.java 
 * Purpose:		 	A class of Fraction
 * Coder:			Sungok Kim
 * Date:			July 30, 2018
 */

public class Fraction implements Comparable<Fraction>
{	
	//Declare variables
	private int num;
	private int den;
	
	//No-arg constructor
	public Fraction() 
	{
		this.num = 1;
		this.den = 1;
	}
	
	//arg constructor
	public Fraction(int num, int den) 
	{
		this.num = num;
		this.den = den;
	}

	public int getNum() 
	{
		return num;
	}

	public void setNum(int num) 
	{
		this.num = num;
	}

	public int getDen() 
	{
		return den;
	}

	public void setDen(int den) 
	{
		this.den = den;
	}
	
	/*Method Name: convertToDecimal()
	 *Returns: result double or float data
	 *Purpose: Method for decimal operations
	 *Accepts: 	  
	 */
	public double convertToDecimal() 
	{ 
		return (double)this.num/this.den;
	}
	
	/*Method Name: convertToReciprocal()
	 *Returns: Fraction
	 *Purpose: Method for reciprocal operations
	 *Accepts: 	  
	 */
	public Fraction convertToReciprocal() 
	{
		int n = this.den;
		int d = this.num;
		
		return new Fraction(n,d);	
	}
	
	/*Method Name: add()
	 *Returns: Fraction result 
	 *Purpose: Methods for adding operations
	 *Accepts: Fraction	  
	 */
	public Fraction add(Fraction f) 
	{
		int n = (this.num * f.getDen()) + (this.den * f.getNum()); 
		int d = this.den * f.getDen();	
		
		return new Fraction(n,d);
	}
	
	/*Method Name: multiply()
	 *Returns: Fraction result
	 *Purpose: Methods for multipling operations
	 *Accepts: Fraction	  
	 */
	public Fraction multiply(Fraction f) 
	{
		int n = this.num * f.getNum(); 
		int d = this.den * f.getDen();	
		
		return new Fraction(n,d);
	}
	
	/*Method Name: equals()
	 *Returns: boolean
	 *Purpose: Methods for checking fractions are equal or not
	 *Accepts: Fraction	  
	 */
	public boolean equals(Fraction f) 
	{		
		if(this.convertToDecimal() == f.convertToDecimal())
		{
			return true;
		}
		else
		{
			return false;
		}		
	}
	
	/*Method Name: greaterThan()
	 *Returns: boolean
	 *Purpose: Methods to check whether fraction is greater than other's
	 *Accepts: Fraction	  
	 */
	public boolean greaterThan(Fraction f) 
	{	
		if(this.convertToDecimal() > f.convertToDecimal())
		{
			return true;
		}
		else
		{
			return false;
		}		
	}
	
	/*Method Name: lowestTerms()
	 *Returns: Fraction
	 *Purpose: Methods to find the lowest term of Fraction
	 *Accepts: 	  
	 */
	public Fraction lowestTerms() 
	{
		int n = this.num;
		int d = this.den;

		int remainder = n % d;
		
		while (remainder != 0) 
		{     
			n = d;     
			d = remainder;     
			remainder = n % d;  
		}
		
		int nResult = this.num / d;  
		int dResult = this.den / d;
				
		return new Fraction(nResult,dResult);
	}
	
	/*Method Name: compareTo()
	 *Returns: int
	 *Purpose: Methods to check between fractions
	 *Accepts: Fraction	  
	 */
	public int compareTo(Fraction f)
	{		
		if(this.convertToDecimal() > f.convertToDecimal())
		{
			return 1;
		}
		else if(this.convertToDecimal() == f.convertToDecimal())
		{
			return 0;
		}	
		else
		{
			return -1;
		}		
	}

	/*Method Name: toString()
	 *Returns: string
	 *Purpose: Methods to return string for two objects
	 *Accepts: 	  
	 */
	public String toString() 
	{		
		return this.num + "/" + this.den;
	}		
}
