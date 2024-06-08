namespace Business.Dtos.Users;

public class DeletedUserResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string Lastname { get; set; }
    public string? Email { get; set; }
}
