/**
 * Created with IntelliJ IDEA.
 * User: Dima
 * Date: 12/9/12
 * Time: 3:51 PM
 * To change this template use File | Settings | File Templates.
 */
public class ExtraCredit
{
    public static void main(String[] args)
    {
        Integer k = new Integer(0);
        Math.pow(((3-k)/4),2);

        Integer x = new Integer(1);
        Integer y = new Integer(1);
        System.out.println((9 * x - (4.5 - y)) / (2 * x));

        String s = "hedge";
        s += "hog";
        System.out.println(s.equals("hedgehog"));
        System.out.println((s.length()-6) + " " + s.charAt(0) + "\'s");

        int f = 3;
        do
        {
            x -= 2;
        }while (x >= 0);

        Boolean a = true;
        Boolean b = true;
        System.out.println(!(!a || !b))      ;
        System.out.println((a || b));
    }
}
