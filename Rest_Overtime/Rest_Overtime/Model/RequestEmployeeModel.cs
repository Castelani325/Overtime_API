using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rest_Overtime.Models
{
    public class RequestEmployeeModel
    {
        [Key]
        public int Id { get; set; }

        public int RegistrationId { get; set; } // Matrícula vinda do formulário
        public string Name { get; set; } = string.Empty; // Nome que sua API buscou no outro BD

        // CHAVE ESTRANGEIRA: Liga este funcionário à solicitação acima
        public int OvertimeRequestId { get; set; }

        [ForeignKey("OvertimeRequestId")]
        public RequestModel? OvertimeRequest { get; set; }
    }
}