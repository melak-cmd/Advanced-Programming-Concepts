using System;
using System.Threading;

namespace TimerExample
{
    class Program
    {
        static void Main()
        {
            // Create an event to signal the timeout maxCount threshold in the
            // timer callback.
            AutoResetEvent autoEvent = new AutoResetEvent(false);

            StatusChecker statusChecker = new StatusChecker(10);

            // Create an inferred delegate that invokes methods for the timer.
            TimerCallback tcb = statusChecker.CheckStatus;

            // Create a timer that signals the delegate to invoke 
            // CheckStatus after one second, and every 1/4 second 
            // thereafter.
            Console.WriteLine("{0} Creating timer.\n",
                DateTime.Now.ToString("h:mm:ss.fff"));
            Timer stateTimer = new Timer(tcb, autoEvent, 1000, 250);

            // When autoEvent signals, change the period to every
            // 1/2 second.
            autoEvent.WaitOne(5000, false);
            stateTimer.Change(0, 500);
            Console.WriteLine("\nChanging period.\n");

            // When autoEvent signals the second time, dispose of 
            // the timer.
            autoEvent.WaitOne(5000, false);
            stateTimer.Dispose();
            Console.WriteLine("\nDestroying timer.");
        }
    }
}
