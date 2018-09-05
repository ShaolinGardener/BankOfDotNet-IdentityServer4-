using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace BankOfDotNet.IdentitySvr
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("bankOfDotNetApi", "Customer API for BankOfDotNet")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            //Client-Credential based grant type
            return new List<Client>
            {
                new Client
                {
                    ClientId="client",
                    AllowedGrantTypes=GrantTypes.ClientCredentials, // machine to machine or trusted resources 
                    ClientSecrets=
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={"bankOfDotNetApi"}
                }
            };
        }
    }
}

/*
Grant Types:
Client Credentials (no user involved, machine to machine, trusted 1st party sources, server/server
Resource Owner Password (user involved, trusted 1st party apps (spa, js, native 1st party
Authorization Code (google, facebook, etc, user involved, web app (server app), )
Implicit (web applications, user, server side web apps)
Hybrid (combination of implicit and authorization code, user, native apps, server side web apps, native desktop, mobile apps)

oath 2.0 and oidc (open id connect) protocols 







Client Credentials:

+---------+                                  +---------------+
:         :                                  :               :
:         :>-- A - Client Authentication --->: Authorization :
: Client  :                                  :     Server    :
:         :<-- B ---- Access Token ---------<:               :
:         :                                  :               :
+---------+                                  +---------------+




Resource Owner Password Credentials:

+----------+
| Resource |
|  Owner   |
|          |
+----------+
     v
     |    Resource Owner
    (A) Password Credentials
     |
     v
+---------+                                  +---------------+
|         |>--(B)---- Resource Owner ------->|               |
|         |         Password Credentials     | Authorization |
| Client  |                                  |     Server    |
|         |<--(C)---- Access Token ---------<|               |
|         |    (w/ Optional Refresh Token)   |               |
+---------+                                  +---------------+
*/
