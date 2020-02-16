﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MezbanAirKitchen.Authentication
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorize : System.Web.Mvc.AuthorizeAttribute
    {
        private readonly string[] _allowedRoles;

        public CustomAuthorize(params string[] roles)
        {
            _allowedRoles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            var user = httpContext.User;
            if (user.Identity.IsAuthenticated)
            {
                if (isInRole(user, _allowedRoles))
                {
                    return true;
                }
                if (!string.IsNullOrWhiteSpace(Roles))
                {
                    var roles = Roles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (isInRole(user, roles))
                        return true;
                }
                return true;
            }
            return false;
        }

        bool isInRole(IPrincipal user, string[] roles)
        {
            return roles.Length > 0 && roles.Any(user.IsInRole);
        }
    }
}