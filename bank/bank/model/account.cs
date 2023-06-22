/* bank => model => account */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace bank.model
{
    public class account
    {
        public int no;
        public string name;
        public int bal;
        public string type;
        public Collection<string> trans;
        public string password=null;
        public  account(int no,string name,int bal,string type)
        {
            this.no = no;
            this.name = name;
            this.bal = bal;
            this.type = type;
            trans = new Collection<string>();
        }

    }
}
