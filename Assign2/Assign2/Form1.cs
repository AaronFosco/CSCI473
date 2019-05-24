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
||   This is the Class for the main window that implements form. ||
||   It contains an array of options such as viewing students,   ||
||   Courses, Course Rosters, and Student's enrollment. It also  ||
||   allows for students to be enrolled and droped from courses  ||
||   ass well as adding new students or courses.                 ||
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
using System.Globalization;
using System.Text.RegularExpressions;

namespace Assign2
{
    public partial class MainForm : Form
    {
        #region class properties
        //Variables used for the "apply search critera" button
        private uint? zidSearch;
        private string departSearch;
        #endregion

        #region Constuctor and Event handlers

        /* -------------------------------------------------------------------------------
        * Constructor: MainForm
        * 
        * Use: Constructs a new Dirived Form object.
        * 
        * Parameters: none 
        * -------------------------------------------------------------------------------*/

        public MainForm()
        {
            InitializeComponent();

            //Set defaults for private properties
            zidSearch = null;
            departSearch = null;

            //Fill of both listboxes
            this.UpdateStudentListBox();
            this.UpdateCourseListBox();

            //add all majors to the major combobox
            foreach(string x in Program.majorArray)
                majorCbx.Items.Add(x);

            //Sort the combobox in alphabetical order
            majorCbx.Sorted = true;

            //add departments to the department combobox
            foreach (string x in Program.DepartmentArray)
                departCbx.Items.Add(x);

            //sort the combobox in alphabetical order
            departCbx.Sorted = true;

            //Freshman = 0, Sophomore = 1, Junior = 2, Senior = 3, PostBacc = 4
            yearCbx.Items.Add("Freshman");
            yearCbx.Items.Add("Sophomore");
            yearCbx.Items.Add("Junior");
            yearCbx.Items.Add("Senior");
            yearCbx.Items.Add("PostBacc");

        }


