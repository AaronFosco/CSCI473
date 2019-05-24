/*
  _______________________________________________________________
 /                                                               \
||  Course: CSCI-473    Assignment #: 2    Semester: Fall 2018   ||
||                                                               ||
||  NAME1:  Aaron Fosco                    Z-ID: z1835687        ||
||                                                               ||
||  NAME2:  Marco Martinez                 Z-ID: z1767068        ||
||                                                               ||
||  TA's Name: Shivasupraj Pasham                                ||
||                                                               ||
||  Due: Thursday 9/27/2018 by 11:59PM                           ||
||                                                               ||
||  Description:                                                 ||
||   This file contains data for the Student class. This class   ||
||   Implements the IComparable interface to allow sorting by    ||
||   Zid (a property of this class). There are other functions   ||
||   such as Enrolling or dropping a student from a course.      ||
 \_______________________________________________________________/
*/

using System;


namespace Assign2
{
    class Student : IComparable
    {
        //Private attributes
        readonly uint zid;
        private string firstName, lastName, major;
        private float gpa;
        private ushort credHours;

        public enum Year { Freshman, Sophomore, Junior, Senior, PostBacc };
        private Year academicYear;

        //public Properties
        public Year AcademicYear
        {
            get { return academicYear; }
            set { academicYear = value;  }
        }
        
        public uint Zid { get { return zid; } }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Major
        {
            get { return major; }
            set { major = value; }
        }

        public float Gpa
        {
            get { return gpa; }
            set
            {
                if (value > 4.0)
                    gpa = 4;
                else if (value < 0)
                    gpa = 0;
                else
                    gpa = value;
            }
        }

        ushort CredHours
        {
            get { return credHours; }
            set
            {
                if (value > 18)
                    credHours = 18;
                else if (value < 0)
                    credHours = 0;
                else
                    credHours = value;
            }
        }

        /* -------------------------------------------------------------------------------
        * Function: CompareTo
        * 
        * Use: Used by the IComparable interface; Compairs student's zid
        * 
        * Parameters: alpha: a Student object to compair IDs with
        * 
        * Returns: -1: If First zid was less than the second
        *           0: If Both zids were the same
        *           1: If First zid was greater than the second
        * -------------------------------------------------------------------------------*/

        public int CompareTo(object alpha)
        {
            Student beta = alpha as Student;

            int rv = 0;
            if (Zid < beta.Zid)
                rv = -1;
            else if (zid > beta.Zid)
                rv = 1;

            return rv;
        }
        /* -------------------------------------------------------------------------------
         * Constructor: Student
         * 
         * Use: Default constructor for Students; Assigns values to each property
         * 
         * Parameters: none
         * -------------------------------------------------------------------------------*/

        public Student()
        {
            FirstName = "\0";
            LastName = "\0";
            Major = "\0";
            AcademicYear = 0;
            Gpa = 0;
            zid = 0;
        }

        /* -------------------------------------------------------------------------------
         * Constructor: Student
         * 
         * Use: Initalizes Student with all of it's properties set.
         * 
         * Parameters: ConZid: The Zid of the student
         *             ConFirstName: The First Name of the student
         *             ConLastName: The Last name of the student
         *             ConMajor: The major of the student 
         *             ConYear: The student's current year
         *             Congpa: The student's current GPA
         *-------------------------------------------------------------------------------*/

        public Student(uint ConZid, string ConLastName, string ConFirstName, string ConMajor, uint ConYear, float Congpa)
        {
            FirstName = ConFirstName;
            LastName = ConLastName;
            Major = ConMajor;
            AcademicYear = (Year)ConYear;
            Gpa = Congpa;

            if (ConZid < 1000000)
                zid = 0;
            else
                zid = ConZid;

        }

        /* -------------------------------------------------------------------------------
         * Function: Enroll
         * 
         * Use: Allows a student to Enroll in a new class by placing thier zid in the 
         *      Roster & updating the Student cound for the class
         * 
         * Parameters: NewCourse: A course that the student will enroll into
         * 
         * Returns: 5: If the Course is full
         *          10: If the Student is already enrolled
         *          15: If the ammount of credit hours for the course would put the
         *              student over the limit
         * -------------------------------------------------------------------------------*/

        public int Enroll(Course NewCourse)
        {
            int rv = 0;
            if (NewCourse.NoEnrolledStudents >= NewCourse.MaxCapacity)
                rv = 5;
            else if (NewCourse.FindZid(Zid))
                rv = 10;
            else if ((NewCourse.CreditHours + CredHours) >= 18)
                rv = 15;
            else
            {
                CredHours += NewCourse.CreditHours;
                NewCourse.EnrolledZid.Add(this.Zid);
                NewCourse.NoEnrolledStudents++;
            }
            return rv;
        }

        /* -------------------------------------------------------------------------------
         * Function: Drop
         * 
         * Use: Drops a Student from a Course
         * 
         * Parameters: OldCourse: The course that the student needs to be droped from
         * 
         * Returns: 0: If successful
         *          20: If the student wasn't found in the course
         * -------------------------------------------------------------------------------*/

        public int Drop(Course OldCourse)
        {
            int rv = 0;
            int FoundIndex = OldCourse.EnrolledZid.FindIndex(MatchZid => MatchZid == Zid);
            if (FoundIndex == -1)
                rv = 20;
            else
            {
                OldCourse.EnrolledZid.RemoveAt(FoundIndex);
                CredHours -= OldCourse.CreditHours;
                OldCourse.NoEnrolledStudents--;
            }
            return rv;
        }

        /* -------------------------------------------------------------------------------
         * Function: ToString, Override from Object
         * 
         * Use: Neatly formats the Zid, Last Name, First Name, Academic Year,
         *      Major, and GPA for easy outputting
         * 
         * Parameters: none
         * 
         * Returns: A String of the Zid, Last Name, First Name, Academic Year,
         *          Major, and GPA of the student.
         * -------------------------------------------------------------------------------*/

        public override string ToString()
        {
            string rv = String.Format("z{0} -- {1,12}, {2,-12} [{3,9}] <{4}> | {5:0.000} |", Zid, LastName, FirstName, AcademicYear, Major, gpa);
            return rv;
        }
    }


}