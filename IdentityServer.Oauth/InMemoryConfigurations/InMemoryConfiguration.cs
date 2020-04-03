using IdentityServer4;
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

        // Configuracion de recursos 
        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> Clents()
        {
            return new[]
            {
                // Cliente Servidor de recursos API
                new Client
                {
                    ClientId="clientearestapi",
                    ClientSecrets= new [] {new Secret("clavesecreta".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new []{"myapi"}
                },
                // cliente con flujo Implicito (redireccionamiento)
                new Client
                {
                    ClientId="clientemvc_implicit",
                    ClientSecrets= new [] {new Secret("clavesecreta".Sha256())},
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new []{
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "myapi",

                    },
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new[]{ "http://localhost:58799/signin-oidc" },
                    PostLogoutRedirectUris ={ "http://localhost:58799/signout-callback-oidc" }
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
