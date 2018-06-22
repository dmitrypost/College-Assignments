/**
 * Programmer: Dmitry Post
 * Date: 11/15/12
 * Time: 7:19 PM
 *
 2 your music
 +display data about your favorite musical artists. construct parallel arrays with data such
 +as artist name, genre, greatest hit, and record label.
 interface displays data in formatted jtextpane with scrolling capabilities
 +menu allows add new data to arrays.
 +instead of using jcombobox create sort command on the menu with a submenu that displays the field names.
 scrolling includes horizontal and vertical


 */

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

public class yourMusic extends Frame implements ActionListener
{
    String[] artist = new String [0];
    String[] genre= new String [0];
    String[] hit= new String [0];
    String[] label= new String [0];



    // Main window

        // data contains artist name, genre, greatest hit, record label
        JTextPane display = new JTextPane();
        //menu
        JMenuBar menuBar = new JMenuBar();

        JMenu m = new JMenu("Menu");
        JMenu viewAs = new JMenu("Sort by");

        JMenuItem add = new JMenuItem("Add");

        JMenuItem viewAsArtist = new JMenuItem("artist");
        JMenuItem viewAsGenre = new JMenuItem("genre");
        JMenuItem viewAsHit = new JMenuItem("greatest hit");
        JMenuItem viewAsLabel = new JMenuItem("label");

        Document doc;
        SimpleAttributeSet attributes = new SimpleAttributeSet();

    // Add new information window <Publicly accessible>

        JFrame newData = new JFrame("New Entry");

        JTextArea new_artist = new JTextArea();
        JTextArea new_genre = new JTextArea();
        JTextArea new_hit = new JTextArea();
        JTextArea new_label = new JTextArea();

        JButton add_new = new JButton("Add");

    public static void main(String[] args)
    {
        yourMusic window = new yourMusic();

    }   //runs the yourMusic()

    public yourMusic()
    {

        //creates the frame with that label
        JFrame frame = new JFrame("Your music");
        //adds the close event
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        //make the frame so it allows exact positioning and sizing
        frame.setLayout(null);
        //
        frame.setSize(600, 400);
        frame.setVisible(true);
        {   //controls
            //menu
            menuBar.setBounds(0,0,frame.getWidth(),20);
            menuBar.add(m);
            m.add(add);
            m.add(viewAs);
            viewAs.add(viewAsArtist);
            viewAsArtist.setActionCommand("View as Artist");
            viewAsArtist.addActionListener(this);
            viewAs.add(viewAsGenre);
            viewAsGenre.setActionCommand("View as genre");
            viewAsGenre.addActionListener(this);
            viewAs.add(viewAsHit);
            viewAsHit.setActionCommand("View as hit");
            viewAsHit.addActionListener(this);
            viewAs.add(viewAsLabel);
            viewAsLabel.setActionCommand("View as label");
            viewAsLabel.addActionListener(this);
            add.setActionCommand("new");
            add.addActionListener(this);
            frame.add(menuBar);

            display.setBounds(10,23, frame.getWidth() - 35 , frame.getHeight() - 65);
            frame.add(display);


        }

        //end of main window


        //start of the new entry window
        {
            newData.setSize(250,210);
            newData.setDefaultCloseOperation(JFrame.HIDE_ON_CLOSE);
            //make the frame so it allows exact positioning and sizing
            newData.setLayout(null);
            //artist
            JLabel artist_label = new JLabel("Artist");
            artist_label.setBounds(20,5,100,20);
            newData.add(artist_label);

            new_artist.setBounds(20,22,100,20);
            newData.add(new_artist);

            //genre
            JLabel genre_label = new JLabel("Genre");
            genre_label.setBounds(20,45,100,20);
            newData.add(genre_label);

            new_genre.setBounds(20,62,100,20);
            newData.add(new_genre);

            //hit
            JLabel hit_label = new JLabel("Hit");
            hit_label.setBounds(20,85,100,20);
            newData.add(hit_label);

            new_hit.setBounds(20,102,100,20);
            newData.add(new_hit);

            //label
            JLabel label_label = new JLabel("Label");
            label_label.setBounds(20,125,100,20);
            newData.add(label_label);

            new_label.setBounds(20,142,100,20);
            newData.add(new_label);

            //button
            add_new.setBounds(130,142,60,20);
            newData.add(add_new);
            add_new.setActionCommand("New entry");
            add_new.addActionListener(this);


        }   //end of new entry window
        add_new.doClick();
    }   //constructs windows

