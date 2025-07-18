using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BaiTuanTuan3_NguyenChiTruong;
public class ExtentReportManager
{
    private static ExtentReports extent;

    public static ExtentReports GetInstance()
    {
        if (extent == null)
        {
            var htmlReporter = new ExtentHtmlReporter("Reports\\index.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        return extent;
    }
}
