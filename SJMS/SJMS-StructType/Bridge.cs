using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace SJMS_StructType
{
    //桥接模式
    //将抽象部分与它的实现部分分离，使它们都可以独立地变化。

    //抽象类（接口） 与 接口（抽象类） 的组合

    class Bridge
    {
       
        public static void DoMain()
        {
            Color white = new White();
            Color gray = new Gray();

            Shape rectangle = new Rectangle();
            Shape square = new Square();

            rectangle.color = white;
            rectangle.draw();

            square.color = gray;
            square.draw();
        }
    }

    abstract class Shape
    {
        public Color color { get; set; }

        public abstract void draw();
    }

    interface Color
    {
        void bepaint(string shape);
    }

    class Rectangle : Shape
    {
        public override void draw()
        {
            color.bepaint("长方形");
        }
    }

    class Square : Shape
    {
        public override void draw()
        {
            color.bepaint("正方形");
        }
    }

    class White : Color
    {
        public void bepaint(string shape)
        {
            Console.WriteLine("白色" + shape);
        }
    }

    class Gray : Color
    {
        public void bepaint(string shape)
        {
            Console.WriteLine("灰色" + shape);
        }
    }
}
