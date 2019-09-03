using System;
using System.Timers;

class Orchestrator
{
    private static readonly WareHouse _wareHouse = WareHouse.GetInstance;

    public static void Run(int amountOfProducers, int amountOfConsumers)
    {
        for (int i = 0; i < amountOfProducers; i++)
            ProducerHandler(new Producer(_wareHouse));

        for (int i = 0; i < amountOfConsumers; i++)
            ConsumerHandler(new Consumer(_wareHouse));

        Console.WriteLine("Press a key to stop the application");
        Console.ReadLine();

        Console.Write("There are {0} items left in the warehouse", _wareHouse.Amount);
    }

    private static void ProducerHandler(Producer producer)
    {
        var _random = new Random();
        var _timer = new Timer();

        var _times = _random.Next(2, 6);
        var _iteration = 0;
        int _amountOfItems;

        _timer.Interval = 2000;
        _timer.Elapsed += (object source, ElapsedEventArgs args) => {
            producer.Push(_amountOfItems = _random.Next(1, 3));
            Console.WriteLine("Producer {0} pushed {1} items.", producer.Identifier, _amountOfItems);

            if(++_iteration == _times)
                _timer.Enabled = false;
        };

        _timer.Enabled = true;
    }

    private static void ConsumerHandler(Consumer consumer)
    {
        var _random = new Random();
        var _timer = new Timer();

        var _times = _random.Next(2, 6);
        var _iteration = 0;
        int _amountOfItems;        

        _timer.Interval = 3000;
        _timer.Elapsed += (object source, ElapsedEventArgs args) => {
            if(consumer.Pull(_amountOfItems = _random.Next(2, 4)))
                Console.WriteLine("Consumer {0} pulled {1} items.", consumer.Identifier, _amountOfItems);
            else
                Console.WriteLine("Producer {0} couldn't pull {1} items.", consumer.Identifier, _amountOfItems);

            if(++_iteration == _times)
                _timer.Enabled = false;
        };

        _timer.Enabled = true;
    }
}