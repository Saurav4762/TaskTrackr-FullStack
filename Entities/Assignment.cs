namespace TaskTrackr.Entities;

public class Assignment
{
    public int Id { get; set; }
    
    public string AssignmentName { get; set; }
    
    public string AssignmentDescription { get; set; }
    
    public DateTime AssignmentDate { get; set; }
}