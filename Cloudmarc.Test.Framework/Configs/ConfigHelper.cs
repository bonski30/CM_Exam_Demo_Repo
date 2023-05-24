using Cloudmarc.Test.Framework.Common;
using Newtonsoft.Json;

namespace Cloudmarc.Test.Framework.Configs
{
    public static class ConfigHelper
    {
        public static T GetConfig<T>(string fileName)
        {

            var jsonFile = File.ReadAllText($@"{DirHelper.GetSolutionRoot()}\Cloudmarc.Test.Framework\Configs\{fileName}");
            var testData = JsonConvert.DeserializeObject<T>(jsonFile);

            return testData;

        }
    }
}
