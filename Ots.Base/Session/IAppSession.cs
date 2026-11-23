namespace Ots.Base;

public interface IAppSession
{
    string UserName { get; }
    string Token { get; }
    DateTime Expiration { get; }
    string UserId { get; }
    string UserRole { get; }
    string FirstName { get; }
    string LastName { get; }
    HttpContext httpContext { get; }
}