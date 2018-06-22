// Dmitry Post
// 10/11/2012
// Programming take home test
import javax.swing.JOptionPane;
public class CableCompanyBilling {
public static void main(String[] args){
    // variables
    int accountNumber;
    int numOfPremChannels;
    int numOfBasicServConn;
    double amountDue;
    final double RES_BILL_PROC_FEES = 4.50;
    final double RES_BASIC_SERV_COST = 20.50;
    final double RES_COST_PREM_CHANNEL = 7.50;
    final double BUS_BILL_PROC_FEES = 15.00;
    final double BUS_BASIC_SERV_COST = 75.00;
    final double BUS_BASIC_CONN_COST = 5.00;
    final double BUS_COST_PREM_CHANNEL = 50.00;
    String[] options = {"Residential", "Business"};
    //get account number
    accountNumber = Integer.parseInt(JOptionPane.showInputDialog(null,"Enter account number"));
    //get customer type
    int response=JOptionPane.showOptionDialog(null, "What type of customer?", "Customer Type", JOptionPane.YES_NO_OPTION, JOptionPane.PLAIN_MESSAGE, null, options, null);
    switch (response)
    {
    case 0: // Residential
	// get premium channels
	numOfPremChannels = Integer.parseInt(JOptionPane.showInputDialog(null,"Enter number of basic service connections"));
	// compute amount due
	amountDue = RES_BILL_PROC_FEES + RES_BASIC_SERV_COST + numOfPremChannels * RES_COST_PREM_CHANNEL;
	// show output
	JOptionPane.showMessageDialog(null,"The account number is: " + accountNumber + "\nThe amount due is: $"+ String.format("%.2f",amountDue));
	break;
    case 1: // Buisness
	// get basic channels
	numOfBasicServConn = Integer.parseInt(JOptionPane.showInputDialog(null,"Enter number of basic service connections"));
	// get premium channels
	numOfPremChannels = Integer.parseInt(JOptionPane.showInputDialog(null,"Enter number of premium channels"));
	if (numOfBasicServConn<=10) // computer amount due depending on basic channel amount
	{
	amountDue = BUS_BILL_PROC_FEES + BUS_BASIC_SERV_COST + numOfPremChannels * BUS_COST_PREM_CHANNEL;
	}
	else
	{
	amountDue = BUS_BILL_PROC_FEES + BUS_BASIC_SERV_COST + (numOfBasicServConn=10) * BUS_BASIC_CONN_COST + numOfPremChannels * BUS_COST_PREM_CHANNEL;
	// show output
	JOptionPane.showMessageDialog(null,"The account number is: " + accountNumber + "\nThe amount due is: $"+ String.format("%.2f",amountDue));
	}
	break;
    }
  }
}
