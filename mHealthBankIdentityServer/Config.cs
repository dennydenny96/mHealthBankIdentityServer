using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace mHealthBankIdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("resource.WRITE"),
                new ApiScope("resource.READ")
            };

        public static IEnumerable<ApiResource> ApiResources => new[]
        {
            new ApiResource("mhb_bca_API")
            {
                Scopes = new List<string> { "resource.WRITE", "resource.READ"},
                ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
                UserClaims = new List<string> {"role"}
            }
        };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = Environment.GetEnvironmentVariable("BCA_HostedPayment_ClientKey"),
                    ClientName = "Client Mhb-Bca Credentials",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret(Environment.GetEnvironmentVariable("BCA_HostedPayment_ClientSecret").Sha256())
                    },
                    AllowedScopes = { "resource.WRITE", "resource.READ" }
                },

                // Testing
                new Client
                {
                    ClientId = Environment.GetEnvironmentVariable("Testing_ClientKey"),
                    ClientName = "Client Testing Credentials",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret(Environment.GetEnvironmentVariable("Testing_ClientSecret").Sha256())
                    },
                    AllowedScopes = { "resource.WRITE", "resource.READ" }
                },
            };
    }
}