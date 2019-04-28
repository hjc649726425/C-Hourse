using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS_BehaviorType
{
    //观察者模式
    //定义对象间的一种一对多的依赖关系,当一个对象的状态发生改变时,所有依赖于它的对象都得到通知并被自动更新。 （被观察者通知观察者）
    //抽象主题（Subject）：它把所有观察者对象的引用保存到一个聚集里，每个主题都可以有任何数量的观察者。抽象主题提供一个接口，可以增加和删除观察者对象。
    //具体主题（ConcreteSubject）：将有关状态存入具体观察者对象；在具体主题内部状态改变时，给所有登记过的观察者发出通知。
    //抽象观察者（Observer）：为所有的具体观察者定义一个接口，在得到主题通知时更新自己。
    //具体观察者（ConcreteObserver）：实现抽象观察者角色所要求的更新接口，以便使本身的状态与主题状态协调。
    class Observer
    {
        public static void DoMain()
        {
            Blog xmfdsh = new MyBlog("xmfdsh", "发布了一篇新博客");

            // 添加订阅者
            //xmfdsh.AddObserver(new Subscriber("王尼玛"));
            //xmfdsh.AddObserver(new Subscriber("唐马儒"));
            //xmfdsh.AddObserver(new Subscriber("王蜜桃"));
            //xmfdsh.AddObserver(new Subscriber("敖尼玛"));

            Subscriber wnm = new Subscriber("王尼玛");
            Subscriber tml = new Subscriber("唐马儒");
            Subscriber wmt = new Subscriber("王蜜桃");
            Subscriber anm = new Subscriber("敖尼玛");

            xmfdsh.AddObserver(new NotifyEventHandler(wnm.Receive)); 
            xmfdsh.AddObserver(new NotifyEventHandler(tml.Receive));
            xmfdsh.AddObserver(new NotifyEventHandler(wmt.Receive));
            xmfdsh.AddObserver(new NotifyEventHandler(anm.Receive));
            xmfdsh.AddObserver((blog) => {
                Subscriber z = new Subscriber("观察者Z");
                z.Receive(blog);
            });

            xmfdsh.AddObserver(wnm.Receive);

            //更新信息
            xmfdsh.Update();
            //输出结果，此时所有的订阅者都已经得到博客的新消息
         
        }

    }

    public delegate void NotifyEventHandler(Blog sendMsg);
    public abstract class Blog  //订阅抽象类  （被观察者）
    {
        private IList<IObserver> observers = new List<IObserver>();
        private NotifyEventHandler mydel;

        public string Symbol { get; set; }  //订阅号相关信息
        public string Info { get; set; }   //更新信息

        public Blog(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        public void AddObserver(IObserver ob)
        {
            this.observers.Add(ob);
        }

        public void RemoveObserver(IObserver ob)
        {
            observers.Remove(ob);

        }

        //委托实现
        public void AddObserver(NotifyEventHandler notdel)
        {
            mydel += notdel;
        }

        public void RemoveObserver(NotifyEventHandler notdel)
        {
            mydel -= notdel;

        }

        public void Update()
        {
            // 遍历订阅者列表进行通知
            //foreach (IObserver ob in observers)
            //{
            //    if (ob != null)
            //    {
            //        ob.Receive(this);
            //    }
            //}

            mydel(this);
        }
    }

    class MyBlog : Blog
    {
        public MyBlog(string symbol, string info) : base(symbol, info)
        {
        }
    }


    public interface IObserver  //订阅者接口   （观察者）
    {
        void Receive(Blog tenxun);
    }

    class Subscriber : IObserver
    {
        public string Name { get; set; }

        public Subscriber(string name)
        {
            this.Name = name;
        }

        public void Receive(Blog xmfdsh)
        {
            Console.WriteLine("订阅者 {0} 观察到了{1}{2}", Name, xmfdsh.Symbol, xmfdsh.Info);
        }
    }
}

