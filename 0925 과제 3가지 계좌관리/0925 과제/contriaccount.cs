using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0925_과제
{
    [Serializable]
    class contriaccount :account
    {
        double contribution =0;

        public double Contribution
        {
            get { return contribution; }
            set
            {
                contribution = value;
            }
        }

        public contriaccount(string n, int id, int b) :base(n,id,b)
        {
            Balance = b - (int)(b * 0.01);
            Contribution= (int)(b * 0.01);
        }

        public override void addmoney(int money)
        {
            Contribution += (money * 0.01);
            Balance += money- (money * 0.01);
        }

        public override void  Print()
        {
            Console.WriteLine("이름 : " + Name);
            Console.WriteLine("계좌번호 : " + Id);
            Console.WriteLine("잔액 : " + Balance);
            Console.WriteLine("기부액 : " + Contribution);
        }
        public override string ToString()
        {
            string temp = string.Format("[{0}] 계좌 :{1} 잔액 : {2} 기부액 : {3}"
                                        , Name, Id, Balance, Contribution);
            return temp;
        }
    }
}
