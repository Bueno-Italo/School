using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace School.Infra.Ioc
{
    public static class ClaimsPricipalExtension
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst("id");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }
            throw new Exception("User ID not found or invalid.");
        }
    }
}