using Aquality.Selenium.Browsers;
using DataDrivenKsp.Utils.ConfigUtils;
using DataDrivenKsp.Utils.GmailUtils;

namespace DataDrivenKsp.Utils
{
    internal static class WaiterUtils
    {
        public static void WaitGmailMessage()
        {
            AqualityServices.ConditionalWait.WaitForTrue(() => GmailUtil.ReceiveMessages() != null);
        }
    }
}
