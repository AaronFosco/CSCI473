/*
  _______________________________________________________________
 /                                                               \
||  Course: CSCI-473    Assignment #: 6    Semester: Fall 2018   ||
||                                                               ||
||  NAME1:  Aaron Fosco                    Z-ID: z1835687        ||
||                                                               ||
||  TA's Name: Shivasupraj Pasham                                ||
||                                                               ||
||  Due: Thursday 11/29/2018 by 11:59PM                          ||
||                                                               ||
||  Description:                                                 ||
||   This is the file containing main form. From this form, the  ||
||   user will be able to navigate from one chart to another by  ||
||   clicking each of the buttons.                               ||
||                                                               ||
||   * * * NOTE * * *                                            ||
||   There is only one name on this assignment as Rogness        ||
||   Allowed me to separate from my partner since he didn't      ||
||   really contribute more than 10% on any of the assignments.  ||
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
    public partial class Form1 : Form
    {
        /* -------------------------------------------------------------------------------
        * Constructor: Form1
        * 
        * Use: Constructs a new Derived Form object.
        * 
        * Parameters: none 
        * -------------------------------------------------------------------------------*/

        public Form1()
        {
            InitializeComponent();
        }

        /* -------------------------------------------------------------------------------
        * Function: ScatterButton_Click
        * 
        * Use: Hides this form and open/show a new form
        *      
        * Parameters: Sender: Reference to the object that called this function
        *             EventArgs: The arguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void ScatterButton_Click(object sender, EventArgs e)
        {
            //generate new form & attach event handler
            Form2 f2 = new Form2();
            f2.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.externForm_Close);

            //hide this form and show new form
            this.Hide();
            f2.Show();
        }

        /* -------------------------------------------------------------------------------
        * Function: BarButton_Click
        * 
        * Use: Hides this form and open/show a new form
        *      
        * Parameters: Sender: Reference to the object that called this function
        *             EventArgs: The arguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void BarButton_Click(object sender, EventArgs e)
        {
            //generate new form & attach event handler
            Form3 f3 = new Form3();
            f3.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.externForm_Close);

            //hide this form and show new form
            this.Hide();
            f3.Show();
        }

        /* -------------------------------------------------------------------------------
        * Function: LineButton_Click
        * 
        * Use: Hides this form and open/show a new form
        *      
        * Parameters: Sender: Reference to the object that called this function
        *             EventArgs: The arguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void LineButton_Click(object sender, EventArgs e)
        {
            //generate new form & attach event handler
            Form4 f4 = new Form4();
            f4.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.externForm_Close);

            //hide this form and show new form
            this.Hide();
            f4.Show();
        }

        /* -------------------------------------------------------------------------------
        * Function: BubbleButton_Click
        * 
        * Use: Hides this form and open/show a new form
        *      
        * Parameters: Sender: Reference to the object that called this function
        *             EventArgs: The arguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void BubbleButton_Click(object sender, EventArgs e)
        { 
           //generate new form & attach event handler 
            Form5 f5 = new Form5();
            f5.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.externForm_Close);

            //hide this form and show new form
            this.Hide();
            f5.Show();
        }

        /* -------------------------------------------------------------------------------
        * Function: externForm_Close
        * 
        * Use: Called when other forms were closed. this event handler will show this main form.
        *      
        * Parameters: Sender: Reference to the object that called this function
        *             EventArgs: The arguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void externForm_Close(object sender, EventArgs e)
        {
            this.Show();
        }

        /* -------------------------------------------------------------------------------
        * Function: ExitButton_Click
        * 
        * Use: Closes this form to return to the main form
        *      
        * Parameters: Sender: Reference to the object that called this function
        *             EventArgs: The arguments passed from the calling object
        * 
        * Returns: Nothing
        * -------------------------------------------------------------------------------*/

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
