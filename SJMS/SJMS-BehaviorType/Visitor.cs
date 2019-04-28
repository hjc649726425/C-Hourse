using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS_BehaviorType
{

    //访问者模式
    //表示一个作用于某对象结构中的各元素的操作。
    //    它使你可以在不改变各元素的类的前提下定义作用于这些元素的新操作。

    class Visitor
    {
        public static void DoMain()
        {
            AccoutBook book = new AccoutBook();

            book.addBill(new ConsumeBill(10000, "工资"));
            book.addBill(new ConsumeBill(8000, "材料"));

            book.addBill(new IncomeBill(15000, "项目"));
            book.addBill(new IncomeBill(5000, "兼职"));

            AccountBookViewer boss = new Boss();
            AccountBookViewer cpa = new CPA();

            book.show(boss);
            book.show(cpa);

            ((Boss)boss).getTotalConsume();
            ((Boss)boss).getTotalIncome();
        }
    }

    interface Bill      //接受访问类 Element
    {
        void accept(AccountBookViewer viewer);
    }

    class ConsumeBill : Bill   //消费单子    具体接受访问类 ConcreteElement
    {
        public double amount { get; set; }
        public string item { get; set; }

        public ConsumeBill(double amount,string item)
        {
            this.amount = amount;
            this.item = item;
        }

        public void accept(AccountBookViewer viewer)
        {
            viewer.view(this);
        }
    }

    class IncomeBill : Bill   //收入单子    具体接受访问类 ConcreteElement
    {
        public double amount { get; set; }
        public string item { get; set; }

        public IncomeBill(double amount, string item)
        {
            this.amount = amount;
            this.item = item;
        }

        public void accept(AccountBookViewer viewer)
        {
            viewer.view(this);
        }
    }

    interface AccountBookViewer     //访问者  Visitor
    {
        void view(ConsumeBill conbill);

        void view(IncomeBill incombill);
    }

    class Boss : AccountBookViewer     //具体访问类  ConcreteVisitor
    {
        private double totalIncome;

        private double totalConsume;

        public void view(IncomeBill incombill)
        {
            totalIncome += incombill.amount;
        }

        public void view(ConsumeBill conbill)
        {
            totalConsume += conbill.amount;
        }

        public double getTotalIncome()
        {
            Console.WriteLine("老板查看一共收入多少，数目是：" + totalIncome);
            return totalIncome;
        }

        public double getTotalConsume()
        {
            Console.WriteLine("老板查看一共花费多少，数目是：" + totalConsume);
            return totalConsume;
        }
    }

    class CPA : AccountBookViewer  //注册会计师     具体访问类  ConcreteVisitor
    {
        public void view(IncomeBill incombill)
        {
            Console.WriteLine(incombill.item + ",查看是否交个人所得税");
        }

        public void view(ConsumeBill conbill)
        {
            if (conbill.item.Equals("工资"))
            {
                Console.WriteLine("查看是否交收入税");
            }

        }
    }

    class AccoutBook  //账本类          ObjectStructure结构对象 管理元素集合，可以直接用list代替
    {
        private IList<Bill> list_bill = new List<Bill>();  //单子列表

        public void addBill(Bill bill)
        {
            list_bill.Add(bill);
        }

        public void show(AccountBookViewer viewer)
        {
            foreach(Bill bill in list_bill)
            {
                bill.accept(viewer);
            }
        }
        
    }

}
