using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS_BehaviorType
{
    //模板方法
    //定义一个操作中的算法的骨架，将一些步骤延迟到子类中。

    class TemplateMethod
    {
        public static void DoMain()
        {
            DishModel meat = new MeatDish();
            Console.WriteLine("荤菜做法：");
            meat.Dish();

            Console.Write("\n");

            DishModel vegetarian = new VegetarianDish();
            Console.WriteLine("素菜做法：");
            vegetarian.Dish();
        }

    }

    //C#虚方法才能被子类重写
    //java final关键字，不允许子类重写父类方法
    abstract class DishModel
    {
        public void Dish()
        {
            getIngredients();
            wash();
            cooking();
            onPlate();
        }

        public abstract void getIngredients(); //获取食材
        public void wash()
        {
            Console.WriteLine("洗菜");
        }

        public abstract void cooking();  //烧菜
        public void onPlate()
        {
            Console.WriteLine("装盘");
        } 
        
    }

    class MeatDish : DishModel   //荤菜
    {   
        public override void cooking()  
        {
            Console.WriteLine("荤菜烹饪时间有点长，还要红烧");
        }

        public override void getIngredients()
        {
            Console.WriteLine("先杀家禽，获取其肉");
        }
    }

    class VegetarianDish : DishModel   //素菜
    {
        public override void cooking()
        {
            Console.WriteLine("素菜基本过下水就好了");
        }

        public override void getIngredients()
        {
            Console.WriteLine("从地里摘菜，洗干净即可");
        }
    }
}
