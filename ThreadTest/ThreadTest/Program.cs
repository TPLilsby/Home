
using ThreadTest;

public class Program
{
    public static Dictionary<string, Queue<Baggage>> sortedBaggageQueues = new Dictionary<string, Queue<Baggage>>();
    static void Main(string[] args)
    {
        Thread counterThread1 = new Thread(Counter.ProduceBaggage);
        counterThread1.Name = "Counter 1";
        Thread counterThread2 = new Thread(Counter.ProduceBaggage);
        counterThread2.Name = "Counter 2";
        Thread counterThread3 = new Thread(Counter.ProduceBaggage);
        counterThread3.Name = "Counter 3";

        Thread sorterThread = new Thread(Sorter.Splitter);
        sorterThread.Name = "Conveyor Belt";

        Thread terminalThread1 = new Thread(Terminal.ConsumeBaggage);
        terminalThread1.Name = "Terminal 1";
        Thread terminalThread2 = new Thread(Terminal.ConsumeBaggage);
        terminalThread2.Name = "Terminal 2";
        Thread terminalThread3 = new Thread(Terminal.ConsumeBaggage);
        terminalThread3.Name = "Terminal 3";

        counterThread1.Start();
        counterThread2.Start();
        counterThread3.Start();

        sorterThread.Start();

        terminalThread1.Start();
        terminalThread2.Start();
        terminalThread3.Start();

    }

    public static Baggage DequeueBaggage(string queueKey)
    {
        if (sortedBaggageQueues.ContainsKey(queueKey) && sortedBaggageQueues[queueKey].Count > 0)
        {
            return sortedBaggageQueues[queueKey].Dequeue();
        }

        return null;
    }