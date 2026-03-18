using System.ComponentModel.DataAnnotations;

namespace Rest_Overtime.Model
{

	public class EmployeeDTO //DTO de funcionário, para receber os dados do formulário
	{

		[Required]
		public string RegistrationId { get; set; } = string.Empty;


		[Required]
		public string Name { get; set; } = string.Empty;

	}

	public class OvertimeRequestDTO

	{

		[Required(ErrorMessage = "Campo Obrigatório")]
		public string facility { get; set; } = string.Empty;

		[Required(ErrorMessage = "Campo Obrigatório")]
		public string client { get; set; } = string.Empty;

		[Required(ErrorMessage = "Campo Obrigatório")]
		public string reason { get; set; } = string.Empty;

		[Required(ErrorMessage = "Campo Obrigatório")]
		public DateTime DateStart { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório")]
		public DateTime DateEnd { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório")]
		public List<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();


	}
}

	