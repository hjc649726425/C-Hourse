using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace SJMS_StructType
{
    //代理模式
    //为其他对象提供一种代理以控制对这个对象的访问

    class MyProxy
    {
        
        public static void DoMain()
        {
            Person p = new Person();
            ProxyPerson prop = new ProxyPerson(p);
            prop.action();  //静态

            DynProxy proxy = new DynProxy(typeof(Plane), new Plane());  //动态代理
            Plane plane = (Plane)proxy.GetTransparentProxy();
            plane.action();
        }
    }

    //静态代理
    interface IPerson
    {
        void action();
    }

    class Person : IPerson   //被代理类
    {
        public void action()
        {
            Console.WriteLine("人在走路");
        }
    }

    class ProxyPerson : IPerson
    {
        Person p;

        public ProxyPerson(Person p)
        {
            this.p = p;
        }

        public void action()
        {
            Console.WriteLine("============代理前===========");
            p.action();
            Console.WriteLine("============代理后===========");
        }
    }


    //动态代理
    class DynProxy : RealProxy
    {
        public Plane plane = null;

        public DynProxy(Type t,Plane plane) :base(t)
        {
            this.plane = plane;
        }

        public override IMessage Invoke(IMessage msg)
        {
            Console.WriteLine("开始代理");
            IMethodCallMessage methodCall = (IMethodCallMessage)msg;
            var result = methodCall.MethodBase.Invoke(plane, methodCall.Args);
            Console.WriteLine("结束代理");
            return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
        }
    }

    class Plane : MarshalByRefObject //被代理类一定要继承 MarshalByRefObject
    {
        public void action()
        {
            Console.WriteLine("action");
        }
    }
}
