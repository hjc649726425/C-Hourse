using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS_StructType
{
    class Flyweight
    {
        //享元模式
        //运用共享技术有效地支持大量细粒度的对象。

        //池技术的应用

        public static void DoMain()
        {
            WebSiteFactory factory = new WebSiteFactory();
            factory.getWebSite("视频");
            factory.getWebSite("文学");
            factory.getWebSite("动漫");
            factory.getWebSite("小说");
            factory.getWebSite("视频");

            Console.WriteLine(factory.getWebSiteCount());
        }
    }

    //网站抽象类
    public abstract class WebSite
    {
        public abstract void use();
    }

    public class ConcreteWebSite : WebSite
    {
        private string name = null;

        public ConcreteWebSite(string name)
        {
            this.name = name;
        }

        public override void use()
        {
            Console.WriteLine("网站分类：" + name);
        }
    }

    public class WebSiteFactory
    {
        private Dictionary<string, WebSite> factory = new Dictionary<string, WebSite>();

        public WebSite getWebSite(string name)
        {
            if (!factory.ContainsKey(name))
            {
                factory.Add(name, new ConcreteWebSite(name));
            }

            return factory[name];
        }

        public int getWebSiteCount()
        {
            return factory.Count;
        }
    }
}
