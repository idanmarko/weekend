using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI_Color_Gray_Label_Square_Rectangle_UpDown
{


    public class myEventArgs : EventArgs
    {
        public static UserControl1 m_usercontrol { get; set; }
        public static Label[] m_arrLabels { get; set; }
        public static string m_BoxRecOrSqr { get; set; }

        public delegate void dl_userControlClicked(UserControl1 instance, Label[] arrLabels);
        public static event dl_userControlClicked OnUserControlClicked;
        public static void userControlClicked(UserControl1 usercontrol, Label[] arrLabels)
        {
            //m_child = child;
            m_usercontrol = usercontrol;
            m_arrLabels = arrLabels;
            if (OnUserControlClicked != null)
            {
                OnUserControlClicked(usercontrol, arrLabels);
            }
        }


        public delegate void dl_ChildPassSelection(string BoxRecOrSqr, string childContent, UserControl1 usercontrol, Label[] arrLabels);
        public static event dl_ChildPassSelection OnChildPassSelection;
        public static void ChildPassSelection(string BoxRecOrSqr,string childContent)
        {
            m_BoxRecOrSqr = BoxRecOrSqr;
            if (OnChildPassSelection != null)
            {
                OnChildPassSelection(BoxRecOrSqr, childContent, m_usercontrol, m_arrLabels);
            }
        }



       

    }
}
