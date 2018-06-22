/**
 * Programmer: Dmitry Post
 * Date: 11/15/12
 * Time: 6:47 PM
 * +
 *
 * 1 create a bibliography
 program accepts input of data from user: author, title of book, publisher, year and number of pages
 displays the dat in a formatted text pane using a standard mla or ap style bibliography entry.
 include font family, style and tabs in solution

 */

import javax.sound.midi.SysexMessage;
import javax.swing.*;
import java.io.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.Component;
import javax.swing.*;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JTextField;
import javax.swing.*;
import javax.swing.text.*;

import java.awt.*;              //for layout managers and more
import java.awt.event.*;        //for action events

import java.net.URL;
import java.io.IOException;


public class Bibliography extends JFrame implements ActionListener
{
    //placed here so the actionlistener can access these controls

    JTextField author = new JTextField();
    JTextField title = new JTextField();
    JTextField city = new JTextField();
    JTextField publisher = new JTextField();
    JTextField year = new JTextField();
    JTextField type = new JTextField("Print");
    //Create a text pane.
    StyledDocument document = new DefaultStyledDocument();
    JTextPane textPane = new JTextPane(document);
    JScrollPane paneScrollPane = new JScrollPane(textPane);
    SimpleAttributeSet attributes = new SimpleAttributeSet();
    //error status
    JLabel error = new JLabel("");

    public static void main(String[] args)
    {
                      Bibliography window = new Bibliography();

    }

    public  Bibliography()
    {

        //creates the frame with that label
        JFrame frame = new JFrame("Bibliography");
        //adds the close event
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        //make the frame so it allows exact positioning and sizing
        frame.setLayout(null);
        //Components
        {
            //Author
            JLabel authorlabel = new JLabel("Author:");
            authorlabel.setBounds(20,20,45,20);
            frame.add(authorlabel);

            author.setBounds(70, 20, 100, 20);
            frame.add(author);

            //Title
            JLabel titlelabel = new JLabel("Title:");
            titlelabel.setBounds(20, 45, 45, 20);
            frame.add(titlelabel);

            title.setBounds(70, 45, 100, 20);
            frame.add(title);

            //City of Piblication
            JLabel citylabel = new JLabel("City:")  ;
            citylabel.setBounds(20,70,200,20);
            frame.add(citylabel);

            city.setBounds(70,70,100,20);
            frame.add(city);

            //Publisher
            JLabel publisherlabel = new JLabel("Publisher:")  ;
            publisherlabel.setBounds(10,95,200,20);
            frame.add(publisherlabel);

            publisher.setBounds(70, 95, 100, 20);
            frame.add(publisher);

            //Year of publication
            JLabel yearlabel = new JLabel("Year:")  ;
            yearlabel.setBounds(20,120,200,20);
            frame.add(yearlabel);

            year.setBounds(70, 120, 100, 20);
            frame.add(year);

            //Medium of publication
            JLabel typelabel = new JLabel("Type:")  ;
            typelabel.setBounds(20,145,200,20);
            frame.add(typelabel);

            type.setBounds(70, 145, 100, 20);
            frame.add(type);

            //Pages
            JLabel pageslabel = new JLabel("Pages:")  ;
            pageslabel.setBounds(20,170,200,20);
            //frame.add(pageslabel);

            JTextField pages = new JTextField();
            pages.setBounds(70, 170, 100, 20);
            //frame.add(pages);

            //Displayed Bibliography
            JLabel outputLabel = new JLabel("Bibliography for a book...");
            outputLabel.setBounds(210,20,150,20);
            frame.add(outputLabel);



            //button
            JButton show = new JButton("Show");
            show.setBounds(200, 145,120,20);
            show.setActionCommand("ShowBibliography");
            show.addActionListener(this);
            frame.add(show);

            //output...
            paneScrollPane.setVerticalScrollBarPolicy(
                    JScrollPane.VERTICAL_SCROLLBAR_ALWAYS);
            paneScrollPane.setPreferredSize(new Dimension(250, 155));
            paneScrollPane.setMinimumSize(new Dimension(10, 10));
            textPane.setBounds(200,45,175,75);
            textPane.setEditable(false);
            frame.add(textPane);

            //error label
           error.setBounds(20,170,2000,20);
            frame.add(error);
        }


        frame.setSize(400, 250);
        frame.setVisible(true);

    }

    public void addFormattedText(Boolean bold, Boolean italic, Color color, String string)
    {
        attributes = new SimpleAttributeSet();
        attributes.addAttribute(StyleConstants.CharacterConstants.Bold, bold);
        attributes.addAttribute(StyleConstants.CharacterConstants.Italic, italic);
        attributes.addAttribute(StyleConstants.CharacterConstants.Foreground, color);

        //attempt to add the formatted text.
        try {
            document.insertString(document.getLength(), string, attributes);
        } catch (BadLocationException badLocationException) {
            System.err.println("Bad insert");
        }

        //hanging indent
        MutableAttributeSet mas = new SimpleAttributeSet();
        StyleConstants.setLeftIndent(mas, 20);
        StyleConstants.setFirstLineIndent(mas, -20);
        document.setParagraphAttributes(0, document.getLength(), mas, false);
    }

    public void actionPerformed(ActionEvent e)
    {
        if(e.getActionCommand() == "ShowBibliography")
        {



            try
            {

                //authors last name...
                Integer startIndex = new Integer(author.getText().indexOf(" "));
                String authorLastName = new String(author.getText().substring(startIndex));
                addFormattedText(false,false,Color.black,authorLastName + ", ");
                //authors first name...
                String authorFirstName = new String(author.getText().substring(0,author.getText().indexOf(" ")));
                addFormattedText(false,false,Color.black,authorFirstName + ". ");


                //Title  'itialicized
                addFormattedText(false,true,Color.black,title.getText());
                addFormattedText(false,false,Color.black,". ");
                //city
                addFormattedText(false,false,Color.black,city.getText() + ": ");
                //Publisher
                addFormattedText(false,false,Color.black,publisher.getText() + ", ");
                //date
                addFormattedText(false,false,Color.black,year.getText() + ". ");
                //print
                addFormattedText(false,false,Color.black, "Print.");
                error.setText("");
            }
            catch (StringIndexOutOfBoundsException el)
            {
                error.setText("The author is not properly formatted: First Last");

            }


        }
        //   Works Cited Format: Author’s Last Name, First name. Title. City: Publisher, Date. Print.
        //
        //
    }

}