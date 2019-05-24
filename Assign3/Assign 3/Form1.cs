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
||   This is the class file for the Main form that implements    ||
||   Form. The Form window will allow for multiple specific      ||
||   queries, as well as displaying the results. Each Button is  ||
||   Labeled 1-6 to match these six queries respectivly:         ||
||   1. All grades posted for a single Student.                  ||
||   2. Students who got an X grade or higher/lower in one       ||
||      particular course.                                       ||
||   3. Students of a particular major who failed a particular   ||
||      course.                                                  ||
||   4. All grades posted for a single Course.                   ||
||   5. Courses with a fail rate (grade == "F") greater than or  ||
||      less than X%.                                            ||
||   6. The percentage of students who passed each Course with   ||
||      an X grade or higher/lower.                              ||
 \_______________________________________________________________/
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //list of passing grades
            string[] gradeCharacters = { "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "D-"};


            //add grades to combo box
            gradeComboPassReport.Items.AddRange(gradeCharacters);

            //Start the selection at the first index
            gradeComboPassReport.SelectedIndex = 0;


            //add grades to combo box
            gradeComboBoxThreshold.Items.AddRange(gradeCharacters);

            //add F to this one as well
            gradeComboBoxThreshold.Items.Add("F");

            //start the selection at the first index
            gradeComboBoxThreshold.SelectedIndex = 0;


            //add all the majors to the combo box
            majorComboBoxStudentFail.Items.AddRange(Program.majorArray);

            //start the selection at the first index
            majorComboBoxStudentFail.SelectedIndex = 0;

        }

        #region Queries 1-3
        /* -------------------------------------------------------------------------------
        * Function: ResultButton1_Click
        * 
        * Use: Event handler for 1st button on the form to support the query:
        *      "All grades posted for a single Student."
        *      
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void ResultButton1_Click(object sender, EventArgs e)
        {
            //Clear main output box
            queryOut.Clear();
            
            string inputZid = zidBox.Text;

            //make sure somthing of value is in the textbox
            if (!String.IsNullOrWhiteSpace(inputZid) && (inputZid.Length == 7 || inputZid.Length == 8))
            {
                //remove 'Z' if it is there
                if (inputZid.StartsWith("z"))
                    inputZid = inputZid.Substring(1);

                if (inputZid.StartsWith("Z"))
                    inputZid = inputZid.Substring(1);

                if (uint.TryParse(inputZid, out uint zidHolder))
                {
                    //print header
                    queryOut.Text = string.Format("Single Student Grade Report ({0})\n", inputZid);
                    queryOut.Text += "------------------------------------------\n";

                    IEnumerable<GradeRow> singleStudent =
                        from A in Program.GradeList
                        where A.zid == zidHolder
                        select A;

                    bool printFlag = singleStudent.Any();

                    //Loop thru our LINQ-generated enumerable container, & print Data
                    foreach (GradeRow row in singleStudent)
                    {
                        queryOut.Text += string.Format("z{0} | {1}-{2} | {3}{4}\n", row.zid, row.departCode, row.courseNo, row.letterGrade, row.charPlusOrMinus);
                    }

                    //print footer
                    if (!printFlag)
                        queryOut.Text += "No Students matched the query criteria.";
                    else
                        queryOut.Text += "\n### END RESULTS ###";

                } else
                {
                    queryOut.Text += "The Zid you entered seems to be incorrect, Please make sure you have entered it correctly";
                }
            } else
            {
                queryOut.Text += "Please enter a valid Zid";
            }
        }

        /* -------------------------------------------------------------------------------
        * Function: ResultButton2_Click
        * 
        * Use: Event handler for 2nd button on the form to support the query:
        *      "Students who got an X grade or higher/lower in one particular course."
        *      
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/
        
        private void ResultButton2_Click(object sender, EventArgs e)
        {
            //Clear main output box
            queryOut.Clear();

            //Make certain somthing of value is in our course box
            if (!string.IsNullOrWhiteSpace(courseBoxThreshold.Text))
            {
                //Get values from correlating form elements
                string inputText = courseBoxThreshold.Text;
                string[] splitInput = inputText.Split(' ');

                //make sure there is somthing inputted with only 1 whitespace
                if (splitInput.Length == 2)
                {
                    //try to convert courseNo string to uint, & make sure the length is 3
                    if (uint.TryParse(splitInput[1], out uint courseNo) && splitInput[1].Length == 3)
                    {
                        //print header
                        queryOut.Text += string.Format("Grade Threshold Report for  ({0})\n", inputText);
                        queryOut.Text += "------------------------------------------\n";

                        string grade = gradeComboBoxThreshold.SelectedItem.ToString();

                        short plusOrMinusHolder;

                        //Obtain a transcribed version of our plus/minus
                        switch (grade[grade.Length - 1])
                        {
                            case '+':
                                plusOrMinusHolder = 1;
                                break;
                            case '-':
                                plusOrMinusHolder = -1;
                                break;
                            default:
                                plusOrMinusHolder = 0;
                                break;
                        }

                        bool printFlag;

                        //If->the greater than button was set, else->It was not and less than was checked (2 Radio buttons are Mutually exclusive)
                        if (greaterThanRadioThreshold.Checked)
                        {
                            IEnumerable<GradeRow> rows =
                                from B in Program.GradeList
                                where (B.courseNo == courseNo && B.departCode == splitInput[0].ToUpper() &&
                                        (
                                          (B.letterGrade < grade[0]) ||
                                          (B.plusOrMinus >= plusOrMinusHolder && B.letterGrade == grade[0])
                                        )
                                      )
                                orderby B.zid
                                select B;

                            //Loop thru our LINQ-generated enumerable container, & print Data
                            foreach (GradeRow row in rows)
                            {
                                queryOut.Text += string.Format("z{0} | {1}-{2} | {3}{4}\n", row.zid, row.departCode, row.courseNo, row.letterGrade, row.charPlusOrMinus);
                            }

                            //set footer flag
                            printFlag = rows.Any();

                        } else
                        {
                            IEnumerable<GradeRow> rows =
                                from B in Program.GradeList
                                where (B.courseNo == courseNo && B.departCode == splitInput[0].ToUpper() &&
                                        (
                                          (B.letterGrade > grade[0]) ||
                                          (B.plusOrMinus <= plusOrMinusHolder && B.letterGrade == grade[0])
                                        )
                                      )
                                orderby B.zid
                                select B;

                            //Loop thru our LINQ-generated enumerable container, & print Data
                            foreach (GradeRow row in rows)
                            {
                                queryOut.Text += string.Format("z{0} | {1}-{2} | {3}{4}\n", row.zid, row.departCode, row.courseNo, row.letterGrade, row.charPlusOrMinus);
                            }

                            //set footer flag
                            printFlag = rows.Any();
                        }

                        //Display Footer
                        if (!printFlag)
                            queryOut.Text += "No students matched the query criteria.";
                        else
                            queryOut.Text += "\n### END RESULTS ###";

                    }
                    else
                    {
                        queryOut.Text += "Please make sure the department number is infact a number and is only 3 numbers";
                    }
                }
                else
                {
                    queryOut.Text += "Please enter course in the format of 'DEPT ###'";
                }
            }
            else
            {
                queryOut.Text += "Please Enter a Course into the text box";
            }

        }

        /* -------------------------------------------------------------------------------
        * Function: ResultButton3_Click
        * 
        * Use: Event handler for 3rd button on the form to support the query:
        *      "Students of a particular major who failed a particular course."
        *      
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void ResultButton3_Click(object sender, EventArgs e)
        {
            //Clear main output box
            queryOut.Clear();

            //Make certain somthing of value is in our course box
            if (!string.IsNullOrWhiteSpace(courseBoxStudentFail.Text))
            {
                //Get values from correlating form elements
                string inputText = courseBoxStudentFail.Text;
                string[] splitInput = inputText.Split(' ');

                //make sure there is somthing inputted with only 1 whitespace
                if (splitInput.Length == 2)
                {
                    //try to convert courseNo string to uint, & make sure the length is 3
                    if (uint.TryParse(splitInput[1], out uint courseNo) && splitInput[1].Length == 3)
                    {
                        //print header
                        queryOut.Text += string.Format("Fail Report for Majors ({0}) in ({1})\n", majorComboBoxStudentFail.Text ,inputText);
                        queryOut.Text += "------------------------------------------\n";

                        IEnumerable<GradeRow> rows =
                            from X in Program.GradeList
                            where X.departCode == splitInput[0].ToUpper() &&
                                  X.courseNo == courseNo &&
                                  X.letterGrade == 'F' &&
                                  Program.StudentList.Exists(Y => Y.Major == majorComboBoxStudentFail.Text && Y.Zid == X.zid)
                            orderby X.zid
                            select X;

                        //Loop thru our LINQ-generated enumerable container, & print Data
                        foreach (GradeRow row in rows)
                        {
                            queryOut.Text += string.Format("z{0} | {1}-{2} | {3}{4}\n", row.zid, row.departCode, row.courseNo, row.letterGrade, row.charPlusOrMinus);
                        }

                        //Display Footer
                        if (!rows.Any())
                            queryOut.Text += "No students matched the query criteria.";
                        else
                            queryOut.Text += "\n### END RESULTS ###";
                    }
                    else
                    {
                        queryOut.Text += "Please make sure the department number is infact a number and is only 3 numbers";
                    }
                }
                else
                {
                    queryOut.Text += "Please enter course in the format of 'DEPT ###'";
                }
            }
            else
            {
                queryOut.Text += "Please Enter a Course into the text box";
            }
        }
#endregion
        #region Queries 4-6

        /* -------------------------------------------------------------------------------
        * Function: ResultButton4_Click
        * 
        * Use: Event handler for 4th button on the form to support the query:
        *      "All grades posted for a single Course."
        *      
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void ResultButton4_Click(object sender, EventArgs e)
        {
            //Clear main output box
            queryOut.Clear();

            //Make certain somthing of value is in our course box
            if (!string.IsNullOrWhiteSpace(courseBoxGradeReport.Text))
            {
                //Get values from correlating form elements
                string inputText = courseBoxGradeReport.Text;
                string[] splitInput = inputText.Split(' ');

                //make sure there is somthing inputted with only 1 whitespace
                if (splitInput.Length == 2)
                {
                    //try to convert courseNo string to uint, & make sure the length is 3
                    if (uint.TryParse(splitInput[1], out uint courseNo) && splitInput[1].Length == 3)
                    {
                        IEnumerable<GradeRow> foundValues =
                            from N in Program.GradeList
                            where N.departCode == splitInput[0].ToUpper() &&
                                  N.courseNo == courseNo
                            select N;

                        //if there is anything in our enumerable container, we are going to print somthing,
                        //so set the flag to true
                        bool printFlag = foundValues.Any();

                        //print header
                        queryOut.Text += string.Format("Grade Report for ({0})\n", inputText);
                        queryOut.Text += "------------------------------------------\n";
                        
                        //Loop thru our LINQ-generated enumerable container, & print Data
                        foreach (GradeRow row in foundValues)
                        {
                            queryOut.Text += string.Format("z{0} | {1}-{2} | {3}{4}\n", row.zid, row.departCode, row.courseNo, row.letterGrade, row.charPlusOrMinus);
                        }

                        //Display Footer
                        if (!foundValues.Any())
                            queryOut.Text += "No students matched the query criteria.";
                        else
                            queryOut.Text += "\n### END RESULTS ###";

                    }
                    else
                    {
                        queryOut.Text += "Please make sure the department number is infact a number and is only 3 numbers";
                    }
                }
                else
                {
                    queryOut.Text += "Please enter course in the format of 'DEPT ###'";
                }
            }
            else
            {
                queryOut.Text += "Please Enter a Course into the text box";
            }
        }

        /* -------------------------------------------------------------------------------
        * Function: ResultButton5_Click
        * 
        * Use: Event handler for 5th button on the form to support the query:
        *      "Courses with a fail rate (grade == "F") greater than/less than X%", 
        *      where the 'X' is an inputted value by the user in the Spinner:
        *      'percentSpinnerFailReport'
        *      
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void ResultButton5_Click(object sender, EventArgs e)
        {
            //Clear main output box
            queryOut.Clear();

            bool printFlag = false;

            //To make sure we dont print out the same courses twice
            List<String> alreadyOutputtedCourses = new List<string>();

            //Get values from correlating form elements
            double percentage = (double)percentSpinnerFailReport.Value / 100.0;
            bool greaterThanSet = (greaterThanRadioFailReport.Checked);

            //Display header
            queryOut.Text += string.Format("Fail Percentage ({0} {1}%) Report for Classes.\n", 
                                           greaterThanSet ? ">=" : "<=",
                                           (int) (percentage*100));
            queryOut.Text += "------------------------------------------\n";

            
            foreach (Course row in Program.CourseList)
            {
                double enrolledCount = (
                    from A in Program.GradeList
                    where A.departCode == row.DepartCode &&
                          A.courseNo == row.CourseNo
                    select A
                    ).Count();

                //if there are no students, or we already outputted this course, 
                if (!(enrolledCount == 0 || alreadyOutputtedCourses.Contains(row.DepartCode + row.CourseNo)))
                {

                    //Match our current row where the grade is F
                    double failCount = (
                    from B in Program.GradeList
                    where B.letterGrade == 'F' &&
                          B.departCode == row.DepartCode &&
                          B.courseNo == row.CourseNo
                    select B
                    ).Count();

                    //Calculate the Ratio of failure and success
                    double calculatedPercentage = failCount / enrolledCount;

                    if (greaterThanSet)
                    {
                        if (calculatedPercentage >= percentage)
                        {
                            //as to not output the same course again
                            alreadyOutputtedCourses.Add(row.DepartCode+row.CourseNo);

                            //Display Data
                            queryOut.Text += string.Format("Out of {0} enrolled in {1}, {2} failed ({3: #0.##}%)\n\n",
                                                            enrolledCount,
                                                            row.DepartCode + "-" + row.CourseNo,
                                                            failCount,
                                                            calculatedPercentage * 100);

                            //We printed somthing \o/
                            printFlag = true;
                        }
                    }
                    else
                    {
                        if (calculatedPercentage <= percentage)
                        {

                            //as to not output the same course again
                            alreadyOutputtedCourses.Add(row.DepartCode + row.CourseNo);

                            //Display Data
                            queryOut.Text += string.Format("Out of {0} enrolled in {1}, {2} failed ({3: #0.##}%)\n\n",
                                                            enrolledCount,
                                                            row.DepartCode + "-" + row.CourseNo,
                                                            failCount,
                                                            calculatedPercentage * 100 );

                            //We printed somthing \o/
                            printFlag = true;
                        }
                    }
                }
            }

            //Display Footer
            if (!printFlag)
                queryOut.Text += "No Courses matched the query criteria.";
            else
                queryOut.Text += "\n### END RESULTS ###";

        }

        /* -------------------------------------------------------------------------------
        * Function: ResultButton6_Click
        * 
        * Use: Event handler for 6th button on the form to support the query:
        *      "The percentage of students who passed each Course with an 
        *       X grade or higher/lower", where 'X' is an slected Grade by
        *       the user in the Combo Box: 'gradeComboPassReport'
        *       
        *       
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void ResultButton6_Click(object sender, EventArgs e)
        {
            //Clear main output box
            queryOut.Clear();

            bool printFlag = false;

            //To make sure we dont print out the same courses twice
            List<String> alreadyOutputtedCourses = new List<string>();

            //Get values from correlating form elements
            string grade = gradeComboPassReport.SelectedItem.ToString();
            bool greaterThanSet = greaterThanRadioPassReport.Checked;

            //output header
            queryOut.Text += string.Format("Pass Percentage ({0} {1}%) Report for Classes.\n",
                                           greaterThanSet ? ">=" : "<=",
                                           grade);
            queryOut.Text += "------------------------------------------\n";

            //iterate thru each Course in CourseList
            foreach (Course row in Program.CourseList)
            {
                //Count every student that was enrolled in to the class (1 row in GradeList = 1 student)
                double enrolledCount = (
                    from A in Program.GradeList
                    where A.departCode == row.DepartCode &&
                          A.courseNo == row.CourseNo
                    select A
                    ).Count();

                //if there are no students, or we already outputted this course, exit
                if (!(enrolledCount == 0 || alreadyOutputtedCourses.Contains(row.DepartCode+row.CourseNo)))
                {

                    //Obtain a transcribed version of our plus/minus
                    short plusOrMinusHolder;
                    switch (grade[grade.Length-1])
                    {
                        case '+':
                            plusOrMinusHolder = 1;
                            break;
                        case '-':
                            plusOrMinusHolder = -1;
                            break;
                        default:
                            plusOrMinusHolder = 0;
                            break;
                    }

                    //If->the greater than button was set, else->It was not and less than was checked (2 Radio buttons are Mutually exclusive)
                    if (greaterThanSet)
                    {
                       
                        IEnumerable<GradeRow> passAbove =
                            from B in Program.GradeList

                                 //Find everything that matches our current row (DepartCode/CourseNo)
                            where (B.departCode == row.DepartCode && B.courseNo == row.CourseNo &&
                                    (
                                      //Find every grade that is 'ASCII' less than our selected value
                                      (B.letterGrade < grade[0] && B.letterGrade != 'F') ||

                                      //OR If the grade letter we are looking at is our selected grade letter, 
                                      //respect the 'Plus or Minus', and obtain elements based off of it
                                      (B.plusOrMinus >= plusOrMinusHolder && B.letterGrade == grade[0])
                                    )
                                  )
                            select B;

                        //number of passes in a class
                        int passCount = passAbove.Count();

                        //as to not output the same course again
                        alreadyOutputtedCourses.Add(row.DepartCode + row.CourseNo);

                        //Display data
                        queryOut.Text += string.Format("Out of {0} enrolled in {1}, {2} Passed at or above this threshold ({3: #0.##}%)\n\n",
                                                        enrolledCount,
                                                        row.DepartCode + "-" + row.CourseNo,
                                                        passCount,
                                                        (passCount / enrolledCount) * 100);

                        //Generally, there will always be output as long as there are classes, 
                        //so this is not needed..
                        printFlag = true;

                    } else
                    {
                        IEnumerable<GradeRow> passBelow =
                            from B in Program.GradeList

                                  //Find everything that matches our current row (DepartCode/CourseNo)
                            where (B.departCode == row.DepartCode && B.courseNo == row.CourseNo &&
                                    ( 
                                      //Find every grade that is 'ASCII' greater than our selected value
                                      (B.letterGrade > grade[0] && B.letterGrade != 'F') ||

                                      //OR If the grade letter we are looking at is our selected grade letter, 
                                      //respect the 'Plus or Minus', and obtain elements based off of it
                                      (B.plusOrMinus <= plusOrMinusHolder && B.letterGrade == grade[0])
                                    )
                                  )
                            select B;

                        //number of passes in a class
                        int passCount = passBelow.Count();

                        //as to not output the same course again
                        alreadyOutputtedCourses.Add(row.DepartCode + row.CourseNo);

                        //Display data
                        queryOut.Text += string.Format("Out of {0} enrolled in {1}, {2} Passed at or below this threshold ({3: #0.##}%)\n\n",
                                                        enrolledCount,
                                                        row.DepartCode + "-" + row.CourseNo,
                                                        passCount,
                                                        (passCount / enrolledCount) * 100);

                        //Generally, there will always be output as long as there are classes, 
                        //so this is not needed..
                        printFlag = true;
                    }
                }

            }

            //Display Footer
            if (!printFlag)
                queryOut.Text += "No Courses Available for querying.";
            else
                queryOut.Text += "\n### END RESULTS ###";
        }
        #endregion
    }
}
