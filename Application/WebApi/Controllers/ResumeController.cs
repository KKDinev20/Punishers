﻿using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("resumes")]
    public class ResumeController : Controller
    {
        [HttpPost(Name = "PostResumes")]
        public void Post(Resume resume) 
        {
            ResumeRepository.CreateResume(resume);
        }

        [HttpGet(Name = "{id}")]
        public Resume Get(int id) 
        {
            return ResumeRepository.GetResumeById(id);
        }

        [HttpPut(Name = "{id}")]
        public void Put(Resume resume) 
        {
            ResumeRepository.UpdateResume(resume);
        }

        [HttpDelete(Name = "{id}")]
        public void Delete(int id) 
        {
            ResumeRepository.DeleteResume(id);
        }
    }
}
