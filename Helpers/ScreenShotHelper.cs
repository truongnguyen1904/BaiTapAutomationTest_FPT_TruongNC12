//using OpenQA.Selenium;
//using System;
//using System.IO;

//namespace BaiTuanTuan3_NguyenChiTruong.Helper
//{
//    public static class ScreenshotHelper
//    {
//        public static string CaptureScreenshot(IWebDriver driver, string testName)
//        {
//            try
//            {
//                if (!Directory.Exists("Screenshots"))
//                    Directory.CreateDirectory("Screenshots");

//                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
//                string fileName = $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
//                string filePath = Path.Combine("Screenshots", fileName);
//                screenshot.SaveAsFile(filePath);

//                return filePath;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Failed to capture screenshot: " + ex.Message);
//                return null;
//            }
//        }

//    }
//}
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.IO;

namespace BaiTuanTuan3_NguyenChiTruong.Helper
{
    public static class ScreenshotHelper
    {
        private static string screenshotsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");

        static ScreenshotHelper()
        {
            if (!Directory.Exists(screenshotsFolder))
            {
                Directory.CreateDirectory(screenshotsFolder);
            }
        }

        public static string CaptureScreenshot(IWebDriver driver, string testName)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fileName = $"{testName}_{timestamp}.png";
                string filePath = Path.Combine(screenshotsFolder, fileName);
                screenshot.SaveAsFile(filePath);
                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
                return null;
            }
        }

        public static void AddScreenshotToReport(ExtentTest test, IWebDriver driver, string screenshotName)
        {
            string screenshotPath = ScreenshotHelper.CaptureScreenshot(driver, screenshotName);

            if (screenshotPath != null)
            {
                test.Log(Status.Info, "Screenshot captured: " + screenshotName);
                test.AddScreenCaptureFromPath(screenshotPath); 
            }
            else
            {
                test.Log(Status.Warning, "Screenshot could not be captured for " + screenshotName);
            }
        }


    }
}
