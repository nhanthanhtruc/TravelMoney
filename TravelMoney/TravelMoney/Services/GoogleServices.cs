using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using TravelMoney.Models;
using Newtonsoft.Json;

namespace TravelMoney.Services
{
    class GoogleServices
    {
        public static readonly string ClientID = "540164971679-18bhcrirulct4i36t8i55lp35h6svnv0.apps.googleusercontent.com";
        public static readonly string ClientSecret = "ySxK7qAPMC1cFlfVNBVspiwf";
        public static readonly string RedirectUri = "https://www.youtube.com/user/nhanthanhtruc/playlists?view_as=subscriber";
        public static readonly string State = "security_token%3D138r5719ru3e1%26url%3Dhttps://oauth2.example.com/token&";
        //public static readonly string RedirectUri = "com.example.app:/oauth2redirect";
        public static async Task<TokenGoogle> GetAccessTokenAsync(string code)
        {

            //using System.Net.Http;
            //using System.Net.Http.Headers;
            var requestUrl = string.Format("https://www.googleapis.com/oauth2/v4/token?code={0}&client_id={1}&client_secret={2}&redirect_uri={3}&grant_type=authorization_code",
               code,
               ClientID,
               ClientSecret,
               RedirectUri);                     
            var httpCilent = new HttpClient();
            var response = await httpCilent.PostAsync(requestUrl, null);
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                //using Newtonsoft.Json;
                TokenGoogle AccessToken = JsonConvert.DeserializeObject<TokenGoogle>(body);
                return AccessToken;
            }
            else
            {
                return new TokenGoogle();
            }
        }
        public static async Task<UserProfileGoogle> GetUserProfileAsync(TokenGoogle Token)
        {

            //using System.Net.Http;
            //using System.Net.Http.Headers;
            var requestUrl = string.Format("https://www.googleapis.com/plus/v1/people/me?access_token={0}",Token.AccessToken);
            var httpCilent = new HttpClient();
            var response = await httpCilent.PostAsync(requestUrl, null);
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                //using Newtonsoft.Json;
                UserProfileGoogle UserGoogle = JsonConvert.DeserializeObject<UserProfileGoogle>(body);
                return UserGoogle;
            }
            else
            {
                return new UserProfileGoogle();
            }
        }
    }
}
