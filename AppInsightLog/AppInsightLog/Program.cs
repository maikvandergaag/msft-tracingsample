using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInsightLog {
    class Program {
        static void Main(string[] args) {
            AppTrace.Verbose("Test Verbose");
            AppTrace.Error("Test Error");
            AppTrace.Warning("Test Warning");
            AppTrace.Information("Test Information");
            AppTrace.Critical("Test Critical");

            Console.ReadKey();
        }
    }
}
