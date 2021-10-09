using System;

namespace BuilderPattern
{

    class Program
    {
        static void Main(string[] args)
        {
            // Facade FLuent Builder
            var workerBuilder = new WorkerBuilder()
                .Is.Called("Antonio")
                   .LiveIn("Bari")
                .Works.HasPosition("Software develoepr")
                      .HasSalary("500 000k€")
                .Build();
            Console.WriteLine(workerBuilder);
            Console.ReadLine();

            // Fluent Builder with Recursive Generics
            //var me = Builder.New
            //    .Called("Antonio")
            //    .WorkAs("Developer")
            //    .HasSalary(2500.70)
            //    .Build();
            //Console.WriteLine(me);
        }
    }
}
