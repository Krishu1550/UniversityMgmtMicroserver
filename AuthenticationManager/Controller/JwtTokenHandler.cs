using AuthenticationManager.DataBase;
using AuthenticationManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationManager.Controller
{
    public class JwtTokenHandler
    {
       
        AuthDBContext _authDB;
        public const string JWT_SECURITY_KEY = "yPkCqn4kSWLtaJwXvN2jGzpQRyTZ3gdXkt7FeBJP";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;


        public JwtTokenHandler(AuthDBContext authDB)
        {
            this._authDB = (AuthDBContext) authDB;
        }

        public async Task <AuthenticationResponse> GenerateJwtToken(AuthenticationRequest authAccount)
        {

            if (string.IsNullOrWhiteSpace(authAccount.UserName) || string.IsNullOrWhiteSpace(authAccount.Password))
                return null;


            UserAccount userAccount = await _authDB.Accounts.Where(a=>a.UserName == authAccount.UserName
            && a.Password==authAccount.Password).FirstOrDefaultAsync();
            if (userAccount == null) return null;
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
               new Claim( JwtRegisteredClaimNames.Name, authAccount.UserName),
                new Claim( "Role",userAccount.Role)
                }
                );

            var signingCredentials = new SigningCredentials(
               new SymmetricSecurityKey(tokenKey),
               SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                UserName = userAccount.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token
            };

        }

        public async Task<bool> Registeration(UserAccount userAccount)
        {

                if(userAccount== null)
                {
                   return false;

                }

                await _authDB.Accounts.AddAsync(userAccount);
                await _authDB.SaveChangesAsync();
            return true;
        

        }

     

    }
}

