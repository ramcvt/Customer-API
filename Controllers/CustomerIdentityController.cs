using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CustomerIdentityAPI.Infrastructure;
using CustomerIdentityAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CustomerIdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerIdentityController : ControllerBase
    {

        private CustomerInfoContext db;
        private IConfiguration configuration;

        public CustomerIdentityController(CustomerInfoContext dbcontext, IConfiguration configuration)
        {
            db = dbcontext;
            this.configuration = configuration;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("register")]
        public async Task<ActionResult<dynamic>> RegisterCustomer([FromBody] CustomerInfo customer)
        {
            TryValidateModel(customer);
            if (ModelState.IsValid)
            {
                var result = await db.Customers.AddAsync(customer);
                await db.SaveChangesAsync();
                return Created("", new { Email = result.Entity.Email, Name=result.Entity.Name });
            }
            else
            {
                
                return BadRequest(ModelState);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost("token")]
        public ActionResult<dynamic> GetToken([FromBody] LoginModel login)
        {
            TryValidateModel(login);
            if (ModelState.IsValid)
            {
                var tokenObject = GenerateToken(login);

                if (string.IsNullOrEmpty(tokenObject.token))
                    return Unauthorized();
                else
                    return Ok(new { validUser = true, token = tokenObject });
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("addAddress")]
        public async Task<ActionResult<dynamic>> AddAddress([FromBody] CustomerAddress customerAddress)
        {
            TryValidateModel(customerAddress);
            if (ModelState.IsValid)
            {
                var result = await db.custaddress.AddAsync(customerAddress);
                await db.SaveChangesAsync();
                return Ok();
            }
            else
            {

                return BadRequest(ModelState);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("getAddress")]
        public async Task<ActionResult<dynamic>> GetAddress(string key)
        {

            var result = await db.custaddress.FindAsync(key);
          
            return Ok(result);

        }

        private dynamic  GenerateToken(LoginModel login)
        {
            var user = db.Customers.SingleOrDefault(u => u.Email == login.Email && u.Password == login.Password);
            if (user == null)
                return null;
            else
            {
                var claims = new[] {
                                    new Claim(JwtRegisteredClaimNames.Sub ,user.Name),
                                    new Claim(JwtRegisteredClaimNames.Email ,user.Email),
                                    new Claim(JwtRegisteredClaimNames.Jti ,Guid.NewGuid().ToString()),
                                   };

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Secret")));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                     issuer: configuration.GetValue<string>("Jwt:Issuer"),
                     audience: configuration.GetValue<string>("Jwt:Audience"),
                     claims: claims,
                     expires: DateTime.Now.AddMinutes(30),
                     signingCredentials: credentials
                    );

                var stringtoken = new JwtSecurityTokenHandler().WriteToken(token);

               return  new { token = stringtoken , name=user.Name,email=user.Email, phone = user.Phonenumber};
            }


        }
    }
}