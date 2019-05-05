using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS_BehaviorType
{
    //责任链模式
    //使多个对象都有机会处理请求，从而避免请求的发送者和接收者之间的耦合关系。将这些对象连成一条链，

    class Responsibility
    {
        public static void DoMain()
        {
            Request req = new Request();
            req.reqStr = "草，[张三]MMP的，:):";
            Console.WriteLine("原字符串：{0}",req.reqStr);

            Response resp = new Response();

            Filter html = new HTMLFilter();
            Filter sensitive = new SensitiveFilter();
            Filter face = new FaceFilter();
            FilterChain chain = new FilterChain();
            chain.addFilter(html).addFilter(sensitive).addFilter(face);

            chain.DoFiilter(req, resp, chain);

            Console.WriteLine("过滤后的字符串：{0}", req.reqStr);
            Console.WriteLine(resp.respStr);
        }
    }

    //请求
    class Request
    {
        public string reqStr { get; set; }
    }

    //响应
    class Response
    {
        public string respStr { get; set; }
    }

    interface Filter
    {
        void DoFiilter(Request req, Response resp, FilterChain chain);
    }

    class FilterChain : Filter
    {
        List<Filter> list = new List<Filter>();
        int index = 0; //规则引用顺序

        public FilterChain addFilter(Filter filter){
            list.Add(filter);
            return this;
        }

        public void DoFiilter(Request req, Response resp, FilterChain chain)
        {
            if(index == list.Count)
            {
                return;
            }

            Filter f = list[index];
            index++;
            f.DoFiilter(req, resp, chain);
        }
    }

    class HTMLFilter : Filter
    {
        public void DoFiilter(Request req, Response resp, FilterChain chain)
        {
            req.reqStr = req.reqStr.Replace('<', '[').Replace('>', ']') + "------HTMLFilter";
            chain.DoFiilter(req, resp, chain);
            resp.respStr += "------HTMLFilter";
        }
    }

    class SensitiveFilter : Filter
    {
        public void DoFiilter(Request req, Response resp, FilterChain chain)
        {
            req.reqStr = req.reqStr.Replace("草", "*").Replace("MMP", "***") + "------SensitiveFilter";
            chain.DoFiilter(req, resp, chain);
            resp.respStr += "------SensitiveFilter";
        }
    }

    class FaceFilter : Filter
    {
        public void DoFiilter(Request req, Response resp, FilterChain chain)
        {
            //将字符串中出现的":):"转换成"^V^";
            req.reqStr = req.reqStr.Replace(":):", "^V^") + "------FaceFilter";
            chain.DoFiilter(req, resp, chain);
            resp.respStr += "------FaceFilter";
        }
    }

}
