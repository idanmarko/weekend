using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI_Color_Gray_Label_Square_Rectangle_UpDown
{
    public partial class Child : Form
    {
        public UserControl1[] arrUC = new UserControl1[2];


        public Child(string ColorOrPicture, string MinMax)
        {

            InitializeComponent();
            for (int i = 0; i < 2; i++)
            {
                arrUC[i] = new UserControl1();
                arrUC[i].Location = new Point(2, 64 + 61 * i);
                this.Controls.Add(arrUC[i]);
            }

            this.Text = ColorOrPicture;
            Min_Max_label.Text = MinMax;


            comboBoxRecOrSqr.Items.Add("Rectangle");
            comboBoxRecOrSqr.Items.Add("Square");
            comboBoxRecOrSqr.SelectedIndex = 0;
            myEventArgs.OnUserControlClicked += MyEventArgs_OnUserControlClicked;
        }

        private void MyEventArgs_OnUserControlClicked(UserControl1 instance, Label[] arrLabels)
        {
            if (arrUC.Contains(instance)==true)
            {
                myEventArgs.ChildPassSelection(comboBoxRecOrSqr.SelectedItem.ToString(), this.Text);
            }
        }

        private void Child_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
