using System;
using System.Net.Http;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Hahn.ApplicationProcess.February2021.Data.Services
{
    public class CountrySearch : ICountrySearch
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _clientFactory;
        public CountrySearch(IConfiguration config, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _config = config;

        }
        public async Task<bool> SearchByName(string countryName)
        {
            var client = _clientFactory.CreateClient("search");

            client.DefaultRequestHeaders.Accept.Clear();

            using var request =
                    new HttpRequestMessage(HttpMethod.Get, countryName + "?fullText=true");

            var response = await client.SendAsync(request);
            return response.IsSuccessStatusCode;

        }
    }

}

