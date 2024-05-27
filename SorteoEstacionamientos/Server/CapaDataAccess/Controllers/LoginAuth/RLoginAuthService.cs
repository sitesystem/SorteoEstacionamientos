using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using SorteoEstacionamientos.Shared.CapaEntities.Common;
using SorteoEstacionamientos.Shared.CapaEntities.Request;
using SorteoEstacionamientos.Shared.CapaEntities.Response;
using SorteoEstacionamientos.Shared.CapaTools;

namespace SorteoEstacionamientos.Server.CapaDataAccess.Controllers.LoginAuth
{
    public class RLoginAuthService(IOptions<AppSettings> appSettings, DBSorteoParkingContext db) : ILoginAuthService
    {
        private readonly AppSettings _appSettings = appSettings.Value;
        private readonly DBSorteoParkingContext _db = db;

        public async Task<ResponseDTO_LoginUsuario> Auth(RequestDTO_LoginAuth model)
        {
            ResponseDTO_LoginUsuario participanteResponse = new();

            string spassword = Encrypt.GetSHA256(model.PartContraseña);
            var participante = await _db.MsTbParticipantes
                                   .Where(l => l.PartEmail == model.PartCorreoPersonal && l.PartContraseña == spassword && l.PartStatus.Equals(true))
                                   .FirstOrDefaultAsync();
            if (participante != null)
            {
                // DATOS ID DEL USUARIO
                participanteResponse.IdParticipante = participante.IdParticipante;
                participanteResponse.PartIdRol = participante.PartIdRol;
                participanteResponse.PartIdTipoParticipante = participante.PartIdTipoParticipante;
                // DATOS PERSONALES
                participanteResponse.PartNombre = participante.PartNombre;
                participanteResponse.PartPrimerApellido = participante.PartPrimerApellido;
                participanteResponse.PartSegundoApellido = participante.PartSegundoApellido;
                participanteResponse.PartCurp = participante.PartCurp;
                participanteResponse.PartNoTelCelular = participante.PartNoTelCelular;
                participanteResponse.PartEmail = participante.PartEmail;
                participanteResponse.PartContraseña = participante.PartContraseña;
                // DATOS ACADÉMICOS
                participanteResponse.PartNoEmpleado = participante.PartNoEmpleado;
                participanteResponse.PartBoleta = participante.PartBoleta;
                participanteResponse.PartIdCarrera = participante.PartIdCarrera;
                participanteResponse.PartIdSemestre = participante.PartIdSemestre;
                // DATOS VEH[ICULO
                participanteResponse.PartIdTipoVehiculo = participante.PartIdTipoVehiculo;
                participanteResponse.PartIdEdoRepMexVehiculo = participante.PartIdEdoRepMexVehiculo;
                participanteResponse.PartIdTipoPlaca = participante.PartIdTipoPlaca;
                participanteResponse.PartPlaca = participante.PartPlaca;
                participanteResponse.PartMarca = participante.PartMarca;
                participanteResponse.PartModelo = participante.PartModelo;
                participanteResponse.PartVersion = participante.PartVersion;
                participanteResponse.PartAño = participante.PartAño;
                participanteResponse.PartColor = participante.PartColor;
                // DATOS DE LOS ARCHIVOS
                participanteResponse.PartFileNameCredencialIpnine = participante.PartFileNameCredencialIpnine;
                participanteResponse.PartFileNameComprobanteEstudiosHorario  = participante.PartFileNameComprobanteEstudiosHorario;
                participanteResponse.PartFileNameLicenciaConducir = participante.PartFileNameLicenciaConducir;
                participanteResponse.PartFileNameTarjetaCirculacion = participante.PartFileNameTarjetaCirculacion;
                // OTROS DATOS
                participanteResponse.PartFechaHoraAlta = participante.PartFechaHoraAlta;
                participanteResponse.PartRegistrado = participante.PartRegistrado;
                participanteResponse.PartStatus = participante.PartStatus;
            }

            return participanteResponse;
        }

        private string GetToken(MsTbParticipante participante)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            //var key = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var key = Encoding.UTF8.GetBytes(_appSettings.Secreto ?? string.Empty);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = null,
                Audience = null,
                Subject = new ClaimsIdentity(
                        new Claim[]
                        {
                            new(ClaimTypes.NameIdentifier, participante.IdParticipante.ToString()),
                            new(ClaimTypes.Name, participante.PartNombre.ToString()),
                            new(ClaimTypes.Role, participante.PartIdRol.ToString()),
                            new("ID", participante.IdParticipante.ToString()),
                            new("Name", participante.PartNombre.ToString() + " " + participante.PartPrimerApellido.ToString() + " " + participante.PartSegundoApellido?.ToString()),
                            new("Email", participante.PartEmail.ToString()),
                            new("Rol", participante.PartIdRol.ToString()),
                            new("TipoPersonal", participante.PartIdTipoParticipante.ToString()),
                            new("RecuperarContraseña", participante.PartContraseña.ToString().ToLower())
                        }
                    ),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }




    }
}
