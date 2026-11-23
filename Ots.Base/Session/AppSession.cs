namespace Ots.Base;

public class AppSession : IAppSession
{
    public string UserName { get; }
    public string Token { get; }
    public DateTime Expiration { get; }
    public string UserId { get; }
    public string UserRole { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public HttpContext httpContext { get; }
}