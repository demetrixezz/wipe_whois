using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhoIs
{
    class InstanceChecker
    {
        static readonly Mutex mutex = new Mutex(true,"WhoIs");
        private static bool taken;

        public static bool TakeMemory() => taken = mutex.WaitOne(0, true);

        public static void ReleaseMemory()
        {
            if(taken)
                mutex.ReleaseMutex();
        }
    }
}
