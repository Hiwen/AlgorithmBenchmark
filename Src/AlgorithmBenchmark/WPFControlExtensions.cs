using System;
using System.Threading;
using System.Windows.Threading;

namespace AlgorithmBenchmark
{
    public static class WPFControlExtensions
    {
        public static void InvokeIfNeeded(
        this DispatcherObject ctl, Action doit)
        {
            if (Thread.CurrentThread !=
                ctl.Dispatcher.Thread)
            {
                ctl.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, doit);
            }
            else
            {
                doit();
            }
        }

        public static void InvokeIfNeeded(
        this DispatcherObject ctl, Action doit, DispatcherPriority priority)
        {
            if (Thread.CurrentThread !=
                ctl.Dispatcher.Thread)
            {
                ctl.Dispatcher.Invoke(priority, doit);
            }
            else
            {
                doit();
            }
        }

        public static void InvokeIfNeeded<T>(
            this DispatcherObject ctl,
            Action<T> doit, T args)
        {
            if (Thread.CurrentThread != ctl.Dispatcher.Thread)
            {
                ctl.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, doit, args);
            }
            else
            {
                doit(args);
            }
        }

        public static void InvokeIfNeeded<T>(
            this DispatcherObject ctl,
            Action<T> doit, T args, DispatcherPriority priority)
        {
            if (Thread.CurrentThread != ctl.Dispatcher.Thread)
            {
                ctl.Dispatcher.Invoke(priority, doit, args);
            }
            else
            {
                doit(args);
            }
        }
    }
}
