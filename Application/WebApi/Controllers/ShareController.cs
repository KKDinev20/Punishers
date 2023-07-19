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
using MySqlX.XDevAPI.Common;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("resumes")]
    public class ShareController : Controller
    {
        [HttpPost]
        [Route("email")]
        public void Email(int id, int templateId, string? receiver)
        {
            Resume resume = ResumeRepository.GetResumeById(id);
            Template template = TemplateRepository.GetTemplateById(templateId);
            string filename = String.Concat(resume.Personalinfos.First().FullName.Replace(" ", ""), DateTime.Now);

            GeneratePDFFromRazorView(resume, template.TemplateFilePath, filename);

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

        [HttpPost]
        [Route("download")]
        public void Download(int id, int templateId)
        {
            Resume resume = ResumeRepository.GetResumeById(id);
            Template template = TemplateRepository.GetTemplateById(templateId);
            string filename = String.Concat(resume.Personalinfos.First().FullName.Replace(" ", ""), DateTime.Now);

            var result = GeneratePDFFromRazorView(resume, template.TemplateFilePath, filename);

            result.ExecuteResult(ControllerContext);
            return;
        }
        [NonAction]
        private FileContentResult GeneratePDFFromRazorView(Resume resume, string templateName, string filename)
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