        /* -------------------------------------------------------------------------------
        * Function: PrintRoster
        * 
        * Use: Prints the full roster of all students enrolled in a selected class
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void Print_Roster(object sender, EventArgs e)
        {
            //if no course is selected in courseListBox, then SelectedIndex == -1; dont print anything
            if (courseListBox.SelectedIndex != -1)
            {

                Course PrintCourse = GetSelectedCourseFromListBox();

                //Print the requested roster
                courseOut.Clear();
                foreach (string student in PrintCourse.PrintRoster())
                {
                    courseOut.Text += student + "\n";
                }

            }
        }


        /* -------------------------------------------------------------------------------
        * Function: Enroll_Student
        * 
        * Use: Enrolls a student into a course if both a course and a student is selected
        *      in their respective ListBox. Prints a success/failure message to the 
        *      courseOut box.
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void Enroll_Student(object sender, EventArgs e)
        {
            courseOut.Clear();

            //make sure something is selected in each of the listboxes
            if (StudentListBox.SelectedIndex == -1 || courseListBox.SelectedIndex == -1)
            {
                courseOut.Text += "Please Select a student and a course to enroll a student to a course";
            } else
            {
                //Get both the Student & The Course
                Student EnrollStudent = GetSelectedStudentFromListBox();
                Course EnrollCourse = GetSelectedCourseFromListBox();

                int EnrollCode = -1;

                //Enroll the student & obtain an EnrollCode
                EnrollCode = EnrollStudent.Enroll(EnrollCourse);

                //Print a message based on EnrollCode
                switch (EnrollCode)
                {
                    case 0:
                        courseOut.Text += (String.Format("z{0} has successfully been enrolled into {1}", EnrollStudent.Zid, EnrollCourse.ToString()));

                        //Since UpdateCourseListBox refreshes the courselist, our selection is changed to '-1'.
                        //To combat this, we hold the selection index and put it back after the update.
                        int holdindex = courseListBox.SelectedIndex;
                        UpdateCourseListBox();
                        courseListBox.SelectedIndex = holdindex;
                        break;
                    case 5:
                        courseOut.Text += (String.Format("The course {0} has reached its max capacity.", EnrollCourse.ToString()));
                        break;
                    case 10:
                        courseOut.Text += (String.Format("z{0} has already been enrolled in {1}", EnrollStudent.Zid, EnrollCourse.ToString()));
                        break;
                    case 15:
                        courseOut.Text += (String.Format("The couse {1} will put the student z{0} over the maximum allowed enrolled credit hours (18)", EnrollStudent.Zid, EnrollCourse.ToString()));
                        break;
                    default:
                        break;

                }
            }
        }


        /* -------------------------------------------------------------------------------
        * Function: Drop_Student
        * 
        * Use: Drops a student From a course if both a course and a student is selected
        *      in their respective ListBox. Prints a success/failure message to the 
        *      courseOut box.
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void Drop_Student(object sender, EventArgs e)
        {
            courseOut.Clear();

            //make sure something is selected in each of the listboxes
            if (StudentListBox.SelectedIndex == -1 || courseListBox.SelectedIndex == -1)
            {
                courseOut.Text += "Please Select a student and a course to drop a student from a course";
            }
            else
            {
                //Get both the Student & The Course
                Student DropStudent = GetSelectedStudentFromListBox();
                Course DropCourse = GetSelectedCourseFromListBox();

                int DropCode = -1;

                //attempt to drop the student from the course, and obtain a return code
                DropCode = DropStudent.Drop(DropCourse);

                //Print a message based on return Code
                switch (DropCode)
                {
                    case 0:
                        courseOut.Text += string.Format("z{0} has successfully been droped from {1}", DropStudent.Zid, DropCourse.ToString());

                        //Since UpdateCourseListBox refreshes the courselist, our selection is changed to '-1'.
                        //To combat this, we hold the selection index and put it back after the update.
                        int holdindex = courseListBox.SelectedIndex;
                        UpdateCourseListBox();
                        courseListBox.SelectedIndex = holdindex;
                        break;
                    case 20:
                        courseOut.Text += string.Format("z{0} was not found in {1}", DropStudent.Zid, DropCourse.ToString());
                        break;
                    default:
                        break;
                }
            }
        }


        /* -------------------------------------------------------------------------------
        * Function: Apply_Search
        * 
        * Use: Filters the Student Listbox, Course Listbox, or both depending on what
        *      the user has entered into the 'searchStudentInputBox' and/or the
        *      'filterCoursesInputBox'. If the search ended in a sucess/failure, a 
        *      message will outputed into 'courseOut' with the courrect message.
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void Apply_Search(object sender, EventArgs e)
        {
            //If "Apply search criteria" was only clicked to clear the search, don't call courseOut.Clear();
            if ((searchStudentInputBox.Text != null && searchStudentInputBox.Text != "") ||
                (filterCoursesInputBox.Text != null && filterCoursesInputBox.Text != ""))
            {
                courseOut.Clear();
            }

            //--Student Search--
            if (searchStudentInputBox.Text != null && searchStudentInputBox.Text != "")
            {
                //get the text from the textbox
                string inputZid = searchStudentInputBox.Text;

                //remove the 'z' at the beginning of the input, if it is there
                if (inputZid.StartsWith("z"))
                    inputZid = inputZid.Substring(1);

                //try to convert the string input to uint
                if (uint.TryParse(inputZid, out uint zidholder))
                {
                    courseOut.Text += "Zid search applied\n";

                    //update private property & update the ListBox
                    zidSearch = zidholder;
                    UpdateStudentListBox();

                } else //TryParse Failed, there are non-numeric characters!
                {
                    courseOut.Text += "The Zid you entered seems to be incorrect, Please make sure you have entered it correctly\n";
                }

            } else //Nothing is entered in 'searchStudentInputBox'
            {
                zidSearch = null;
                UpdateStudentListBox();
            }


            //--Department Search--
            if (filterCoursesInputBox.Text != null && filterCoursesInputBox.Text != "")
            {
                string inputDepart = filterCoursesInputBox.Text.ToUpper();

                //regex is to check if the string contains only letters, no numbers & is exactly 3 or 4 characters long
                if ((inputDepart.Length == 3 || inputDepart.Length == 4) && Regex.IsMatch(inputDepart, @"^[a-zA-Z]+$"))
                {
                    courseOut.Text += "Department filter applied\n";

                    //update private property & update the ListBox
                    departSearch = inputDepart;
                    UpdateCourseListBox();

                } else
                {
                    courseOut.Text += "The department code that was entered seems to be incorrect, Please make sure you have entered it correctly\n";
                }
            }
            else //Nothing is entered in 'filterCoursesInputBox'
            {
                departSearch = null;
                UpdateCourseListBox();
            }
        }


        /* -------------------------------------------------------------------------------
        * Function: Add_Student
        * 
        * Use: Adds a student to the 'StudentList'
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void Add_Student(object sender, EventArgs e)
        {
            //basic concept with no error handling
            string[] t = nameInputBox.Text.Split(',');
            int z = int.Parse(zidBox.Text);
            Program.StudentList.Add(new Student((uint)z, t[0], t[1], majorCbx.SelectedText, (uint)yearCbx.SelectedIndex, 4));
            courseOut.Text += Program.StudentList[Program.StudentList.Count - 1].ToString();
            Program.StudentList.Sort();
            UpdateStudentListBox();
        }


        /* -------------------------------------------------------------------------------
        * Function: Add_Course
        * 
        * Use: Adds a course to the 'CourseList' based on what the user inputs into
        *      'departCbx', 'courseNoInputBox', 'sectionNoInputBox', and
        *      'CapacitySpinnerBox'. If the formatting on any of the input fields are
        *      incorrect or the entered course already exists, an error message will
        *      be displayed in 'courseOut'. Alternatively, If the new course was entered
        *      successfully, a success message will be displayed.
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void Add_Course(object sender, EventArgs e)
        {
            courseOut.Clear();

            //Check to see if somthing was selected in the combo box
            if (departCbx.Text != "")
            {
                //Check to see if somthing was entered into the input boxes
                if (courseNoInputBox.Text != "" && sectionNoInputBox.Text != "")
                {
                    //Obtain the text from input boxes
                    string inputCourseNo = courseNoInputBox.Text;
                    string inputSectNo = sectionNoInputBox.Text;

                    //Check to see if the inputted course number is 3 characters, the section number is 4 characters, and
                    //the course number is only numeric
                    if (inputCourseNo.Length == 3 && inputSectNo.Length == 4 && uint.TryParse(inputCourseNo, out uint convertedCourseNo))
                    {
                        //check to see if the inputted course information is already in our CourseList
                        Course doesItExist = Program.CourseList.Find(SearchCourse => (SearchCourse.DepartCode.Contains(departCbx.Text.ToUpper()) &&
                                                                                  SearchCourse.CourseNo == convertedCourseNo &&
                                                                                  SearchCourse.SectNo.Contains(inputSectNo.ToUpper())));
                        if (doesItExist == null)
                        {
                            //Add a new course to the CourseList
                            Program.CourseList.Add(new Course(departCbx.Text, convertedCourseNo, inputSectNo.ToUpper(), 3, (ushort)CapacitySpinnerBox.Value));
                            courseOut.Text += "New course entered successfully!\nCourse: " + Program.CourseList[Program.CourseList.Count - 1].ToString();

                            //Sort the list & update the CourseListBox
                            Program.CourseList.Sort();
                            UpdateCourseListBox();

                        } else //item was already in the list
                        {
                            courseOut.Text += "Course already in list!";
                        }
                    } else //Conditions for correct input were not met
                    {
                        courseOut.Text += "Couse Number must be a 3 digit number and Section number must be a 4 alphanumeric characters";
                    }
                } else //nothing was entered in either courseNoInputBox or sectionNoInputBox
                {
                    courseOut.Text += "Please enter both a course number and section number";
                }
            } else //no department was selected
            {
                courseOut.Text += "Please select a department\n";
            }
        }

        /* -------------------------------------------------------------------------------
        * Function: StudentListBox_SelectedIndexChanged
        * 
        * Use: When a student is selected from the 'StudentListBox', that student's 
        *      information will be printed in 'courseOut'.
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void StudentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            Student selectedStudent = GetSelectedStudentFromListBox();

            courseOut.Clear();
            courseOut.Text += selectedStudent.ToString() + "\n";
            courseOut.Text += "-------------------------------------------------------\n";

            foreach (Course currentlyEnrolledCourse in Program.CourseList.Where(x => x.FindZid(selectedStudent.Zid)))
                courseOut.Text += currentlyEnrolledCourse.ToString() + "\n";
        }
        #endregion

        #region Supplimetery functions

        /* -------------------------------------------------------------------------------
        * Function: UpdateCourseListBox
        * 
        * Use: Redraws 'CourseListBox'. If 'departSearch' is not null, then it redraws 
        *      'CourseListBox' with all Course object's 'DepartCode' property that matches
        *      'departSearch'.
        * 
        * Parameters: none
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void UpdateCourseListBox()
        {
            //clear all items in the ListBox
            courseListBox.Items.Clear();

            //Prevent the listbox from being redrawn until the end of the update
            courseListBox.BeginUpdate();
            if (departSearch == null)
            {
                foreach (Course x in Program.CourseList)
                {
                    courseListBox.Items.Add(x.ToString());
                }
            } else
            {
                foreach (Course x in Program.CourseList.Where(departCheck => departCheck.DepartCode == departSearch))
                {
                    courseListBox.Items.Add(x.ToString());
                }
            }

            courseListBox.EndUpdate();
        }

        /* -------------------------------------------------------------------------------
        * Function: UpdateStudentListBox
        * 
        * Use: Redraws 'StudentListBox'. If 'zidSearch' is not null, then it redraws 
        *      'StudentListBox' with all Student object's 'Zid' property that matches
        *      'zidSearch'.
        * 
        * Parameters: none
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void UpdateStudentListBox()
        {
            //clear all items in the ListBox
            StudentListBox.Items.Clear();

            //Prevent the listbox from being redrawn until the end of the update
            StudentListBox.BeginUpdate();
            if (zidSearch == null)
            {
                foreach (Student x in Program.StudentList)
                {
                    StudentListBox.Items.Add(string.Format("z{0} -- {1}, {2}", x.Zid, x.LastName, x.FirstName));
                }
            }
            else
            {
                //lambda expression to check to see if any zid matches or starts with a requested zid
                foreach (Student x in Program.StudentList.Where(x => x.Zid.ToString().StartsWith(zidSearch.ToString()) || x.Zid == zidSearch))
                {
                    StudentListBox.Items.Add(string.Format("z{0} -- {1}, {2}", x.Zid, x.LastName, x.FirstName));
                }
            }
            StudentListBox.EndUpdate();
        }

        /* -------------------------------------------------------------------------------
        * Function: GetSelectedStudentFromListBox
        * 
        * Use: obtains a student object that matches the selected one in 'StudentListBox'
        * 
        * Parameters: none
        * 
        * Returns: A student object that is selected in 'StudentListBox'
        * -------------------------------------------------------------------------------*/

