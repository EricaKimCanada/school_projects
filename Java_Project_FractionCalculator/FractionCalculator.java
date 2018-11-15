/**
 * Class Name: FractionCalculator.java 
 * Purpose: A class of Fraction Calculator GUI
 * Coder:	Sungok Kim
 * Date:	July 30, 2018
 */

import java.awt.*;
import java.awt.event.*;
import java.text.DecimalFormat;
import java.util.*;
import javax.swing.*;

public class FractionCalculator extends JFrame {
	
	//Declare class variables (references to GUI objects)
	private JTextField numeratorFld, denominatorFld;
	private JButton buildBtn, startBtn;	
	private JTextArea fractionArea, operationArea;	
	private JComboBox<String> cboOptions;
	private JLabel enterFracLbl, fractionLbl, selectOperLbl, operationLbl, numeratorLbl, denominatorLbl;
	
	private JPanel enterPanel, fractionPanel, selectPanel, operationPanel;	
	private JPanel fldBtnPanel, fracAreaPanel, comboBoxPanel, operAreaPanel;
	private Font font;
	private Font fontTitle;
	private String [] options = {"Decimal","Reciprocal","Fraction1+Fraction2","Fraction1*Fraction2","Is Fraction1=Fraction2","Is Fraction1>Fraction2","Lowest Terms","Sort List"}; 
	
	private int num;
	private int den;
	
	private JMenuBar bar;
	private JMenu menuOption;
	private JMenuItem dec,rec,add,mul,equal,greater,lowest,sortList,about;
	
	private ArrayList<Fraction> fracList = new ArrayList<>();
	
	private int sortCount = 0;
	
	//no-arg constructor
	public FractionCalculator() {
		
		//Call to superclass constructor
		super("Fraction Calculator");
		
		//Set the layout manager
		this.setLayout(new GridLayout(1,4,10,10));
		
		//Create a customized font
		font = new Font("SansSerif", Font.PLAIN,16);
		fontTitle = new Font("SansSerif", Font.BOLD,18);
		
		//Call method to build panels
		buildEnterPanel();
		buildFractionPanel();
		buildSelectPanel();
		buildOperationPanel();		
		
		//Add panels to frame
		this.add(enterPanel);
		this.add(fractionPanel);
		this.add(selectPanel);
		this.add(operationPanel);
		
		buildMenuBar();
		
		//Set up methods for the frame
		this.setSize(1100, 450);							
		this.setLocationRelativeTo(null);										
		this.setDefaultCloseOperation(EXIT_ON_CLOSE);				
		this.setVisible(true);					
		
	}//End of constructor
	
	/*Method Name: buildEnterPanel()
	 *Returns: void
	 *Purpose: Building enter panel to facilitate input values
	 *Accepts: 
	 */
	public void buildEnterPanel() {
		
		enterPanel = new JPanel(new BorderLayout());		
		fldBtnPanel = new JPanel(new FlowLayout());
		fldBtnPanel.setBorder(BorderFactory.createLineBorder(Color.DARK_GRAY, 2));
		
		enterFracLbl = new JLabel("Enter a fraction:");		
		numeratorLbl = new JLabel("Numerator:");		
		denominatorLbl = new JLabel("Denominator:");
			
		numeratorFld = new JTextField();
		denominatorFld = new JTextField();		
		buildBtn = new JButton("Build Fraction");		
		startBtn = new JButton("Start Over!");
		
		numeratorLbl.setPreferredSize(new Dimension(150,40));
		numeratorFld.setPreferredSize(new Dimension(200,40));
		denominatorLbl.setPreferredSize(new Dimension(150,40));
		denominatorFld.setPreferredSize(new Dimension(200,40));
		buildBtn.setPreferredSize(new Dimension(150,40));
		startBtn.setPreferredSize(new Dimension(150,40));
		
		//Set a font
		enterFracLbl.setFont(fontTitle);
		numeratorLbl.setFont(font);
		denominatorLbl.setFont(font);
		buildBtn.setFont(font);
		startBtn.setFont(font);
		
		//Add components to panel		
		fldBtnPanel.add(numeratorLbl);
		fldBtnPanel.add(numeratorFld);
		fldBtnPanel.add(denominatorLbl);
		fldBtnPanel.add(denominatorFld);
		fldBtnPanel.add(buildBtn);
		fldBtnPanel.add(startBtn);
		
		enterPanel.add(enterFracLbl,BorderLayout.NORTH);
		enterPanel.add(fldBtnPanel, BorderLayout.CENTER);
		
		buildBtn.addActionListener(new ButtonHandler());
		startBtn.addActionListener(new ButtonHandler());
		
	}//End of buildEnterPanel method
	
