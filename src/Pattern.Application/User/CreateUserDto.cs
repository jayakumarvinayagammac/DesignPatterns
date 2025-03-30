namespace Pattern.Application.User
{
    public record CreateUserDto(
        int UserId, 
        string? FirstName, 
        string? LastName, 
        string? Email,
        string? PasswordHash, 
        DateTime CreatedAt);
}
