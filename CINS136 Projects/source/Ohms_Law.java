import javax.swing.*;
import java.awt.*;
import java.awt.event.*;


/**
 * Programmer: Dmitry Post
 * Date: 11/2/12
 * Time: 10:12 AM
 * Extra Credit p. 215
 */
public class Ohms_Law  extends Frame implements ActionListener
{
    double V;   //voltage
    double R;   //ohms
    double I;   //amps
    JLabel voltagelabel = new JLabel("Voltage:       ");
    JLabel resistancelabel = new JLabel("Resistance:");
    JTextField voltage = new JTextField(5);
    JTextField resistance = new JTextField(5);
    JLabel ampslabel = new JLabel("AMPS:              ");
    Panel firstRow = new Panel();
    Panel secondRow = new Panel();
    Panel thirdRow = new Panel();
    Button calculate = new Button("Calculate");
    Panel dataFields = new Panel();


    public static void main(String[] args)
    {
        Ohms_Law window = new Ohms_Law();
        window.setTitle("OHM's Law");
        window.setSize(250, 150);
        window.setVisible(true);
    }


    public Ohms_Law()
    {
        setLayout(new BorderLayout());
        dataFields.setLayout(new GridLayout(6,1));
        FlowLayout rowSetup = new FlowLayout(FlowLayout.LEFT,5,2);
        firstRow.setLayout(rowSetup);
        secondRow.setLayout(rowSetup);
        thirdRow.setLayout(rowSetup);

        firstRow.add(voltagelabel);
        firstRow.add(voltage);

        secondRow.add(resistancelabel);
        secondRow.add(resistance);

        thirdRow.add(ampslabel);
        thirdRow.add(calculate);

        dataFields.add(firstRow);
        dataFields.add(secondRow);
        dataFields.add(thirdRow);

        calculate.addActionListener(this);
        add(dataFields, BorderLayout.NORTH);

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
        V = Double.valueOf(voltage.getText().toString());
        R = Double.valueOf(resistance.getText().toString());
        I = V/R;
        ampslabel.setText("AMPS:  "+  I   );
    }
}
