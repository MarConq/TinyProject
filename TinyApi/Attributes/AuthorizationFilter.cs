using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using TinyApi.Extensions.Http;
using TinyApi.Helpers;
using TinyModel;
using static TinyApi.Helpers.JwtHelper;

namespace TinyApi.Attributes
{
    public class AuthorizationFilter: ActionFilterAttribute
    {
        private List<UserRole> _roles;
        private AuthorizationFilter() {}
        public AuthorizationFilter(UserRole role)
        {
            _roles = new List<UserRole> { role };
        }
        public AuthorizationFilter(params UserRole[] roles)
        {
            _roles = roles.ToList();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var authHeader = context.HttpContext.Request.GetHeader("Authorization");

            if (authHeader == null || !authHeader.StartsWith("Bearer "))
            {
                throw new Exception("Authorization Bearer token is missing");
            }

            string token = authHeader.Replace("Bearer", "").Trim();

            JwtContext jwtContext = null;

            try
            {
                jwtContext = Decode(token);
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException("Invalid token");
            }

            if (jwtContext != null && _roles.Contains(jwtContext.UserRole))
            {
                base.OnActionExecuting(context);
            } 
            else
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }
        }
    }
}