	/*Method Name: buildFractionPanel()
	 *Returns: void
	 *Purpose: Building Fraction panel to facilitate operations on  input fraction values
	 *Accepts: 
	 */
	public void buildFractionPanel() {
		fractionPanel = new JPanel(new BorderLayout());
		fractionLbl = new JLabel("Here is your fraction:");			
		fractionArea = new JTextArea();
		fractionArea.setEditable(false);
		fractionArea.setPreferredSize(new Dimension(200,320));
		fractionArea.setBorder(BorderFactory.createLineBorder(Color.DARK_GRAY, 2));
		
		fracAreaPanel = new JPanel(new FlowLayout());
		fracAreaPanel.setBorder(BorderFactory.createLineBorder(Color.DARK_GRAY, 2));
		fracAreaPanel.add(fractionArea);
				
		//Set a font
		fractionLbl.setFont(fontTitle);
		fractionArea.setFont(font);		
		
		fractionPanel.add(fractionLbl, BorderLayout.NORTH);
		fractionPanel.add(fracAreaPanel, BorderLayout.CENTER);			
		
	}//End of buildFractionPanel method
	
	/*Method Name: buildSelectPanel()
	 *Returns: void
	 *Purpose: Building select panel to choose the types data and do arithmetic operation                                    on it 
	 *Accepts: 
	 */
	public void buildSelectPanel() {
		selectPanel = new JPanel(new BorderLayout());
		selectOperLbl = new JLabel("Select an operation:");	
						
		cboOptions = new JComboBox<String>(options);
		cboOptions.setSelectedIndex(0);
		cboOptions.setPreferredSize(new Dimension(200,40));
		cboOptions.addActionListener(new OperationHandler());
		
		comboBoxPanel = new JPanel(new FlowLayout());
		comboBoxPanel.setBorder(BorderFactory.createLineBorder(Color.DARK_GRAY, 2));
		comboBoxPanel.add(cboOptions);
		
		//Set a font
		selectOperLbl.setFont(fontTitle);
		cboOptions.setFont(font);
		
		selectPanel.add(selectOperLbl, BorderLayout.NORTH);
		selectPanel.add(comboBoxPanel, BorderLayout.CENTER);	
		
	}//End of buildSelectPanel method
	
	/*Method Name: buildOperationPanel()
	 *Returns: void
	 *Purpose: Building operation panel to receive output after arithmetic operation                    
	 *Accepts:  
	 */
	public void buildOperationPanel() 
	{
		//Create panel
		operationPanel = new JPanel(new BorderLayout());
		operationLbl = new JLabel("Here is your operation:");			
		operationArea = new JTextArea();
		operationArea.setEditable(false);
		operationArea.setPreferredSize(new Dimension(200,320));
		operationArea.setBorder(BorderFactory.createLineBorder(Color.DARK_GRAY, 2));
		
		operAreaPanel = new JPanel(new FlowLayout());
		operAreaPanel.setBorder(BorderFactory.createLineBorder(Color.DARK_GRAY, 2));
		operAreaPanel.add(operationArea);
		
		//Set a font
		operationLbl.setFont(fontTitle);
		operationArea.setFont(font);	
		
		operationPanel.add(operationLbl, BorderLayout.NORTH);
		operationPanel.add(operAreaPanel, BorderLayout.CENTER);	
		
	}//End of buildOperationPanel method
	
