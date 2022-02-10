using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using Common;

namespace Client
{
    public partial class Form1 : Form
    {
        int ClientId;
        private ICommon myICommon;
        private Random myRand = new Random();
        private Control[] arrControls;
        private List<Control> ServerControls;

        public Form1()
        {

            InitializeComponent();
            HttpChannel channel = new HttpChannel();
            ChannelServices.RegisterChannel(channel, false);

            myICommon = (ICommon)Activator.GetObject(
                 typeof(ICommon),
                "http://localhost:1234/_Server_");


            ClientId = myICommon.connect();

            arrControls = new Control[25];
            ServerControls = new List<Control>();
            int currPosition = 3;
            for (int i = 0; i < arrControls.Length; i++)
            {
                if (myRand.Next(2) == 0)
                    arrControls[i] = new Button();
                else
                {
                    arrControls[i] = new Label();
                    arrControls[i].AutoSize = false;
                    ((Label)arrControls[i]).TextAlign = ContentAlignment.MiddleCenter;
                }
                arrControls[i].BackColor = Color.FromArgb(myRand.Next(100, 256), myRand.Next(100, 256), myRand.Next(100, 256));
                arrControls[i].TabIndex = i;

                int temp = myRand.Next(15, 40);
                switch (myRand.Next(4))
                {
                    case 0: arrControls[i].Size = new Size(temp, temp); break;
                    case 1: arrControls[i].Size = new Size(2 * temp, 2 * temp); break;
                    case 2: arrControls[i].Size = new Size(2 * temp, temp); break;
                    case 3: arrControls[i].Size = new Size(temp, 2 * temp); break;
                }

                arrControls[i].Location = new Point(currPosition, 3);
                currPosition += arrControls[i].Size.Width + 2;
                arrControls[i].Click += new EventHandler(allControls_Click);
                this.Controls.Add(arrControls[i]);

                int type = myRand.Next(2);
                this.Text = type == 0 ? "Button" : "Label";

            }

            timer1.Interval = 500;
            timer1.Start();

        }

        private void allControls_Click(object sender, EventArgs e)
        {
            var item = new clsItem();
            var control = new Control();
            if (sender is Button)
            {
                control = sender as Button;
            }
            else if (sender is Label)
            {
                control = sender as Label;
            }
            item.type = control.GetType().Name.ToString();
            item.point = control.Location;
            item.size = control.Size;
            item.color = control.BackColor;
            item.clientId = ClientId;
            control.Dispose();
            myICommon.setItem(item);
        }


        private void radioButtonRectangleSquaare_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            string shape = string.Empty;
            if (radioButtonRectangle.Checked == true)
            {
                shape = "Rectangle";
            }
            if (radioButtonSquare.Checked == true)
            {
                shape = "Square";
            }
            var ret = myICommon.GetItems(shape, this.Text);
            foreach (Control item in ServerControls)
            {
                item.Dispose();
            }

            int position = 0;
            foreach (var item in ret)
            {
                Control c = new Control();
                ServerControls.Add(c);
                switch (item.type)
                {
                    case "Button":
                        {
                            c = new Button();
                            
                            break;
                        }
                    case "Label":
                        {
                            c = new Label();
                            break;
                        }
                }
                c.Location = new Point(position, 80);
                position += item.size.Width + 2;
                c.Size = item.size;
                c.BackColor = item.color;
                c.Text = item.clientId.ToString();

                this.Controls.Add(c);

            }

            timer1.Start();

        }
    }


}

