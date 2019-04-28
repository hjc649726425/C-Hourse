using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS
{

    //原型模式：用原型实例指定创建对象的种类，并且通过拷贝这些原型创建新的对象
    //大量相同或相似对象的创建

    class Prototype
    {
        public static void DoMain()
        {
            Stu s1 = new ConcreteStu("12");
            Stu s2 = s1.Clone();

            s1.Id = "25";
            Console.WriteLine(s2.Id);
        }

    }

    abstract class Stu
    {
        public string Id { get; set; }

        public Stu(string id)
        {
            this.Id = id;
        }

        public abstract Stu Clone();
    }

    class ConcreteStu : Stu
    {
        public ConcreteStu(string id) : base(id)
        {
        }

        public override Stu Clone()
        {
            return (Stu)this.MemberwiseClone();
        }
    }

}
