using Microsoft.AspNetCore.Mvc;
using Rest_Overtime.Model; // Importa o "sobrenome" lógico, não o caminho do arquivo

namespace Rest_Overtime.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Boa prática manter o /api/
    public class FormController : ControllerBase
    {
        private static long _counter = 0;
        private static readonly string _template = "Hello, {0}!";


        [HttpGet]
        public Greeting Get([FromQuery] string name = "World") // Removido o 'class' daqui, é apenas o tipo de retorno
        {
            
            // Simulando acesso a um BD (Dados mockados)
            var id = Interlocked.Increment(ref _counter);
            var content = string.Format(_template, name);
            
            return new Greeting (id, content, 2222222 );
        }
    }
}