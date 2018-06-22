import javax.swing.*;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.*;
/**
 * Programmer: Dmitry Post
 * Date: 11/4/12
 * Time: 3:43 PM
 *
 * cars.dat is to contain only numbers; one number per line for each salesperson
 */
public class Dealership
{


    public static void main(String[] args)
    {
        try
        {
            int[] cars = new int[10];
            int totalcarssold = 0;
            int salespersonwithlargestamountofcarssold = 0;
            int numberofcarssoldbysalesperson =0;
            Scanner inFile = new Scanner(new FileReader("cars.dat"));
            for (int i = 0; i < 10; i++)
            {
                cars[i] = Integer.valueOf(inFile.nextLine());
                System.out.println("Salesperson "+(i+1) +" sold " + cars[i] + " cars.");
                totalcarssold +=  cars[i];
                if(numberofcarssoldbysalesperson < cars[i])
                {
                    salespersonwithlargestamountofcarssold = i+1;
                    numberofcarssoldbysalesperson = cars[i];
                }
            }
            System.out  .println("Salesperson " + salespersonwithlargestamountofcarssold + " sold the most number of cars with " + numberofcarssoldbysalesperson);
            System.out  .println("Total number of cars sold is: " + totalcarssold);

        }
        catch (FileNotFoundException ex)
        {
            JOptionPane.showMessageDialog(null,"The file 'cars.dat' is not found.","Error", JOptionPane.ERROR_MESSAGE);
            System.exit(5);
        }
    }


}
