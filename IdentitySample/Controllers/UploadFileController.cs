using System;
using System.IO;
using System.Web;
using System.Web.Mvc;


namespace IdentitySample.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: UploadFile
        public ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult UploadImage(HttpPostedFileBase mediaFile)
        {
            if(mediaFile != null && mediaFile.ContentLength > 0)
            {
                string fileName = Path.GetTempFileName();
                var tempPath = Path.GetTempPath();
                var tempFilePath = tempPath + mediaFile.FileName;
                mediaFile.SaveAs(tempFilePath);
                return Json(new { Photo = fileName }, "text/plain");
            }
            //var file = new HttpPostedFileBaseWrapper(mediaFile);
            //var tempPath = Path.GetTempPath();
            //var tempFilePath = tempPath + mediaFile.FileName;
            //file.SaveAs(tempPath);

            //string newNmae = string.Format(SettingManager.Settings["Weixin.PlayImage.Path"], Guid.NewGuid().ToString("N"));
            //newNmae += Path.GetExtension(mediaFile.FileName);
            //try
            //{
            //    AliyunFile.Upload(tempFilePath, newNmae);

            //    return Json(new { url = string.Format("{0}{1}{2}", SettingManager.Settings["Aliyun.ImageDomain"], "/", newNmae) });
            //}
            //catch (Exception error)
            //{
            //    return Json(new { error = error.Message });
            //}
            //finally
            //{
            //    System.IO.File.Delete(tempFilePath);
            //}
            return null;
        }
        public virtual ActionResult RemoveImage()
        {
            return null;
        }
    }
}