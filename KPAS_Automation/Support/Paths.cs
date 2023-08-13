using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPAS_Automation.Support
{
    public class Paths
    {
        private static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string ReportsPath => Path.Combine(BaseDirectory, "Reports");
        public static string ScreenshotsPath => Path.Combine(ReportsPath, "Screenshots");
        public static string HtmlReport => Path.Combine(ReportsPath, "TestReport.html");

    }
}
