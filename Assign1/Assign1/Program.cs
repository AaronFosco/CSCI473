/*
  _______________________________________________________________
 /                                                               \
||  Course: CSCI-473    Assignment #: 1    Semester: Fall 2018   ||
||                                                               ||
||  NAME1:  Aaron Fosco                    Z-ID: z1835687        ||
||                                                               ||
||  NAME2:  Marco Martinez                 Z-ID: z1767068        ||
||                                                               ||
||  TA's Name: Shivasupraj Pasham                                ||
||                                                               ||
||  Due: Thursday 9/13/2018 by 11:59PM                           ||
||                                                               ||
||  Description:                                                 ||
||   This is the main file containing the main routine. This     ||
||   program will read student and course data from two files    ||
||   to populate 2 Lists and allow the user an array of options  ||
||   such as viewing students, classes, enrolling students,      ||
||   dropping students, and so on.
 \_______________________________________________________________/
*/

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;


namespace Assign1
{
    class Program
    {
           public static List<Student> StudentList = new List<Student>();
           public static List<Course> CourseList = new List<Course>();
           public static void Main()
           {
              string holdline;
              string[] splited, splited2;
              string UserInput = "\0";
              string ExtraUserInput = "\0";
              List<string> ExitStatements = new List<string> { "8", "h", "q", "quit", "exit"};
              int EnrollCode, DropCode;
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

                Console.WriteLine(string.Format("We have {0} Students and {1} courses.\n", StudentList.Count, CourseList.Count));

                //for loop for user input
                bool endOfInput = false;
                while (endOfInput != true)
                 {

                    Console.WriteLine("Please Choose From the list of following options:\n");
                    Console.WriteLine("1. Print Student List (All)");
                    Console.WriteLine("2. Print Student List (Major)");
                    Console.WriteLine("3. Print Student List (Academic Year)");
                    Console.WriteLine("4. Print Course List");
                    Console.WriteLine("5. Print Course Roster");
                    Console.WriteLine("6. Enroll Student");
                    Console.WriteLine("7. Drop Student");
                    Console.WriteLine("8. Quit Application\n");
                    UserInput = Console.ReadLine();
                    if (ExitStatements.Contains(UserInput.ToLower()))
                    {
                        //User has inputted a character string to exit the program
                        endOfInput = true;
                    }
                    else if (UserInput.ToLower() == "1") //Print Student List (All)
                    {
                        //Sort all the students
                        StudentList.Sort();

                        //Output all the students
                        Console.WriteLine("Student List (All Students)");
                        Console.WriteLine("--------------------------------------------------------");
                        foreach (var x in StudentList)
                        {
                            Console.WriteLine(x.ToString());
                        }
                    }
                    else if (UserInput.ToLower() == "2") //Print Student List (Major)
                    {
                        //Prompt user for a Major
                        Console.WriteLine("What major would you like Printed?\n");
                        UserInput = Console.ReadLine();

                        //sort students
                        StudentList.Sort();

                        //flag for foreach look to make sure that somthing is outputted
                        bool SupplementaryOutputFlag = false;

                        //Output all the students with the requested major
                        Console.WriteLine(string.Format("Student List ({0} Majors)", UserInput));
                        Console.WriteLine("--------------------------------------------------------");
                        foreach (var User in StudentList.Where(x => x.Major == UserInput))
                        {
                            //couldn't figure out a way to not have to set this every iteration
                            SupplementaryOutputFlag = true;
                            Console.WriteLine(User.ToString());
                        }

                        //Output somthing if the above foreach failed to do so
                        if (SupplementaryOutputFlag == false)
                            Console.WriteLine(String.Format("There doesn't appear to be any students majoring in '{0}'", UserInput));
                    }
                    else if (UserInput.ToLower() == "3") //Print Student List (Academic Year)
                    {
                        //Prompt user for an academic year
                        Console.WriteLine("What academic year would you like printed?\n<Freshman, Sophomore, Junior, Senior, PostBacc>");
                        UserInput = Console.ReadLine();

                        //sort students
                        StudentList.Sort();

                        bool SupplementaryOutputFlag = false;

                        //cant figure out how to get enum Year outside of the Student class since it cannot be static...
                        uint NonEnumYear = 0;
                        switch (UserInput)
                        {
                            case "Freshman":
                                NonEnumYear = 0;
                                break;
                            case "Sophomore":
                                NonEnumYear = 1;
                                break;
                            case "Junior":
                                NonEnumYear = 2;
                                break;
                            case "Senior":
                                NonEnumYear = 3;
                                break;
                            case "PostBacc":
                                NonEnumYear = 4;
                                break;
                            default:
                                //If the user inputted somthing erroneous, output a message, and set a flag 
                                Console.WriteLine(String.Format("Could not find {0} As an academic year", UserInput));
                                SupplementaryOutputFlag = true;
                                break;
                        }

                        //if the flag was triggered from the above switch statement, do not print out anything else
                        if (SupplementaryOutputFlag != true)
                        {
                            //Output all the students with the requested Academic year
                            Console.WriteLine(String.Format("Student List (Academic year of {0})", UserInput));
                            Console.WriteLine("--------------------------------------------------------");
                            foreach (var User in StudentList.Where(x => (uint)x.AcademicYear == NonEnumYear))
                            {
                                SupplementaryOutputFlag = true;
                                Console.WriteLine(User.ToString());
                            }
                        }

                        //Output somthing if the above foreach failed to do so
                        if (SupplementaryOutputFlag == false)
                            Console.WriteLine(String.Format("There doesn't appear to be any students in the academic year of '{0}'", UserInput));
                    }
                    else if (UserInput.ToLower() == "4") // Print Course List
                    {
                        CourseList.Sort();
                        foreach (var x in CourseList)
                        {
                            Console.WriteLine(x.ToString());
                        }
                    }
                    else if (UserInput.ToLower() == "5") // Print Course Roster
                    {
                        //Prompt a user For a course and Split the input into parsable data
                        Console.WriteLine("Which coruse roster would you like printed?\nPlease enter it in this format: DEPT COURSE_NUM-SECTION_NUM");
                        UserInput = Console.ReadLine();

                        splited = UserInput.Split(' ');

                        //if there wasn't a space between DEPT and COURSE_NUM, print an error
                        if (splited.Length != 2)
                        {
                            Console.WriteLine("There was an error in your input");
                        }
                        else
                        {
                            //seperate the COURSE_NUM and the SECTION_NUM
                            splited2 = splited[1].Split('-');

                            //Lambda expression inside List<T>.Find() to look for a course matching the user's input
                            Course PrintCourse = CourseList.Find(SearchCouse => (SearchCouse.DepartCode.Contains(splited[0].ToUpper()) &&
                                                                 SearchCouse.CourseNo == uint.Parse(splited2[0]) &&
                                                                 SearchCouse.SectNo.Contains(splited2[1])));

                            //if the List<T>.Find() function failed, stop processing, otherwise print the requested class roster
                            if (PrintCourse != null)
                                PrintCourse.PrintRoster();
                            else
                                Console.WriteLine("The requested Course wasn't found in the course list!");
                        }
                    }
                    else if (UserInput.ToLower() == "6") // Enroll Student
                    {
                        //Prompt a user For a Zid (without the z)
                        Console.WriteLine("Please enter the Z-ID (omitting the Z character)\nof the student you like to enroll into a course:");
                        UserInput = Console.ReadLine();

                        //Prompt a user For a course and Split the input into parsable data
                        Console.WriteLine("Which couse will this student be enrolled into?\nPlease enter it in this format: DEPT COURSE_NUM-SECTION_NUM");
                        ExtraUserInput = Console.ReadLine();
                        splited = ExtraUserInput.Split(' ');

                        //if there wasn't a space between DEPT and Course, print an error
                        if (splited.Length != 2)
                        {
                            Console.WriteLine("There was an error in your input");
                        }
                        else
                        {
                            //seperate the COURSE_NUM and the SECTION_NUM
                            splited2 = splited[1].Split('-');

                            //Lambda expression inside List<T>.Find() to look for a student Zid matching the user's input
                            Student EnrollStudent = StudentList.Find(SearchStudent => SearchStudent.Zid == uint.Parse(UserInput));

                            //Lambda expression inside List<T>.Find() to look for a course matching the user's input
                            Course EnrollCourse = CourseList.Find(SearchCouse => (SearchCouse.DepartCode.Contains(splited[0].ToUpper()) &&
                                                                                  SearchCouse.CourseNo == uint.Parse(splited2[0]) &&
                                                                                  SearchCouse.SectNo.Contains(splited2[1])));

                            EnrollCode = -1;

                            //if the List<T>.Find() was Sucessful, enroll the student & obtain an EnrollCode
                            //Otherwise Don't Obtain EnrollCode & print an error
                            if (EnrollCourse != null && EnrollStudent != null)
                                EnrollCode = EnrollStudent.Enroll(EnrollCourse);
                            else if (EnrollStudent == null)
                                Console.WriteLine("The requested Student wasn't found in the student list!");
                            else if (EnrollCourse == null)
                                Console.WriteLine("The requested Course wasn't found in the course list!");

                            //Print a message based on EnrollCode
                            switch (EnrollCode)
                            {
                                case 0:
                                    Console.WriteLine(String.Format("z{0} has successfully been enrolled into {1}", UserInput, ExtraUserInput));
                                    break;
                                case 5:
                                    Console.WriteLine(String.Format("The course {0} has reached its max capacity.", ExtraUserInput));
                                    break;
                                case 10:
                                    Console.WriteLine(String.Format("z{0} has already been enrolled in {1}", UserInput, ExtraUserInput));
                                    break;
                                case 15:
                                    Console.WriteLine(String.Format("The couse {1} will put the student z{0} over the maximum allowed enrolled credit hours (18)", UserInput, ExtraUserInput));
                                    break;
                                case -1: // Case where EnrollCourse == null or EnrollStudent == null
                                    break;
                                default:
                                    break;

                            }
                        }

                    }
                    else if (UserInput.ToLower() == "7") // Drop Student
                    {
                        //Prompt a user For a Zid (without the z)
                        Console.WriteLine("Please enter the Z-ID (omitting the Z character)\nof the student you like to Drop from a course:");
                        UserInput = Console.ReadLine();

                        //Prompt a user For a course and Split the input into parsable data
                        Console.WriteLine("Which couse will this student be Droped from?\nPlease enter it in this format: DEPT COURSE_NUM-SECTION_NUM");
                        ExtraUserInput = Console.ReadLine();
                        splited = ExtraUserInput.Split(' ');

                        //if there wasn't a space between DEPT and COURSE_NUM, print an error
                        if (splited.Length != 2)
                        {
                            Console.WriteLine("There was an error in your input");
                        }
                        else
                        {
                            //seperate the COURSE_NUM and the SECTION_NUM
                            splited2 = splited[1].Split('-');

                            //Lambda expression inside List<T>.Find() to look for a student Zid matching the user's input
                            Student DropStudent = StudentList.Find(SearchStudent => SearchStudent.Zid == uint.Parse(UserInput));

                            //Lambda expression inside List<T>.Find() to look for a course matching the user's input
                            Course DropCourse = CourseList.Find(SearchCouse => (SearchCouse.DepartCode.Contains(splited[0].ToUpper()) &&
                                                                                  SearchCouse.CourseNo == uint.Parse(splited2[0]) &&
                                                                                  SearchCouse.SectNo.Contains(splited2[1])));
                            DropCode = -1;

                            //if the List<T>.Find() was Sucessful, Drop the student & obtain an DropCode
                            //Otherwise Don't Obtain DropCode & print an error
                            if (DropCourse != null && DropStudent != null)
                                DropCode = DropStudent.Drop(DropCourse);
                            else if (DropStudent == null)
                                Console.WriteLine("The requested Student wasn't found in the student list!");
                            else if (DropCourse == null)
                                Console.WriteLine("The requested Course wasn't found in the course list!");

                            //Print a message based on DropCode
                            switch (DropCode)
                            {
                                case 0:
                                    Console.WriteLine("z{0} has successfully been droped from {1}", UserInput, ExtraUserInput);
                                    break;
                                case 20:
                                    Console.Write("z{0} was not found in {1}", UserInput, ExtraUserInput);
                                    break;
                                case -1:// Case where DropCourse == null or DropStudent == null
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    else //An incorrect command was read
                    {
                        Console.WriteLine("Command Not recognized!");
                    }

                    //Extra padding for next interface option
                    Console.WriteLine("\n\n");
                }
            }
            //The file is not in the correct place or is missing
            catch (System.IO.FileNotFoundException) 
            {
                Console.WriteLine("File not found! \nExiting Gracefully...");
                System.Threading.Thread.Sleep(3000);
                Environment.Exit(1);
            }

            //Exit message
            Console.WriteLine("Thanks for using This application!");
            System.Threading.Thread.Sleep(3000);
        }
    }
}
