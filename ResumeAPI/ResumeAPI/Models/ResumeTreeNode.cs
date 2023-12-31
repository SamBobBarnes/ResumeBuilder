namespace ResumeAPI.Models;

public class ResumeTreeNode
{
    public List<ResumeTreeNode> Children { get; set; }
    public string Comments { get; set; }
    public Guid Id { get; set; }
    public bool Active { get; set; }
    public Guid UserId { get; set; }
    public Guid? ParentId { get; set; }
    public string Content { get; set; }
    public string NodeType { get; set; }
    public int Depth { get; set; }
    public int Order { get; set; }
}
