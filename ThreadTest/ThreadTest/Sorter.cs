using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadTest
{
    public class Sorter
    {
        public static Queue<Baggage> baggageQueue = new Queue<Baggage>();
        public static void Splitter()
        {
            while (true)
            {
                Baggage baggage;

                lock (baggageQueue)
                {
                    baggage = baggageQueue.Dequeue();

                    lock (baggageQueue)
                    {
                        if (!Program.sortedBaggageQueues.ContainsKey(baggage.Destination))
                        {
                            Program.sortedBaggageQueues[baggage.Destination] = new Queue<Baggage>();
                        }

                        Program.sortedBaggageQueues[baggage.Destination].Enqueue(baggage);


                        Console.WriteLine($"Baggage with Barcode {baggage.Barcode} sorted by {Thread.CurrentThread.Name} for Destination {baggage.Destination}");
                    }
                }
            }
        }
    }
}
