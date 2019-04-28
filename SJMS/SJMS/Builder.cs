using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS
{
    //建造者模式
    //将一个复杂对象的构造与它的表示分离，使同样的构建过程可以创建不同的表示。
    //    1.当创建复杂对象的算法应该独立于该对象的组成部分以及它们的装配方式时。
    //    2.当构造过程必须允许被构造的对象有不同类表示时。

    //指挥者1个    指挥建造
    //建造对象n个  产品，例如自行车
    //建造生产线n条   生产对应的产品，例如摩拜和ofo

    //如果同一种产品，不同款式，就可以用接口（抽象类更好）实现，如公路自行车，登山自行车,指挥部 和 工厂 都无法完全指挥
    

    //与工厂区别
    //1.意图不同
    //工厂关注的是一个产品的整体，不关心各部分是如何创造出来的
    //建造者创建的是一个复合产品，它由各个部件复合而成
    //2.复杂度不同
    //工厂方法一般是单一性质产品
    //建造者创建的是各部件复合而成的产品
    class Builder
    {
       public void DoMain()
        {
            BikeBuilder b1 = new MoBikeBuild();
            EngineeringDept eng1 = new EngineeringDept(b1);
            eng1.Construct();

            BikeBuilder b2 = new OfoBikeBuild();
            EngineeringDept eng2 = new EngineeringDept(b2);
            eng2.Construct();
        }

    }

    interface BikeBuilder
    {
        void buildTyres();  //轮胎
        void buildFrame();  //车架
        void buildGPS();   //GPS
        Bike getMounBike();    //获取登山自行车
        Bike getHighBike();   //获取公路自行车
    }

    class MoBikeBuild : BikeBuilder
    {
        Bike mounbike = new MountainBike();
        Bike highbike = new HighWayBike();
        public void buildFrame()
        {
            mounbike.Frame = "摩拜车架";
            highbike.Frame = "摩拜车架";
        }

        public void buildGPS()
        {
            mounbike.GPS = "摩拜GPS";
            highbike.GPS = "摩拜GPS";
        }

        public void buildTyres()
        {
            mounbike.Tyres = "摩拜轮胎";
            highbike.Tyres = "摩拜轮胎";
        }

        public Bike getHighBike()
        {
            return highbike;
        }

        public Bike getMounBike()
        {
            return mounbike;
        }
    }

    class OfoBikeBuild : BikeBuilder
    {
        Bike mounbike = new MountainBike();
        Bike highbike = new HighWayBike();

        public void buildFrame()
        {
            mounbike.Frame = "Ofo车架";
            highbike.Frame = "Ofo车架";
        }

        public void buildGPS()
        {
            mounbike.GPS = "OfoGPS";
            highbike.GPS = "OfoGPS";
        }

        public void buildTyres()
        {
            mounbike.Tyres = "Ofo轮胎";
            highbike.Tyres = "Ofo轮胎";
        }

        public Bike getHighBike()
        {
            return highbike;
        }

        public Bike getMounBike()
        {
            return mounbike;
        }
    }

    abstract class Bike
    {
        public string Frame { get; set; }
        public string GPS { get; set; }
        public string Tyres { get; set; }
    }

    class MountainBike : Bike   //登山自行车
    {
        public string Shock { get; set; }
    }

    class HighWayBike : Bike   //登山自行车
    {
        public string Decs { get; set; }
    }

    class EngineeringDept   //工程部，指导生产
    {
        BikeBuilder builder;

        public EngineeringDept(BikeBuilder builder)
        {
            this.builder = builder;
        }

        public void Construct()
        {
            builder.buildFrame();
            builder.buildGPS();
            builder.buildTyres();
        }
    }
}
