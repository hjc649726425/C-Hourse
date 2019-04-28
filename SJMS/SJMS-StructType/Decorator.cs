using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS_StructType
{

    //装饰模式
    // 动态地给一个对象添加一些额外的职责。就增加功能来说，Decorator模式相比生成子类更为灵活。

    //Component为统一接口，也是装饰类和被装饰类的基本类型。
    //ConcreteComponent为具体实现类，也是被装饰类，他本身是个具有一些功能的完整的类。
    //Decorator是装饰类，实现了Component接口的同时还在内部维护了一个ConcreteComponent的实例，并可以通过构造函数初始化。
        //而Decorator本身，通常采用默认实现，他的存在仅仅是一个声明：我要生产出一些用于装饰的子类了。而其子类才是赋有具体装饰效果的装饰产品类。
    //ConcreteDecorator是具体的装饰产品类，每一种装饰产品都具有特定的装饰效果。可以通过构造器声明装饰哪种类型的ConcreteComponent，从而对其进行装饰
    class Decorator
    {
       
        public static void DoMain()
        {
            TheGreatestSage sage = new Mokey();     //永远都要把大圣的所有变化当成大圣看，当成鱼或者鸟就被骗了
            TheGreatestSage fish = new Fish(sage);
            fish.move();

            TheGreatestSage bird = new Bird(fish);
            bird.move();

            Bird b = (Bird)bird;    //半透明装饰模式，允许装饰器有新的方法（介于 装饰器  与  适配器 之间）
            b.fly();
        }
    }

    public interface TheGreatestSage   //大圣 (统一接口)
    {
        void move();
    }

    public class Mokey : TheGreatestSage   //( 具体实现类，被装饰类 )
    {
        public void move()
        {
            Console.WriteLine("Monkey Move");   
        }
    }

    public class Change : TheGreatestSage    //七十二变   （装饰类）
    {

        private TheGreatestSage sage;

        public Change(TheGreatestSage sage)
        {
            this.sage = sage;
        }

        public virtual void move()
        {
            Console.WriteLine("七十二变");
            sage.move();
        }
    }

    public class Fish : Change    //变鱼  （具体装饰类）
    {
        public Fish(TheGreatestSage sage):base(sage)
        {
 
        }

        public override void move()
        {
            Console.WriteLine("Fish Move");
        }
    }

    public class Bird : Change    //变鸟   （具体装饰类）
    {
        public Bird(TheGreatestSage sage) : base(sage)
        {

        }

        public override void move()
        {
            Console.WriteLine("Brid Move");
        }

        public void fly()
        {
            Console.WriteLine("Brid fly");
        }
    }
}
