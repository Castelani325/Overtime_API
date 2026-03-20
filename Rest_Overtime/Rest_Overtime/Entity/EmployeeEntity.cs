using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Rest_Overtime.Model
{
	[Table("PFUNC", Schema = "dbo")]
	public class EmployeeEntityModel
	{
		[Key]
		[Column ("CHAVE")]
		public int Id { get; set; }


		[Column("NOME")]
		public string Name { get; set; }


		//Pode ser adicionado salário aqui
		// [Column("SALARIO")]
		// Pendente : adicionar salário para calculo de horas extras
	}


}