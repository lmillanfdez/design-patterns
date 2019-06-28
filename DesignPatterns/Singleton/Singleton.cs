public class Singleton
{
    private static readonly Singleton _instance = new Singleton();

    private Singleton(){}

    public static Singleton GetInstance 
    { 
        get
        {
            /* if(_instance == null)
                _instance = new Singleton(); */

            return _instance;
        }
    }

    public int SomeIntegerField { get; set; }
}