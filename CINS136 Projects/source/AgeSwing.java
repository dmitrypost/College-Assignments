/*
	Chapter 3:	Age Calculator
	Programmer:	Dmitry Post
	Date:		September 23, 2012
	Filename:	AgeSwing.java
	Purpose:	This project calculates the persons age.
*/

import javax.swing.JOptionPane;

public class AgeSwing
{
		public static void main(String[] args)
		{
			// declare and construct variables
			String inYear;
			int birthYear, age;

			// print prompts and get input
				inYear = JOptionPane.showInputDialog(null,"Enter your birth year formated as yyyy: ");
				birthYear = Integer.parseInt(inYear);

			// calculations
			age = 2012 - birthYear;

			// output
                        JOptionPane.showMessageDialog(null,"Your age is IS "+ age,null,JOptionPane.PLAIN_MESSAGE);
			System.exit(0);
		}
}