//NAME	:	    RandomAgeGender.cs
//PROJECT :     assignment4
//Date	:	    10/10/2014
//AUTHORS	:	Alex Guerrero
//DISCRIPTION :	This RandomAgeGender.cs file contains a public class called RandomAgeGender.  It implements
//              methods to create random values of ints




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//CLASS
//-------------------------
//NAME	:	People
//PURPOSE :	This object stores an id, age and gender.  This object will used to test fata insertion and retrieval execution times.
//-------------------------
namespace assignment4
{
    class RandomAgeGender
    {
        Random calcAge;
        Random calcGender;


        //constructor initializes new random object to return values
        public RandomAgeGender()
        {
            calcAge = new Random();
            calcGender = new Random();
        }



        /* ---------------------------
         *	Name	:   returnAge
         *
         *	Purpose :   Returns random value bewteen 1 and 110  
         *
         *	Inputs	:	NONE
         *	
         *	Outputs	:	NONE
         *	Returns	:	NONE
         */
        public Int32 returnAge()
        {
            return calcAge.Next(1, 111);
        }



        /* ---------------------------
         *	Name	:   returnGender
         *
         *	Purpose :   Returns random value bewteen 1 and 2  
         *
         *	Inputs	:	NONE
         *	
         *	Outputs	:	NONE
         *	Returns	:	NONE
         */
        public Int32 returnGender()
        {
            return calcGender.Next(1, 3);
        }

    }
}
