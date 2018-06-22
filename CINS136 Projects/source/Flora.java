/**
 * Programmer: Dmitry Post
 * Date: 10/29/12
 * Time: 2:53 PM
 */
/*
   Chapter 8      Programming Assignment 2
   Programmer:
   Date:
   Program Name:  Flora
*/

import javax.swing.*;
import java.io.*;
import java.awt.*;
import java.awt.event.*;


public class Flora extends Frame implements ActionListener
{

    DataOutputStream output;
    //Construct components
    Panel dataFields = new Panel();
    Panel firstRow = new Panel();
    Panel secondRow = new Panel();
    Panel thirdRow = new Panel();
    Panel fourthRow = new Panel();
    Panel fifthRow = new Panel();
    Panel sixthRow = new Panel();
    Panel buttonArea= new Panel();

    Button newSticker = new Button("New Sticker");
    Button renewal = new Button("Renewal");

    Label vinLabel = new Label("Enter Vehicle VIN number:    ");
    TextField vin = new TextField(20);
    Label yearLabel = new Label("Year:   ");
    TextField year = new TextField(4);
    Label makeLabel = new Label("Make:               ");
    TextField make = new TextField(10);
    Label modelLabel = new Label("Model:");
    TextField model = new TextField(10);
    Label firstNameLabel = new Label("Enter First Name:       ");
    TextField firstName = new TextField(15);
    Label lastNameLabel = new Label("Enter Last Name:");
    TextField lastName = new TextField(20);
    Label addressLabel = new Label("Enter Flora Address:");
    TextField address = new TextField (35);

    public static void main(String[] args)
    {
        Flora window = new Flora();
        window.setTitle("Flora City Stickers");
        window.setSize(450, 250);
        window.setVisible(true);
    }

    public Flora()
    {
        //Set background and layout managers
        setBackground(Color.magenta);
        setLayout(new BorderLayout());
        dataFields.setLayout(new GridLayout(6,1));
        FlowLayout rowSetup = new FlowLayout(FlowLayout.LEFT,5,2);
        firstRow.setLayout(rowSetup);
        secondRow.setLayout(rowSetup);
        thirdRow.setLayout(rowSetup);
        fourthRow.setLayout(rowSetup);
        fifthRow.setLayout(rowSetup);
        sixthRow.setLayout(rowSetup);
        buttonArea.setLayout(new FlowLayout());

        //Add fields to rows
        firstRow.add(vinLabel);
        firstRow.add(yearLabel);
        firstRow.add(makeLabel);
        firstRow.add(modelLabel);

        secondRow.add(vin);
        secondRow.add(year);
        secondRow.add(make);
        secondRow.add(model);

        thirdRow.add(firstNameLabel);
        thirdRow.add(lastNameLabel);

        fourthRow.add(firstName);
        fourthRow.add(lastName);

        fifthRow.add(addressLabel);

        sixthRow.add(address);

        //Add rows to panel
        dataFields.add(firstRow);
        dataFields.add(secondRow);
        dataFields.add(thirdRow);
        dataFields.add(fourthRow);
        dataFields.add(fifthRow);
        dataFields.add(sixthRow);

        //Add buttons to panel
        buttonArea.add(newSticker);
        buttonArea.add(renewal);

        //Add panels to frame
        add(dataFields, BorderLayout.NORTH);
        add(buttonArea, BorderLayout.SOUTH);

        //Add functionality to buttons
        newSticker.addActionListener(this);
        renewal.addActionListener(this);

        //Open the file
        try
        {
            output = new DataOutputStream(new FileOutputStream("Sticker.dat"));
        }
        catch(IOException c)
        {
            System.exit(1);
        }

        //Construct window listener
        addWindowListener(
                new WindowAdapter()
                {
                    public void windowClosing(WindowEvent e)
                    {
                        System.exit(0);
                    }
                }
        );
    }

    public void actionPerformed(ActionEvent e)
    {
        String arg = e.getActionCommand();
        String code;
        if (arg == "New Sticker")
            code = "N";
        else
            code = "R";

        if (
                (vin.getText().compareTo("")<1)       ||
                        (year.getText().compareTo("")<1)      ||
                        (make.getText().compareTo("")<1)      ||
                        (model.getText().compareTo("")<1)     ||
                        (firstName.getText().compareTo("")<1) ||
                        (lastName.getText().compareTo("")<1)  ||
                        (address.getText().compareTo("")<1)
                )
        {

             JOptionPane.showMessageDialog(this, "You must complete all fields.", "Data Entry Error",JOptionPane.ERROR_MESSAGE);

        }
        else
        {
            try
            {
                output.writeUTF(code);
                output.writeUTF(vin.getText());
                output.writeUTF(year.getText());
                output.writeUTF(make.getText());
                output.writeUTF(model.getText());
                output.writeUTF(firstName.getText());
                output.writeUTF(lastName.getText());
                output.writeUTF(address.getText());

                JOptionPane.showMessageDialog(this, "The vehicle information has been saved.", "Data Submitted",JOptionPane.INFORMATION_MESSAGE);

            }
            catch(IOException c)
            {
                System.exit(1);
            }
            clearFields();
        }
    }

    public void clearFields()
    {
        //Clear fields and reset the focus
        vin.setText("");
        year.setText("");
        make.setText("");
        model.setText("");
        firstName.setText("");
        lastName.setText("");
        address.setText("");
        vin.requestFocus();
    }
}