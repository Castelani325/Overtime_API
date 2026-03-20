using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rest_Overtime.Model
{


    [Table("Empregados")]
	public class EmployeeDTO //DTO de funcionário, para receber os dados do formulário
	{
        [Key] // para EF conseguir criar a tabela
        public int Id { get; set; }

        [Required]
		public string RegistrationId { get; set; }

		[Required]
		public string? Name { get; set; }

	}


    [Table("Sol_Horas_Extras")]
    public class OvertimeRequestDTO

	{


        //CRIAR DTO
        [Required(ErrorMessage = "A unidade é obrigatória.")]
        [RegularExpression("^(VTT|VTE|VAC)$", ErrorMessage = "Unidade inválida. Use VTT, VTE ou VAC.")]
        public string Unit { get; set; } = string.Empty;


        //PUXAR DO BD OU CRIAR DTO DE CLIENTES (IDELA QUE SE PUXE DE ALGUM LUGAR)
        [Required]
        public string Client { get; set; } = string.Empty; // React: client

        [Required]
        public string Justification { get; set; } = string.Empty; // React: justification

        [Required]
        public DateTime DateStart { get; set; }

        [Required]
        public DateTime DateEnd { get; set; }


        //PUXAR DO BD
        [Required]
        public List<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();

    }
}

	