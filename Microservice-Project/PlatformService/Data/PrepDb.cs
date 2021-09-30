using System;
using System.Linq;
using PlatformService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PlatformService.Data
{
	public static class PrepDb
	{
		public static void PrepPopulation(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{
				SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
			}
		}

		private static void SeedData(AppDbContext context)
		{
			if (!context.Platforms.Any())
			{
				Console.WriteLine("Seeding data...");
				context.Platforms.AddRange(
					new Platform() { Name = "DotNet", Publisher = "Microsoft", Cost = "Free" },
					new Platform() { Name = "SqlServer Express", Publisher = "Microsoft", Cost = "Free" },
					new Platform() { Name = "Docker", Publisher = "Solomon Hykes", Cost = "Free" },
					new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
				); ;

				context.SaveChanges();
			}

			else
			{
				Console.WriteLine("Data is already persisted");
			}
		}
	}
}