using System.ComponentModel.DataAnnotations;

namespace Rest_Overtime.Model
{
	public class RequestModel
	{
		[Key] // Chave primária para o banco
		public int Id { get; set; }

        [Required]
        public string Unit { get; set; } = string.Empty;


        public string Client { get; set; } = string.Empty;
		public string Justification { get; set; } = string.Empty;

		public DateTime DateStart { get; set; }
		public DateTime DateEnd { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.Now;

		// RELAÇÃO: Uma solicitação tem vários funcionários
		public List<RequestEmployeeModel> Employees { get; set; } = new();
	}

	

    }