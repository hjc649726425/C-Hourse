using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS_StructType
{

    //组合模式
    //将对象组合成树形结构以表示"部分-整体"的层次结构。"Composite使得用户对单个对象和组合对象的使用具有一致性。"

    class Composite
    {
        public static void DoMain()
        {
            Animal catamount = new Catamount("猫科动物");
            Animal cat = new WildAnimal("猫");
            Animal tiger = new WildAnimal("虎");

            Animal canine = new Canine("犬科动物");
            Animal dog = new WildAnimal("狗");
            Animal wolf = new WildAnimal("狼");

            catamount.addAnimal(cat);
            catamount.addAnimal(tiger);
            Animal cat1 = new WildAnimal("猫");
            //catamount.deleteAnimal(cat1);    // 无法删除 即使属性相同的两个实体，在集合中也不会认为是同一个对象，因此从实体集合中，删除元素还是建议使用Linq来删除
            catamount.deleteAnimal(catamount.getAnimal().Where(a => a.Name == "猫").FirstOrDefault());  //FirstOrDefault   返回序列中的第一个元素；如果序列中不包含任何元素，则返回默认值。
            foreach (Animal a in catamount.getAnimal())
            {
                Console.WriteLine(a.Name);
            }

            canine.addAnimal(dog);
            canine.addAnimal(wolf);
            foreach (Animal a in canine.getAnimal())
            {
                Console.WriteLine(a.Name);
            }
        }
       
    }

    abstract class Animal
    {
        public string Name { get; set; }

        protected IList<Animal> list = null;

        public Animal(string name)
        {
            this.Name = name;
        }

        public abstract void addAnimal(Animal animal);
        public abstract void deleteAnimal(Animal animal);

        public IList<Animal> getAnimal()
        {
            return list;
        }

    }

    class Catamount : Animal     //猫科动物
    {
        public Catamount(string name) : base(name)
        {
            list = new List<Animal>();
        }

        public override void addAnimal(Animal animal)
        {
            list.Add(animal);
        }

        public override void deleteAnimal(Animal animal)
        {
            list.Remove(animal);
        }
    }

    class Canine : Animal     //猫科动物
    {
        public Canine(string name) : base(name)
        {
            list = new List<Animal>();
        }

        public override void addAnimal(Animal animal)
        {
            list.Add(animal);
        }

        public override void deleteAnimal(Animal animal)
        {
            list.Remove(animal);
        }
    }

    class WildAnimal : Animal
    {
        public WildAnimal(string name) : base(name)
        {
        }

        public override void addAnimal(Animal animal)
        {
            
        }

        public override void deleteAnimal(Animal animal)
        {
           
        }
    }

}
