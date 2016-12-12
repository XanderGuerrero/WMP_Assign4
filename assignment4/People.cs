//NAME	:	    People.cs
//PROJECT :     assignment4
//Date	:	    10/10/2014
//AUTHORS	:	Alex Guerrero
//DISCRIPTION :	This People.cs file contains a public class called People.  It provides
//              an object to store data into for the program to run tests and display test results.




//references
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
    class People 
    {
        private int age;
        private string gender;
        private int id;

        //constructor initializes all private data to zero or null
        public People()
        {
            age = 0;
            gender = "\0";
            id = 0;
        }

        //SETTERS/GETTERS
        public int myAge
        {
            get { return age; }
            set { age = value; }
        }

        public string myGender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int myId
        {
            get { return id; }
            set { id = value; }
        }

        /* ---------------------------
        *	Name	:   Equals
        *
        *	Purpose :   This method overrides the equals method to compare if two objects are the same(holding the same values)  
        *
        *	Inputs	:	object obj
        *	
        *	Outputs	:	NONE
        *	Returns	:	NONE
        */
        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj != null && GetType() == obj.GetType())
            {
                People pers = (People)obj;
                result = (this.id == pers.id) && (this.age == pers.age);
            }
            return result;
        }
    
    }
}
