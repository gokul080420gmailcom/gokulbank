/* bank => controllar => translactioncontroller => translationmethods*/


using bank.controllar.accountcontroller;
using bank.controllar.exceptionhandel;
using bank.model;
using bank.repositary;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.controllar.translactioncontroller
{
    public class translationmethods
    {
        public static  bankrepositary bb = new bankrepositary();
        public static myownexception myown=new myownexception();
        public static void translation()
        {
            Console.WriteLine("select the options");
            Console.WriteLine("1. deposit");
            Console.WriteLine("2. withdraw");
            Console.WriteLine("3. net banking");
            string opstr = Console.ReadLine();
            try
            {
                if (myown.checkisno(opstr))
                {
                    int op = Convert.ToInt32(opstr);
                    Console.WriteLine("enter the acc no");
                    string nostr = Console.ReadLine();
                    if (myown.checkisno(nostr))
                    {
                        int no = Convert.ToInt32(nostr);
                        if (op == 1)
                        {
                            if (accountmethod.deposite(no))
                            {
                                //  s1 = "deposited amount    :" + 0;
                                Console.WriteLine("deposit successfully");
                            }

                        }
                        else if (op == 2)
                        {
                            int bal = accountmethod.Withdraw(no);
                            if (bal > 0)
                            {
                                //s1 = "withdraw amount   :" + bal;
                                //bb.addtrans(s1);

                                //a.trans.Add(s);
                                Console.WriteLine("withdraw sucessfully");
                            }
                        }
                        else if (op == 3)
                        {
                            mobilebanking(no);
                        }
                    }
                    else throw new myexceptions("invaid acc no, it is complesary integer");

                }
                else throw new myexceptions("invaid option, it is complesary integer");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
                
        }
        public static bool mobilebanking(int no)
        {
            
            account a = accountmethod.seach(no);
            try {
                if (a.no != 0)
                {

                    if (a.password != null)
                    {
                        Console.WriteLine("enter the password");
                        String pass = Console.ReadLine();
                        if (pass == a.password)
                        {

                            Console.WriteLine("enter the resiver acc no");
                            string accnostr = Console.ReadLine();

                            if (myown.checkisno(accnostr))
                            {
                                int accno = Convert.ToInt16(accnostr);
                                account b = accountmethod.seach(accno);
                                if (b.no != 0)
                                {

                                    int cheak = accountmethod.Withdraw(no);
                                    if (cheak != 0)
                                    {
                                        b.bal += cheak;
                                        //b.trans.Add(b.no + "   deposited amount   :" + cheak);
                                        string s = a.trans[a.trans.Count - 1];
                                        string n = "";
                                        for (int i = s.Length - 1; s[i] >= 48 && s[i] <= 57; i--)
                                            n = (s[i] - 48) + n;
                                        bankrepositary.alltrans.RemoveAt(bankrepositary.alltrans.Count - 1);
                                        bb.addtrans("the amount " + n + "transfer from  " + a.no + " to " + b.no);
                                        a.trans.RemoveAt(a.trans.Count - 1);
                                        a.trans.Add("amount  " + n + "   transfer to " + b.no);

                                        /*string s1= b.trans[b.trans.Count - 1];
                                         n = "";
                                        for (int i = s1.Length - 1; s1[i] >= 48 && s1[i] <= 57; i--)
                                            n = (s1[i] - 48) + n;*/


//b.trans.RemoveAt((b.trans.Count) - 1);
b.trans.Add("amount  " + n + "   create from " + a.no);


                                        Console.WriteLine("translation completed");
                                        return true;
                                    }
                                    else
                                        Console.WriteLine("translation failed");
                                    return false;
                                }
                                else
                                    Console.WriteLine("invaid acc no");
                            }
                            else throw new myexceptions("invaid acc no, it is complesary integer");
                        }
                        else
                            Console.WriteLine("invaid password");
                    }

                    else
                    {
                        Console.WriteLine("you not have mobile banking");
                        Console.WriteLine("if you want create mobile banking");
                        Console.WriteLine("press   1  :");
                        string op = Console.ReadLine();
                        if (myown.checkisno(op))
                        {
                            if (Convert.ToInt16(op) == 1)
                            {
                                if (accountmethod.opennetbanking(no))
                                {
                                    Console.WriteLine("do you want to continue transtraction..");
                                    Console.WriteLine("press  1:");
                                    string op1str = Console.ReadLine();
                                    if (myown.checkisno(op1str))
                                    {
                                        int op1 = Convert.ToInt16(op1str);
                                        if (op1 == 1)
                                            mobilebanking(no);
                                    }
                                    else throw new myexceptions("invailed option , option its must be ingeter");
                                }
                            }
                        }
                        else throw new myexceptions("invailed option , option its must be ingeter");
                    }
                }
                else
                    Console.WriteLine("invaid acc");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
    }
}