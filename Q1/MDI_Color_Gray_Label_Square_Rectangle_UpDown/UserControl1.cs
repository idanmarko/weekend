using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MDI_Color_Gray_Label_Square_Rectangle_UpDown
{
    public partial class UserControl1 : UserControl
    {
        public Label[] arrLabels;
        private static Random ucRand = new Random();

        public UserControl1()
        {
            InitializeComponent();
            int arrSize = ucRand.Next(12, 23);
            arrLabels = new Label[arrSize];

            int currPosition = 2;
            for (int i = 0; i < arrSize; i++)
            {
                arrLabels[i] = new Label();

                arrLabels[i].Location = new Point(currPosition, 1);
                int temp = ucRand.Next(15, 29);
                switch (ucRand.Next(4))
                {
                    case 0: arrLabels[i].Size = new Size(temp, temp); break;
                    case 1: arrLabels[i].Size = new Size(temp * 2, temp * 2); break;
                    case 2: arrLabels[i].Size = new Size(temp * 2, temp); break;
                    case 3: arrLabels[i].Size = new Size(temp, temp * 2); break;
                }
                temp = ucRand.Next(100, 250);
                switch (ucRand.Next(3))
                {
                    case 0: arrLabels[i].BackColor = Color.FromArgb(ucRand.Next(100, 256), 0, 0); break;
                    case 1: arrLabels[i].BackColor = Color.FromArgb(0, 0, ucRand.Next(100, 256)); break;
                    case 2: arrLabels[i].Image = getImage(arrLabels[i].Size); break;
                }

                currPosition += arrLabels[i].Size.Width + 2;
                this.Controls.Add(arrLabels[i]);
            }

        }


        private Image getImage(Size size)
        {
            Image image = Image.FromFile("../../teddybear.jpg");
            image = (Image)new Bitmap(image, size);

            return image;
        }

        private void UserControl1_Click(object sender, EventArgs e)
        {
            myEventArgs.userControlClicked(this, arrLabels);
        }

        public void updateLabelArray(Label[] NewArrLabels)
        {
            foreach (var item in arrLabels)
            {
                if (!NewArrLabels.Contains(item))
                {
                    item.Dispose();
                }
            }

            var ordersList = NewArrLabels.OrderBy(x => x.Width * x.Height).ToArray();
            int currPosition = 2;
            for (int i = 0; i < ordersList.Length; i++)
            {
                ordersList[i].Location = new Point(currPosition, 1);
                currPosition += ordersList[i].Size.Width + 2;
            }
            arrLabels = NewArrLabels;


            this.Refresh();
            Application.DoEvents();
        }
        private void UserControl1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
