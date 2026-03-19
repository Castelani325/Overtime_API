using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rest_Overtime.Model
{


    [Table("Empregados")]
	public class EmployeeDTO //DTO de funcionário, para receber os dados do formulário
	{

		[Required]
		public string RegistrationId { get; set; }

		[Required]
		public string? Name { get; set; }

	}


    [Table("Sol_Horas_Extras")]
    public class OvertimeRequestDTO

	{


        //CRIAR DTO
        [Required]
        public string Unit { get; set; } = string.Empty; // React: unit


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

	