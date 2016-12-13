//NAME	:	    Program.cs
//PROJECT :     assignment4
//Date	:	    10/10/2014
//AUTHORS	:	Alex Guerrero
//DESCRIPTION :	This program tests the execution time of inserting and retrieving data into a Hashtable
// 	            ArrayList, Sorted list and Dictionary




using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate lists and arrays
            UserInterface UI = new UserInterface();
            People[] copyBuffer = new People[20001];
            ArrayList timedArrayList = new ArrayList();
            Hashtable timedHashtable = new Hashtable();
            SortedList timedSortedList = new SortedList();
            Dictionary<int, People> timedDictionaryList = new Dictionary<int, People>();
            double[] listTestResults = new double[20001];
            double[] hashTestResults = new double[20001];
            double[] sortedTestResults = new double[20001];
            double[] dictionaryTestResults = new double[20001];

            Console.WriteLine("TIMED EXECUTION TESTS\n");
            //data insertion
            UI.LoadData(copyBuffer, listTestResults, hashTestResults, sortedTestResults, dictionaryTestResults, timedArrayList, timedHashtable, timedSortedList, timedDictionaryList);
            UI.CalcAvgLoadTimes(listTestResults, hashTestResults, sortedTestResults, dictionaryTestResults);
            Array.Clear(listTestResults, 0, listTestResults.Length);
            Array.Clear(hashTestResults, 0, hashTestResults.Length);
            Array.Clear(sortedTestResults, 0, sortedTestResults.Length);
            Array.Clear(dictionaryTestResults, 0, dictionaryTestResults.Length);

            //Single item retrieval
            UI.RetrieveSingleItem(copyBuffer, listTestResults, hashTestResults, sortedTestResults, dictionaryTestResults, timedArrayList, timedHashtable, timedSortedList, timedDictionaryList);
            UI.CalcAvgSingleItemSearchTime(listTestResults, hashTestResults, sortedTestResults, dictionaryTestResults);
            Array.Clear(listTestResults, 0, listTestResults.Length);
            Array.Clear(hashTestResults, 0, hashTestResults.Length);
            Array.Clear(sortedTestResults, 0, sortedTestResults.Length);
            Array.Clear(dictionaryTestResults, 0, dictionaryTestResults.Length);

            //block of items retrieval
            //search for all males, time the length of time taken to get all data back
            UI.RetrieveBlockOfItem(copyBuffer, listTestResults,  hashTestResults,  sortedTestResults,  dictionaryTestResults, timedArrayList, timedHashtable,  timedSortedList, timedDictionaryList);
            Array.Clear(listTestResults, 0, listTestResults.Length);
            Array.Clear(hashTestResults, 0, hashTestResults.Length);
            Array.Clear(sortedTestResults, 0, sortedTestResults.Length);
            Array.Clear(dictionaryTestResults, 0, dictionaryTestResults.Length);
            Console.ReadKey();

        }
    }
}