	/*Method Name: buildMenuBar()
	 *Returns: void
	 *Purpose: Building menubar to select the types of operation will perform                    	 
	 *Accepts: 
	 */
	public void buildMenuBar()
	{
		//Call method to build for menuBar
		bar = new JMenuBar();
		menuOption = new JMenu("Menu Option");	
		menuOption.setFont(fontTitle);
				
		dec = new JMenuItem("Decimal");
		rec = new JMenuItem("Reciprocal");
		add = new JMenuItem("Fraction1+Fraction2");
		mul = new JMenuItem("Fraction1*Fraction2");
		equal = new JMenuItem("Is Fraction1=Fraction2");
		greater = new JMenuItem("Is Fraction1>Fraction2");
		lowest = new JMenuItem("Lowest Terms");
		sortList = new JMenuItem("Sort List");
		about = new JMenuItem("About");
		
		dec.addActionListener(new MenuListener());
		rec.addActionListener(new MenuListener());
		add.addActionListener(new MenuListener());
		mul.addActionListener(new MenuListener());
		equal.addActionListener(new MenuListener());
		greater.addActionListener(new MenuListener());
		lowest.addActionListener(new MenuListener());
		sortList.addActionListener(new MenuListener());
		about.addActionListener(new MenuListener());
				
		menuOption.add(dec);
		menuOption.add(rec);
		menuOption.add(add);
		menuOption.add(mul);
		menuOption.add(equal);
		menuOption.add(greater);
		menuOption.add(lowest);
		menuOption.add(sortList);
		menuOption.add(about);
		
		bar.add(menuOption);
		setJMenuBar(bar);
	}
	
	/**
	 * Class Name: ButtonHandler 
	 * Purpose: An inner class which implements ActionListener
	 *          check invalid data and throw exceptions
	 *          show the Fraction result
	 * Coder:	Sungok Kim & MD Nasim Uddin		
	 * Date:	July 30, 2018
	 */
	private class ButtonHandler implements ActionListener
	{				
		public void actionPerformed(ActionEvent ev)
		{			
			if(ev.getSource().equals(buildBtn))
			{
				String numString = numeratorFld.getText(); 
				String denString = denominatorFld.getText();
				
				if(numString.isEmpty() || denString.isEmpty()) 
				{
					try 
					{						
						throw new EmptyOperandException();						
					} 
					catch (EmptyOperandException ex)
					{
						if(numString.isEmpty())
						{
							showWarning(ex.getMessage(),numeratorFld);
						}
						else if(!numString.isEmpty() && denString.isEmpty())
						{	
							showWarning(ex.getMessage(),denominatorFld);
						}
						else
						{
							showWarning(ex.getMessage(),numeratorFld);
						}						
					}
				}
				else 
				{									
					long numLong = 0;
					long denLong = 0;
					boolean isNumExcep = false;
					
					try
					{
						numLong = Long.parseLong(numString);
					}
					catch(NumberFormatException ex)
					{
						showWarning("Only integer values are aollwed.",numeratorFld);
						isNumExcep = true;
					}	
					catch(Exception ex)
					{
						showWarning("Input Error",numeratorFld);
						isNumExcep = true;
					}
					try
					{
						denLong = Long.parseLong(denString);
					}
					catch(NumberFormatException ex)
					{						
						showWarning("Only integer values are aollwed.",denominatorFld);
						isNumExcep = true;
					}
					catch(Exception ex)
					{
						showWarning("Input Error",denominatorFld);						
						isNumExcep = true;
					}
					
					int maxValue = 2147483647;
					int minValue = -2147483648; 
					
					if(numLong > maxValue || numLong < minValue || denLong > maxValue || denLong < minValue)
					{
						try 
						{						
							throw new LongOperandException();						
						} 
						catch (LongOperandException ex)
						{
							if(numLong > maxValue || numLong < minValue)
							{
								showWarning(ex.getMessage(),numeratorFld);
							}
							else if(denLong > maxValue || denLong < minValue)
							{
								showWarning(ex.getMessage(),denominatorFld);
							}
							else
							{
								showWarning(ex.getMessage(),numeratorFld);
							}												
						}
					}
					else if(denLong == 0)
					{
						if(!isNumExcep)
						{
							try 
							{						
								throw new DenominatorOfZeroException();						
							} 
							catch (DenominatorOfZeroException ex)
							{
								showWarning(ex.getMessage(),denominatorFld);
							}	
						}
					}									
					else if((numLong == 0 && denLong != 0)||(numLong != 0 && denLong != 0))
					{
						num = Integer.parseInt(numString);
						den = Integer.parseInt(denString);
						
						//if both numbers are minus, change them to plus
						if(num < 0 && den < 0)
						{
							num = Math.abs(num);
							den = Math.abs(den);
						}
						
						Fraction f = new Fraction(num,den);						
						fracList.add(f);
						
						String strArea = "";
						for(int i = 0; i < fracList.size(); i++)
						{
							strArea = strArea+fracList.get(i).getNum()+"/"+fracList.get(i).getDen()+"\n";							
						}
						fractionArea.setText(strArea);	
						numeratorFld.setText("");
						denominatorFld.setText("");
					}							
				}
			}
			else if (ev.getSource().equals(startBtn))
			{
				clearAll();
			}				
		}//End of actionPerformed method
	}//End of inner class
		
