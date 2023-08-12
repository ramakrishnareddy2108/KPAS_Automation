using KPAS_Automation.Enums;

namespace KPAS_Automation.Infrastructure.Config
{
    public class BrowserConfig
    {
        public BrowserType BrowserType { get; set; }
        public bool RecordTrace { get; set; }
        public bool RecordVideo { get; set; }
        public int SlowMo { get; set; }
        public bool Headless { get; set; }
    }
}