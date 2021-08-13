using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Todo.Application.Authentication.Interfaces;
using Todo.Core.Entities;
using Todo.Core.Models;

namespace Todo.Application.Authentication
{
    public class TokenHandle : ITokenHandle
    {
        public Response<AccessToken> CreateAccessToken(User user)
        {
            try
            {
                var accessTokenExpiration = DateTime.Now.AddMinutes(10);
                var securityKey = SignHandle.GetSecurityKey("mysecuritykeymysecuritykeymysecuritykeyahmet");

                SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(

                    audience: "www.todo.com",
                    issuer: "www.todo.com",
                    expires: accessTokenExpiration,
                    notBefore: DateTime.Now,
                    claims: GetClaims(user),
                    signingCredentials: signingCredentials

                    );

                var handle = new JwtSecurityTokenHandler();
                var token = handle.WriteToken(jwtSecurityToken);
                AccessToken accessToken = new AccessToken();
                accessToken.Token = token;
                accessToken.Expiration = accessTokenExpiration;
                return Response.Ok("Success", accessToken);
            }
            catch (Exception ex)
            {

                return Response.Fail<AccessToken>(ex.Message);
            }
        }

        private IEnumerable<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
           {

               new Claim(ClaimTypes.NameIdentifier,user.Id),
               new Claim(ClaimTypes.Email,user.Email),
           };
            return claims;
        }

    }
}
