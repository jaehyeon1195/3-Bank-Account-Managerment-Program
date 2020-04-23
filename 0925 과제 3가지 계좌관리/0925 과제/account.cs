using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0925_과제
{
    [Serializable]
    class account
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        private double balance;
        public int Acc { get; private set; }

        public double Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)
                    balance = value;
            }
        }

        public account(string n,int id,int b)
        {
            Name = n;
            Id = id;
            Balance = b;
        }

        public virtual void addmoney(int money)
        {
            Balance += money;
        }

        public void MinMoney(int money)
        {
            Balance -= money;
        }

        public virtual void Print()
        {
            Console.WriteLine("이름 : " + Name);
            Console.WriteLine("계좌번호 : " + Id);
            Console.WriteLine("잔액 : " + Balance);
        }
        public override string ToString()
        {
            string temp = string.Format("[{0}] 계좌 : {1} 잔액 : {2}", Name, Id, Balance);
            return temp;
        }
    }
}
