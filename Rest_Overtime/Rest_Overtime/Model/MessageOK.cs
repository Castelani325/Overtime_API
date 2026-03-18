using System.ComponentModel.DataAnnotations;

namespace Rest_Overtime.Model
{


    //Não utilizado ainda

    public class messageOK
    {
        [Required]
        public string message { get; set; } = string.Empty;


        [Required]
        public int id { get; set; } = 0;

    }

}