	/**
	 * Class Name: OperationHandler 
	 * Purpose: An inner class which implements ActionListener
	 *          check the data is valid and show the operation result
	 * Coder:	Sungok Kim & MD Nasim Uddin		
	 * Date:	July 30, 2018
	 */
	private class OperationHandler implements ActionListener
	{
		public void actionPerformed (ActionEvent ev)
		{			
			if(fracList.isEmpty()) 
			{
				showWarning("Enter a fraction first.",numeratorFld);
				cboOptions.setSelectedIndex(0);
				operationArea.setText("");
			}
			else 
			{						
				String selected = (String)cboOptions.getSelectedItem();
				//decimal
				if(selected.equals(options[0])) 
				{
					Fraction fLast = fracList.get(fracList.size()-1);
					double deci = fLast.convertToDecimal();
					DecimalFormat df = new DecimalFormat("#.##");
					
					operationArea.setText(fLast.getNum()+"/"+fLast.getDen()+" is "+df.format(deci));											
				}
				//reciprocal
				else if (selected.equals(options[1]))
				{
					Fraction fLast = fracList.get(fracList.size()-1);
					Fraction fResult = fLast.convertToReciprocal();
					operationArea.setText(fLast.getNum()+"/"+fLast.getDen()+" : reciprocal is "+fResult.getNum()+"/"+fResult.getDen());
					
				}
				//add
				else if (selected.equals(options[2]))
				{					
					if(fracList.size() > 1)
					{
						Fraction fSecondLast = fracList.get(fracList.size()-2);
						Fraction fLast = fracList.get(fracList.size()-1);
						
						Fraction fResult = fSecondLast.add(fLast);
						operationArea.setText(fSecondLast.getNum()+"/"+fSecondLast.getDen()+" + "+fLast.getNum()+"/"+fLast.getDen()+" = "+fResult.getNum()+"/"+fResult.getDen());						
					}
					else
					{
						showWarning("Enter one more fraction.",numeratorFld);
						cboOptions.setSelectedIndex(0);
						operationArea.setText("");
					}															
				}
				//multiply
				else if (selected.equals(options[3])) 
				{
					if(fracList.size() > 1)
					{
						Fraction fSecondLast = fracList.get(fracList.size()-2);
						Fraction fLast = fracList.get(fracList.size()-1);
						
						Fraction fResult = fSecondLast.multiply(fLast);
						operationArea.setText(fSecondLast.getNum()+"/"+fSecondLast.getDen()+" X "+fLast.getNum()+"/"+fLast.getDen()+" = "+fResult.getNum()+"/"+fResult.getDen());						
					}
					else
					{
						showWarning("Enter one more fraction.",numeratorFld);
						cboOptions.setSelectedIndex(0);
						operationArea.setText("");
					}												
				}
				//equals
				else if (selected.equals(options[4])) 
				{
					if(fracList.size() > 1)
					{
						Fraction fSecondLast = fracList.get(fracList.size()-2);
						Fraction fLast = fracList.get(fracList.size()-1);
						
						boolean isEqual = fSecondLast.equals(fLast);
						if(isEqual)
						{
							operationArea.setText(fSecondLast.getNum()+"/"+fSecondLast.getDen()+" is equal to "+fLast.getNum()+"/"+fLast.getDen());				
						}
						else
						{
							operationArea.setText(fSecondLast.getNum()+"/"+fSecondLast.getDen()+" is not equal to "+fLast.getNum()+"/"+fLast.getDen());				
						}								
					}
					else
					{
						showWarning("Enter one more fraction.",numeratorFld);
						cboOptions.setSelectedIndex(0);
						operationArea.setText("");
					}							
				}
				//greater than
				else if (selected.equals(options[5]))
				{
					if(fracList.size() > 1)
					{
						Fraction fSecondLast = fracList.get(fracList.size()-2);
						Fraction fLast = fracList.get(fracList.size()-1);
						
						boolean isGreater = fSecondLast.greaterThan(fLast);
						if(isGreater)
						{
							operationArea.setText(fSecondLast.getNum()+"/"+fSecondLast.getDen()+" is greater than "+"\n"+fLast.getNum()+"/"+fLast.getDen());				
						}
						else
						{
							operationArea.setText(fSecondLast.getNum()+"/"+fSecondLast.getDen()+" is not greater than "+"\n"+fLast.getNum()+"/"+fLast.getDen());				
						}								
					}
					else
					{
						showWarning("Enter one more fraction.",numeratorFld);
						cboOptions.setSelectedIndex(0);
						operationArea.setText("");
					}				
				}
				//lowest term
				else if (selected.equals(options[6]))
				{
					String strArea = "";
					for(int i = 0; i < fracList.size(); i++)
					{
						Fraction f = fracList.get(i);
						Fraction fResult = f.lowestTerms();
						
						strArea = strArea+f.getNum()+"/"+f.getDen()+" : lowest term is "+fResult.getNum()+"/"+fResult.getDen()+"\n";							
					}
					operationArea.setText(strArea);				
				}
				//sort list
				else if (selected.equals(options[7]))
				{				
					sortCount = 0;
					sortFraction();
					
					String strArea = "";
					for(int i = 0; i < fracList.size(); i++)
					{							
						strArea += fracList.get(i).getNum()+"/"+fracList.get(i).getDen() + "\n";
					}					
					operationArea.setText("Sort Fractions : \n" + strArea);	
					fractionArea.setText(strArea);
				}		
				else  
				{
					System.out.println("The user chose invaild operation");
				}				
			}
		}//End of actionPerformed method
	}//End of inner class
		
	
	/**
	 * Class Name: MenuListener 
	 * Purpose: An inner class which implements ActionListener for menubar
	 * Coder:	Sungok Kim & MD Nasim Uddin		
	 * Date: July 30, 2018
	 */
	private class MenuListener implements ActionListener
	{
		public void actionPerformed(ActionEvent e)
		{
			if ((e.getSource() == about))
			{
				JOptionPane.showMessageDialog(null,"Coders: Erica Kim & Nasim Uddin");
			}
			else 
			{				
				if(fracList.isEmpty()) 
				{
					showWarning("Enter a fraction first.",numeratorFld);
					cboOptions.setSelectedIndex(0);
					operationArea.setText("");
				}
				else 
				{						
					String selected = (String)cboOptions.getSelectedItem();
					//decimal
					if(e.getSource() == dec)	
					{
						Fraction fLast = fracList.get(fracList.size()-1);
						double deci = fLast.convertToDecimal();
						DecimalFormat df = new DecimalFormat("#.##");
						
						operationArea.setText(fLast.getNum()+"/"+fLast.getDen()+" is "+df.format(deci));											
					}
					//reciprocal
					else if ((e.getSource() == rec))
					{
						Fraction fLast = fracList.get(fracList.size()-1);
						Fraction fResult = fLast.convertToReciprocal();
						operationArea.setText(fLast.getNum()+"/"+fLast.getDen()+" : reciprocal is "+fResult.getNum()+"/"+fResult.getDen());
						
					}
					//add
					else if ((e.getSource() == add))
					{
						if(fracList.size() > 1)
						{
							Fraction fSecondLast = fracList.get(fracList.size()-2);
							Fraction fLast = fracList.get(fracList.size()-1);
							
							Fraction fResult = fSecondLast.add(fLast);
							operationArea.setText(fSecondLast.getNum()+"/"+fSecondLast.getDen()+" + "+fLast.getNum()+"/"+fLast.getDen()+" = "+fResult.getNum()+"/"+fResult.getDen());						
						}
						else
						{
							showWarning("Enter one more fraction.",numeratorFld);
							cboOptions.setSelectedIndex(0);
							operationArea.setText("");
						}															
					}
					//multiply
					else if ((e.getSource() == mul)) 
					{
						if(fracList.size() > 1)
						{
							Fraction fSecondLast = fracList.get(fracList.size()-2);
							Fraction fLast = fracList.get(fracList.size()-1);
							
							Fraction fResult = fSecondLast.multiply(fLast);
							operationArea.setText(fSecondLast.getNum()+"/"+fSecondLast.getDen()+" X "+fLast.getNum()+"/"+fLast.getDen()+" = "+fResult.getNum()+"/"+fResult.getDen());						
						}
						else
						{
							showWarning("Enter one more fraction.",numeratorFld);
							cboOptions.setSelectedIndex(0);
							operationArea.setText("");
						}												
					}
					//equals
					else if ((e.getSource() == equal)) 
					{
						if(fracList.size() > 1)
						{
							Fraction fSecondLast = fracList.get(fracList.size()-2);
							Fraction fLast = fracList.get(fracList.size()-1);
							
							boolean isEqual = fSecondLast.equals(fLast);
							if(isEqual)
							{
								operationArea.setText(fSecondLast.getNum()+"/"+fSecondLast.getDen()+" is equal to "+fLast.getNum()+"/"+fLast.getDen());				
							}
							else
							{
								operationArea.setText(fSecondLast.getNum()+"/"+fSecondLast.getDen()+" is not equal to "+fLast.getNum()+"/"+fLast.getDen());				
							}								
						}
						else
						{
							showWarning("Enter one more fraction.",numeratorFld);
							cboOptions.setSelectedIndex(0);
							operationArea.setText("");
						}							
					}
					//greater than
					else if ((e.getSource() == greater))
					{
						if(fracList.size() > 1)
						{
							Fraction fSecondLast = fracList.get(fracList.size()-2);
							Fraction fLast = fracList.get(fracList.size()-1);
							
							boolean isGreater = fSecondLast.greaterThan(fLast);
							if(isGreater)
							{
								operationArea.setText(fSecondLast.getNum()+"/"+fSecondLast.getDen()+" is greater than "+"\n"+fLast.getNum()+"/"+fLast.getDen());				
							}
							else
							{
								operationArea.setText(fSecondLast.getNum()+"/"+fSecondLast.getDen()+" is not greater than "+"\n"+fLast.getNum()+"/"+fLast.getDen());				
							}								
						}
						else
						{
							showWarning("Enter one more fraction.",numeratorFld);
							cboOptions.setSelectedIndex(0);
							operationArea.setText("");
						}				
					}
					//lowest term
					else if ((e.getSource() == lowest))
					{
						String strArea = "";
						for(int i = 0; i < fracList.size(); i++)
						{
							Fraction f = fracList.get(i);
							Fraction fResult = f.lowestTerms();
							
							strArea = strArea+f.getNum()+"/"+f.getDen()+" : lowest term is "+fResult.getNum()+"/"+fResult.getDen()+"\n";							
						}
						operationArea.setText(strArea);					
					}
					//sort list
					else
					{			
						sortCount = 0;
						sortFraction();
						
						String strArea = "";
						for(int i = 0; i < fracList.size(); i++)
						{							
							strArea += fracList.get(i).getNum()+"/"+fracList.get(i).getDen() + "\n";
						}					
						operationArea.setText("Sort Fractions : \n" + strArea);	
						fractionArea.setText(strArea);
					}				
				}
			}
		}//End of actionPerformed method
	}//End of inner class
	
	
	/*Method Name: clearAll()
	 *Returns: void
	 *Purpose: clear all components
	 *Accepts: 
	 */
	private void clearAll()
	{
		numeratorFld.setText("");
		denominatorFld.setText("");
		fractionArea.setText("");
		operationArea.setText("");
		
		fracList = new ArrayList<>();
		num = 0;
		den = 0;
	}//end of method
	
