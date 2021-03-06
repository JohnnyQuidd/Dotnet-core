using System;
using System.Collections;
using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Data
{
	public interface IPlatformRepo
	{
		bool SaveChanges();

		IEnumerable<Platform> GetAllPlatforms();

		Platform GetPlatformById(Guid id);

		void CreatePlatform(Platform platform);
	}
}