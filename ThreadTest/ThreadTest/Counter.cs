using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadTest
{
    public class Counter
    {
        public static void ProduceBaggage()
        {
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                string barcode = $"BAG{Thread.CurrentThread.Name}{i}";
                string destination = GetRandomDestination();
                Baggage baggage = new Baggage(barcode, destination);

                lock (Sorter.baggageQueue)
                {
                    Console.WriteLine($"Counter {Thread.CurrentThread.Name} producing baggage with Barcode: {barcode} | and destination: {destination}");
                    Sorter.baggageQueue.Enqueue(baggage);
                }
            }

            Console.WriteLine(Sorter.baggageQueue.Count);
        }

        public static string GetRandomDestination()
        {
            string[] destinations = { "London", "Tokoyo", "Oslo" };
            Random random = new Random();
            return destinations[random.Next(destinations.Length)];
        }
    }
}
