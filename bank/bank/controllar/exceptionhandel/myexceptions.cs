/* bank => controllar => exceptionhandel => myexceptions */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.controllar.exceptionhandel
{
    public class myexceptions : Exception  
    {
        public  myexceptions(string messages)
            :base(messages){ }
    }
}
