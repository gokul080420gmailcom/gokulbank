/* bank => repositary => bankrepositary*/

using bank.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.repositary
{
    public class bankrepositary
    {
        public static Collection<account> acc;
        public static Collection<string> alltrans;
        public bankrepositary()
        {
            set();
        }
        public void set()
        {
            if (acc == null && alltrans == null)
            {
                acc = new Collection<account>();
                alltrans = new Collection<string>();
            }
        }
        public int getaccno(int i)
        {
            return acc[i].no;
        }
        public string getaccname(int i)
        {
            return acc[i].name;
        }
        public int getaccbal(int i)
        {
            return acc[i].bal;
        }
        public string getacctype(int i)
        {
            return acc[i].type;
        }
        public account getacc(int i)
        {
            return acc[i];
        }
        public void Add(account account)
        {
            acc.Add(account);
        }
        public void addtrans(string a)
        {
            alltrans.Add(a);
        }
        public int size()
        {
            return acc.Count();
        }
        public void remove(account a)
        {
            acc.Remove(a);
        }
    }
}