using Microsoft.AspNetCore.Mvc;
using Rest_Overtime.Model; // Importa o "sobrenome" lógico, não o caminho do arquivo

namespace Rest_Overtime.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] OvertimeRequestDTO request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); // Valida o modelo e retorna erros, se houver


            try
            {
                // - Salva no BD 

                // DB : MASTER 2 RM FOLHA - PFUNC
                // TABELA : 



                // - Envia email
                // - Verifica Saldo de horas
                // - Confirma sucesso


                Console.WriteLine($"Recebida a solicitação para atender o cliente : {request.client}");
                Console.WriteLine($"Total de Colaboradores envolvidos: {request.Employees.Count}");

                return Ok(new { message = "Solicitação de horas extras criadas com sucesso", id = Guid.NewGuid() });

            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Erro internos : {ex.Message}");

            }
        }
    }
}