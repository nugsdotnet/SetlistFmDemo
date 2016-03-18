using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace SetlistFmDemo.Controllers
{
    public class SetlistController : ApiController
    {
        [HttpGet]
        [Route("setlists")]
        public async Task<object[]> GetPage(string p)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.setlist.fm/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = new HttpResponseMessage();
                object obj;

                object[] list = new object[1];

                response = await client.GetAsync("rest/0.1/search/setlists.json?artistName=phish&p=" + p);
                obj = await response.Content.ReadAsAsync<object>();

                list[0] = obj;

                return list;
            }
        }
    }
}
