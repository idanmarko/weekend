using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace RedGreenBlue_ButtonLabel_Transport_UserControl
{

   

    public partial class Form1 : Form
    {
        private UserControl1 UC_From;
        private UserControl1[] arrUC_To = new UserControl1[3], arrUC_Transport = new UserControl1[3];
        private int width_FromTo = 1000, maxCounter_FromTo = 80, width_Transport = 150, maxCounter_Transport = 8;

        public Form1()
        {
            InitializeComponent();
            this.Width = 1025;

            UC_From = new UserControl1(width_FromTo, maxCounter_FromTo, "Full", "Label");

            UC_From.Location = new Point(2, 70);
            this.Controls.Add(UC_From);

            for (int i = 0; i < 3; i++)
            {
                arrUC_Transport[i] = new UserControl1(width_Transport, maxCounter_Transport, "Empty", "");
                arrUC_Transport[i].Location = new Point(2 + (width_Transport + 8) * i, 161);
                this.Controls.Add(arrUC_Transport[i]);

                arrUC_To[i] = new UserControl1(width_FromTo, maxCounter_FromTo, "Empty", "");
                arrUC_To[i].Location = new Point(2, 220 + 57 * i);
                this.Controls.Add(arrUC_To[i]);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var groupedList = UC_From.arrControls.Where(x => x is Label == true).GroupBy(x => x.BackColor);

            for (int i = 0; i < 3; i++)
            {

                clsItemsAndUC ItemsAndUC = new clsItemsAndUC();
                ItemsAndUC.UC_From = arrUC_Transport[i];
                ItemsAndUC.UC_To = arrUC_To[i];
                if (i == 0)
                {
                    ItemsAndUC.controls = groupedList.Where(x => x.Key == Color.Red).SelectMany(group => group).ToList();
                }
                if (i == 1)
                {
                    ItemsAndUC.controls = groupedList.Where(x => x.Key == Color.Green).SelectMany(group => group).ToList();
                }
                if (i == 2)
                {
                    ItemsAndUC.controls = groupedList.Where(x => x.Key == Color.Blue).SelectMany(group => group).ToList();
                }
                ThreadPool.QueueUserWorkItem(Collect, ItemsAndUC);
            }
        }
        public static void Collect(object obj)
        {
            clsItemsAndUC itemsAndUC = obj as clsItemsAndUC;
          
            int storageCommomWith = 2;
            
           
            move(itemsAndUC, storageCommomWith);
        }


        public static void move(clsItemsAndUC itemsAndUC, int storageCommomWith)
        {
            int maxSize = 150;
            int commonWidth = 2;
            var workingItems = new List<Control>();
            var nextWorkingItems = new List<Control>();
            if (itemsAndUC.controls.Count > 8)
            {
                workingItems = itemsAndUC.controls.Take(8).OrderBy(x => int.Parse(x.Text.ToString())).ToList();
                nextWorkingItems = itemsAndUC.controls.Skip(8).ToList();
            }
            else
            {
                workingItems = itemsAndUC.controls.ToList();
            }

            for (int i = 0; i < workingItems.Count; i++)
            {
                Thread.Sleep(100);
                int tmpNewSize = maxSize - workingItems[i].Width;
                if (tmpNewSize < 0)
                {
                    nextWorkingItems.AddRange(workingItems.Skip(i).ToList());
                    break;
                }
                else
                {
                    maxSize = maxSize - workingItems[i].Width;
                    workingItems[i].Invoke((System.Action)(() =>
                    {
                        workingItems[i].Location = new Point(commonWidth, 3);
                    }));

                    itemsAndUC.UC_From.Invoke((System.Action)(() =>
                    {
                        itemsAndUC.UC_From.Controls.Add(workingItems[i]);
                    }));

                    commonWidth += workingItems[i].Width + 2;
                }
            }

            int numberOfItems = itemsAndUC.UC_From.Controls.Count;

            while (itemsAndUC.UC_From.Controls.Count > 0)
            {
                Thread.Sleep(100);
                itemsAndUC.UC_From.Controls[0].Invoke((System.Action)(() =>
                {
                    itemsAndUC.UC_From.Controls[0].Location = new Point(storageCommomWith, 3);
                }));

                itemsAndUC.UC_To.Invoke((System.Action)(() =>
                {
                    storageCommomWith += itemsAndUC.UC_From.Controls[0].Width + 2;
                    itemsAndUC.UC_To.Controls.Add(itemsAndUC.UC_From.Controls[0]);
                    
                }));
            }
            itemsAndUC.controls = nextWorkingItems;
            if (itemsAndUC.controls.Count>0)
            {
                move(itemsAndUC, storageCommomWith);
            }
        }

    }
    public class clsItemsAndUC
    {
        public UserControl1 UC_From { get; set; }
        public UserControl1 UC_To { get; set; }
        public List<Control> controls { get; set; }
    }
}
