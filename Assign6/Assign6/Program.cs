using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign6
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static List<int[]> dataList = new List<int[]>();
        [STAThread]
        static void Main()
        {
            using (StreamReader inFile = new StreamReader("..\\..\\mlr06.csv")) //throws System.IO.FileNotFoundException
            {

                /*
                 * Generally, this read will work for almost all correctly
                 * formatted .csv files.
                 * Assumed format:
                 *    1st observation @ line 2
                 *    No null values (IE ",,")
                 *    all int values
                 *    regular .csv standards
                 *    
                 * (for the charts, however, it is assumed the .csv is is 
                 *   the provided file "mlr60.csv")
                 */
                string holder;
                holder = inFile.ReadLine();
                while (!inFile.EndOfStream)
                {
                    holder = inFile.ReadLine();
                    dataList.Add(Array.ConvertAll(holder.Split(','), int.Parse));
                }
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
