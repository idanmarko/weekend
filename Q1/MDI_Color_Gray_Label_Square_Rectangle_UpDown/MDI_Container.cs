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
    public partial class MDI_Container : Form
    {
        private Child[] arrChild = new Child[2];
        private Random mdiRand = new Random();

        private const string COLOR = "Color";
        private const string PICTURE = "Picture";
        private const string MIN = "Min";
        private const string MAX = "Max";
        private const string RECTANGLE = "Rectangle";
        private const string SQUARE = "Square";

        public MDI_Container()
        {
            InitializeComponent();

            string[] arrColorOrPicture = { COLOR, PICTURE };
            ShakeArray(arrColorOrPicture);

            string[] arrMinMax = { MIN, MAX };
            ShakeArray(arrMinMax);

            for (int i = 0; i < 2; i++)
            {
                arrChild[i] = new Child(arrColorOrPicture[i], arrMinMax[i]);
                arrChild[i].StartPosition = FormStartPosition.Manual;
                arrChild[i].Location = new Point(0, 223 * i);
                arrChild[i].Show();
                arrChild[i].MdiParent = this;
            }
            myEventArgs.OnChildPassSelection += MyEventArgs_OnChildPassSelection;
        }

        private void MyEventArgs_OnChildPassSelection(string BoxRecOrSqr, string childContent, UserControl1 usercontrol, Label[] arrLabels)
        {
            var newLabelArr = new Label[] { };


            switch (BoxRecOrSqr)
            {
                case "Rectangle":
                    {
                        newLabelArr = arrLabels.Where(x => x.Width / x.Height != 1).ToArray();
                        break;
                    }
                case "Square":
                    {
                        newLabelArr = arrLabels.Where(x => x.Width / x.Height == 1).ToArray();
                        break;
                    }
            }
            switch (childContent)
            {
                case COLOR:
                    {
                        newLabelArr = newLabelArr.Where(x => x.Image == null).ToArray();
                        break;
                    }
                case PICTURE:
                    {
                        newLabelArr = newLabelArr.Where(x => x.Image != null).ToArray();
                        break;
                    }
            }
            usercontrol.updateLabelArray(newLabelArr);
        }

        private void ShakeArray(string[] arr)
        {
            if (mdiRand.Next(2) == 0)
            {
                string temp = arr[0];
                arr[0] = arr[1];
                arr[1] = temp;
            }
        }
    }
}
