using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NQ.Database.Data;
using NQ.Database.Interfaces;
using NQ.Database.Models;
using NQ.Database.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NQ.Database
{
    public static class DatabaseModuleConfiguration
    {
        const string MOCK_DATA_FILENAME_CONFIG_NAME = "AppSettings:MockDataFileName";

        public static void RegisterDependencies(IServiceCollection service, IConfiguration configuration)
        {
            var mockFileName = configuration.GetSection(MOCK_DATA_FILENAME_CONFIG_NAME)?.Value;
            if (string.IsNullOrWhiteSpace(mockFileName))
                throw new ArgumentException($"Configuration value '{MOCK_DATA_FILENAME_CONFIG_NAME}' does not contain a valid filename.");

            var location = Assembly.GetEntryAssembly().Location;
            var directory = Path.GetDirectoryName(location);
            var mockDataFilePath = Path.Combine(directory, mockFileName);

            var mockDataContent = File.ReadAllText(mockDataFilePath);
            var mockData = JsonConvert.DeserializeObject<List<User>>(mockDataContent);

            service.AddSingleton<IUsersDatabase>(new MockUserDatabase(mockData));
            service.AddTransient<IUsersRepository, UsersRepository>();
        }
    }
}
