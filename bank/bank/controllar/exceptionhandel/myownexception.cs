/* bank => controllar => exceptionhandel => myownexception */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace bank.controllar.exceptionhandel
{
    public class myownexception
    {
        public bool namecheck(string name)
        {
            int c = 0;
            try
            {
                foreach (var a in name)
                    if (!((a >= 65 && a <= 90) || (a >= 97 && a <= 122) || a == ' '))
                    {
                        c = 1;
                        //throw new myexceptions("name not allowed other character ");
                        
                    }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            if(c==0)
            return true;
            else
                return false;
        }
        public bool checkisno(string no)
        {
            int c = 0;
            try
            {
                foreach (var a in no)
                    if (!(a >= 48 && a <= 57))
                    {
                        c = 1;
                       // throw new myexceptions("no is allowed only interger ");
                        
                    }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            if(c==0)
            return true;
            else return false;
        }


    }
}
