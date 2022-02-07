using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using Pixlpark.Models;

namespace Pixlpark
{
    public class PixlparkAPIWorker
    {

        private const string PUBLIC_KEY = "38cd79b5f2b2486d86f562e3c43034f8";
        private const string PRIVATE_KEY = "8e49ff607b1f46e1a5e8f6ad5d312a80";
        private readonly HttpClient client;

        public PixlparkAPIWorker(HttpClient client)
        {
            this.client = client;
        }

        private async Task<string> GetRequestToken()
        {
            var requestTokenMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(client.BaseAddress, "oauth/requesttoken"),
            };
            var responseMessage = await client.SendAsync(requestTokenMessage);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage.StatusCode.ToString());
            }

            var responseString = await responseMessage.Content.ReadAsStringAsync();
            RequestToken requestToken = JsonConvert.DeserializeObject<RequestToken>(responseString);
            return requestToken.RequestTokenValue;
        }

        private async Task<string> GetAccessToken()
        {
            string requestToken = await GetRequestToken();

            var request = new HttpRequestMessage(HttpMethod.Post, "oauth/accesstoken")
            {
                Content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                {
                    new("oauth_token", requestToken),
                    new("grant_type", "api"),
                    new("username", PUBLIC_KEY),
                    new("password", GetPassword(requestToken))
                })
            };

            var responseMessage = await client.SendAsync(request);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage.StatusCode.ToString());
            }

            var responseString = await responseMessage.Content.ReadAsStringAsync();
            AccessToken accessToken = JsonConvert.DeserializeObject<AccessToken>(responseString);
            return accessToken?.AccessTokenValue;
        }

        private string GetPassword(string requestToken)
        {
            string password = string.Concat(requestToken, PRIVATE_KEY);
            byte[] passwordBytes = Encoding.GetEncoding("UTF-8").GetBytes(password);
            var sha1 = SHA1.Create();
            return BitConverter.ToString(sha1.ComputeHash(passwordBytes)).Replace("-", "").ToLower();
        }

        public async Task<List<Order>> GetOrders()
        {
            var accessToken = await GetAccessToken();
            var request = new HttpRequestMessage(HttpMethod.Get, "/orders")
            {
                Content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                {
                    new("oauth_token", accessToken),
                })
            };

            using var response = await client.SendAsync(request);
            var responseString = response.Content.ReadAsStringAsync().Result;

            try
            {
                var result = JsonConvert.DeserializeObject<RootOrder>(responseString);
                return result.Orders;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }

    public class RootOrder
    {
        public string ApiVersion { get; set; }

        [JsonProperty("Result")]
        public List<Order> Orders { get; set; }
        public int ResponseCode { get; set; }
    }

    class RequestToken
    {
        [JsonProperty("RequestToken")]
        public string RequestTokenValue { get; set; }

        [JsonProperty("Expires")]
        public string Expires { get; set; }

        [JsonProperty("Success")]
        public bool Success { get; set; }
    }

    class AccessToken
    {
        [JsonProperty("AccessToken")]
        public string AccessTokenValue { get; set; }

        [JsonProperty("Expires")]
        public int Expires { get; set; }

        [JsonProperty("RefreshToken")]
        public string RefreshToken { get; set; }

        [JsonProperty("Success")]
        public bool Success { get; set; }
    }

}
