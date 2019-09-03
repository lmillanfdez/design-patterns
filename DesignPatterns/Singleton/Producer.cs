using System;

class Producer
{
    public Producer(IProducerWareHouse wareHouse)
    {
        WareHouse = wareHouse;
        Identifier = Guid.NewGuid().ToString();
    }

    public string Identifier { get; set; }
    public IProducerWareHouse WareHouse { get; set; }

    public void Push(int amount)
    {
        WareHouse.Push(amount);
    }
}