	/*Method Name: showWarning()
	 *Returns: void
	 *Purpose: if error, showing warning message
	 *Accepts: sting, JTextFiled
	 */
	public void showWarning(String message,JTextField fld)
	{
		JOptionPane.showMessageDialog(null,message,"Warning",JOptionPane.WARNING_MESSAGE);
		fld.requestFocus();	
	}//end of method
	
	/*Method Name: sortFraction()
	 *Returns: 
	 *Purpose: sort fractions in the array list
	 *Accepts:
	 */
	public void sortFraction()
	{				
		int checkN = fracList.size();
		
		if (sortCount == checkN)
		{
			return;
		}
				
		for(int i = 0; i < fracList.size()-1; i++)
		{
			int sortNum = fracList.get(i).compareTo(fracList.get(i+1));
			
			if(sortNum == 1)
			{
				Collections.swap(fracList, i, i+1);
			}
		}					
		sortCount++;
		sortFraction();
	}//end of method
		
	private static void setLookAndFeel()
	{
		try
		{
			UIManager.setLookAndFeel("com.sun.java.swing.plaf.nimbus.NimbusLookAndFeel");
		}	
		catch (Exception e)
		{
			System.out.println(e.getMessage());
		}	
	}//end of setLookAndFeel method
	
	
	public static void main (String [] args) {
		
		setLookAndFeel();
		//Create an instance of the frame
		FractionCalculator frame = new FractionCalculator();
	}//end of main method

}//End of class
