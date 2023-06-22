/*bank => program*/

using bank.controllar.accountcontroller;
using bank.controllar.exceptionhandel;
using bank.controllar.printcontroller;
using bank.controllar.translactioncontroller;
using bank.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string g=null;
            // string an = (g != null) ? "yes it" : "noo it";
            //Console.WriteLine(an);
            //Console.WriteLine("let started...");
            myownexception myown = new myownexception();
            accountmethod a = new accountmethod();
            while (true)
            {
                Console.WriteLine("select the option..");
                Console.WriteLine("1 .create account ");
                Console.WriteLine("2. update account");
                Console.WriteLine("3. delete account");
                Console.WriteLine("4. search account");
                Console.WriteLine("5. open net banking");
                Console.WriteLine("6. transtraction");
                Console.WriteLine("7. view  (print acc and trans)");
                string nostr = Console.ReadLine();
                try
                {
                    if (myown.checkisno(nostr))
                    {
                        int no = Convert.ToInt32(nostr);
                        if (no == 1)
                            accountmethod.create();
                        else if (no == 2)
                            accountmethod.Update();
                        else if (no == 3)
                            accountmethod.delete();
                        else if (no == 4)
                        {
                            Console.WriteLine("enter the account no:");
                            string idstr = Console.ReadLine();
                            if (myown.checkisno(idstr))
                            {
                                int id = Convert.ToInt16(idstr);
                                //account a=accountmethod.seach(id);
                                printmethods.particularaccprint(id);
                            }
                            else throw new myexceptions("invailed acc no,it is must be integer");
                        }
                        else
                         if (no == 5)
                        {
                            Console.WriteLine("enter the account no:");
                            string idstr = Console.ReadLine();
                            if (myown.checkisno(idstr))
                            {
                                int id = Convert.ToInt16(idstr);
                                accountmethod.opennetbanking(id);
                            }
                            else throw new myexceptions("invailed acc no,it is must be integer");
                        }
                        else if (no == 6)
                            translationmethods.translation();
                        else if (no == 7)
                        {
                            Console.WriteLine("select the options..");
                            Console.WriteLine("1. print account detail");
                            Console.WriteLine("2. print transtraction");
                            string op2str = Console.ReadLine();
                            if (myown.checkisno(op2str))
                            {

                                int op2 = Convert.ToInt32(op2str);
                                if (op2 == 1)
                                {
                                    Console.WriteLine("select the options..");
                                    Console.WriteLine("1. particular account detail");
                                    Console.WriteLine("2. all account detail");
                                    string op3str = Console.ReadLine();
                                    if (myown.checkisno(op3str))
                                    {
                                        int op3 = Convert.ToInt32(op3str);
                                        if (op3 == 1)
                                        {
                                            Console.WriteLine("enter the account no:");
                                            string idstr = Console.ReadLine();
                                            if (myown.checkisno(idstr))
                                            {
                                                int id = Convert.ToInt16(idstr);
                                                //account a=accountmethod.seach(id);
                                                printmethods.particularaccprint(id);
                                            }
                                            else throw new myexceptions("invailed acc no:it is must be ingeter");
                                        }
                                        if (op3 == 2)
                                            printmethods.accountdel();
                                    }
                                    else throw new myexceptions("invailed option:option must be integer");
                                }
                                else if (op2 == 2)
                                {
                                    Console.WriteLine("select the options..");
                                    Console.WriteLine("1. particular account transration");
                                    Console.WriteLine("2. all transtraction");
                                    string op3str = Console.ReadLine();
                                    if (myown.checkisno(op3str))
                                    {
                                        int op3 = Convert.ToInt32(op3str);


                                        if (op3 == 1)
                                        {
                                            Console.WriteLine("enter the account no:");
                                            string idstr = Console.ReadLine();
                                            if (myown.checkisno(idstr))
                                            {
                                                int id = Convert.ToInt16(idstr);
                                                //account a=accountmethod.seach(id);
                                                printmethods.particularacctrans(id);
                                            }
                                            else
                                                throw new myexceptions("invailed acc no:it must be integer");
                                        }
                                        if (op3 == 2)
                                            printmethods.printalltrans();
                                    }
                                    else
                                        throw new myexceptions("options must be integer");
                                }
                                else break;
                            }
                            else throw new myexceptions("invailed option:option must be integer");
                        }
                    }
                    else throw new myexceptions("invailed option:option must be integer");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}

