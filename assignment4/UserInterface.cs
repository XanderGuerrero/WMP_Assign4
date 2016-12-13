//NAME	:	    UserInterface.cs
//PROJECT :     assignment4
//Date	:	    10/10/2014
//AUTHORS	:	Alex Guerrero
//DESCRIPTION :	This UserInterface.cs file contains a public class called UserInterface.  It provides
//              a data access layer for the program to run tests and display test results.




//references
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




//CLASS
//-------------------------
//NAME	:	UserInterface
//PURPOSE :	This class provides a data access layer for the program to run tests and display test results.
//          UserInterface also contains methods that run each test to load all data, load single item, load block of items and sort
//-------------------------
namespace assignment4
{
    class UserInterface
    {
        /* ---------------------------
    *	Name	:   LoadData
    *
    *	Purpose :   Loads 20 000 People into each type of list (hash, array, sorted, dictionary) and times the execution.  Each iteration 
    *	            is timed and placed into an element in the array.  
    *
    *	Inputs	:	People[] copyBuffer, double[] listTestResults, double[] hashTestResults, double[] sortedTestResults, 
    *	            double[] dictionaryTestResults, ArrayList timedArrayList, Hashtable timedHashtable, SortedList timedSortedList, 
    *               Dictionary<int, People> timedDictionaryList
    *               
    *	Outputs	:	NONE	
    *	Returns	:	NONE
    */
        public void LoadData(People[] copyBuffer, double[] listTestResults, double[] hashTestResults, double[] sortedTestResults, double[] dictionaryTestResults, ArrayList timedArrayList, Hashtable timedHashtable, SortedList timedSortedList, Dictionary<int, People> timedDictionaryList)
        {
            //UserInterface UI = new UserInterface();
            QueryPerfCounter myTimer = new QueryPerfCounter();
            People testPerson;
            RandomAgeGender randomA = new RandomAgeGender();
            double hashTime = 0;
            double arrayTime = 0;
            double sortedTime = 0;
            double dictionaryTime = 0;
            int count = 1;
            int arrayCount = 0;
            int gender = 0;

            //loop 20000 times, add data to each list and time each execution
            for (int i = 0; i <= 19999; ++i)
            {
                testPerson = new People();

                testPerson.myId = count;
                testPerson.myAge = randomA.returnAge();
                gender = randomA.returnGender();

                if (gender == 1)
                {
                    testPerson.myGender = "m";
                }
                else
                {
                    testPerson.myGender = "f";
                }


                //load data into tables
                //arraylist
                myTimer.Start();
                timedArrayList.Add(testPerson);
                myTimer.Stop();
                // Calculate time per iteration in nanoseconds
                arrayTime = myTimer.Duration(count);
                listTestResults[count] = arrayTime;

                //hashtable
                myTimer.Start();
                timedHashtable.Add(testPerson.myId, testPerson);
                myTimer.Stop();
                // Calculate time per iteration in nanoseconds
                hashTime = myTimer.Duration(count);
                hashTestResults[count] = hashTime;

                //sortedList
                myTimer.Start();
                timedSortedList.Add(testPerson.myId, testPerson);
                myTimer.Stop();
                // Calculate time per iteration in nanoseconds
                sortedTime = myTimer.Duration(count);
                sortedTestResults[count] = sortedTime;

                //dictionary
                myTimer.Start();
                timedDictionaryList.Add(testPerson.myId, testPerson);
                myTimer.Stop();
                // Calculate time per iteration in nanoseconds
                dictionaryTime = myTimer.Duration(count);
                dictionaryTestResults[count] = dictionaryTime;

                //make a copy of the list to reference later
                copyBuffer[arrayCount] = testPerson;
                //increment variables
                ++arrayCount;
                ++count;
                if (i == 19999)
                {
                    break;
                }
            }
        }




        /* ---------------------------
        *	Name	:   CalcAvgLoadTimes
        *
        *	Purpose :   Calculate the average time taken to load one object into each type of list .  
        *
        *	Inputs	:	double[] listTestResults, double[] hashTestResults, double[] sortedTestResults, double[] dictionaryTestResults
        *	
        *	Outputs	:	Test results to the screen	
        *	Returns	:	NONE
        */
        public void CalcAvgLoadTimes(double[] listTestResults, double[] hashTestResults, double[] sortedTestResults, double[] dictionaryTestResults)
        {
            double finalResults = 0;

            Console.WriteLine("Average data insertion time per object after 20 000 iterations:\n");

            //LOAD TIME TEST RESULTS AVERAGED
            //arraylist testresults
            //running total of all the times in the array
            for (int i = 0; i < listTestResults.Count(); ++i)
            {
                finalResults = finalResults + listTestResults[i];
            }
            //calculate average and display to user
            finalResults = finalResults / 20000;
            Console.WriteLine("ArrayList:   {0}", finalResults);
            finalResults = 0;
          

            //hashtable results
            //running total of all the times in the array
            for (int i = 0; i < hashTestResults.Count(); ++i)
            {
                finalResults = finalResults + hashTestResults[i];
            }
            //calculate average and display to user
            finalResults = finalResults / 20000;
            Console.WriteLine("HashTable:   {0}", finalResults);
            finalResults = 0;
           

            //sorted list results
            //running total of all the times in the array
            for (int i = 0; i < sortedTestResults.Count(); ++i)
            {
                finalResults = finalResults + sortedTestResults[i];
            }
            //calculate average and display to user
            finalResults = finalResults / 20000;
            Console.WriteLine("SortedList:  {0}", finalResults);
            finalResults = 0;
            

            //dictionary list results
            //running total of all the times in the array
            for (int i = 0; i < dictionaryTestResults.Count(); ++i)
            {
                finalResults = finalResults + dictionaryTestResults[i];
            }
            //calculate average and display to user
            finalResults = finalResults / 20000;
            Console.WriteLine("Dictionary:  {0}", finalResults);
            finalResults = 0;
            Console.WriteLine("\n");
        }



