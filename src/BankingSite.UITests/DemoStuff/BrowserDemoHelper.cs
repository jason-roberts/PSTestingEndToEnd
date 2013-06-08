using WatiN.Core;
using WatiN.Core.Native.Windows;

namespace BankingSite.UITests.DemoStuff
{
    internal static class BrowserDemoHelper
    {
        public static void BringToFront(Browser browser)
        {
            browser.ShowWindow(NativeMethods.WindowShowStyle.Minimize);
            browser.ShowWindow(NativeMethods.WindowShowStyle.Maximize);
        }
    }
}
