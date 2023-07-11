using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("templates")]
    public class TemplateController : Controller
    {
        [HttpGet(Name = "GetTemplates")]
        public List<Template> Get()
        {
            return TemplateRepository.GetAllTemplates();
        }
    }
}
