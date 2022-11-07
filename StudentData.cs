using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_for_the_first_time
{
    internal class StudentData
    {///private member fields
        private string _name;
        private int _grade;

        //public Accesors & Mutators
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 0)
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Invalid name.");   ///this is our custom exception message
                }

            }

        }///end of Name
        public int Grade
        {
            get { return _grade; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _grade = value;
                }
                else
                {
                    throw new Exception("Invalid grade.");
                }

            }
        }///endo of Grade

            ///constructors
            ///
            ///empty constructor
            public StudentData()
        {
            Name = "Wonder Woman";
            Grade = 100;

        }

        ///greedy constructor
        public StudentData(string name, int grade)
        {
            Name = name;
            Grade = grade;
        }
        
        //Class Methods
        public override string ToString()
        {
            return $"Name: {Name} \tGrade: {Grade}";    ///override makes it so this method returns what WE WANT 
        }



    }
}

