using Microsoft.AspNetCore.Mvc;
using Rest_Overtime.Model; // Importa o "sobrenome" lógico, não o caminho do arquivo


namespace Rest_Overtime.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult > Create([FromBody] OvertimeRequestDTO request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); // Valida o modelo e retorna erros, se houver


            try
            {

                foreach (var emp in request.Employees)
                {

                    var funcionarioDb = await _context.Funcionarios.
                        FirstOrDefaultAsync(f => f.Matricula == emp.RegistrationId); ;

                    if (funcionarioDb == null)
                    {
                        return BadRequest($"Funcionário com matrícula {emp.RegistrationId} não encontrado.");
                    }

                   emp.Name = funcionarioDb.Name; // Atualiza o nome do funcionário com o valor do banco de dados
                }
                    _context.OvertimeRequests.Add(request); 
                    await _context.SaveChangesAsync();

                    // Enviar e-mail de confirmação de envio de solicitação ao solicitantes

                    Console.WriteLine($"Recebida a solicitação para atender o cliente : {request.client}");
                    Console.WriteLine($"Total de Colaboradores envolvidos: {request.Employees.Count}");

                    return Ok(new { message = "Solicitação de horas extras criadas com sucesso", id = Guid.NewGuid() });

                
            });
                





                
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Erro internos : {ex.Message}");

            }
        }
    }
}