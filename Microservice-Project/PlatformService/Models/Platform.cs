using System;
using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
	public class Plaform
	{
		[Key]
		public Guid Id { get; set; }
		
		[Required]
		public string Name { get; set; }
		
		[Required]
		public string Publisher { get; set; }

		[Required]
		public string Cost { get; set; }
	}
}