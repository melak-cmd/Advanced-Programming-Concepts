using System;
using System.Threading;

namespace TimerExample
{
    class StatusChecker
    {
        private int maxCount;
        private int invokeCount;

        public StatusChecker(int count)
        {
            // TODO: Complete member initialization
            this.maxCount = count;
            invokeCount = 0;
        }

        // This method is called by the timer delegate.
        public void CheckStatus(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            Console.WriteLine("{0} Checking status {1,2}.",
                DateTime.Now.ToString("h:mm:ss.fff"),
                (++invokeCount).ToString());

            if (invokeCount == maxCount)
            {
                 //Reset the counter and signal Main.
                invokeCount = 0;
                autoEvent.Set();
            }
        }
    }
}
