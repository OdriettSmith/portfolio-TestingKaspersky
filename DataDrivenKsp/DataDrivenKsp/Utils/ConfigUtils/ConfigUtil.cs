using System.Text.Json;
using System.IO;
using DataDrivenKsp.BusinessModels;

namespace DataDrivenKsp.Utils.ConfigUtils
{
    internal static class ConfigUtil
    {
        private const string UrlsFilePath = "Configs//urls.json";
        private const string TestDataFilePath = "TestData//testingData.json";

        public static string GetUrl()
        {
            using (FileStream fs = File.Open(UrlsFilePath, FileMode.Open))
            {
                Urls jsonData = JsonSerializer.Deserialize<Urls>(fs);
                return jsonData.AuthorizationUrl;
            }
        }

        public static UsedData[] GetUsedData()
        {
            using (FileStream fs = new FileStream(TestDataFilePath, FileMode.Open))
            {
                UsedData[] usedData = JsonSerializer.Deserialize<UsedData[]>(fs);
                return usedData;
            }
        }
    }
}
