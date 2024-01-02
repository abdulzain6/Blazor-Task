using Microsoft.AspNetCore.Mvc;
using MyBlazorApp.Server.Data;
using MyBlazorApp.Server.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UserProfilesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UserProfilesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/userprofiles
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserProfile>>> GetUserProfiles()
    {
        return await _context.UserProfiles.ToListAsync();
    }

    // GET api/userprofiles/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<UserProfile>> GetUserProfile(Guid id)
    {
        var userProfile = await _context.UserProfiles.FindAsync(id);
        
        if (userProfile == null)
        {
            return NotFound();
        }

        return userProfile;
    }

    // POST api/userprofiles
    [HttpPost]
    public async Task<ActionResult<UserProfile>> PostUserProfile(UserProfile userProfile)
    {
        userProfile.Id = Guid.NewGuid();
        _context.UserProfiles.Add(userProfile);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUserProfile), new { id = userProfile.Id }, userProfile);
    }

    // PUT api/userprofiles/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUserProfile(Guid id, UserProfile userProfile)
    {
        if (id != userProfile.Id)
        {
            return BadRequest();
        }

        _context.Entry(userProfile).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserProfileExists(id))
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

    private bool UserProfileExists(Guid id)
    {
        return _context.UserProfiles.Any(e => e.Id == id);
    }
}
