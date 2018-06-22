/**
 * Created with IntelliJ IDEA.
 * User: Dima
 * Date: 11/30/12
 * Time: 11:40 PM
 * 4 average grades
 swing program that declares an empty array of grades with a max length of 50.
 joptionpane input box with a while loop to allow the user to enter the grades using a -1 as a sentiel value.
 after the grades are entered, context pane shows the grades sorted from lowest to highest.
 loop goes through array looking for elements that are greater than 0.
 create an average of grades
 display average in jtextpane and format to round the average.
 */
import sun.org.mozilla.javascript.internal.ast.CatchClause;

import javax.swing.*;
import java.io.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.Component;
import java.text.DecimalFormat;
import java.util.Arrays;
import javax.swing.*;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JTextField;
import javax.swing.*;
import javax.swing.text.*;

public class AverageGrades  extends JFrame implements ActionListener
{
    Integer[] grades = new Integer[50];
    Double average = new Double(0);
    Integer total = new Integer(0);
    Integer numberOfGrades = new Integer(0);

    JTextField newGrade = new JTextField();
    JButton add = new JButton("Add");
    JTextPane gradesFeild = new JTextPane();
    JTextPane averageFeild = new JTextPane();
    Document doc;
    SimpleAttributeSet attributes = new SimpleAttributeSet();
    DecimalFormat twoDigits = new DecimalFormat("##0.00");
    JScrollPane scrollpane = new JScrollPane(gradesFeild);

    public AverageGrades()
    {
        JFrame frame = new JFrame("Average Grades");
        //adds the close event
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        //make the frame so it allows exact positioning and sizing
        frame.setLayout(null);

        frame.setSize(250, 330);
        frame.setVisible(true);



        gradesFeild.setBounds(10,40,frame.getWidth() - 35 , frame.getHeight() -120);
        frame.add(gradesFeild);

        newGrade.setBounds(10, 10, frame.getWidth() - 130, 20);
        frame.add(newGrade);

        JLabel average_label = new JLabel("Average grade: ");
        average_label.setBounds(10,260,100,20);
        frame.add(average_label);

        averageFeild.setBounds(105,260,120, 20);
        frame.add(averageFeild);

        add.setBounds(135,10,90,20);
        frame.add(add);
        add.setActionCommand("add");
        add.addActionListener(this);

        doc = gradesFeild.getDocument();
        gradesFeild.setDocument(doc);

        scrollpane.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_ALWAYS);
        frame.add(scrollpane);
    }

    public void switchValues(Integer[] array, int firstValue, int secondValue)
    {
        Integer temp = new Integer(array[firstValue]);
        array[firstValue] = array[secondValue];
        array[secondValue] = temp;
    }

    public static void main(String[] args){AverageGrades window = new AverageGrades();}

    public  void sort(Integer array[],int length)
    {
        for(int i =1 ; i <length;i++)
        {
            for (int e = 0;e <length;e++)
            {
                try
                {
                    if(array[e]>(array[e + 1]))
                    {
                        switchValues(array , e, e +1);
                    }
                }
                catch (NullPointerException outofbounds)
                {

                }

            }
        }
    }
    public void actionPerformed(ActionEvent e)
    {


        if(e.getActionCommand() == "add")
        {


            grades[numberOfGrades] = new Integer(newGrade.getText());

            total += grades[numberOfGrades];
            numberOfGrades ++;
            average = Double.valueOf(total / numberOfGrades);

           sort(grades,numberOfGrades);
            try{doc.remove(0,doc.getLength());}catch(BadLocationException es){}

           for (int j = 0; j<numberOfGrades; j++)
           {
               addFormattedText(false,false,Color.black,grades[j] + "\n");
           }
            System.out.println(Arrays.toString(grades));
            averageFeild.setText(String.valueOf(twoDigits.format(average)));


        }    // end add content to arrays
    }

    public void addFormattedText(Boolean bold, Boolean italic, Color color, String string)
    {
        attributes = new SimpleAttributeSet();
        attributes.addAttribute(StyleConstants.CharacterConstants.Bold, bold);
        attributes.addAttribute(StyleConstants.CharacterConstants.Italic, italic);
        attributes.addAttribute(StyleConstants.CharacterConstants.Foreground, color);

        //attempt to add the formatted text.
        try {
            doc.insertString(doc.getLength(), String.valueOf(string), attributes);
        } catch (BadLocationException badLocationException) {
            System.err.println("Bad insert");
        }
    }
}
