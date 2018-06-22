/*
 * what their year is
 * ask current date or gets current date
 * age var how old they are
 * your age is this 
 * 
 */
package cins136.homework.assignments;
import java.io.*;
public class ageCalculator {
       public static void main(String[] args) throws IOException
   	{
	   	int currentYear, birthYear, age;

		BufferedReader dataIn = new BufferedReader(new InputStreamReader(System.in));
		System.out.println("Input Birth Year:  ");
		birthYear = Integer.parseInt(dataIn.readLine());
		System.out.println("Input Current Year: ");
		currentYear = Integer.parseInt(dataIn.readLine());

		age = currentYear - birthYear;
		System.out.println("your age is " + age);
                
                if (age < 17){
                System.out.println("you may not see r rated movie");    
                }
                    else {
                    System.out.println("you may see r rated movie");
                }
                    
  	}
}
