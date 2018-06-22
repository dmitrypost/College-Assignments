/**
 * Programmer: Dmitry Post
 * Date: 10/28/12
 * Time: 5:35 PM
 */
import java.io.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.text.*;
import java.util.*;



public class BillPayer extends JFrame implements ActionListener
{

    DataOutputStream output;


    JPanel firstRow = new JPanel();
    JPanel secondRow = new JPanel();
    JPanel thirdRow = new JPanel();
    JPanel fourthRow = new JPanel();
    JPanel fifthRow = new JPanel();
    JPanel sixthRow = new JPanel();
    JPanel seventhRow = new JPanel();
    JPanel eighthRow = new JPanel();


    JPanel feildPanel = new JPanel();
    JPanel buttonPanel = new JPanel();


    JLabel acctNumLabel = new JLabel("Account Number:                            ");
            JTextField acctNum = new JTextField(15);
    JLabel pmtLabel = new JLabel("Payment Amount:                            ");
    JTextField pmt = new JTextField(10);
    JLabel firstNameLabel = new JLabel("First Name:                            ");
    JTextField firstName = new JTextField(10);
    JLabel lastNameLabel = new JLabel("Last Name:                            ");
    JTextField lastName = new JTextField(20);
    JLabel addressLabel = new JLabel("Address:                            ");
    JTextField address = new JTextField(35);
    JLabel cityLabel = new JLabel("City:                            ");
    JTextField city = new JTextField(10);
    JLabel stateLabel = new JLabel("State:                            ");
    JTextField state = new JTextField(2);
    JLabel zipLabel = new JLabel("Zip:                            ");
    JTextField zip = new JTextField(9);


    JButton submitButton = new JButton("Submit");

    public static void main(String[] args)
    {

        try
        {
            UIManager.setLookAndFeel("com.sun.java.swing.plaf.motif.MotifLookAndFeel");

        }
        catch (Exception e)
        {
            JOptionPane.showMessageDialog(null,"The UIManager could not set the look and feel for the application.","Error",JOptionPane.INFORMATION_MESSAGE);
        }

        BillPayer f = new BillPayer();
        f.setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
        f.setSize(450,300);
        f.setTitle("Crandall Power and Light Customer Payments");
        f.setResizable(false);
        f.setLocation(200, 200);
        f.setVisible(true);
    }

    public BillPayer()
    {
        Container c = getContentPane();
        c.setLayout((new BorderLayout()));
        feildPanel.setLayout(new GridLayout(8, 1));
        FlowLayout rowSetup = new FlowLayout(FlowLayout.LEFT,5,3);
            firstRow.setLayout(rowSetup);
            secondRow.setLayout(rowSetup);
            thirdRow.setLayout(rowSetup);
            fourthRow.setLayout(rowSetup);
            fifthRow.setLayout(rowSetup);
            sixthRow.setLayout(rowSetup);
            seventhRow.setLayout(rowSetup);
            eighthRow.setLayout(rowSetup);
        buttonPanel.setLayout(new FlowLayout(FlowLayout.CENTER));


        firstRow.add(acctNumLabel);
        firstRow.add(pmtLabel);

        secondRow.add(acctNum);
        secondRow.add(pmt);

        thirdRow.add(firstNameLabel);
        thirdRow.add(lastNameLabel);


        fourthRow.add(firstName);
        fourthRow.add(lastName);

        fifthRow.add(addressLabel);

        sixthRow.add(address);

        seventhRow.add(cityLabel);
        seventhRow.add(stateLabel);
        seventhRow.add(zipLabel);

        eighthRow.add(city);
        eighthRow.add(state);
        eighthRow.add(zip);


        feildPanel.add(firstRow);
        feildPanel.add(secondRow);
        feildPanel.add(thirdRow);
        feildPanel.add(fourthRow);
        feildPanel.add(fifthRow);
        feildPanel.add(sixthRow);
        feildPanel.add(seventhRow);
        feildPanel.add(eighthRow);



        buttonPanel.add(submitButton);


        c.add(feildPanel,BorderLayout.CENTER);
        c.add(buttonPanel, BorderLayout.SOUTH);


        submitButton.addActionListener(this);


        Date today = new Date();
        SimpleDateFormat myFormat = new SimpleDateFormat("MMddyyyy");
        String filename = "payments"+myFormat.format(today);

        try
        {
            output = new DataOutputStream(new FileOutputStream(filename));
        }
        catch (IOException io)
        {
            JOptionPane.showMessageDialog(null,"The progrma could not create a stroage location. Please check the disk drive then run the program again.","Error",JOptionPane.INFORMATION_MESSAGE);

            System.exit(1);
        }

        addWindowListener(
                new WindowAdapter()
                {  @Override
                    public void windowClosing(WindowEvent e)
                    {
                        int answer = JOptionPane.showConfirmDialog(null,"Are you sure you wan to exit and submit the file?","File Submission",JOptionPane.YES_NO_OPTION);
                        if(answer == JOptionPane.YES_OPTION)
                            System.exit(0);
                    }
                }
        );
    }

    public void actionPerformed(ActionEvent e)
    {
        String arg = e.getActionCommand();

        if (checkFields())
        {
            try
            {
                output.writeUTF(acctNum.getText());
                output.writeUTF(pmt.getText());
                output.writeUTF(firstName.getText());
                output.writeUTF(lastName.getText());
                output.writeUTF(address.getText());
                output.writeUTF(city.getText());
                output.writeUTF(state.getText());
                output.writeUTF(zip.getText());

                JOptionPane.showMessageDialog(null,"The payment information has been saved.","Submission Successful", JOptionPane.INFORMATION_MESSAGE);
            }
            catch (IOException c)
            {
                System.exit(1);
            }
            clearFields();
        }
    }

    public boolean checkFields()
    {
        if (    (acctNum.getText().compareTo("")<1)     ||
                (pmt.getText().compareTo("")<1)         ||
                (firstName.getText().compareTo("")<1)   ||
                (lastName.getText().compareTo("")<1)    ||
                (address.getText().compareTo("")<1)     ||
                (city.getText().compareTo("")<1)        ||
                (state.getText().compareTo("")<1)       ||
                (zip.getText().compareTo("")<1)         )
        {
            JOptionPane.showMessageDialog(null,"You must complete all fields.","Data Entry Error",JOptionPane.WARNING_MESSAGE);
            return false;
        }
        else
        {
            return true;
        }
    }

    public void clearFields()
    {

        acctNum.setText("");
        pmt.setText("");
        firstName.setText("");
        lastName.setText("");
        address.setText("");
        city.setText("");
        state.setText("");
        zip.setText("");
        acctNum.requestFocus();
    }
}
