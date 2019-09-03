class WareHouse : IProducerWareHouse, IConsumerWarehouse
{
    private static readonly WareHouse _instance = new WareHouse();
    
    private readonly object _locker;

    private WareHouse()
    {
        _locker = new object();
        Amount = 0;
    }

    public int Amount { get; private set; }
    public static WareHouse GetInstance 
    { 
        get
        {
            return _instance;
        }
    }

    public void Push(int amount)
    {
        lock(_locker)
        {
            this.Amount += amount;
        }
    }

    public bool Pull(int amount)
    {
        lock(_locker)
        {
            if(this.Amount >= amount)
            {
                this.Amount -= amount;
                return true;
            }

            return false;
        }
    }
}