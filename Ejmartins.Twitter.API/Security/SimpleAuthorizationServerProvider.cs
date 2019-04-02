using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Cors;

namespace Ejmartins.Twitter.API.Security
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    //public class SimpleAuthorizationServerProvider: OAuthAuthorizationServerProvider
    //{
    //    private readonly IUsuarioRepository _usuarioRepository;
    //    public SimpleAuthorizationServerProvider(IUsuarioRepository usuarioRepository)
    //    {
    //        _usuarioRepository = usuarioRepository;
    //    }
    //    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    //    {
    //        context.Validated();
    //    }

    //    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    //    {
    //        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
    //        context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {"*"});

    //        IFormCollection parameters = await context.Request.ReadFormAsync();

    //        var usuario = _usuarioRepository.GetByLoginAndPassword(context.UserName, context.Password, Int32.Parse(parameters.Get("Role")));

    //        var roles = new List<string> {
    //            "", "administrador","recursos-humanos","profissional"
    //        };

    //        if (usuario != null)
    //        {
    //            identity.AddClaim(new Claim("Tipo", usuario.Tipo.ToString()));
    //            identity.AddClaim(new Claim("Login", usuario.NomeUsuario));
    //            identity.AddClaim(new Claim("Id", usuario.Id.ToString()));
    //            identity.AddClaim(new Claim("Role", roles[usuario.Tipo]));

    //            var properties = new AuthenticationProperties(new Dictionary<string, string> {
    //                {
    //                    "userdisplayname", context.UserName
    //                },
    //                {
    //                    "role", roles[usuario.Tipo]
    //                }
    //            });

    //            var ticket = new AuthenticationTicket(identity, properties);
    //            context.Validated(ticket);
    //        }
    //        else
    //        {
    //            context.SetError("invalid_grant", "O usuário e/ou senha fornecidos são inválidos");
    //        }
    //    }
    //}
}