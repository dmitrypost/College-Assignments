/*
   Chapter 3       Debugging Assignment
   Programmer:     Dmitry Post
   Date:
   Program Name:   Bert,java
   Purpose:        Output monthly payment amount!
*/

import java.io.*;

public class Bert
{
   	public static void main(String[] args)throws IOException
   	{
	   	//Declaring Variables
	   	int price, downpayment, tradeIn, months,loanAmt;
	   	double annualInterest, payment, interest;
	   	String custName, inputPrice,inputDownPayment,inputTradeIn,inputMonths, inputAnnualInterest;
	   	BufferedReader dataIn = new BufferedReader(new InputStreamReader(System.in));
                //Get Input from User
		System.out.println("What is your name?  ");
		custName = dataIn.readLine();
		System.out.print("What is the price of the car?  ");
		inputPrice = dataIn.readLine();
		System.out.print("What is the downpayment?  ");
		inputDownPayment = dataIn.readLine();
		System.out.print("What is the trade-in value?  ");
		inputTradeIn = dataIn.readLine();
		System.out.print("For how many months is the loan?  ");
		inputMonths = dataIn.readLine();
		System.out.print("What is the decimal interest rate?  ");
		inputAnnualInterest = dataIn.readLine();
		//Conversions
		price = Integer.parseInt(inputPrice);
		downpayment = Integer.parseInt(inputDownPayment);
		tradeIn = Integer.parseInt(inputTradeIn);
		months = Integer.parseInt(inputMonths);
		annualInterest = Double.parseDouble(inputAnnualInterest);
                //calculations
                interest =annualInterest/12;
               	loanAmt = price-downpayment-tradeIn;
                payment=(loanAmt/((1/interest)-(1/(interest*Math.pow(1+interest,months)))));
		//Output
		System.out.print("The monthly payment for " + custName + " is $");
		System.out.println(payment);
                // figures out monthly payment amount!!!
   	}
}