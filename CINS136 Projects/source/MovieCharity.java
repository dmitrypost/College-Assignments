/**
 * Dmitry Post
 * 10/11/2012
 * Take home programming test
 */
import javax.swing.JOptionPane;
public class MovieCharity {
    public static void main(String[] args){
        String movieName;
        String inputStr;
        String outputStr;
        double adultTicketPrice;
        double childTicketPrice;
        int noOfAdultTicketsSold;
        int noOfChildTicketsSold;
        double percetDonation;
        double grossAmount;
        double amountDonated;
        double netSaleAmount;
        movieName = JOptionPane.showInputDialog(null,"Whats the movie name?");
        adultTicketPrice = Double.parseDouble(JOptionPane.showInputDialog(null,"What is the adult ticket price?"));
        childTicketPrice = Double.parseDouble(JOptionPane.showInputDialog(null,"What is the child ticket price?"));
        noOfAdultTicketsSold = Integer.parseInt(JOptionPane.showInputDialog(null,"How many adult tickets were sold?"));
        noOfChildTicketsSold = Integer.parseInt(JOptionPane.showInputDialog(null,"How many child tickets were sold?"));
        percetDonation = Double.parseDouble(JOptionPane.showInputDialog(null,"What percet of gross amount will be donated?"));
        grossAmount = adultTicketPrice * noOfAdultTicketsSold + childTicketPrice*noOfChildTicketsSold;
        amountDonated = (grossAmount*percetDonation)/100;
        netSaleAmount = grossAmount-amountDonated;
        outputStr = "Movie Name: "+ movieName + "\n"+"Number of Tickets Sold: "+(noOfAdultTicketsSold+noOfChildTicketsSold)+"\n"+"Gross Amount: $"+String.format("%.2f",grossAmount)+"\n"+"Percent of Gross Amount Donated: "+String.format("%.2f%%",percetDonation)+"\n"+"Amount Donated: $"+ String.format("%.2f",amountDonated)+"\n"+"Net Sale: $"+String.format("%.2f",netSaleAmount);
        JOptionPane.showMessageDialog(null,outputStr);
    }
}
