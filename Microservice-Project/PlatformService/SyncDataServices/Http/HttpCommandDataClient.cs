using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http
{
	public class HttpCommandDataClient : ICommandDataClient
	{
		private readonly HttpClient _httpClient;

		public HttpCommandDataClient(HttpClient httpClient, IConfiguration confituration)
		{
			_httpClient = httpClient;
		}

		public async Task SendPlatformToCommand(PlatformReadDto platform)
		{
			var httpContent = new StringContent(
				JsonSerializer.Serialize(platform),
				Encoding.UTF8,
				"application/json"
			);

			var response = await _httpClient.PostAsync("http://localhost:6000/api/c/platforms", httpContent);

			if (response.IsSuccessStatusCode)
			{
				Console.WriteLine("---> Sync POST to Command Service was OK");
			}
			else
			{
				Console.WriteLine("---> Sync POST to Command Service was NOT OK");
			}
			throw new NotImplementedException();
		}
	}
}
