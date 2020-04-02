using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Oauth.InMemoryConfigurations
{
    public class InMemoryConfiguration
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[]
            {
                new ApiResource("myapi","Ejemplo de cliente")
            };
        }

        public static IEnumerable<Client> Clents()
        {
            return new[]
            {
                new Client
                {
                    ClientId="clientearestapi",
                    ClientSecrets= new [] {new Secret("clavesecreta".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new []{"myapi"}
                }
            };
        }

        public static IEnumerable<TestUser> Users()
        {
            return new[]
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "daniel",
                    Password = "Qwertyu123!",
                },
                 new TestUser
                {
                    SubjectId = "2",
                    Username = "oscar",
                    Password = "Qwertyu123!",
                }
            };
        }
    }
}
