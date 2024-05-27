using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SorteoEstacionamientos.Shared.CapaEntities.Request;
using SorteoEstacionamientos.Shared.CapaEntities.Response;

namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers.LoginAuth
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAuthController(ILoginAuthService loginAuthService) : ControllerBase
    {
        private readonly ILoginAuthService _loginAuthService = loginAuthService;

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] RequestDTO_LoginAuth model)
        {
            Response<ResponseDTO_LoginUsuario> oResponse = new();

            var participanteResponse = await _loginAuthService.Auth(model);

            if (participanteResponse == null || participanteResponse.IdParticipante == 0) 
            {
                oResponse.Success = 0;
                oResponse.Message = "Usuario y/o contraseña incorrecta o inhabilitado";
                return BadRequest(oResponse);
            }

            oResponse.Success = 1;
            oResponse.Message = "Usuario y contraseña correctos";
            oResponse.Data = participanteResponse;

            return Ok(participanteResponse.PartStatus);
        }
    }
}
