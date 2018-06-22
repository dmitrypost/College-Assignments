/* 
        Chapter 1:	Writing Pseudocode
	Programmer:     Dmitry Post
	Date:		September 16, 2012
	Filename:	public class P38_Writing_Pseudocode.java
	Purpose:	Counts number of males and females
 */
         import java.io.*;
         import java.util.Scanner;
public class P38_Writing_Pseudocode {
    public static void main(String[] args){
        int total = 0;
        int males = 0;
        int females = 0;
        String status;
        Scanner scannerin= new Scanner(System.in);
        while (total < 25){
            System.out.println("(m)ale or (f)emale?");
            status = scannerin.nextLine();
            if ("f".equals(status)){
                females += 1; 
            }
            else if ("m".equals(status)){
                males += 1; 
            }
            total += 1;
        }
        System.out.println(females + " females");
        System.out.println(males + " males");
        System.out.println("Total students: " + total);
    }
}     

