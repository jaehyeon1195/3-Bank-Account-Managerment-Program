using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0925_과제
{
    class control
    {
        //저장소========================
        wbarray array = null;
        //==============================

        public void filesave()
        {
            //wbfile.filesave(array.Memlist,array.Size);
            wbfile.filesersave(array.Acclist, array.Size);
        }
        public void fileload()
        {
            try
            {
                //member[] arr=wbfile.fileload();
                int max;
                account[] arr = wbfile.fileserload(out max);
                array = new wbarray(max);

                for (int i = 0; i < arr.Length; i++)
                {
                    account mem = arr[i];
                    array.insert(mem);
                }
            }
            catch (FileNotFoundException)
            {
                //파일이 없으니깐 배열객체를 생성하겠다.
                int size = wblib.inputnumber("배열의 크기");
                array = new wbarray(size);
            }
        }

            public void printall()
        {
            Console.WriteLine("저장개수 : {0}개", array.Size);
            for (int i = 0; i < array.Size; i++)
            {
                account mem = (account)array.getdata(i);
                Console.WriteLine(mem);
            }
        }
        public void insert()
        {
            try
            {
                string acc = wblib.inputstring("[1]일반, [2] 신용, [3] 기부");
                string name = wblib.inputstring("이름");
                int id = wblib.inputnumber("계좌번호");
                int balance = wblib.inputnumber("잔액");

                switch (acc)
                {
                    case "1":
                        array.insert(new account(name, id, balance));
                        Console.WriteLine("일반계좌 생성 완료"); break;

                    case "2":
                        array.insert(new faithaccount(name, id, balance));
                        Console.WriteLine("신용계좌 생성 완료"); break;

                    case "3":
                        array.insert(new contriaccount(name, id, balance));
                        Console.WriteLine("기부계좌 생성 완료");
                        break;

                    default: Console.WriteLine("잘못된 계좌종류"); break;
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("입력 오류");
                Console.WriteLine(">> " + ex.Message);
            }

        }

        private int idtoidx(int id)
        {
            for (int i = 0; i < array.Size; i++)
            {
                account acc = (account)array[i];
                if (acc.Id.Equals(id) == true)
                    return i;
            }
            throw new Exception("잘못된 계좌");
        }

       
        public void deposit()
        {
            try
            {
                int id = wblib.inputnumber("계좌 ID");
                int money = wblib.inputnumber("입금액");

                if (money <0)
                {
                    Console.WriteLine("잘못된 금액");
                    return;
                }

                account mem = (account)array[idtoidx(id)];


                //new 키워드를 사용하면 기반 형식의 변수로 다양한 파생개체를 참조할때
                //실제개체에 정의된 멤버가 사용되지않는다.
                //그래서 virtual ,override로 바꿨습니다
                //if (mem is contriaccount)
                //{
                //    contriaccount conmem = (contriaccount)mem;
                //    conmem.addmoney(money);
                //}
                //else if (mem is faithaccount)
                //{
                //    faithaccount faitmem = (faithaccount)mem;
                //    faitmem.addmoney(money);
                //}
                //else

                mem.addmoney(money);

            }
            catch (Exception ex)
            {
                Console.WriteLine("입금 오류");
                Console.WriteLine(">> " + ex.Message);
            }


        }

        public void Withdraw()
        {
            try
            {
                int id = wblib.inputnumber("계좌 ID");
                int money = wblib.inputnumber("출금액");
                account mem = (account)array[idtoidx(id)];

                if (money < 0 || mem.Balance<money)
                {
                    Console.WriteLine("잘못된 금액");
                    return;
                }

                mem.MinMoney(money);          

            }
            catch (Exception ex)
            {
                Console.WriteLine("출금 오류");
                Console.WriteLine(">> " + ex.Message);
            }
        }

        public void Inquire()
        {
            int id = wblib.inputnumber("검색할 계좌 ID");
            account mem = (account)array[idtoidx(id)];
            Console.WriteLine(mem);
        }
    }
}
