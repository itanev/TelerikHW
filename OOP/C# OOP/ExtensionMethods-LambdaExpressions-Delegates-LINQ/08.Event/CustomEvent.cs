using System;
using System.Threading;

// Define a class to hold custom event info
public class CustomEventArgs : EventArgs
{
    public CustomEventArgs(int t)
    {
        interval = t;
    }
    private int interval;

    public int Interval
    {
        get { return this.interval; }
        set { this.interval = value; }
    }
}

// Class that publishes an event
class Publisher
{

    // Declare the event using EventHandler<T>
    public event EventHandler<CustomEventArgs> RaiseCustomEvent;

    public void Execute(int interval)
    {
        OnRaiseCustomEvent(new CustomEventArgs(interval));
    }

    protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
    {
        // Make a temporary copy of the event
        EventHandler<CustomEventArgs> handler = RaiseCustomEvent;

        // Event will be null if there are no subscribers
        if (handler != null)
        {
            // Use the () operator to raise the event.
            handler(this, e);
        }
    }
}

//Class that subscribes to an event
class Subscriber
{
    private Func<int> methodToExecute;

    public Subscriber(Func<int> method, Publisher pub )
    {
        // Subscribe to the event
        pub.RaiseCustomEvent += HandleCustomEvent;
        methodToExecute = method;
    }

    // Define what actions to take when the event is raised.
    private void HandleCustomEvent(object sender, CustomEventArgs e)
    {
        while (true)
        {
            Thread.Sleep(e.Interval);
            //execute method
            this.methodToExecute();
        }
    }
}

class CustomEvent
{
    static void Main()
    {
        Publisher pub = new Publisher();
        Subscriber sub = new Subscriber(Message, pub);

        // Call the method that raises the event.
        pub.Execute(1000);
    }

    static int Message()
    {
        Console.WriteLine("ActionExecuted");
        return 0;
    }
}