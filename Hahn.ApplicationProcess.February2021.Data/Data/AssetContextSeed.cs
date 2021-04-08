using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Hahn.ApplicationProcess.February2021.Domain.Entities;

namespace Hahn.ApplicationProcess.February2021.Data.Data
{
    public class AssetContextSeed
    {
        public static async Task SeedAsync(AssetContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var path = Path.GetDirectoryName(Environment.CurrentDirectory);

                // /Users/gbubemismith/Documents/coreApps/Hahn.ApplicationProcess.Application


                if (!context.Assets.Any())
                {
                    var assetsData = File.ReadAllText(path + @"/Hahn.ApplicationProcess.February2021.Data/Data/SeedData/assets.json");
                    var assets = JsonSerializer.Deserialize<List<Asset>>(assetsData);

                    foreach (var item in assets)
                    {
                        context.Assets.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<AssetContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}