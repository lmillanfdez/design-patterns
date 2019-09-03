using System;

class Consumer
{
    public Consumer(IConsumerWarehouse wareHouse)
    {
        WareHouse = wareHouse;
        Identifier = Guid.NewGuid().ToString();
    }

    public string Identifier { get; set; }
    public IConsumerWarehouse WareHouse { get; set; }

    public bool Pull(int amount)
    {
        return WareHouse.Pull(amount);
    }
}