using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SJMS_BehaviorType
{
    //状态模式
    // 定义对象间的一种一对多的依赖关系,当一个对象的状态发生改变时,所有依赖于它的对象都得到通知并被自动更新。

    //Context：它就是那个含有状态的对象，它可以处理一些请求，这些请求最终产生的响应会与状态相关。
    //State：状态接口，它定义了每一个状态的行为集合，这些行为会在Context中得以使用。
    //ConcreteState：具体状态，实现相关行为的具体状态类。

    class State
    {
        
        public static void DoMain()
        {
            Hero hero = new Hero();
            hero.startRun();
            hero.state = Hero.SPEEDUP;
            Thread.Sleep(5000);
            hero.state = Hero.SPEEDDOWN;
            Thread.Sleep(5000);
            hero.stopRun();
        }
    }

    class Hero
    {
        public static RunState COMMON = new CommonState();
        public static RunState SPEEDUP = new SpeedUpState();
        public static RunState SPEEDDOWN = new SpeenDownState();

        public RunState state { get; set; }

        private Thread runThread;

        //停止奔跑
        public void stopRun()
        {
            if (isRunning())
            {
                runThread.Abort();
                Console.WriteLine("---------- 停止奔跑 ----------");
            }
        }

        public void startRun()
        {
            if (isRunning())
            {
                return;
            }

            runThread = new Thread(() =>
            {
                while (isRunning())
                {
                    state.run(this);
                }
            });

            Console.WriteLine("---------- 开始奔跑 ----------");
            runThread.Start();
        }

        private bool isRunning()
        {
            return runThread != null;
        }
    }

    interface RunState
    {
        void run(Hero hero);
    }

    class CommonState : RunState
    {
        public void run(Hero hero)
        {
            //正常状态不输出
        }
    }

    class SpeedUpState : RunState
    {
        public void run(Hero hero)
        {
            Console.WriteLine("---------- 加速奔跑 ----------");
            Thread.Sleep(4000);  //持续4秒
            hero.state = Hero.COMMON;
            Console.WriteLine("---------- 加速状态结束，变为正常状态 ----------");
        }
    }

    class SpeenDownState : RunState
    {
        public void run(Hero hero)
        {
            Console.WriteLine("---------- 减速奔跑 ----------");
            Thread.Sleep(4000);  //持续4秒
            hero.state = Hero.COMMON;
            Console.WriteLine("---------- 减速状态结束，变为正常状态 ----------");
        }
    }
}
