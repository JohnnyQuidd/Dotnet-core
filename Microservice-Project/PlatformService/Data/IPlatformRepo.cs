using System.Collections;
using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Data
{
	public interface IPlatformRepo
	{
		bool SaveChanges();
		IEnumerable<Platform> GetAllPlatforms();
		void CreatePlatform(Platform platform);
	}
}