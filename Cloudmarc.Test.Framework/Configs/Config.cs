using Newtonsoft.Json;

namespace Cloudmarc.Test.Framework.Configs
{
    public class Config
    {
        public string? Environment { get; set; }
        public string? Browser { get; set; }
        public string? WaitTimeout { get; set; }
    }

    public class Urls
    {
        public string? Staging { get; set; }
        public string? UAT { get; set; }
        public string? Prod { get; set; }
        public string? QA { get; set; }
    }
}
