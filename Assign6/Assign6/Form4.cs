/*
  _______________________________________________________________
 /                                                               \
||  Course: CSCI-473    Assignment #: 6    Semester: Fall 2018   ||
||                                                               ||
||  NAME1:  Aaron Fosco                    Z-ID: z1835687        ||
||                                                               ||
||                                                               ||
||  TA's Name: Shivasupraj Pasham                                ||
||                                                               ||
||  Due: Thursday 11/29/2018 by 11:59PM                          ||
||                                                               ||
||  Description:                                                 ||
||   This is the file containing the multiple line-graph form.   ||
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

namespace Assign6
{
    public partial class Form4 : Form
    {
        /* -------------------------------------------------------------------------------
        * Constructor: Form4
        * 
        * Use: Constructs a new Derived Form object. Additionally, fills this form's
        *      chart with data.  
        * 
        * Parameters: none 
        * -------------------------------------------------------------------------------*/

        public Form4()
        {
            InitializeComponent();

            //obtain sorted data and fill the chart with data
            var sort = Program.dataList.OrderBy(x => x[3]);
            foreach (int[] x in sort)
                chart1.Series["Age: 25+ & 4yrs. of high school"].Points.AddXY(x[3], x[1]);


            //obtain sorted data and fill the chart with data
            sort = Program.dataList.OrderBy(x => x[4]);
            foreach (int[] x in sort)
                chart1.Series["Age: 16-19 & not in highschool nor highschool graduates"].Points.AddXY(x[4], x[1]);


            //obtain sorted data and fill the chart with data
            sort = Program.dataList.OrderBy(x => x[5]);
            foreach (int[] x in sort)
                chart1.Series["Age: 18-24 & in college"].Points.AddXY(x[5], x[1]);


            //obtain sorted data and fill the chart with data
            sort = Program.dataList.OrderBy(x => x[6]);
            foreach (int[] x in sort)
                chart1.Series["Age: 25+ & 4+ years of college"].Points.AddXY(x[6], x[1]);
        }

        /* -------------------------------------------------------------------------------
        * Function: button1_Click
        * 
        * Use: Closes this form to return to the main form
        *      
        * Parameters: Sender: Reference to the object that called this function
        *             EventArgs: The arguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
