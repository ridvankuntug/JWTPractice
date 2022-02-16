//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;

//namespace JWTPractice
//{
//    public class JwtSettings : ServiceCollection
//    {
//        private readonly IServiceCollection _services;
//        private readonly string jwtKey = "Uzun string key degeri";

//        public JwtSettings(IServiceCollection services)
//        {
//            _services = services;
//        }

//        public void CustomJwtSettings()
//        {
//            {
//                _services.AddAuthentication(c =>
//                {
//                    c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                    c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//                }).AddJwtBearer(c =>
//            {
//                c.RequireHttpsMetadata = false;
//                c.SaveToken = true;
//                c.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey)),
//                    ValidateIssuer = false,
//                    ValidateAudience = false
//                };
//            }); ;

//            }

//        }
//    }
//}
