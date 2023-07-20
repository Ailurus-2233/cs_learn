using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn21_asynchronous.Model
{
    public class CancellationTokenDemo
    {
        public async Task RunAsync(CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
                return;
            await Task.Run(() => CycleMethod(ct), ct);
        }
        // CycleMethod彻底执行完需要5s
        void CycleMethod(CancellationToken ct)
        {
            Console.WriteLine("Starting CycleMethod");
            const int max = 5;
            for (int i = 0; i < max; i++)
            {
                if (ct.IsCancellationRequested)   // 监控CancellationToken
                    return;
                Thread.Sleep(1000);
                Console.WriteLine("    {0} of {1} iterations completed", i + 1, max);
            }
        }

        static void Test()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            CancellationTokenDemo mc = new CancellationTokenDemo();
            Task t = mc.RunAsync(token);
            Thread.Sleep(3000);//等待3秒
            cts.Cancel();      //取消操作
            t.Wait();
            Console.WriteLine("Was Cancelled: {0}", token.IsCancellationRequested);
            Console.ReadKey();
        }
    }

}
