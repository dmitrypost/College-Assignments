import java.io.File;

/**
 * Programmer: Dmitry Post
 * Date: 11/5/12
 * Time: 11:12 AM
 * Extra Credit: from 'Array and File Input & Output Questions' List files in current directory
 */
public class listFilesInCurrentDir
{
    public static void main(String[] args)
    {
        File[] listOfFiles = (new File(".")).listFiles();
        for (int i = 0; i < listOfFiles.length; i++){
        if(listOfFiles[i].isFile()){
        String files = listOfFiles[i].getName();
        System.out.println(files);}}
    }
}
