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
||   This is the file containing the bubble chart form.          ||
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
    public partial class Form5 : Form
    {
        /* -------------------------------------------------------------------------------
        * Constructor: Form5
        * 
        * Use: Constructs a new Derived Form object. Additionally, fills this form's
        *      chart with data.  
        * 
        * Parameters: none 
        * -------------------------------------------------------------------------------*/

        public Form5()
        {
            InitializeComponent();

            //obtain sorted data and fill the chart with data
            var sort = Program.dataList.OrderBy(x => x[6]);
            foreach (int[] x in sort)
                chart1.Series["CrimeVsSchool3"].Points.AddXY(x[6], x[0]);

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
