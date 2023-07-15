using BussinessLogicLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Net.Mail;
using DataAccessLayer.Repositories;
using Azure;
using System.Runtime.Serialization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("share")]
    public class ShareController : Controller
    {
        [HttpGet(Name = "ShareResume")]
        public void Get(int id, bool download, string? receiver) 
        {
            Resume resume = ResumeRepository.GetResumeById(id);
            string filename = String.Concat("Presiyan Stefanov".Replace(" ", ""), DateTime.Now);
            
            
            FileContentResult result = GeneratePDFFromRazorView(resume, "someName", filename);

            if (download) 
            {
                result.ExecuteResult(ControllerContext);
                return;
            }

            if (receiver != null)
            {
                Attachment attachment = new(filename);
                MailSender.SendMail(receiver, attachment);

                Directory.Delete(filename);
            }
            else 
            {
                throw new Exception("No reveiver specified for email");
            }

        }

        [NonAction]
        public FileContentResult GeneratePDFFromRazorView(Resume resume, string templateName, string filename)
        {
            var Renderer = new ChromePdfRenderer();
            var html = this.RenderViewAsync(templateName, resume);

            using var objPDF = Renderer.RenderHtmlAsPdf(html.Result);
            var objLength = objPDF.BinaryData.Length;

            Response.Headers["Content-Length"] = objLength.ToString();
            Response.Headers.Add("Content-Disposition", $"inline; filename={filename}");

            return File(objPDF.BinaryData, "application/pdf;");
        }
    }

    public static class ControllerPDF
    {
        
        public static async Task<string> RenderViewAsync<TModel>(this Controller controller, string viewName, TModel model, bool partial = false)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controller.ControllerContext.ActionDescriptor.ActionName;
            }
            controller.ViewData.Model = model;
            using (var writer = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, !partial);
                if (viewResult.Success == false)
                {
                    return $"A view with the name {viewName} could not be found";
                }
                ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, writer, new HtmlHelperOptions());
                await viewResult.View.RenderAsync(viewContext);
                return writer.GetStringBuilder().ToString();
            }
        }
    }
}
