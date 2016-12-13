//NAME	:	    QueryPerfCounter.cs
//PROJECT :     assignment4
//Date	:	    10/10/2014
//AUTHORS	:	Alex Guerrero
//DESCRIPTION :	This QueryPerfCounter.cs file contains a public class called QueryPerfCounter.  It provides
//              The timer required to time the tests.

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;



//CLASS
//-------------------------
//NAME	:	QueryPerfCounter
//PURPOSE :	Creates a timer for timing method execution
//-------------------------
public class QueryPerfCounter
{
    [DllImport("KERNEL32")]
    private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

    [DllImport("Kernel32.dll")]
    private static extern bool QueryPerformanceFrequency(out long lpFrequency);

    private long start;
    private long stop;
    private long frequency;

    Decimal multiplier = new Decimal(1.0e9);

    //Constructor
    public QueryPerfCounter()
    {
        if (QueryPerformanceFrequency(out frequency) == false)
        {
            // Frequency not supported
            throw new Win32Exception();
        }
    }


    /* ---------------------------
      *	Name	:   Start
      *
      *	Purpose :   Starts the timer 
      *
      *	Inputs	:	out start
      *	
      *	Outputs	:	NONE
      *	Returns	:	NONE
      */
    public void Start()
    {
        QueryPerformanceCounter(out start);
    }


    /* ---------------------------
      *	Name	:   Stop
      *
      *	Purpose :   Stops the timer  
      *
      *	Inputs	:	out stop
      *	
      *	Outputs	:	NONE
      *	Returns	:	NONE
      */
    public void Stop()
    {
        QueryPerformanceCounter(out stop);
    }


    /* ---------------------------
      *	Name	:   Duration
      *
      *	Purpose :   Calculates the duration of time between start and stop of timer  
      *
      *	Inputs	:	int iterations
      *	
      *	Outputs	:	NONE
      *	Returns	:	NONE
      */
    public double Duration(int iterations)
    {
        return ((((double)(stop - start) * (double)multiplier) / (double)frequency) / iterations);
    }
}

