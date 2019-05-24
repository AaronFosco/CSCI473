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
||   This is the main file containing the main routine. This     ||
||   program will read student, course, and Major data from      ||
||   three files to populate 2 Lists and 1 array then generates  ||
||   a windows form that is populated with the read data.        ||
 \_______________________________________________________________/
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static List<Student> StudentList = new List<Student>();
        public static List<Course> CourseList = new List<Course>();
        public static string[] majorArray;
        public static string[] DepartmentArray = { "CSCI", "MATH", "STAT", "ART", "ANTH", "THEA", "PSYC", "PSYS", "CHEM", "MKTG", "MUSE", "FLGL", "BIOS", "ECON" };
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //moving Application.Run(new Form1()); inside the try/catch block
            //and moreso after the files were read correctly

            string holdline;
            string[] splited;

            try
            {
                using (StreamReader inFile = new StreamReader("..\\..\\StudentInput.txt")) //throws System.IO.FileNotFoundException
                {
                    while (!inFile.EndOfStream)
                    {
                        holdline = inFile.ReadLine();
                        splited = holdline.Split(',');
                        StudentList.Add(new Student(uint.Parse(splited[0]), splited[1], splited[2], splited[3], uint.Parse(splited[4]), float.Parse(splited[5])));
                    }
                }

                StudentList.Sort();

                //relative path and reading course file
                using (StreamReader inFile = new StreamReader("..\\..\\CourseInput.txt")) //throws System.IO.FileNotFoundException
                {
                    while (!inFile.EndOfStream)
                    {
                        holdline = inFile.ReadLine();
                        splited = holdline.Split(',');
                        CourseList.Add(new Course(splited[0], uint.Parse(splited[1]), splited[2], ushort.Parse(splited[3]), ushort.Parse(splited[4])));
                    }
                }

                CourseList.Sort();

                using (StreamReader inFile = new StreamReader("..\\..\\MajorInput.txt")) //throws System.IO.FileNotFoundException
                {
                    List<string> MajorList = new List<string>();
                    while (!inFile.EndOfStream)
                    {
                        holdline = inFile.ReadLine();
                        MajorList.Add(holdline);
                    }
                    majorArray = MajorList.ToArray();
                }

                //Generate a new MainForm window, this happens after the files are read
                //to ensure the listboxes will have valid information to display on startup
                Application.Run(new MainForm());

            }
            catch (System.IO.FileNotFoundException) //The file is not in the correct place or is missing
            {
                Console.WriteLine("File not found! \nExiting Gracefully...");
                System.Threading.Thread.Sleep(3000);
                Environment.Exit(1);
            }

        }
    }
}