    //switch out values in array
    public void switchValues(String[] array, int firstValue, int secondValue)
    {
        String temp = new String(array[firstValue]);
        array[firstValue] = array[secondValue];
        array[secondValue] = temp;
    }
    //sorting
    public void reSort(String[] array)
    {
        for(int i = 1; i < array.length; i ++)
        {
            for (int e = 0; e < array.length -1; e++)
            {
                if (array[e].compareTo(array[e +1 ]) > 0)
                {
                    switchValues(artist,e,e+1);
                    switchValues(genre,e,e+1);
                    switchValues(hit,e,e+1);
                    switchValues(label,e,e+1);

                }

            }
        }

        //reset text
            doc = display.getDocument();
            try
            {
                doc.remove(0,doc.getLength());

                addFormattedText(true,true,Color.blue,"Artist\tGenre\tGreatest Hit\tRecord Label\n");
                for (int i = 1; i < array.length ; i++)
                {
                    addFormattedText(false,false,Color.black,artist[i] + "\t" + genre[i] + "\t" + hit[i] + "\t" + label[i] + "\n");
                }

            }
            catch (BadLocationException e)
            {

            }

    }  //end of resort

    public void addFormattedText(Boolean bold, Boolean italic, Color color, String string)
    {


        attributes = new SimpleAttributeSet();
        attributes.addAttribute(StyleConstants.CharacterConstants.Bold, bold);
        attributes.addAttribute(StyleConstants.CharacterConstants.Italic, italic);
        attributes.addAttribute(StyleConstants.CharacterConstants.Foreground, color);

        //tab stops
        TabStop[] tabs = new TabStop[3];
        tabs[0] = new TabStop(100,TabStop.ALIGN_LEFT,TabStop.LEAD_NONE);
        tabs[1] = new TabStop(200,TabStop.ALIGN_LEFT,TabStop.LEAD_NONE);
        tabs[2] = new TabStop(350,TabStop.ALIGN_LEFT,TabStop.LEAD_NONE);
        TabSet tabset = new TabSet(tabs);

        //attempt to add the formatted text.
        try {
            doc.insertString(doc.getLength(), string, attributes);
        } catch (BadLocationException badLocationException) {
            System.err.println("Bad insert");
        }

        StyleContext sc = StyleContext.getDefaultStyleContext();
        AttributeSet aset = sc.addAttribute(SimpleAttributeSet.EMPTY,
                StyleConstants.TabSet, tabset);
        display.setParagraphAttributes(aset, false);
    }

    public String [] arrayResize(String [] array)
    {
        String [] newString = new String[array.length +1];
        for (int i = 0; i <array.length;i++) newString[i] = array[i];

        return newString;
    }

    public void actionPerformed(ActionEvent e)
    {
        if(e.getActionCommand() == "new")
        {
            newData.setVisible(true);
        }
        else if(e.getActionCommand() == "View as Artist")
        {
            reSort(artist);
        }
        else if(e.getActionCommand() == "View as genre")
        {
            reSort(genre);
        }
        else if(e.getActionCommand() == "View as hit")
        {
            reSort(hit);
        }
        else if(e.getActionCommand() == "View as label")
        {
            reSort(label);
        }
        else if(e.getActionCommand() == "New entry")
        {    // add content to arrays
            //artist
                artist = arrayResize(artist);
                genre = arrayResize(genre);
                hit = arrayResize(hit);
                label = arrayResize(label);

                //insert data
                artist[artist.length - 1] = new String(new_artist.getText());
                genre[genre.length -1] = new String(new_genre.getText());
                hit[hit.length -1] = new String(new_hit.getText());
                label[label.length -1] = new String(new_label.getText());

            reSort(artist);
            newData.setVisible(false);
        }    // end add content to arrays
    }

}