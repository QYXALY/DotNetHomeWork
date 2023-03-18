using System;

namespace Clock
{
    public delegate void TickHandler(object sender, EventArgs e);
    public delegate void AlarmHandler(object sender, EventArgs e);

    class Clock
    {
        public event TickHandler? Tick;
        public event AlarmHandler? Alarm;

        private int hour = DateTime.Now.Hour;
        private int minute= DateTime.Now.Minute;
        private int second= DateTime.Now.Second;

        EventArgs args = new EventArgs();
        public void Start()
        {
            while (true)
            {
                Thread.Sleep(1000); // 让线程休眠1秒钟，模拟时间的流逝

                OnTick();
                hour = DateTime.Now.Hour;
                minute = DateTime.Now.Minute;
                second = DateTime.Now.Second;
               
                if (DateTime.Now.Second == 0) //每分钟刚开始时触发Alarm
                {
                    OnAlarm(); 
                }
            }
        }
        public void GetTime()
        {
            Console.WriteLine($"当前时间为：{hour}:{minute}:{second}");
        }

        public void OnTick()
        {
            Tick(this, args);
        }

        public void OnAlarm()
        {
            Alarm(this, args);
        }
    }

    class Program
    {
        static void Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Tick");
        }

        static void Alarm(object sender, EventArgs e)
        {
            Console.WriteLine("Alarm!");
        }

        static void Main(string[] args)
        {
            Clock myClock = new Clock();

            myClock.Tick += Tick;
            myClock.Alarm += Alarm;
            myClock.GetTime();
            myClock.Start();
        }
    }
}
