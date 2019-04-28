using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS_BehaviorType
{
    //备忘录模式
    //在不破坏封装性的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态。这样以后就可将该对象恢复到原先保存的状态。

    //Originator: 原发器
    //Memento: 备忘录
    //Caretaker: 负责人

    class Memento
    {
        public static void DoMain()
        {
            Console.WriteLine(DateTime.Now);
            Random r = new Random();
            int att = r.Next(30, 40);

            Role braveMan = new Role("勇者", 100, att, 20);
            Role dragon = new Role("魔龙", 100, 25, 30);
            braveMan.StateDisplay();
            dragon.StateDisplay();
            //Console.ReadKey();
            RoleStateMemento memento = braveMan.Save();  //打之前保存

            while(braveMan.Vitality >=0 && dragon.Vitality >= 0)
            {
                braveMan.Fight(dragon);
                dragon.Fight(braveMan);
            }

            if(braveMan.Vitality >= 0)
            {
                Console.WriteLine("勇者打败魔龙");
                return;
            }else
            {
                Console.WriteLine("魔龙打败勇者，读档。。。。");
                braveMan.init(memento);
                dragon.Vitality = 100;
                Console.WriteLine("练级。。。。");
                braveMan.Attack = 40;
            }

            while (braveMan.Vitality >= 0 && dragon.Vitality >= 0)
            {
                braveMan.Fight(dragon);
                dragon.Fight(braveMan);
            }

            Console.WriteLine("勇者打败魔龙");
        }
    }

    class Role   //原发器
    {
        public string Name { get; set; }

        //生命
        public int Vitality { get; set; }

        //攻击
        public int Attack { get; set; }

        //防御
        public int Defense { get; set; }

        public Role(string name, int vit, int att, int def)
        {
            this.Vitality = vit;
            this.Defense = def;
            this.Attack = att;
            this.Name = name;
        }

        public void StateDisplay()
        {
            Console.WriteLine(this.Name + ":");
            Console.WriteLine("生命：" + Vitality);
            Console.WriteLine("攻击：" + Attack);
            Console.WriteLine("防御：" + Defense);
            Console.WriteLine();
        }

        public void Fight(Role role)
        {
            if (role.Defense > this.Attack)
            {
                Console.WriteLine(this.Name + "攻击过低，无法对" + role.Name + "造成伤害");
            }
            else
            {
                int damage = this.Attack - role.Defense;
                role.Vitality -= damage;
                Console.WriteLine(this.Name + "攻击" + role.Name + "造成" + damage + "点伤害，" + role.Name + "剩余生命值：" + role.Vitality);
            }
        }

        public RoleStateMemento Save()   //保存角色状态
        {
            return new RoleStateMemento(Name, Vitality, Attack, Defense);
        }

        public void init(RoleStateMemento memento) //读档
        {
            this.Attack = memento.attack;
            this.Vitality = memento.vitality;
            this.Name = memento.name;
            this.Defense = memento.defense;
        }
    }

    class RoleStateMemento   //备忘录
    {
        public string name;

        //生命
        public int vitality;

        //攻击
        public int attack;

        //防御
        public int defense;

        public RoleStateMemento(string name,int vitality,int attack,int defense)
        {
            this.name = name;
            this.vitality = vitality;
            this.attack = attack;
            this.defense = defense;
        }
    }

    class RoleStateCaretaker   //负责人
    {
        public RoleStateMemento RoleStateMemento { get; set; }
    }
}
