/*
   Chapter 3      Programming Assignment #3
   Programmer:
   Date:
   Program Name:   Money.java
*/

import java.io.*;

public class Money
{
   public static void main(String[] args) throws IOException
   {
	   BufferedReader dataIn = new BufferedReader(new InputStreamReader(System.in));

	   //Declaring Variables
	   int quarters;
	   int dimes;
	   int nickels;
	   int pennies;
	   int dollars;
	   int totalCents;
	   int cents;

	   //Assigning Values
	   quarters = 15;
	   dimes = 10;
	   nickels = 5;
	   pennies = 47;

	   //Calculations
	   quarters = quarters * 25;
	   dimes = dimes * 10;
	   nickels = nickels * 5;
	   pennies = pennies * 1;

	   //Conversions
	   totalCents = quarters + dimes + nickels + pennies;
	   dollars = (totalCents / 100);
	   cents = (totalCents % 100);

	   //Output
	   System.out.println("Your change equalled "+ dollars+" dollars and "+cents+" cents");
   }
}