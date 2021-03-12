using System.Collections.Generic;

using IdentityModel;
using IdentityServer4.Models;

namespace keksualni.Auth
{
    public static class Configuration
    {
        public static IEnumerable<ApiResource> ApiResources => new[]
        {
            new ApiResource("api")
            {
                Scopes = { "api.read", "api.write", "api.request-write" }
            }
        };

        public static IEnumerable<Client> Clients => new[]
        {
            new Client
            {
                ClientId = "driver-app",
                AllowedScopes = { "api.read" },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("driver-secret".ToSha256()) }
            },
            new Client
            {
                ClientId = "admin-app",
                AllowedScopes = { "api.read", "api.write" },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("admin-secret".ToSha256()) }
            },
            new Client
            {
                ClientId = "customer-app",
                AllowedScopes = { "api.read", "api.request-write" },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("customer-secret".ToSha256()) }
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new[]
        {
            new ApiScope("api.read"),
            new ApiScope("api.write"),
            new ApiScope("api.request-write")
        };
    }
}