using Microsoft.EntityFrameworkCore;
using TaskTrackr.Contratcs.Request;
using TaskTrackr.Data;
using TaskTrackr.Entities;
using TaskTrackr.Services.Interface;

namespace TaskTrackr.Services;

public class AssignmentService: IAssignmentService
{
    private readonly EfCoreDbContext _dbcontext;

    public AssignmentService(EfCoreDbContext context)
    {
        _dbcontext = context;
    }

    public async Task<Assignment> AddAssignmentAsync(AssignmentRequestDto dto)
    {
        var assignmentExists = await _dbcontext.Assignments.AnyAsync();

        if (!assignmentExists)
        {
            throw new Exception("Assignment already exists");
        }

        var Assignment = new Assignment()
        {
            AssignmentName = dto.AssignmentName,
            AssignmentDescription = dto.AssignmentDescription,
        };
        
        _dbcontext.Assignments.Add(Assignment);
        await _dbcontext.SaveChangesAsync();
        
        return Assignment;
    }

    public async Task<Assignment> UpdateAssignmentAsync(int id, AssignmentRequestDto dto)
    {
        var assignment = await _dbcontext.Assignments.FindAsync(id);
        if (assignment == null)
        {
            throw new Exception("Assignment not found");
        }
        
        assignment.AssignmentName = dto.AssignmentName;
        assignment.AssignmentDescription = dto.AssignmentDescription;
        
        _dbcontext.Update(assignment);
        
        await _dbcontext.SaveChangesAsync();
        return assignment;
    }

    public async Task DeleteAssignmentAsync(int id)
    {
       var assignment =  await _dbcontext.Assignments.FindAsync(id);

       if (assignment == null)
       {
           throw new Exception("Assignment not found");
       }
       
       _dbcontext.Assignments.Remove(assignment);
       await _dbcontext.SaveChangesAsync();
    }
}