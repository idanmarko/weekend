using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class clsItem
    {
        public Point point { get; set; }
        public Size size { get; set; }
        public string type { get; set; }
        public int clientId { get; set; }
        public Color color { get; set; }

    }

    [Serializable]
    public class items
    {
        public List<T> genericList<T>()
        {
            List<T> lst = new List<T>();
            return lst;
        }
    }


  
}
