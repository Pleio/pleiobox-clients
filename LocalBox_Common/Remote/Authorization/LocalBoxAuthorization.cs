﻿using System;
using System.Text;
using System.Net.Http;
using System.Json;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace LocalBox_Common.Remote.Authorization
{
    public class LocalBoxAuthorization
    {
        readonly string client_key;
        readonly string client_secret;
        readonly string localBoxBaseUrl;

        private string _accessToken = null;

        public string AccessToken { 
            get { 
//                if (_expiry <= DateTime.UtcNow)
//                {
//                    RefreshAccessToken();
//                }
                return _accessToken;
            }
        }
        private string _refreshToken;

        public string RefreshToken {
            get { return _refreshToken; }
        }
        private DateTime _expiry;

        public DateTime Expiry {
            get {
                return _expiry;
            }
        }

        public LocalBoxAuthorization(LocalBox localBox)
        {
            client_key = localBox.ApiKey;
            client_secret = localBox.ApiSecret;
            localBoxBaseUrl = localBox.BaseUrl;

			DateTime.TryParse (localBox.DatumTijdTokenExpiratie, out _expiry);
			//_expiry = new DateTime(1000, 1, 1);
        }


//		public bool Authorize(string userName, string password)
//        {
//            StringBuilder localBoxUrl = new StringBuilder();
//            localBoxUrl.Append(localBoxBaseUrl);
//            localBoxUrl.Append("lox_api/oauth2/token?");
//            localBoxUrl.AppendFormat("client_id={0}", Uri.EscapeDataString(client_key));
//            localBoxUrl.AppendFormat("&client_secret={0}", Uri.EscapeDataString(client_secret));
//            localBoxUrl.Append("&grant_type=password");
//            localBoxUrl.AppendFormat("&username={0}", Uri.EscapeDataString(userName));
//            localBoxUrl.AppendFormat("&password={0}", Uri.EscapeDataString(password));
//
//			return RequestAccessToken(new Uri(localBoxUrl.ToString()));
//        }

		public bool RefreshAccessToken(string refreshToken)
        {
            StringBuilder localBoxUrl = new StringBuilder();
            localBoxUrl.Append(localBoxBaseUrl);
			localBoxUrl.Append("oauth/v2/token?");
            localBoxUrl.AppendFormat("client_id={0}", Uri.EscapeDataString(client_key));
            localBoxUrl.AppendFormat("&client_secret={0}", Uri.EscapeDataString(client_secret));
			localBoxUrl.Append("&grant_type=refresh_token");
			localBoxUrl.AppendFormat("&refresh_token={0}", Uri.EscapeDataString(refreshToken));

			//http://lox.dev.jeukendrup.nl/oauth/v2/token?client_id=32yqjbq9u38koggk040w408cccss8og4c0ckso4sgoocwgkkoc&client_secret=4j8jqubjrbi8wwsk0ocowooggkc44wcw0044skgscg4o4o44s4&grant_type=refresh_token&refresh_token=MGRhZDc4Mzg2NzkwOTU1MmI5MWU3Y2FmNmEwYzYyNWM0M2E4ZGJhZTk4YjU5YTVhMjRiMjE4ZmRhOWNjNGU2YQ


			return RequestAccessToken(new Uri(localBoxUrl.ToString()));
           
        }

		private bool RequestAccessToken(Uri uri) {
			bool result = false;

			using (var httpClient = new HttpClient())
            {
                httpClient.MaxResponseContentBufferSize = int.MaxValue;
                httpClient.DefaultRequestHeaders.ExpectContinue = false;
                httpClient.DefaultRequestHeaders.Add("x-li-format", "json");

                var httpRequestMessage = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = uri };
                var response = httpClient.SendAsync(httpRequestMessage).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var jsonObject = JsonValue.Parse(jsonString);

                    _accessToken = jsonObject["access_token"];

					if (!string.IsNullOrEmpty (jsonObject ["refresh_token"])) {

						_refreshToken = jsonObject ["refresh_token"];

						int expiry = 0;
						if (jsonObject ["expires_in"].JsonType == JsonType.Number) {
							expiry = (int)jsonObject ["expires_in"];
							// We laten de key al vervallen als al 90% van de tijd is verstreken
							_expiry = DateTime.UtcNow.AddSeconds (expiry * 0.9);

							result = true;
						}
					}
                }
                else
                {
                    Debug.WriteLine("Fout in requestaccesstoken: " + response.Headers); 
                }
            }
			return result;
        }
    }
}