        /* ---------------------------
        *	Name	:   RetrieveSingleItem
        *
        *	Purpose :   Time the execution of the retrieval of a randomly chosen object 10 000 in each type of list
        *
        *	Inputs	:	People[] copyBuffer, double[] listTestResults, double[] hashTestResults, double[] sortedTestResults, 
        *	            double[] dictionaryTestResults, ArrayList timedArrayList, Hashtable timedHashtable, SortedList timedSortedList, 
        *               Dictionary<int, People> timedDictionaryList
        *	Outputs	:	NONE
        *	Returns	:	NONE
        */
        public void RetrieveSingleItem(People[] copyBuffer, double[] listTestResults, double[] hashTestResults, double[] sortedTestResults, double[] dictionaryTestResults, ArrayList timedArrayList, Hashtable timedHashtable, SortedList timedSortedList, Dictionary<int, People> timedDictionaryList)
        {
            QueryPerfCounter myTimer = new QueryPerfCounter();
            Random number = new Random();
            People compare = new People();
            People perInList = new People();
            int randNumber = 0;
            double hashTime = 0;
            double arrayTime = 0;
            double sortedTime = 0;
            double dictionaryTime = 0;
            int iterations = 1;

            //loop 10 000 times, each time randomly choose a key value and search for it.
            //Time the start of the search to the point where the key is located
            for (int i = 0; i <= 10000; ++i)
            {
                //arrayList
                randNumber = number.Next(1, 10001);
                compare = copyBuffer[randNumber];
                myTimer.Start();
                if (timedArrayList[randNumber].Equals(compare))
                {
                    myTimer.Stop();
                }
                else
                {
                    Console.WriteLine("not equal");
                }
                randNumber = 0;
                //place time into element of the array
                arrayTime = myTimer.Duration(iterations);
                listTestResults[i] = arrayTime;

                //hashtable
                randNumber = number.Next(1, 10001);
                compare = copyBuffer[randNumber - 1];
                myTimer.Start();
                if (timedHashtable[randNumber].Equals(compare))
                {
                    myTimer.Stop();

                }
                else
                {
                    Console.WriteLine("not equal");
                }
                randNumber = 0;
                //place time into element of the array
                hashTime = myTimer.Duration(iterations);
                hashTestResults[i] = hashTime;

                //SortedList
                randNumber = number.Next(1, 10001);
                compare = copyBuffer[randNumber - 1];
                myTimer.Start();
                if (timedSortedList[randNumber].Equals(compare))
                {
                    myTimer.Stop();
                }
                else
                {
                    Console.WriteLine("not equal");
                }
                randNumber = 0;
                //place time into element of the array
                sortedTime = myTimer.Duration(iterations);
                sortedTestResults[i] = sortedTime;

                //Dictionary
                randNumber = number.Next(1, 10001);
                compare = copyBuffer[randNumber - 1];
                myTimer.Start();
                if (timedDictionaryList[randNumber].Equals(compare))
                {
                    myTimer.Stop();
                }
                else
                {
                    Console.WriteLine("not equal");
                }
                randNumber = 0;
                //place time into element of the array
                dictionaryTime = myTimer.Duration(iterations);
                dictionaryTestResults[i] = dictionaryTime;
            }
        }



