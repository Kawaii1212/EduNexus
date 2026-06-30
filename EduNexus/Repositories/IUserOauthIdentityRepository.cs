using EduNexus.Models;

namespace EduNexus.Repositories;

public interface IUserOauthIdentityRepository
{
    UserOauthIdentity? GetByProviderAndProviderId(string provider, string providerId);
    void Add(UserOauthIdentity entity);
}
