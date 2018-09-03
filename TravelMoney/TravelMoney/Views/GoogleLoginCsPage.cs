using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelMoney.Services;
using Xamarin.Forms;

namespace TravelMoney.Views
{
    public class GoogleLoginCsPage : ContentPage
    {
        private readonly GoogleProfile googleProfile = new GoogleProfile();
        public GoogleLoginCsPage()
        {
            BindingContext = googleProfile;
            var requestUrl = string.Format("https://accounts.google.com/o/oauth2/v2/auth?response_type=code&scope=openid&client_id={0}&redirect_uri={1}",
               TravelMoney.Services.GoogleServices.ClientID,
               TravelMoney.Services.GoogleServices.RedirectUri);
            //var requestUrl = "https://accounts.google.com/o/oauth2/v2/auth"
            //        + "?response_type=code"
            //        + "&scope=openid"
            //        + "&redirect_uri=" + TravelMoney.Services.GoogleServices.RedirectUri
            //        + "&client_id=" + TravelMoney.Services.GoogleServices.ClientID
            //        //+ "&state=" + TravelMoney.Services.GoogleServices.State
            //        ;
            var webView = new WebView { Source = requestUrl, HeightRequest = 1 };
            //Device.OpenUri(new Uri(requestUrl));
            webView.Navigated += WebViewOnNavigated;
            Content = webView;
        }

        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            var code = ExtractCodeFormUrl(e.Url);
            if( code != "")
            {
                var AccessToken = await GoogleServices.GetAccessTokenAsync(code);
                var UserProfile = await GoogleServices.GetUserProfileAsync(AccessToken);
                
            }
        }

        private string ExtractCodeFormUrl(string url)
        {
            if (url.Contains("code="))
            {
                var attributes = url.Split('&');
                var code = attributes.FirstOrDefault(s => s.Contains("code=")).Split('=')[1];
                return code;
            }
            else return string.Empty;
        }
    }
}
