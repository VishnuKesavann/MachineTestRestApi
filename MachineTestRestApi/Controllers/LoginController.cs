using MachineTestRestApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;
using MachineTestRestApi.Models;

namespace MachineTestRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginRepository _loginRepository;

        private readonly IConfiguration _configuration;
        public LoginController(ILoginRepository loginRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
        }


        #region

        private TblLogin UserValidation(string username, string password)
        {

            TblLogin users = _loginRepository.ValidationUser(username, password);

            if (users == null)
            {
                return null;
            }

            return users;
        }
        //Generate Json web Token

        private string GenerateJSONWebToken(TblLogin users)
        {
            //security key

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            //generate token

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion

        [HttpGet("{userName}/{password}")]

        public IActionResult userLogin(string username, string password)
        {

            IActionResult response = Unauthorized();

            //Authenticate the user by passing username,password

            TblLogin dbLogin = UserValidation(username, password);

            if (dbLogin != null)
            {
                var tokenString = GenerateJSONWebToken(dbLogin);
                response = Ok(new
                {

                    uName = dbLogin.Username,
                    uPassword = dbLogin.Password,
                    token = tokenString

                });
            }
            return response;
        }




        /*
                //get the User
                #region validateUserlogin
                [HttpGet]
                private TblLogin AuthenticateUser(string username, string password)
                {
                    //Validate the user credintials
                    TblLogin user = _loginRepository.ValidationUser(username, password);
                    if (user != null)
                    {
                        return user;
                    }
                    return null;
                }
                #endregion

                //Generate JSON web Token
                private string GenerateJSONWebToken(TblLogin user)
                {
                    //security key
                    var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

                    //generate token
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);
                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
        */

    }
}
