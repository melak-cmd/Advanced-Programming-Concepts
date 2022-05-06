using System;
using System.Runtime.Remoting.Messaging;

namespace UseAsyncCallback
{
    class Program
    {
        delegate int MyDelegate(string s);

        static void Main(string[] args)
        {
            MyDelegate X = new MyDelegate(DoSomething);
            AsyncCallback cb = new AsyncCallback(DoSomething2);
            IAsyncResult ar = X.BeginInvoke("Hello", cb, null);

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
        static int DoSomething(string s)
        {
            Console.WriteLine("doooooooooooooooo");
            return 0;
        }

        static void DoSomething2(IAsyncResult ar)
        {
            MyDelegate X = (MyDelegate)((AsyncResult)ar).AsyncDelegate;
            X.EndInvoke(ar);
        }
    }
}
