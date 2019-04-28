using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJMS_BehaviorType
{
    //命令模式
    //  将一个请求封装为一个对象，从而使你可用不同的请求对客户进行参数化；对请求排队或记录请求日志，以及支持可撤消的操作。

    class Command
    {
        public static void DoMain()
        {
            Fan fan = new Fan();
            Light light = new Light();

            FanOffCommand fanoff = new FanOffCommand(fan);
            FanOnCommand fanon = new FanOnCommand(fan);

            LightOffCommand lightoff = new LightOffCommand(light);
            LightOnCommand lighton = new LightOnCommand(light);

            RemoteControl control = new RemoteControl();

            control.setCommand(fanoff);
            control.Execute();

            control.setCommand(fanon);
            control.Execute();

            control.setCommand(lighton);
            control.Execute();

            control.setCommand(lightoff);
            control.Execute();
        }   

       

    }

    class Fan
    {
        public void FanOn()
        {
            Console.WriteLine("风扇开");
        }

        public void FanOff()
        {
            Console.WriteLine("风扇关");
        }
    }

    class Light
    {
        public void LightOn()
        {
            Console.WriteLine("电灯开");
        }

        public void LightOff()
        {
            Console.WriteLine("电灯关");
        }
    }

    interface ICommand
    {
        void Execute();
    }

    class FanOnCommand : ICommand
    {
        Fan fan;

        public FanOnCommand(Fan fan)
        {
            this.fan = fan;
        }

        public void Execute()
        {
            fan.FanOn();
        }
    }

    class FanOffCommand : ICommand
    {
        Fan fan;

        public FanOffCommand(Fan fan)
        {
            this.fan = fan;
        }

        public void Execute()
        {
            fan.FanOff();
        }
    }

    class LightOnCommand : ICommand
    {
        Light light;

        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.LightOn();
        }
    }

    class LightOffCommand : ICommand
    {
        Light light;

        public LightOffCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.LightOff();
        }
    }

    class RemoteControl
    {
        private ICommand command;

        public void setCommand(ICommand command)
        {
            this.command = command;
        }

        public void Execute()
        {
            command.Execute();
        }
    }

}
