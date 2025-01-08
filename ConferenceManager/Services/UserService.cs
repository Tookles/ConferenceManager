using ConferenceManager.Data;
using ConferenceManager.UserLogin;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ConferenceManager.Services
{
    public class UserService()
    {

        private readonly string Key = "GTNONCE9YBYyfRDULsbHP2m8CPFUZxwWzYAAmyA4MhkNt25s10TIcaWg3m93cZdwKTl5GpjnhJ/K6vxu8dqCSnjbQ6KCaLa8vwcjolbXWNnC43pwjqsqY76Sm66cvwPj3pwUtrVJ3+Zf79TmtI8IhKm9oAtozCVzH+wCPZ0JCZ3QDyfP8CBM+7O6Qf/cufgGBfsURnZ5Eac7/z2yK33p6tsgOhEQfDxhgt37ZwVxXAQIt+5M8RK5TD46eBaEsq30hwoecea0Xm+do2bZWVON6EKz4QDuMw9+HE/ZL5XrLWxzua7snXtZPUA6s2wQnkLSIbGXjbhlCb3N+uKew0aEBSmZi+XsVvaRAivWC8JlFks=";

        public string hashedPassword { get; set; }    


        public string SavePassword(string password)
        {
            hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(password, 11);
            return hashedPassword; 
        }


        public bool DoesUserExist(int id)
        {
            return true;
        }

        public bool CheckUsernameExists(string userName)
        {
            return true; 
        }

        public bool ValidatePassword(UserDetails userLogin)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(userLogin.Password, hashedPassword);
         }

        public string GetToken(UserDetails userLogin)
        {
            // get the user from the database for role 

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userLogin.UserId.ToString()),
                new Claim(ClaimTypes.Name,userLogin.UserName),
                new Claim(ClaimTypes.Role,"Admin")
            };

            var token = new JwtSecurityToken("Nick&Rachel", "ConferenceManager", userClaims,
                 expires: DateTime.UtcNow.AddHours(1), signingCredentials: credentials); 

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
