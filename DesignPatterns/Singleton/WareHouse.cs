public class WareHouse
{
    private static readonly WareHouse _instance = new WareHouse();
    
    private object _locker;
    private int _amount;

    private WareHouse()
    {
        _amount = 0;
    }

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
            this._amount += amount;
        }
    }

    public void Pull(int amount)
    {
        lock(_locker)
        {
            if(this._amount >= amount)
                this._amount -= amount;
        }
    }
}