using Marten;
using Products.Api.Endpoints.Management.Events;
using Products.Api.Endpoints.Management.ReadModels;

namespace Products.Api.Endpoints.Services;

public class UserInfoProvider(IDocumentSession session, IHttpContextAccessor httpContextAccessor)
{
    public async Task<UserInfo> GetUserInfoAsync()
    {
        var user = httpContextAccessor.HttpContext?.User;
        var sub = user?.Claims.FirstOrDefault(c => c.Type == "sub")?.Value ?? throw new UnauthorizedAccessException();
        var info = await session.Query<UserInfo>().Where(u => u.Sub == sub).SingleOrDefaultAsync();

        if (info is not null) return info;

        var userId = Guid.NewGuid(); 
        session.Events.StartStream(userId, new UserCreated(userId, sub));
        await session.SaveChangesAsync();
        return new UserInfo
        {
            Id = userId,
            Sub = sub
        };
    }
}