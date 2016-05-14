﻿using Discussion.Web.Tests.Specs;
using System.Net;
using System.Threading.Tasks;
using Xunit;


namespace Discussion.Web.Tests.IntegrationTests
{
    [Collection("AppSpecs")]
    public class HomePageSpecs
    {
        private Application _theApp;
        public HomePageSpecs(Application theApp) {
            _theApp = theApp;
        }


        public const string HomePagePath = "/";
        public const string ErrorPagePath = "/error";

        [Fact]
        public async Task should_serve_home_page_correctly()
        {
            // arrange
            var request = _theApp.Server.CreateRequest(HomePagePath);

            // act
            var response = await request.GetAsync();

            // assert
            response.StatusCode.ShouldEqual(HttpStatusCode.OK);
        }


        [Fact]
        public async Task should_serve_about_page()
        {
            // arrange
            var request = _theApp.Server.CreateRequest("/about");

            // act
            var response = await request.GetAsync();

            // assert
            response.StatusCode.ShouldEqual(HttpStatusCode.OK);
        }



        [Fact]
        public async Task should_serve_error_as_error_response()
        {
            // arrange
            var request = _theApp.Server.CreateRequest(ErrorPagePath);

            // act
            var response = await request.GetAsync();

            // assert
            response.StatusCode.ShouldEqual(HttpStatusCode.InternalServerError);
        }

    }
}