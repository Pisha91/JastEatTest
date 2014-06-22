namespace JustEat.Implementation
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class WebClient
    {
        private readonly HttpClient httpClient; 

        public WebClient()
        {
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://api-interview.just-eat.com/"),
            };

            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "VGVjaFRlc3RBUEk6dXNlcjI=");
            this.httpClient.DefaultRequestHeaders.Add("Accept-Tenant", "uk");
            this.httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-GB");
            this.httpClient.DefaultRequestHeaders.Add("Accept-Charset", "utf-8");
            this.httpClient.DefaultRequestHeaders.Add("Host", "api-interview.just-eat.com");
        }

        public async Task<T> Get<T>(string url)
        {
           HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsAsync<T>();
            }

            throw new Exception(string.Format("Unsuccess status code. Status code: {0}. Content: {1}", responseMessage.StatusCode, responseMessage.Content.ReadAsStringAsync().Result));
        }
    }
}
