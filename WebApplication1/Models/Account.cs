using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class Account
	{

		[Required]
		[MinLength(3)]
		[MaxLength(20)]
        public String? Username { get; set; }

		[Required]
		[MinLength(3)]
		[MaxLength(20)]
		public String? Password { get; set; }

		[Range(3, 100)]
		public int Age { get; set; }

		[Required]
		[EmailAddress]
		public String? Email { get; set; }

    }
}
