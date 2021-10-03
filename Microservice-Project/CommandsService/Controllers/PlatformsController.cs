using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
	[Route("/api/c/[controller]")]
	[ApiController]
	public class PlatformsController : ControllerBase
	{
		public PlatformsController()
		{

		}

		public ActionResult TestInboundConnection()
		{
			Console.WriteLine("--> Inbound connection");
			return Ok("Inbound connection from Platforms Controller");
		}
	}
}
