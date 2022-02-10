using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedGreenBlue_ButtonLabel_Transport_UserControl
{
    public partial class UserControl1 : UserControl
    {
        static Random myRand = new Random();
        public Control[] arrControls;
        public UserControl1(int width, int maxCounter, string fullEmpty, string ButtonLabel)
        {
            InitializeComponent();
            arrControls = new Control[maxCounter];
            this.Width = width;

            int commonWidth = 2; 
            if (fullEmpty == "Full")
            {
                for (int i = 0; commonWidth < width; i++)
                {
                    int tempWidth = myRand.Next(12, 42);
                    if(commonWidth + tempWidth + 2 > width)
                        break;

                    if (ButtonLabel == "Button")
                        arrControls[i] = new Button();
                    else
                        arrControls[i] = new Label();
                    arrControls[i].Size = new Size(tempWidth, 30);
                    switch (myRand.Next(3))
                    {
                        case 0: arrControls[i].BackColor = Color.Red; break;
                        case 1: arrControls[i].BackColor = Color.Green; break;
                        case 2: arrControls[i].BackColor = Color.Blue; break;
                    }

                    arrControls[i].Text = myRand.Next(1, maxCounter + 1).ToString();
                    arrControls[i].Location = new Point(commonWidth, 3);
                    commonWidth += tempWidth + 2;
                    this.Controls.Add(arrControls[i]);
                }
            }
        }
    }
}
