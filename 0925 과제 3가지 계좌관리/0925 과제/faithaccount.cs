using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0925_과제
{
    [Serializable]
    class faithaccount : account
    {
 
        public faithaccount(string n, int id, int b) : base(n, id, b)
        {
            Balance = b +(b * 0.01);
        }

        public override void addmoney(int money)
        {
            Balance += money +(money * 0.01);
        }

    }
}

