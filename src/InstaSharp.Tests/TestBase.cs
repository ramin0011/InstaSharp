using InstaSharp.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace InstaSharp.Tests
{
    public class TestBase
    {
        protected readonly OAuthResponse Auth;
        protected readonly InstagramConfig Config;
        protected readonly InstagramConfig ConfigWithSecret;

        protected TestBase()
        {
            // test account client id
            Config = new InstagramConfig()
            {
                ClientId = "554dfe9286994bbe98417d8dc7b69a24"
            };

            ConfigWithSecret = new InstagramConfig()
            {
                ClientId = "382410ad20d1473baf4dbd09eb5e2fd6",
                CallbackUri = "http://instalist.me/test/SocialApp/OAuth/",
                ClientSecret = "65117f57cf354a869d6c0ba7a366b726"
            };


            // dummy account data. InstaSharpTest
            Auth = new OAuthResponse()
            {
                AccessToken = "558141812.382410a.7e55ff974466416baef14d91dfb1212e",
                User = new Models.UserInfo { Id = 558141812 }
            };
        }
        protected static void AssertMissingClientSecretUrlParameter(Response result)
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Meta.Code);
            Assert.AreEqual("Missing client_secret URL parameter.", result.Meta.ErrorMessage);
            Assert.AreEqual("OAuthClientException", result.Meta.ErrorType);
        }
    }
}
