using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDWebAPI.Models;
using CRUDWebAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using CRUDWebAPI.Services;
using static CRUDWebAPI.Services.EmailService;

namespace CRUDWebAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectContext _context;
        public ProjectController(ProjectContext context)
        {
            _context = context;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> GetProject(int? id)
        {
            try
            {
                
                if (id != null)
                {
                    var project = await _context.Project.FindAsync(id);
                    if (project == null)
                    {
                        return NotFound();
                    }
                    
                    return Ok(project);
                }
                else
                {
                    var project = await _context.Project.ToListAsync();
                    if (project.Count == 0)
                    {
                        return NotFound();
                    }
                    return Ok(project);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project projects)
        {
            if (id != projects.id)
            {
                return BadRequest();
            }

            _context.Entry(projects).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (_context.Project.Any(e => e.id == id) == false)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostProject(Project projects)
        {

            _context.Project.Add(projects);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = projects.id }, projects);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Project.Remove(project);
            await _context.SaveChangesAsync();

            return Ok("Deleted");
        }
    }
}