        private Student GetSelectedStudentFromListBox()
        {
            //Obtain zid from StudentListBox, without the 'z' prefix
            uint selectedZid = uint.Parse(StudentListBox.SelectedItem.ToString().Substring(1, 7));

            //return the student with the matching zid selection
            return Program.StudentList.Find(findStudent => findStudent.Zid == selectedZid);
        }

        /* -------------------------------------------------------------------------------
        * Function: GetSelectedCourseFromListBox
        * 
        * Use: Obtains a Course object that matches the selected one in 'CourseListBox'
        * 
        * Parameters: none
        * 
        * Returns: A Course object that is selected in 'CourseListBox'
        * -------------------------------------------------------------------------------*/

        private Course GetSelectedCourseFromListBox()
        {
            //indices of 0 and 1 represent Department and courseNo-sectionNo respectivly. 2 is unused.
            string[] deptAndCourseNos = courseListBox.SelectedItem.ToString().Split(' ');

            //indices 0 and 1 represent the courseNo and sectionNo respectivly.
            string[] courseNoAndSectionNo = deptAndCourseNos[1].Split('-');

            //Lambda expression inside List<T>.Find() to look for a course matching the Selection
            return Program.CourseList.Find(SearchCourse => (SearchCourse.DepartCode.Contains(deptAndCourseNos[0].ToUpper()) &&
                                                                                  SearchCourse.CourseNo == uint.Parse(courseNoAndSectionNo[0]) &&
                                                                                  SearchCourse.SectNo.Contains(courseNoAndSectionNo[1])));
        }
        #endregion
    }
}


       
