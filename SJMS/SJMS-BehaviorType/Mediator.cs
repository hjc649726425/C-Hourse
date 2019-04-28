using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS_BehaviorType
{
    //中介者模式： 用一个中介对象来封装一系列的对象交互。中介者使各对象不需要显式地相互引用，从而使其耦合松散，而且可以独立地改变它们之间的交互。

    class Mediator
    {
        public static void DoMain()
        {
            CardPartner pa = new PA(500);
            CardPartner pb = new PC(100);
            CardPartner pc = new PC(100);

            MidPartner jack = new Mid_Jack(pa);
            jack.addPartner(pb);
            jack.addPartner(pc);

            pa.WinMoney(10, jack);
            Console.WriteLine("A.Money" + pa.Money);
            Console.WriteLine("B.Money" + pb.Money);
            Console.WriteLine("C.Money" + pc.Money);

            pa.lossMoney(5, jack);
            Console.WriteLine("A.Money" + pa.Money);
            Console.WriteLine("B.Money" + pb.Money);
            Console.WriteLine("C.Money" + pc.Money);
        }
    }

    interface CardPartner
    {
        int Money { get; set; }

        void WinMoney(int money, MidPartner mid);

        void lossMoney(int money, MidPartner mid);
    }

    interface MidPartner
    {
        void addPartner(CardPartner partner);
        void rmovePartner(CardPartner partner);
        void winMoney(int money);

        void lossMoney(int money);
    }

    class Mid_Jack : MidPartner
    {
        private List<CardPartner> list = new List<CardPartner>();  //参与者

        private CardPartner partner;    //庄家

        public Mid_Jack(CardPartner partner)
        {
            this.partner = partner;
        }

        public void addPartner(CardPartner partner)
        {
            list.Add(partner);
        }

        public void winMoney(int money)
        {
            partner.Money += money * list.Count;
            list.ForEach(list =>
            {
                list.Money -= money;
            });
        }

        public void lossMoney(int money)
        {
            partner.Money -= money * list.Count;
            list.ForEach(list =>
            {
                list.Money += money;
            });
        }

        public void rmovePartner(CardPartner partner)
        {
            list.Remove(partner);
        }
    }
    class PA : CardPartner
    {

        public int Money
        {
            get; set;
        }

        public PA(int money)
        {
            Money = money;
        }


        public void lossMoney(int money, MidPartner mid)
        {
            mid.lossMoney(money);
        }

        public void WinMoney(int money, MidPartner mid)
        {
            mid.winMoney(money);
        }
    }

    class PB : CardPartner
    {
        public int Money
        {
            get; set;
        }

        public PB(int money)
        {
            Money = money;
        }


        public void lossMoney(int money, MidPartner mid)
        {
            mid.lossMoney(money);
        }

        public void WinMoney(int money, MidPartner mid)
        {
            mid.winMoney(money);
        }
    }

    class PC : CardPartner
    {
        public int Money
        {
            get; set;
        }

        public PC(int money)
        {
            Money = money;
        }


        public void lossMoney(int money, MidPartner mid)
        {
            mid.lossMoney(money);
        }

        public void WinMoney(int money, MidPartner mid)
        {
            mid.winMoney(money);
        }
    }
}
