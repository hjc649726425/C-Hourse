using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS
{
    class Program
    {
        static void Main(string[] args)
        {

            //FactoryMain.DoMain(); //工程模式
            //AbstractFactory.DoMain(); //抽象工厂模式
            Prototype.DoMain(); //原型模式

            Console.ReadKey();
        }
    }
}
