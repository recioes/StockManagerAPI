//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using StockAPI.Core.DTOs.Auth;

//namespace StockAPI.Controllers.Auth
//{
//    public class AuthController : ApiController
//    {
//        //private readonly ILoginService _loginService;
//        //public AuthController(ILoginService loginService)
//        //{
//        //    _loginService = loginService;
//        //}

//        #region Login
//        [AllowAnonymous]
//        [HttpPost("v1/login")]
//        //public async Task<IActionResult> Login([FromBody] LoginRequestDto login)
//        {
//            if (!ModelState.IsValid)
//            {
//                return ValidateAndResponse();
//            }

//          //  return Ok(await _loginService.LoginAsync(login.Email, login.Password));
//        }
//        #endregion
//    }
//}
