/*
  _______________________________________________________________
 /                                                               \
||  Course: CSCI-473    Assignment #: 4    Semester: Fall 2018   ||
||                                                               ||
||  NAME1:  Aaron Fosco                    Z-ID: z1835687        ||
||                                                               ||
||  NAME2:  Marco Martinez                 Z-ID: z1767068        ||
||                                                               ||
||  TA's Name: Shivasupraj Pasham                                ||
||                                                               ||
||  Due: Thursday 11/1/2018 by 11:59PM                           ||
||                                                               ||
||  Description:                                                 ||
||    A very simple paint program that allows you to draw, save  ||
||    and open images.                                           ||
 \_______________________________________________________________/
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign_4
{
    public partial class Form1 : Form
    {
        /* -------------------------------------------------------------------------------
        * Constructor: Form1
        * 
        * Use: Constructs a new Dirived Form object.
        * 
        * Parameters: none 
        * -------------------------------------------------------------------------------*/
        public Form1()
        {
            InitializeComponent();

            //Generate a new graphics object for displaying images
            g = DrawPanel.CreateGraphics();

            //Creates a new bitmap that is the same size as the drawing field, and sets it to all white
            Canvas = new Bitmap(DrawPanel.Size.Width, DrawPanel.Size.Height);
            DrawPanel.DrawToBitmap(Canvas, new Rectangle(0, 0, DrawPanel.Size.Width, DrawPanel.Size.Height));

            //Generate a new graphics object for saving images
            bitmapg = Graphics.FromImage(Canvas);

            //Initialize Variables.
            DrawCurrentColor = Color.Black;
            DrawBackgroundColor = Color.White;
            BackgroundButton.BackColor = Color.White;

            RecentFiles.Add(SaveHold1);
            RecentFiles.Add(SaveHold2);
            RecentFiles.Add(SaveHold3);
            RecentFiles.Add(SaveHold4);
            RecentFiles.Add(SaveHold5);
        }

        //Reserve Variable names
        Graphics g, bitmapg;
        Pen p;
        Nullable<int> XPos = null;
        Nullable<int> YPos = null;
        char DrawingMedium = 'p';
        bool AnythingDrawn = false;
        bool MouseHeldDown = false;
        Bitmap Canvas;
        Stack<Bitmap> UndoStack = new Stack<Bitmap>();
        Stack<Bitmap> RedoStack = new Stack<Bitmap>();
        Color DrawCurrentColor;
        Color DrawBackgroundColor;
        String CurrentSaveName = null;
        ImageFormat CurrentImageFormat = ImageFormat.Png;
        List<System.Windows.Forms.ToolStripMenuItem> RecentFiles = new List<ToolStripMenuItem>();
        int PositionInRecentFileArray = 0;

        /* -------------------------------------------------------------------------------
        * Function: PencilButton_Click
        * 
        * Use: Sets the DrawingMedium flag
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void PencilButton_Click(object sender, EventArgs e)
        {
            DrawingMedium = 'p';
            CurrentMediumLabel.Text = "Pencil";
        }

        /* -------------------------------------------------------------------------------
        * Function: BrushButton_Click
        * 
        * Use: Sets the DrawingMedium flag
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void BrushButton_Click(object sender, EventArgs e)
        {
            DrawingMedium = 'b';
            CurrentMediumLabel.Text = "Brush";
        }

        /* -------------------------------------------------------------------------------
        * Function: EraserButton_Click
        * 
        * Use: Sets the DrawingMedium flag
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void EraserButton_Click(object sender, EventArgs e)
        {
            DrawingMedium = 'e';
            CurrentMediumLabel.Text = "Eraser";
        }

        /* -------------------------------------------------------------------------------
        * Function: LineButton_Click
        * 
        * Use: Sets the DrawingMedium flag
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void LineButton_Click(object sender, EventArgs e)
        {
            DrawingMedium = 'l';
            CurrentMediumLabel.Text = "Draw Line";
        }

        /* -------------------------------------------------------------------------------
        * Function: ColorButton_Click
        * 
        * Use: Changes the current color
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void ColorButton_Click(object sender, EventArgs e)
        {
            //gets the color of the clicked box, and sets The current color to it
            TextBox ClickedBox = (TextBox)sender;
            DrawCurrentColor = ClickedBox.BackColor;
            DrawPanel.Focus();
        }

        /* -------------------------------------------------------------------------------
        * Function: DrawPanel_MouseDown
        * 
        * Use: Saves current image onto the Undo stack & clears Redo stack. Creates a pen
        *      for the 1st of 3 parts for the draw event
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             MouseEventArs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            //We drew somthing
            AnythingDrawn = true;

            //clear redostack since we drew somthing
            if (RedoStack.Any())
            {
                while (RedoStack.Any())
                    RedoStack.Pop().Dispose();

                RedoButton.Enabled = false;
            }

            //push previous image onto the stack
            UndoStack.Push(new Bitmap(Canvas));

            //trigger for drawing stuff while moving the mouse
            MouseHeldDown = true;

            //generate a new pen object based on what is currently selected
            switch (DrawingMedium)
            {
                case 'p':
                    p = new Pen(DrawCurrentColor, (float) PencilSize.Value);
                    break;
                case 'b':
                    p = new Pen(DrawCurrentColor, (float) BrushSize.Value);
                    break;
                case 'e':
                    p = new Pen(DrawBackgroundColor, (float) EraserSize.Value);
                    break;
                case 'l':
                    p = new Pen(DrawCurrentColor, 1);
                    XPos = e.X;
                    YPos = e.Y;
                    break;
                default:
                    break;
            }
        }

        /* -------------------------------------------------------------------------------
        * Function: DrawPanel_MouseMove
        * 
        * Use: Draws a line between the previous mouse position and the current one iif
        *      DrawLine isn't selected. 2nd part of 3 in the draw event
        *      
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             MouseEventArs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            //If mousedown wass called, start/continue drawing
            if (MouseHeldDown)
            {
                //draw a 'line' on our canvas & on our drawpanel based on what tool we have selected
                switch (DrawingMedium)
                {
                    case 'p':
                        bitmapg.DrawLine(p, new Point(XPos ?? e.X, YPos ?? e.Y), new Point(e.X, e.Y));
                        g.DrawImage(Canvas, Point.Empty);
                        XPos = e.X;
                        YPos = e.Y;
                        break;
                    case 'b':
                        bitmapg.DrawLine(p, new Point(XPos ?? e.X, YPos ?? e.Y), new Point(e.X, e.Y));
                        g.DrawImage(Canvas, Point.Empty);
                        XPos = e.X;
                        YPos = e.Y;
                        break;
                    case 'e':
                        bitmapg.DrawLine(p, new Point(XPos ?? e.X, YPos ?? e.Y), new Point(e.X, e.Y));
                        g.DrawImage(Canvas, Point.Empty);
                        XPos = e.X;
                        YPos = e.Y;
                        break;
                    default:
                        break;
                }
            }
        }

        /* -------------------------------------------------------------------------------
        * Function: DrawPanel_MouseUp
        * 
        * Use: Clears position variables & disposes of pen. If DrawLine was clicked, it
        *      draws a line between the inital position, and the current mouse position
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             MouseEventArs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            //we can now undo our action
            UndoButton.Enabled = true;

            //we are no longer holding down the mouse button
            MouseHeldDown = false;

            //if our medium was DrawLine, finish by drawing that line
            if (DrawingMedium == 'l')
            {
                bitmapg.DrawLine(p, new Point(XPos ?? e.X, YPos ?? e.Y), new Point(e.X, e.Y));
                g.DrawImage(Canvas, Point.Empty);
            }

            //reset our start positions
            YPos = null;
            XPos = null;

            //free up resources
            if (!(p == null))
                p.Dispose();
        }

        /* -------------------------------------------------------------------------------
        * Function: ColorPicker_Click
        * 
        * Use: Changes the pen color when drawing
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void ColorPicker_Click(object sender, EventArgs e)
        {
            //let user pick a pen color with a ColorDialog
            ColorDialog ColorPickerDialog = new ColorDialog();
            if (ColorPickerDialog.ShowDialog() == DialogResult.OK)
                DrawCurrentColor = ColorPickerDialog.Color;
        }

        /* -------------------------------------------------------------------------------
        * Function: BackgroundButton_Click
        * 
        * Use: Changes the background of the Current Image
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void BackgroundButton_Click(object sender, EventArgs e)
        {
            bool result = true;

            //if there is anything on our stacks, tell the user they will be cleared.
            if(UndoStack.Any() || RedoStack.Any())
                result = (MessageBox.Show("Your Undo/Redo stack will be cleared if you change the background! Continue?", "Continue?", MessageBoxButtons.YesNo) == DialogResult.Yes);

            //if the user is OK with having their stacks cleared then continue
            if(result)
            {
                Color OldColor = DrawBackgroundColor;

                //Ask user to choose a background color
                ColorDialog ColorPickerDialog = new ColorDialog();
                if (ColorPickerDialog.ShowDialog() == DialogResult.OK)
                {
                    DrawBackgroundColor = ColorPickerDialog.Color;

                    int H = DrawPanel.Size.Height;
                    int W = DrawPanel.Size.Width;

                    //Generate a colormap to change all background color pixels to the new color
                    ColorMap[] ReplaceColorMap = new ColorMap[1];
                    ReplaceColorMap[0] = new ColorMap();
                    ReplaceColorMap[0].OldColor = OldColor;
                    ReplaceColorMap[0].NewColor = DrawBackgroundColor;
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetRemapTable(ReplaceColorMap);

                    //Redraw the image with the new background color
                    bitmapg.DrawImage(Canvas, new Rectangle(0, 0, W, H), 0, 0, W, H, GraphicsUnit.Pixel, attr);
                    g.DrawImage(Canvas, Point.Empty);

                    BackgroundButton.BackColor = DrawBackgroundColor;


                    //Free up resources
                    attr.Dispose();

                    while (RedoStack.Any())
                        RedoStack.Pop().Dispose();

                    while (UndoStack.Any())
                        UndoStack.Pop().Dispose();

                    //Our stacks are empty
                    RedoButton.Enabled = false;
                    UndoButton.Enabled = false;
                }
            }
        }

        /* -------------------------------------------------------------------------------
        * Function: RedoButton_Click
        * 
        * Use: Redoes a Previous draw action by redrawing the older image
        *         
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void RedoButton_Click(object sender, EventArgs e)
        {
            bitmapg.Dispose();

            //Save the currently drawn image to the Undostack
            UndoStack.Push(new Bitmap(Canvas));
            Canvas.Dispose();

            //Use the image off the top of our Redostack
            Canvas = RedoStack.Pop();

            //redraw image
            g.DrawImage(Canvas, Point.Empty);

            //disable the button if we dont have anything on our undostack
            if (!RedoStack.Any())
                RedoButton.Enabled = false;

            UndoButton.Enabled = true;

            //Remake our 'Persistant' Graphics object 
            bitmapg = Graphics.FromImage(Canvas);
        }

        /* -------------------------------------------------------------------------------
        * Function: UndoButton_Click
        * 
        * Use: Undos a Previous draw action by redrawing the older image
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void UndoButton_Click(object sender, EventArgs e)
        {
            bitmapg.Dispose();
            
            //Save the currently drawn image to the Redostack
            RedoStack.Push(new Bitmap(Canvas));
            Canvas.Dispose();

            //Use the image off the top of our Undostack
            Canvas = UndoStack.Pop();

            //Redraw image
            g.DrawImage(Canvas, Point.Empty);

            //disable the button if we dont have anything on our undostack
            if (!UndoStack.Any())
                UndoButton.Enabled = false;

            RedoButton.Enabled = true;

            //Remake our 'Persistant' Graphics object 
            bitmapg = Graphics.FromImage(Canvas);
        }

        /* -------------------------------------------------------------------------------
        * Function: newToolStripMenuItem_Click
        * 
        * Use: Clears the currently Drawn Image
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If anything is drawn, or if the user hasn't saved, ask if they would like to
            if (AnythingDrawn)
            {
               if (MessageBox.Show("Would you like to save your progress?", "Save?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
            }

            //save Current filename for most recent files
            if (CurrentSaveName != null)
            {
                if (PositionInRecentFileArray == 5)
                    PositionInRecentFileArray = 0;

                RecentFiles[PositionInRecentFileArray].Text = CurrentSaveName;
                RecentFiles[PositionInRecentFileArray].Enabled = true;
                PositionInRecentFileArray++;
                CurrentSaveName = null;
            }

            //Reset anythingdrawn flag & defaults
            AnythingDrawn = false;
            DrawBackgroundColor = Color.White;
            BackgroundButton.BackColor = Color.White;

            //reset resources
            Canvas.Dispose();
            Canvas = new Bitmap(DrawPanel.Size.Width, DrawPanel.Size.Height);
            bitmapg.Dispose();

            //clear stacks
            while (RedoStack.Any())
                RedoStack.Pop().Dispose();

            while (UndoStack.Any())
                UndoStack.Pop().Dispose();

            //reset buttons
            RedoButton.Enabled = false;
            UndoButton.Enabled = false;

            //this works because the "CreateGraphics" is not persistent & DrawPanel will always be 'blank'
            DrawPanel.DrawToBitmap(Canvas, new Rectangle(0, 0, DrawPanel.Size.Width, DrawPanel.Size.Height));
            bitmapg = Graphics.FromImage(Canvas);

            //Redraw our canvas on drawpanel
            g.DrawImage(Canvas, Point.Empty);
        }

        /* -------------------------------------------------------------------------------
        * Function: saveToolStripMenuItem_Click
        * 
        * Use: Saves the currently Drawn Image
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If we dont have a filename, call saveastoolstripmenueitem_click, otherwise just save
            if (CurrentSaveName == null)
                saveAsToolStripMenuItem_Click(sender, e);
            else
            {
                CurrentSaveName.Replace("\\\\", "\\");
                Canvas.Save(CurrentSaveName);
                AnythingDrawn = false;
            }

        }

        /* -------------------------------------------------------------------------------
        * Function: saveAsToolStripMenuItem_Click
        * 
        * Use: Saves the currently Drawn Image to a Location specificed by the user
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open a savefiledialog and save the picture in the place the user selects
            SaveFileDialog FileDialog = new SaveFileDialog();
            FileDialog.Filter = "Png Image |*.png";
            FileDialog.Title = "Save Image";
            FileDialog.ShowDialog();
            if (FileDialog.FileName != "")
            {
                CurrentSaveName = FileDialog.FileName;
                Canvas.Save(CurrentSaveName, CurrentImageFormat);
                AnythingDrawn = false;
            }
        }

        /* -------------------------------------------------------------------------------
        * Function: OpenSelectRecent_Click
        * 
        * Use: Opens a recent Image
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void OpenSelectRecent_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem hold = (System.Windows.Forms.ToolStripMenuItem)sender;
            string TryOpenFile = hold.Text;

            //If anything is drawn, or if the user hasn't saved, ask if they would like to
            if (AnythingDrawn)
            {
                if (MessageBox.Show("Would you like to save your progress?", "Save?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
            }

            //save Current filename for most recent files
            if (CurrentSaveName != null)
            {
                if (PositionInRecentFileArray == 5)
                    PositionInRecentFileArray = 0;

                RecentFiles[PositionInRecentFileArray].Text = CurrentSaveName;
                RecentFiles[PositionInRecentFileArray].Enabled = true;
                PositionInRecentFileArray++;
                CurrentSaveName = null;
            }

            //Reset anythingdrawn flag & defaults
            AnythingDrawn = false;
            DrawBackgroundColor = Color.White;
            BackgroundButton.BackColor = Color.White;

            //reset resources
            Canvas.Dispose();
            try
            {
                Canvas = new Bitmap(TryOpenFile);
            } catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("File Not Found!");

                //this works because the "CreateGraphics" is not persistent & DrawPanel will always be 'blank'
                DrawPanel.DrawToBitmap(Canvas, new Rectangle(0, 0, DrawPanel.Size.Width, DrawPanel.Size.Height));
            } finally
            {
                bitmapg.Dispose();

                //clear stacks
                while (RedoStack.Any())
                    RedoStack.Pop().Dispose();

                while (UndoStack.Any())
                    UndoStack.Pop().Dispose();

                //reset buttons
                RedoButton.Enabled = false;
                UndoButton.Enabled = false;

                bitmapg = Graphics.FromImage(Canvas);
                g.DrawImage(Canvas, Point.Empty);
            }
        }

        /* -------------------------------------------------------------------------------
        * Function: exitToolStripMenuItem_Click
        * 
        * Use: Exits the program
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If anything is drawn, or if the user hasn't saved, ask if they would like to
            if (AnythingDrawn)
            {
                if (MessageBox.Show("Would you like to save your progress before closing?", "Save?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
            }

            //exit
            this.Close();
        }

        /* -------------------------------------------------------------------------------
        * Function: openFileToolStripMenuItem_Click
        * 
        * Use: Opens a .png image that the user selects
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open a openfiledialog to promt the user for an image to open
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Png Image|*.png";
            openFile.Title = "Select an Image";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //If anything is drawn, or if the user hasn't saved, ask if they would like to
                if (AnythingDrawn)
                {
                    if (MessageBox.Show("Would you like to save your progress?", "Save?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        saveToolStripMenuItem_Click(sender, e);
                    }                
                }
                //save Current filename for most recent files
                if (CurrentSaveName != null)
                {
                    if (PositionInRecentFileArray == 5)
                        PositionInRecentFileArray = 0;

                    RecentFiles[PositionInRecentFileArray].Text = CurrentSaveName;
                    RecentFiles[PositionInRecentFileArray].Enabled = true;
                    PositionInRecentFileArray++;
                }

                //Reset anythingdrawn flag & defaults
                AnythingDrawn = false;
                DrawBackgroundColor = Color.White;
                BackgroundButton.BackColor = Color.White;

                CurrentSaveName = openFile.FileName;
                
                //reset resources
                Canvas.Dispose();
                bitmapg.Dispose();

                //for some reason, saving an open file will crash the program without this...
                Bitmap HoldCanvas = new Bitmap(CurrentSaveName);
                Canvas = new Bitmap(HoldCanvas);
                HoldCanvas.Dispose();

                bitmapg = Graphics.FromImage(Canvas);

                //clear stacks
                while (RedoStack.Any())
                    RedoStack.Pop().Dispose();

                while (UndoStack.Any())
                    UndoStack.Pop().Dispose();

                //reset buttons
                RedoButton.Enabled = false;
                UndoButton.Enabled = false;

                //empty canvas
                g.DrawImage(Canvas, new Rectangle(0, 0, DrawPanel.Size.Width, DrawPanel.Size.Height));
            }
        }
        /* -------------------------------------------------------------------------------
         * 
        * Function: Form1_KeyDown
        * 
        * Use: Handles hotkeys
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Z)
                {
                    if (UndoButton.Enabled == true)
                        UndoButton_Click(sender, e);
                } else if (e.KeyCode == Keys.X)
                {
                    if (RedoButton.Enabled == true)
                        RedoButton_Click(sender, e);
                } else if (e.KeyCode == Keys.S)
                {
                    saveToolStripMenuItem_Click(sender, e);
					e.SuppressKeyPress = true;
                }

            }
        }

        /* -------------------------------------------------------------------------------
        * Function: Form1_Activated
        * 
        * Use: Redraws current image when the form gains focus
        * 
        * Parameters: Sender: Refrence to the object that called this function
        *             EventArgs: The auguments passed from the calling object
        * 
        * Returns: nothing
        * -------------------------------------------------------------------------------*/

        private void Form1_Activated(object sender, EventArgs e)
        {
            //since creategraphics isn't persistant, we need to redraw the current image whenever
            //any other window may be obscuring the drawpanel
            g.DrawImage(Canvas, Point.Empty);
        }
    }
}
