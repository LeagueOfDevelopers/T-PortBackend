using System;

namespace TPortApi.Security
{
    public interface IJwtIssuer
    {
        string IssueJwt(Guid userId);
    }
}