using AOEGameInfo.App.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace AOEGameInfo.App.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private HttpClient _httpClient;

        public UnitsController(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://age-of-empires-2-api.herokuapp.com/api/v1/units");
        }

        [HttpGet]
        public async Task<List<Unit>> GetUnits()
        {
            var unitsResponse = await this._httpClient.GetAsync(this._httpClient.BaseAddress);
            var unitsResponseString = await unitsResponse.Content.ReadAsStringAsync();
            var units = JsonConvert.DeserializeObject<UnitsList>(unitsResponseString);
            return units.Units;
        }
    }
}
 