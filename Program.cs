using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


        internal class ClockTime
        {
            private int hours;
            private int minutes;
            private int seconds;

            public int Hours
            {
                get { return hours; }
                set
                {
                    if (value < 0 || value > 23)
                    {
                        throw new ArgumentException("неверное значение часов");
                    }
                    hours = value;
                }
            }

            public int Minutes
            {
                get { return minutes; }
                set
                {
                    if (value < 0 || value > 59)
                    {
                        throw new ArgumentException("Неверное значение минут.");
                    }
                    minutes = value;
                }
            }

            public int Seconds
            {
                get { return seconds; }
                set
                {
                    if (value < 0 || value > 59)
                    {
                        throw new ArgumentException("Неверное значение секунд.");
                    }
                    seconds = value;
                }
            }

            // конструкторы
            public ClockTime(int hours, int minutes, int seconds)
            {
                Hours = hours;
                Minutes = minutes;
                Seconds = seconds;
            }

            public ClockTime(int hours, int minutes) : this(hours, minutes, 0) { }
            public ClockTime(int hours) : this(hours, 0) { }
            public ClockTime() : this(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) { }

            // перемещение времени на одну секунду вперед (учесть обнуление секунд, минут, часов)
            public void Tick()
            {
                seconds++;
                if (seconds == 60)
                {
                    seconds = 0;
                    minutes++;
                    if (minutes == 60)
                    {
                        minutes = 0;
                        hours++;
                        if (hours == 24)
                        {
                            hours = 0;
                        }
                    }
                }
            }

            //получение всего временив секундах
            public int ToSeconds()
            {
                return hours * 3600 + minutes * 60 + seconds;
            }

            // получение разницы в секундах между двумя объектами ClockTime
            public int ClockTimeTwo(ClockTime other)
            {
                return Math.Abs(this.ToSeconds() - other.ToSeconds());
            }

            // вывод времени в консоль в формате чч:мм:сс
            public void Print()
            {
                Console.WriteLine($"{hours:D2}:{minutes:D2}:{seconds:D2}");
            }

            // переопределение ToString, возвращающая время в формате чч:мм:сс (доп. задание)
            public override string ToString()
            {
                return $"{hours}:{minutes}:{seconds}";
            }
        }


    class Program
    {
        static void Main(string[] args)
        {
            // Пример использования класса ClockTime
            ClockTime time1 = new ClockTime(10, 30, 15);
            Console.WriteLine("время 1:");
            time1.Print(); // Вывод времени в формате чч:мм:сс
            Console.WriteLine($"количество секунд: {time1.ToSeconds()}");

            ClockTime time2 = new ClockTime(8, 45);
            Console.WriteLine("\nвремя 2:");
            time2.Print(); // Вывод времени в формате чч:мм:сс
            Console.WriteLine($"количество секунд: {time2.ToSeconds()}");

            Console.Write($"\nРазница между {time1} и {time2}: ");
            Console.WriteLine(time1.ClockTimeTwo(time2));

            Console.WriteLine("\nВремя 1 в виде строки:");
            Console.WriteLine(time1);
        }
    }
