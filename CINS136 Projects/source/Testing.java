/**
 * Programmer: Dmitry Post
 * Date: 11/4/12
 * Time: 2:51 PM
 */
public class Testing
{
    public static void main(String[] args)
    {
        char arr1[] = {'x','y','z'};
        char arr2[] = new char[26];

        for(int i = 0; i <3;i++)arr2[23+i] = arr1[i];
        System.out.println(arr2);
        System.out.println("||||||||||||||||||||||||||||");
        System.arraycopy(arr1, 0, arr2, 23, 3);
        System.out.println(arr2);
    }
}
