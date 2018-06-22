public class Window extends java.awt.Frame
{

    public Window()
    {
	addWindowListener(new java.awt.event.WindowAdapter()
	{
            public void windowClosing(java.awt.event.WindowEvent evt)
	    {
                System.exit(0);
            }
        });

        pack();
    }

    public static void main(String args[])
    {
	java.awt.EventQueue.invokeLater(new Runnable()
	{
	    public void run() {
		new Window().setVisible(true);
	    }
	});
    }
}
