using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rest_Overtime.Model;
using Rest_Overtime.Data;


namespace Rest_Overtime.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        private readonly AppDbContext _appContext;
        private readonly EmpresaDbContext _empresaContext;

        public FormController(AppDbContext appContext, EmpresaDbContext empresaContext)
        {
            _appContext = appContext;
            _empresaContext = empresaContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OvertimeRequestDTO request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                foreach (var emp in request.Employees)
                {
                    // BUSCA NO BANCO DA EMPRESA
                    var funcionarioDb = await _empresaContext.FuncionariosEmpresa
                        .FirstOrDefaultAsync(f => f.RegistrationId == emp.RegistrationId);

                    if (funcionarioDb == null)
                    {
                        return BadRequest($"Funcionário com matrícula {emp.RegistrationId} não encontrado.");
                    }

                    // Preenche o nome vindo do banco da empresa no DTO
                    emp.Name = funcionarioDb.Name;
                }

                // SALVA NO BANCO DA APLICAÇÃO (Horas Extras)
                // Nota: Aqui você precisaria converter o DTO para uma Entity de Banco se quiser persistir
                // Por agora, assumindo que OvertimeRequests aceita o DTO:
                _appContext.OvertimeRequests.Add(request);
                await _appContext.SaveChangesAsync();

                Console.WriteLine($"Recebida a solicitação para o cliente: {request.Client}");

                return Ok(new { message = "Solicitação criada com sucesso", id = Guid.NewGuid() });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("employee/{registrationId}")]
        public async Task<IActionResult> GetEmployees(int registrationId)
        {
            // Busca a entidade completa no banco da empresa
            var employee = await _empresaContext.FuncionariosEmpresa
                .FirstOrDefaultAsync(f => f.RegistrationId == registrationId);

            if (employee == null)
                return NotFound($"Funcionário com matrícula {registrationId} não encontrado.");

            // Mapeia para o DTO que o React espera
            var result = new EmployeeDTO
            {
                RegistrationId = employee.RegistrationId,
                Name = employee.Name
            };

            return Ok(result);
        }


        public enum UnidadeNegocio { VTT, VTE, VAC } //Futuramente, deve se tornar uma tabela

        [HttpGet("units")]
        public IActionResult GetUnits()
        {
            // Retorna ["VTT", "VTE", "VAC"]
            return Ok(Enum.GetNames(typeof(UnidadeNegocio)));
        }

    }
}