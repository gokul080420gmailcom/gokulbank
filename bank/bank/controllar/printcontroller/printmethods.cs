/*bank =>controllar =>printcontroller => printmethods*/

using System;
using bank.repositary;
using bank.controllar.accountcontroller;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using bank.model;

namespace bank.controllar.printcontroller
{
    public class printmethods
    {
        public static void accountdel()
        {
            int size=bankrepositary.acc.Count();
            Console.WriteLine("-----------------------------------------------------------");
            for (int i = 0;i<size;i++)
            {
                Console.WriteLine("account no          :" + bankrepositary.acc[i].no);
                Console.WriteLine("account holder name :" + bankrepositary.acc[i].name);
                Console.WriteLine("balance             :" + bankrepositary.acc[i].bal);
                Console.WriteLine("account type        :" + bankrepositary.acc[i].type);
                string an = (bankrepositary.acc[i].password != null) ? "yes it" : "noo it";
                Console.WriteLine("netbanking status   :" + an);

            }
            Console.WriteLine("-----------------------------------------------------------");
        }
        public static void particularaccprint(int no)
        { 
            account a=accountmethod.seach(no);
            if (a.no != 0)
            {
                Console.WriteLine("account no          :" + a.no);
                Console.WriteLine("account holder name :" + a.name);
                Console.WriteLine("balance             :" + a.bal);
                Console.WriteLine("account type        :" + a.type);
                string an = (a.password != null) ? "yes it" : "noo it";
                Console.WriteLine("netbanking status   :" + an);
            }
            else
                Console.WriteLine("invail account");

        }
        public static void printalltrans()
        {
            int size = bankrepositary.alltrans.Count();
            Console.WriteLine("-------------------------------------------------");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine( bankrepositary.alltrans[i]);
            }
            Console.WriteLine("------------------------------------------------");
        }
        public static void particularacctrans(int no)
        {
            account a = accountmethod.seach(no);
            if (a.no != 0)
            {

                int size = a.trans.Count();
                Console.WriteLine("-------------------------------------------------");
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine(a.trans[i]);
                }
                Console.WriteLine("------------------------------------------------");
            }
        }
    }
}