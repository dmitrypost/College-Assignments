/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package cins136.homework.assignments;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Scanner;

/**
 *
 * @author Acer
 */
public class counter {
    public static void main(String[] args)throws IOException{
        System.out.println("enter number");
        BufferedReader dataIn = new BufferedReader(new InputStreamReader(System.in));
        int number = Integer.parseInt(dataIn.readLine());
        while(number !=0){
            System.out.println("your number is " + number);
            number --;    
    }
    }
}
