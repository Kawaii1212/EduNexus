using EduNexus.DAOs;
using EduNexus.Models;

namespace EduNexus.Repositories;

public class UserOauthIdentityRepository : IUserOauthIdentityRepository
{
    public UserOauthIdentity? GetByProviderAndProviderId(string provider, string providerId)
    {
        return UserOauthIdentityDAO.Instance.GetByProviderAndProviderId(provider, providerId);
    }

    public void Add(UserOauthIdentity entity)
    {
        UserOauthIdentityDAO.Instance.Add(entity);
    }
}
