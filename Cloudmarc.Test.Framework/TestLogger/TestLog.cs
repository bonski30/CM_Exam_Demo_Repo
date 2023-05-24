namespace Cloudmarc.Test.Framework.TestLogger
{
    public class TestLog
    {
        private static string fileName = string.Empty;

        static TestLog()
        {
            fileName = GenerateLogFileName();
        }

        private static string GenerateLogFileName()
        {
            return string.Format("log-{0}-{1}.txt", DateTime.Now.ToString("yyyyMMdd"), Guid.NewGuid().ToString("N").Substring(0, 5));
        }

        public static void WriteLine(string text)
        {
            try
            {
                string logPath = $"C:\\TestLogs\\{fileName}.txt";

                using (var sw = System.IO.File.AppendText(logPath))
                {
                    sw.WriteLine(text);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
