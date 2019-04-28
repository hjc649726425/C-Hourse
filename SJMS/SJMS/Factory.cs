using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS
{

    // 工厂模式 ：定义一个创建对象的接口，让子类觉得实例化哪个类

    //简单工厂模式没有接口，只有一个类，返回同一类产品不同的实例，如联想鼠标，惠普鼠标
    
    //工厂模式与抽象工厂模式都是实现接口，它们的区别只是 它们生产的产品数量不同，工厂模式只有一种产品，抽象工厂模式有多种产品
    // 如抽象工厂生产键盘+鼠标，工厂只生产鼠标

    interface IFactory  //只有一种产品
    {
        IStudent getStudent();
    }

    class CNFactory : IFactory
    {
        public IStudent getStudent()
        {
            return new CNStudent();
        }
    }

    interface IStudent
    {
        void work();
    }

    class CNStudent : IStudent
    {
        public void work()
        {
            Console.WriteLine("中国学生写作业");
        }
    }


    public class FactoryMain
    {
        public static void DoMain()
        {
            IFactory factory = new CNFactory();
            IStudent stu = factory.getStudent();
            stu.work();
        }
    }
    
}
