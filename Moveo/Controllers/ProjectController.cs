using DBAdapter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManager;

namespace Moveo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectContext _context;

        public ProjectsController(ProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> GetProjects()
        {
            return await _context.ProjectModels.Include(p => p.Tasks).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ProjectModel>> CreateProject(ProjectModel project)
        {
            _context.ProjectModels.Add(project);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProjects), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, ProjectModel updatedProject)
        {
            var project = await _context.ProjectModels.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            project.Name = updatedProject.Name;
            project.Description = updatedProject.Description;
            _context.ProjectModels.Update(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.ProjectModels.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
             
            _context.ProjectModels.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