        /* ---------------------------
        *	Name	:   CalcAvgSingleItemSearchTime
        *
        *	Purpose :   Calculate the average time it takes to search for one item in each type of list 
        *
        *	Inputs	:	double[] listTestResults, double[] hashTestResults, double[] sortedTestResults, double[] dictionaryTestResults
        *	
        *	Outputs	:	Test results to the screen	
        *	Returns	:	NONE
        */
        public void CalcAvgSingleItemSearchTime(double[] listTestResults, double[] hashTestResults, double[] sortedTestResults, double[] dictionaryTestResults)
        {
            double finalResults = 0;

            Console.WriteLine("Average single item search time after 10 000 iterations:\n");
           
            
            //LOAD TIME TEST RESULTS AVERAGED
            //arraylist testresults
            //running total of time taken to search for one item
            for (int i = 0; i < listTestResults.Count(); ++i)
            {
                finalResults = finalResults + listTestResults[i];
            }
            //calculate average display to user
            finalResults = finalResults / 10000;
            Console.WriteLine("ArrayList:   {0}", finalResults);
            finalResults = 0;        

            //hashtable results           
            //running total of time taken to search for one item
            for (int i = 0; i < hashTestResults.Count(); ++i)
            {
                finalResults = finalResults + hashTestResults[i];
            }
            //calculate average display to user
            finalResults = finalResults / 10000;
            Console.WriteLine("HashTable:   {0}", finalResults);
            finalResults = 0;


            //sorted list results         
            //running total of time taken to search for one item
            for (int i = 0; i < sortedTestResults.Count(); ++i)
            {
                finalResults = finalResults + sortedTestResults[i];
            }
            //calculate average display to user
            finalResults = finalResults / 10000;
            Console.WriteLine("SortedList:  {0}", finalResults);
            finalResults = 0;


            //dictionary list results
            //running total of time taken to search for one item
            for (int i = 0; i < dictionaryTestResults.Count(); ++i)
            {
                finalResults = finalResults + dictionaryTestResults[i];
            }
            //calculate average display to user
            finalResults = finalResults / 10000;
            Console.WriteLine("Dictionary:  {0}", finalResults);
            finalResults = 0;
            Console.WriteLine("\n");
        }




        /* ---------------------------
        *	Name	:   RetrieveBlockOfItem
        *
        *	Purpose :   Time the retrieval of a block of related items and display reults to the user
        *
        *	Inputs	:	People[] copyBuffer, double[] listTestResults, double[] hashTestResults, double[] sortedTestResults, 
        *	            double[] dictionaryTestResults, ArrayList timedArrayList, Hashtable timedHashtable, SortedList timedSortedList, 
        *               Dictionary<int, People> timedDictionaryList
        *               
        *	Outputs	:	NONE
        *	Returns	:	NONE
        */
        public void RetrieveBlockOfItem(People[] copyBuffer, double[] listTestResults, double[] hashTestResults, double[] sortedTestResults, double[] dictionaryTestResults, ArrayList timedArrayList, Hashtable timedHashtable, SortedList timedSortedList, Dictionary<int, People> timedDictionaryList)
        {
            QueryPerfCounter myTimer = new QueryPerfCounter();
            Random number = new Random();
            People compare = new People();
            People perInList = new People();
            double hashTime = 0;
            double arrayTime = 0;
            double sortedTime = 0;
            double dictionaryTime = 0;
            int iterations = 1;
            int numberOfFemales = 0;
            int numberOfMales = 0;

            //arrayList
            //time execution
            myTimer.Start();
            for (int i = 0; i <= timedArrayList.Count - 1; ++i)
            {
                compare = (People)timedArrayList[i];
                if (compare.myGender.Equals("f"))
                {                    
                    ++numberOfFemales;
                }
                else
                {
                    ++numberOfMales;
                }         
            }
            myTimer.Stop();
            //store value reset counters
            arrayTime = myTimer.Duration(iterations);
            listTestResults[0] = arrayTime;
            numberOfFemales = 0;
            numberOfMales = 0;

            //hashtable
            //time execution
            myTimer.Start();
            for (int i = 0; i <= timedHashtable.Count - 1; ++i)
            {
                compare = (People)timedHashtable[i + 1];
                if (compare.myGender.Equals("f"))
                {
                    ++numberOfFemales;
                }
                else
                {
                    ++numberOfMales;
                }
            }
            myTimer.Stop();
            //store value reset counters
            hashTime = myTimer.Duration(iterations);
            hashTestResults[0] = hashTime;
            numberOfFemales = 0;
            numberOfMales = 0;
            
            //SortedList
            //time execution
            myTimer.Start();
            for (int i = 0; i <= timedSortedList.Count - 1; ++i)
            {
                compare = (People)timedSortedList[i+1];
                if (compare.myGender.Equals("f"))
                {
                    ++numberOfFemales;
                }
                else
                {
                    ++numberOfMales;
                }
            }
            myTimer.Stop();
            //store value reset counters
            sortedTime = myTimer.Duration(iterations);
            sortedTestResults[0] = sortedTime;
            numberOfFemales = 0;
            numberOfMales = 0;
            
            //Dictionary
            //time execution
            myTimer.Start();
            for (int i = 0; i <= timedDictionaryList.Count - 1; ++i)
            {
                compare = (People)timedDictionaryList[i+1];
                if (compare.myGender.Equals("f"))
                {
                    ++numberOfFemales;
                }
                else
                {
                    ++numberOfMales;
                }
            }
            myTimer.Stop();
            //store value reset counters
            dictionaryTime = myTimer.Duration(iterations);
            dictionaryTestResults[0] = dictionaryTime;
            numberOfFemales = 0;
            numberOfMales = 0;

            //display test results to user
            Console.WriteLine("Execution time of retrieving a block of items: \n");
            Console.WriteLine("ArrayList:   {0}", listTestResults[0]);
            Console.WriteLine("HashTable:   {0}", hashTestResults[0]);
            Console.WriteLine("SortedList:  {0}", sortedTestResults[0]);
            Console.WriteLine("Dictionary:  {0}", dictionaryTestResults[0]);
            
        }
    }
}
