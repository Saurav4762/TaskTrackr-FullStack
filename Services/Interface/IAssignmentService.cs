using TaskTrackr.Contratcs.Request;
using TaskTrackr.Entities;

namespace TaskTrackr.Services.Interface;

public interface IAssignmentService
{
    Task <Assignment> AddAssignmentAsync (AssignmentRequestDto dto);
    
    Task<Assignment> UpdateAssignmentAsync (int id,AssignmentRequestDto dto);
    
    Task DeleteAssignmentAsync (int id);
}