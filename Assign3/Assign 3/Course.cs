/*
  _______________________________________________________________
 /                                                               \
||  Course: CSCI-473    Assignment #: 3    Semester: Fall 2018   ||
||                                                               ||
||  NAME1:  Aaron Fosco                    Z-ID: z1835687        ||
||                                                               ||
||  NAME2:  Marco Martinez                 Z-ID: z1767068        ||
||                                                               ||
||  TA's Name: Shivasupraj Pasham                                ||
||                                                               ||
||  Due: Thursday 10/11/2018 by 11:59PM                          ||
||                                                               ||
||  Description:                                                 ||
||     This file contains data for the Course class. This class  ||
||     Implements the IComparable interface and allows for       ||
||     sorting by DepartCode & CourseNo (both properties of      ||
||     This class). There are other functions Such as seeing     ||
||     what students are enrolled in a specific course and       ||
||     displaying results of the like.                           ||
 \_______________________________________________________________/
*/
using System;
using System.Collections.Generic;
using System.IO;


namespace Assign3
{
    class Course : IComparable
    {
        //noEnrolledStudents - number of students currently enrolled
        //max capacity - max cap of student enrollment
        private ushort creditHours, noEnrolledStudents, maxCapacity;

        //the course number
        private uint courseNo;

        //Auto generated Attributes for 2 properties.
        public string DepartCode { get; set; }
        public string SectNo { get; set; }

        //Public Properties 
        public uint CourseNo
        {
            get { return courseNo; }
            set { courseNo = value; }
        }

        public ushort CreditHours
        {
            get { return creditHours; }
            set { creditHours = value; }
        }

        public ushort NoEnrolledStudents
        {
            get { return noEnrolledStudents; }
            set { noEnrolledStudents = value; }
        }

        public ushort MaxCapacity
        {
            get { return maxCapacity; }
            set { maxCapacity = value; }
        }

        public List<uint> EnrolledZid = new List<uint>();

        /* -------------------------------------------------------------------------------
        * Function:
        * 
        * Use: Used by the IComparable interface; Compairs Course's 
        *      Department code and Course number
        * 
        * Parameters: alpha: A Course object to compair course department code/numbers with
        * 
        * Returns: -1: Department code of the first course was less than the second
        *              or department code was the same, but course number of the first
        *              was less than the second course number
        *              
        *           0: Both Department code & Course numbers were the same
        *           
        *           1: Department code of the first course was greater than the second
        *              or department code was the same, but course number of the first
        *              was greater than the second course number
        * -------------------------------------------------------------------------------*/

        public int CompareTo(object alpha)
        {
            Course beta = alpha as Course;
            int rv = 0;
            if (String.Compare(DepartCode, beta.DepartCode) < 0)
                rv = -1;
            else if (String.Compare(DepartCode, beta.DepartCode) > 0)
                rv = 1;
            else
            {
                if (CourseNo < beta.CourseNo)
                    rv = -1;
                else if (CourseNo > beta.CourseNo)
                    rv = 1;
            }
            return rv;
        }

        /* -------------------------------------------------------------------------------
        * Function: FindZid
        * 
        * Use: Iterates Through Every student's zid that is enrolled in this class to
        *      check and see If a certain student is enrolled
        * 
        * Parameters: Zid: student's zid to look for 
        * 
        * Returns: True: If the Zid was found
        *          False: if the Zid was not found
        * -------------------------------------------------------------------------------*/

        public bool FindZid(uint Zid)
        {
            bool rv = false;
            foreach (uint x in EnrolledZid)
            {
                if (x == Zid)
                    rv = true;
            }
            return rv;
        }


        /* -------------------------------------------------------------------------------
        * Constructor: Course
        * 
        * Use: Default constructor for Course; Assigns values to each property.
        * 
        * Parameters: None
        * -------------------------------------------------------------------------------*/

        public Course()
        {
            DepartCode = "\0";
            CourseNo = 0;
            SectNo = "\0";
            CreditHours = 0;
            MaxCapacity = 0;
        }

        /* -------------------------------------------------------------------------------
        * Constructor: Course
        * 
        * Use: Initalizes Course with all of it's properties set
        * 
        * Parameters: ConDepartCode: Course's Department code
        *             ConCourseNo: Course's course number
        *             ConCreditHours: Course's Section number 
        *             ConMaxCapacity: Course's max capacity
        * -------------------------------------------------------------------------------*/

        public Course(string ConDepartCode, uint ConCourseNo, string ConSectNo, ushort ConCreditHours, ushort ConMaxCapacity)
        {
            DepartCode = ConDepartCode;
            CourseNo = ConCourseNo;
            SectNo = ConSectNo;
            CreditHours = ConCreditHours;
            MaxCapacity = ConMaxCapacity;
        }

        /* -------------------------------------------------------------------------------
        * Function: PrintRoster
        * 
        * Use: Prints the full roster of all students enrolled in a class
        * 
        * Parameters: none
        * 
        * Returns: A string 
        * -------------------------------------------------------------------------------*/

        public string[] PrintRoster()
        {
            string[] returnStringArr = new string[10 + EnrolledZid.Count];
            
            //Put the first two Entries in the return array
            returnStringArr[0] = ("Course: " + this.ToString());
            returnStringArr[1] = ("--------------------------------------------------------");

            //start the return array index at two.
            int returnStringIndex = 2;

            int IndexHolder = 0;
            foreach (uint x in EnrolledZid)
            {
                //Using a lambda expression to find a matching zid in the global list of students "StudentList",
                //and using "FindIndex" to obtain it's given index.
                IndexHolder = Program.StudentList.FindIndex(SearchStudent => SearchStudent.Zid == x);
                returnStringArr[returnStringIndex] = (String.Format("z{0}{1,12}, {2,-12}{3}",
                                                      x,
                                                      Program.StudentList[IndexHolder].LastName,
                                                      Program.StudentList[IndexHolder].FirstName,
                                                      Program.StudentList[IndexHolder].Major));
                returnStringIndex++;
            }
            return returnStringArr;
        }

        /* -------------------------------------------------------------------------------
         * Function: ToString, Override from Object
         * 
         * Use: Neatly formats the Department Code, Course Number, Section Number,
         *      Number of Enrolled Students, and Max Capacity for easy outputting
         * 
         * Parameters: none
         * 
         * Returns: A String of the Department Code, Course Number, Section Number,
         *          Number of Enrolled Students, and Max Capacity of the Course.
         * -------------------------------------------------------------------------------*/

        public override string ToString()
        {
            return String.Format("{0} {1}-{2} ({3}/{4})", DepartCode, CourseNo, SectNo, NoEnrolledStudents, MaxCapacity);
        }

    }
}
