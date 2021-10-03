﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http
{
	interface ICommandDataClient
	{
		Task SendPlatformToCommand(PlatformReadDto platform);
	}
}
