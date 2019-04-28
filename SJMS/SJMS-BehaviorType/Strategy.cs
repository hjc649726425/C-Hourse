using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS_BehaviorType
{
    //策略模式
    //定义一系列的算法,把它们一个个封装起来,并且使它们可相互替换。本模式使得算法可独立于使用它的客户而变化。

    class Strategy
    {
        
        public static void DoMain()
        {
            Promotion newcus = new Promotion(new NewCustom());
            newcus.PromotionMethod();

            Promotion oldcus = new Promotion(new OldCustom());
            oldcus.PromotionMethod();

            Promotion vipcus = new Promotion(new VIPCustom());
            vipcus.PromotionMethod();
        } 
    }

    interface IStorePromotion
    {
        void Promotion();
    }

    class NewCustom : IStorePromotion
    {
        public void Promotion()
        {
            Console.WriteLine("新顾客没有优惠");
        }
    }

    class OldCustom : IStorePromotion
    {
        public void Promotion()
        {
            Console.WriteLine("老顾客8.5折");
        }
    }

    class VIPCustom : IStorePromotion
    {
        public void Promotion()
        {
            Console.WriteLine("VIP顾客7折");
        }
    }

    
    class Promotion             //上下文，连接策略实现与客户端
    {
        IStorePromotion storePromotion; 

        public Promotion(IStorePromotion storePromotion)
        {
            this.storePromotion = storePromotion;
        }

        public void PromotionMethod()
        {
            storePromotion.Promotion();
        }
    }
}
