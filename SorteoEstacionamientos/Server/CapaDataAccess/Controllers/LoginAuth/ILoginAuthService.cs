using SorteoEstacionamientos.Shared.CapaEntities.Request;
using SorteoEstacionamientos.Shared.CapaEntities.Response;

namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers.LoginAuth
{
    public interface ILoginAuthService
    {
        public Task<ResponseDTO_LoginUsuario> Auth(RequestDTO_LoginAuth model);
    }
}
