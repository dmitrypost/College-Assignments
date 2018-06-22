/*
	Programmer:	Daniel Wallace
	Class: 		CINS136
	Date:		October 28, 2012
	Filename:	SpeedTest.java
	Purpose:	Test compile/process speed from different IDEs
*/

public class Speedtest
{
    public static void main(String[] args)
    {
        long numLoops = 1000000000;
        long i;
        long startTime = System.currentTimeMillis();

        for(i=1;i<=numLoops;i++)
        {
            if(i % 100000000==0) System.out.println(i + " loops in " + (System.currentTimeMillis() - startTime)/1000.00 + " seconds.");
        }
    }
}