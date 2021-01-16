using System;

namespace SingletonPattern
{
    public class Bus
    {
        protected static readonly DateTime globalStartTime;
        public int BusNumber { get; set; }

        // Static constructor
        static Bus()
        {
            globalStartTime = DateTime.Now;
        }

        // Instance constructor
        public Bus(int busNumber)
        {
            BusNumber = busNumber;
        }

        public override string ToString()
        {
            return $"{nameof(globalStartTime)}: {globalStartTime} \n{nameof(BusNumber)}: {BusNumber} ";
        }
    }

    public class CEO
    {
        // static property traditional
        public static string Name { get; set; }

        // static property - monostate pattern
        private static int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
    }
}
