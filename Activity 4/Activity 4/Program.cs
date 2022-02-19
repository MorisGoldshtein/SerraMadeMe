interface ITestInterface
{
    //Properties
    string Str { get; set; }
    float Flo { get; set; }
    double Dou { get; set; }

    //Delegate to create event type
    delegate void HandleSomething(object source, EventArgs args);

    //Event
    event HandleSomething TestEvent;

    //Instance Method
    void Check();

}


class Test : ITestInterface
{
    //Inherited Properties Implemented
    public string Str { get; set; }
    public float Flo { get; set; }
    public double Dou { get; set; }

    //Inherited Event Implemented
    event ITestInterface.HandleSomething ITestInterface.TestEvent{
        add{ throw new NotImplementedException(); }
        remove{ throw new NotImplementedException(); }
    }

    //Inherited Instance Method Implemented
    public void Check(){
        Console.WriteLine("Active");
    }



    static void Main(){
        var obj = new Test();
        obj.Check();
    }
}

