import javax.swing.*;

/**
 * Created with IntelliJ IDEA.
 * User: Dima
 * Date: 11/29/12
 * Time: 6:51 PM
 * To change this template use File | Settings | File Templates.
 */
public class SerialNumber
{
    String first = new String();
    String second = new String();
    String third = new String();
    boolean valid;



    public static void validate(String sn)
    {
        final String validChars = new String("abcdefghijklmnopqrstuvwxyz1234567890");
        String firstgroup = new String(sn.substring(0,5));
        Integer secondgroup = new Integer(0);
        try
        {
             secondgroup = new Integer(sn.substring(6,10));
        }
         catch (java.lang.NumberFormatException e)
         {
             System.out.print("invalid");
         }
        String thirdgroup = new String(sn.substring(11,15));
       // String
        for(Integer i = 0;i<=4;i++)
        {
            try
            {
                Integer character = new Integer(firstgroup.substring(i,i+1));
                System.out.print("invalid 1st group");
            }
             catch (java.lang.NumberFormatException e)
             {

             }

        }
        boolean valid = false;
        for(Integer i = 0;i<=3;i++)
        {
            try
            {
                Integer character = new Integer(thirdgroup.substring(i,i+1));
                System.out.print("invalid 3rd group");
                valid = false;
            }
            catch (java.lang.NumberFormatException e)
            {

            }
            finally {
                valid = true;
            }

        }

         if(valid == true)
        {
             System.out.print("Valid");
        }



    }
    public static void main(String[] args)
    {


        String s = new String("lllll-5545-llll");
        s = JOptionPane.showInputDialog(null, "enter serial number");

        validate(s);
    }
}
