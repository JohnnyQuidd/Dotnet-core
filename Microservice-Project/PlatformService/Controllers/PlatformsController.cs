﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlatformsController : ControllerBase
	{
		private readonly IPlatformRepo _repository;
		private readonly IMapper _mapper;
		private readonly ICommandDataClient _commandDataClient;

		public PlatformsController(
			IPlatformRepo repository,
			IMapper mapper,
			ICommandDataClient commandDataClient)
		{
			_repository = repository;
			_mapper = mapper;
			_commandDataClient = commandDataClient;
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

		[HttpPost]
		public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
		{
			var platformModel = _mapper.Map<Platform>(platformCreateDto);

			_repository.CreatePlatform(platformModel);
			_repository.SaveChanges();

			var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

			try
			{
				await _commandDataClient.SendPlatformToCommand(platformReadDto);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"---> Could not send synchronously: {ex.Message}");
			}

			return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
		}
	}
}
