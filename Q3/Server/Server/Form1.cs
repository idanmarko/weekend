using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using Common;

namespace Server
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();
            HttpChannel chnl = new HttpChannel(1234);
            ChannelServices.RegisterChannel(chnl, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(ServerPart),
                "_Server_",
                WellKnownObjectMode.Singleton);

        }

    }

    class ServerPart : MarshalByRefObject, ICommon
    {
        public List<T> genericList<T>()
        {
            List<T> lst = new List<T>();
            return lst;
        }
        public ServerPart()
        {
            rectangleList = genericList<clsItem>();
            squareList = genericList<clsItem>();
        }
        public int ClientId { get; set; }
        public List<clsItem> rectangleList { get; set; }
        public List<clsItem> squareList { get; set; }
        public int connect()
        {
            return ++ClientId;
        }

        public void setItem(clsItem item)
        {
            if (item.size.Height / item.size.Width == 1)
            {
                squareList.Add(item);
            }
            else
            {
                rectangleList.Add(item);
            }
        }
        public clsItem[] GetItems(string shape, string type)
        {

            if (shape == "Rectangle")
            {
                return rectangleList.Where(x => x.type == type).ToArray();
            }

            else if (shape == "Square")
            {
                return squareList.Where(x => x.type == type).ToArray();
            }
            else
            {
                return null;
            }
        }


    }


}