using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.WebAPI.Core.User
{
    public class ContextUser : IContextUser
    {
        private readonly IHttpContextAccessor _acessor;
        private string Name => _acessor.HttpContext.User.Identity.Name;

        public ContextUser(IHttpContextAccessor acessor)
        {
            _acessor = acessor;
        }

        public HttpContext GetHttpContext()
        {
            return _acessor.HttpContext;
        }

        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(_acessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }

        public string GetUserEmail()
        {
            return IsAuthenticated() ? _acessor.HttpContext.User.GetUserEmail() : string.Empty;
        }

        public IEnumerable<Claim> GetClaims()
        {
            return IsAuthenticated() ? _acessor.HttpContext.User.Claims : new List<Claim>();
        }

        public bool hasRole(string role)
        {
            return IsAuthenticated() ? _acessor.HttpContext.User.IsInRole(role) : false; 
        }

        public bool IsAuthenticated()
        {
            return _acessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
