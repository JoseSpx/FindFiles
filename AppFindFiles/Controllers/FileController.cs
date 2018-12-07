using AppFindFiles.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppFindFiles.Controllers
{
    [RoutePrefix("Files")]
    public class FileController : Controller
    {
        [Route("Data")]
        [HttpPost]
        public ActionResult GetFiles()
        {
            string path = "C:\\Users\\Jose sp\\source\\repos\\AppFindFiles\\AppFindFiles\\Files";
            string[] files = Directory.GetFiles(path);

            List<FileModel> list = new List<FileModel>();

            for(int i = 0; i < files.Length; i++)
            {
                int index = files[i].LastIndexOf("\\");
                string pathFile = files[i].Substring(index + 1);

                int indexDot = files[i].LastIndexOf(".");
                string extension = files[i].Substring(indexDot + 1);

                FileModel fileModel = new FileModel()
                {
                    Path = files[i],
                    Name = pathFile,
                    Extension = extension
                };

                list.Add(fileModel);

            }

            return Json(list);
        }
    }
}
