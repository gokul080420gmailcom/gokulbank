/* bank => controllar => accountcontroller => accountmethod*/

using bank.controllar.exceptionhandel;
using bank.model;
using bank.repositary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.controllar.accountcontroller
{
    public class accountmethod
    {
       public static bankrepositary b = new bankrepositary();
        public static myownexception myown =new myownexception();
        public static void create()
        {
            try
            {
                Console.WriteLine("enter the number");
                string no1 = Console.ReadLine();
                if (myown.checkisno(no1))
                {
                    int no = Convert.ToInt16(no1);
                    if (no != 0 && checkin(no))
                    {
                        Console.WriteLine("enter the name");
                        string name = Console.ReadLine();
                        if (myown.namecheck(name))
                        {
                            string type = typeset();
                            Console.WriteLine("enter the openbal");
                            string balstr = Console.ReadLine();
                            if (myown.checkisno(balstr))
                            {
                                int bal = Convert.ToInt32(balstr);
                                account c = new account(no, name, bal, type);

                                b.Add(c);
                            }
                            else
                               throw new myexceptions("it is the balance so no other character");
                        }
                        else
                           throw new myexceptions("name not allowed other character ");
                    }
                    else throw new myexceptions("invaid acc no not be 0 or its already exit");
                }
                else throw new myexceptions("invaid acc no, it is complesary integer");
            }
            catch (Exception e)
            {
                Console.WriteLine("try again.."+e);
            }            
        }
        public static bool checkin(int no)
        {
            for (int i = 0; i < b.size(); i++)
                if (b.getaccno(i) == no)
                    return false;
            return true;
        }
        public static string typeset()
        {
            Console.WriteLine("Select the account type..");
            Console.WriteLine("1. saving");
            Console.WriteLine("2. current");
            Console.WriteLine("3. business");
            string opstr = Console.ReadLine();
            string type = "saving";
            try
            {
                if (myown.checkisno(opstr))
                {
                    int op = Convert.ToInt16(opstr);
                    
                    if (op == 1)
                        type = "saving";
                    if (op == 2)
                        type = "current";
                    if (op == 3)
                        type = "business";
                    

                }
                else throw new myexceptions("it is complesary integer");

            }
            catch (Exception e)
            {
                Console.WriteLine( "error:"+e);
            }
            return type;
        }

        public static void Update()
        {
            Console.WriteLine("Select the account type..");
            Console.WriteLine("1. Account type chance");
            Console.WriteLine("2. Account holder name");
            string opstr = Console.ReadLine();
            try
            {
                if (myown.checkisno(opstr))
                {
                    int op = Convert.ToInt32(opstr);
                    if (op == 1)
                    {
                        Console.WriteLine("enter the acc no:");
                        string idstr = Console.ReadLine();
                        if (myown.checkisno(idstr))
                        {
                            int id = Convert.ToInt32(idstr);
                            account a = seach(id);


                            if (a.no != 0)
                            {
                                // Console.WriteLine("select the choice..");
                                a.type = typeset();
                                Console.WriteLine("set successfully");
                            }
                            else Console.WriteLine("invailed");
                        }
                        else throw new myexceptions("invaid acc no, it is complesary integer");
                    }
                    if (op == 2)
                    {
                        Console.WriteLine("enter the acc no:");
                        string idstr = Console.ReadLine();
                        if (myown.checkisno(idstr))
                        {
                            int id = Convert.ToInt32(idstr);
                            account a = seach(id);
                            if (a.no != 0)
                            {
                                Console.WriteLine("enter your name:");
                                string name = Console.ReadLine();
                                if (myown.namecheck(name))
                                {
                                    a.name = name;
                                    Console.WriteLine("set sucessfull");
                                }
                                else throw new myexceptions("the name must be character");
                            }
                            else Console.WriteLine("invailed");
                        }
                        else throw new myexceptions("invaid acc no, it is complesary integer");
                    }
                }
                else throw new myexceptions("invaid option, it is complesary integer");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    
        public static account seach(int no)
        {
            int n = b.size();
            for (int i=0;i<n;i++)
            {
                if (b.getaccno(i) == no)
                    return b.getacc(i);
            }
            account c = new account(0, null, 0, null);
            return c;
        }
        public static void delete()
        {
            Console.WriteLine("enter the acc no:");
            string nostr=Console.ReadLine();
            try
            {
                if (myown.checkisno(nostr))
                {
                    int no = Convert.ToInt16(nostr);
                    account a = seach(no);
                    if (a.no != 0)
                    {
                        b.remove(a);
                        Console.WriteLine("remove successfully");
                    }
                    else
                        Console.WriteLine("there was a error..");
                }
                else throw new myexceptions("invaid acc no, it is complesary integer");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static bool find(int no)
        {
            int n = b.size();
            for (int i = 0; i < n; i++)
            {
                if (b.getaccno(i) == no)
                    return true;
            }
            return false;
        }
        public static bool deposite(int no)
        {

            account a = seach(no);
            if (a.no != 0)
            {
                Console.WriteLine("enter the amount..");
                string balstr = Console.ReadLine();
                try
                {
                    if (myown.checkisno(balstr))
                    {
                        int bal = Convert.ToInt16(balstr);
                        a.bal += bal;
                        string s = a.no+"   deposited amount   :" + bal;
                        b.addtrans(s);
                        a.trans.Add(s);
                        return true;
                    }
                    else
                        throw new myexceptions("it is the balance so no other character");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
                Console.WriteLine("invailed acc no.");
            return false;
        }
        public static int Withdraw(int no)
        {
            account a = seach(no);
            if (a.no != 0)
            {
                Console.WriteLine("enter the amount..");
                string balstr = Console.ReadLine();
                try 
                    {
                    if (myown.checkisno(balstr))
                    {
                        int bal = Convert.ToInt16(balstr);
                        if (bal <= a.bal)
                        {
                            a.bal -= bal;
                            string s = a.no+"   withdraw amount   :" + bal;
                            b.addtrans(s);
                            a.trans.Add(s);
                            return bal;
                        }
                        return 0;
                    }
                    else
                        throw new myexceptions("it is the balance so no other character");
                    }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return 0;
            }
            else
                Console.WriteLine("try again..");
            return 0;
        }
        public static bool opennetbanking(int no)
        {
            int n = b.size();
            account a=seach(no);
            if (a.no != 0)
            {
                if (a.password == null)
                {
                    Console.WriteLine("enter the password in below condition");
                    Console.WriteLine("condition 1 : caps ,  1 :spcial char  , 1 :numeric  , 1 :small char  , atleast 8 char");
                    string pass = generatepassword();
                    if (pass != null)
                    {
                        a.password = pass;
                        Console.WriteLine("set the mobil banking sucessfully");
                        return true;
                    }
                    else Console.WriteLine("try again..");
                }
                else
                    Console.WriteLine("you allready create the password..");
            }
            else Console.WriteLine("invailed");
            return false;
        }
        public static string  generatepassword()
        {

            string pss = Console.ReadLine();
            int c=0, s=0, sp=0, n=0;
            if (pss.Length >= 8)
            {
                for (int i = 0; i < pss.Length; i++)
                {
                    if (pss[i] >= 65 && pss[i] <= 90)
                        c++;
                    else if (pss[i] >= 97 && pss[i] <= 122)
                        s++;
                    else if (pss[i] >= 48 && pss[i] <= 57)
                        n++;
                    else if (pss[i] == ' ')
                        return null;
                    else
                        sp++;
                }
                if (c >= 1 && s >= 1 && n >= 1)
                    return pss;
            }
            return null;
        }
 
    }
}