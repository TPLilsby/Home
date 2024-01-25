using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadTest
{
    public class Terminal
    {

        public static void ConsumeBaggage()
        {
            Baggage baggage;

            while (true)
            {
                lock (Program.sortedBaggageQueues)
                {
                    while (Program.sortedBaggageQueues.Count == 0)
                    {
                        Monitor.Wait(Sorter.baggageQueue);
                    }

                    baggage = Sorter.baggageQueue.Dequeue();

                    if (Program.sortedBaggageQueues.ContainsKey(baggage.Destination))
                    {

                    }
                }

                ProccessBaggage(baggage);   
            }
        }

        public static void ProccessBaggage(Baggage baggage)
        {
            lock (Sorter.baggageQueue)
            {
                Console.WriteLine($"Terminal {Thread.CurrentThread.Name} processing baggage with Barcode: {baggage.Barcode}");

                Console.WriteLine($"Baggage with Barcode {baggage.Barcode} processed at Terminal {Thread.CurrentThread.Name}");
            }
        }
    }
}
