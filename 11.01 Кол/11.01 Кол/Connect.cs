using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._01_Кол
{
    internal class Connect
    {
        public static KolEntities c;
        public static KolEntities context
        {
            get
            {
                if (c == null)
                    c = new KolEntities();
                return c;
            }
        }
    }
}
