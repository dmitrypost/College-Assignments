import java.io.*;
import java.util.Random;
/**
 * Programmer: Dmitry Post
 * Date: 11/4/12
 * Time: 5:51 PM
 * For testing purposes: Creates a file that will contain the student first and last name and the five scores for the student
 * Reads the file test.txt and adds data into an array
 * calculates the average of the scores
 * Writes the results to a file
 */
public class testscoresavg
 {
    public static void main(String[] args)
    {
        //creates the file to work with containing the scores...
        try
        {
            System.out.println("creating the file test.txt");
            DataOutputStream output = new DataOutputStream(new FileOutputStream("test.txt"));
            for(int i = 0;i<10;i++)
            {
                output.writeUTF("firstname " + (i+1)); //first name
                output.writeUTF("lastname " + (i+1)); //last name

                for(int j = 2; j<7 ; j++)
                {
                    Random generator = new Random();
                    int randomIndex = generator.nextInt( 100 );
                    output.writeUTF(String.valueOf(randomIndex)); //scores
                }
            }
            System.out.println("created the file test.txt");
        }
        catch (IOException c)
        {
                                      System.exit(9);
        }


        try
        {

            // reads data and adds data into a 'data' array with all the information.
            System.out.println("reading file test.txt");
            DataInputStream input = new DataInputStream(new FileInputStream("test.txt"));

            String[][] data = new String[10][7];

            for(int i = 0;i<10;i++)
            {
                data[i][0] = input.readUTF(); //first name
                data[i][1] = input.readUTF(); //last name

                for(int j = 2; j<7 ; j++)
                {
                    data[i][j] = input.readUTF(); //scores
                }
            }
            System.out.println("calculating average");
            //Calculate the average of all scores
            double avgscore = 0.00;
            for(int i = 0;i<10;i++)
            {
                for(int j = 2; j<7 ; j++)
                {
                    avgscore +=  Double.valueOf(data[i][j]); //scores
                }
            }
            avgscore = avgscore/50;
            System.out.println("average: "+avgscore+"\n");

            //write data from 'data' to file including the average of all the scores
            System.out.println("writing results to testavg.out");
            DataOutputStream output = new DataOutputStream(new FileOutputStream("testavg.out"));
            for(int i = 0;i<10;i++)
            {
                output.writeUTF(data[i][0]); //first name
                output.writeUTF(data[i][1]); //last name

                System.out.print(("\n" + data[i][0]) + " "); //shows the first name
                System.out.println((data[i][1]) + " "); //shows the last name

                for(int j = 2; j<7 ; j++)
                {
                    output.writeUTF(data[i][j]); //scores

                    System.out.print((data[i][j])+" ");
                }
            }
            output.writeUTF("The average test score is: " + avgscore);
            System.out.println("\n\nThe average is: "+avgscore);
            System.out.println("finished all the processing... exiting.");
        }
        catch(IOException c)
        {
            System.exit(1);
        }


    }
 }
