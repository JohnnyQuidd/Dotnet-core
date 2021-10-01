using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;

namespace PlatformService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlatformsController : ControllerBase
	{
		private readonly IPlatformRepo _repository;
		private readonly IMapper _mapper;

		public PlatformsController(IPlatformRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
		{
			Console.WriteLine("Fetching platforms");

			var platformItems = _repository.GetAllPlatforms();

			return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
		}

		[HttpGet("{id}", Name = "GetPlatformById")]
		public ActionResult<PlatformReadDto> GetPlatformById(string id)
		{
			Console.WriteLine(id);

			var platform = _repository.GetPlatformById(Guid.Parse(id));

			if (platform != null)
			{
				return Ok(_mapper.Map<PlatformReadDto>(platform));
			}

			return NotFound();
		}

	}
}
