using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Autorizador.ULF.Cliente.Model;

public class AuthorizeRolesAttribute : AuthorizeAttribute
{
    public AuthorizeRolesAttribute(params string[] roles) : base()
    {
        Roles = string.Join(",", roles);
    }
}
