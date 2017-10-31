using Gnome.Api.AuthenticationMiddleware;
using Gnome.Core.Model.Database;
using Gnome.Core.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class TokenProviderMiddlewareTests
    {
        public const string PATH = "/gettoken";

        [Fact]
        public async void Should_Return_Bad_Request_Response()
        {
            var middleware = new TokenProviderMiddleware(null, Options.Create(new TokenProviderOptions() { Path = PATH }));
            var context = new DefaultHttpContext();
            context.Request.Method = "GET";
            context.Request.Path = PATH;

            await middleware.Invoke(context, null);

            Assert.Equal(400, context.Response.StatusCode);
        }

        [Fact]
        public async void Should_Generate_Token()
        {
            var middleware = new TokenProviderMiddleware(null, Options.Create(new TokenProviderOptions() { Path = PATH }));
            var context = new DefaultHttpContext();

            var userService = Substitute.For<IUserService>();
            userService.Verify("username", "password").Returns(new User()
            {
                Email = "user@email.com",
                Id = new System.Guid("af330cca-4715-4005-8da1-e1505d24aa2c")
            });

            context.Request.Method = "POST";
            context.Request.Path = PATH;
            context.Request.ContentType = "application/x-www-form-urlencoded";
            context.Request.Form = GetFormCollection();

            await middleware.Invoke(context, userService);

            Assert.Equal(200, context.Response.StatusCode);
        }

        [Fact]
        public async void Should_Not_Generate_Token()
        {
            var middleware = new TokenProviderMiddleware(null, Options.Create(new TokenProviderOptions() { Path = PATH }));
            var context = new DefaultHttpContext();
            var userService = Substitute.For<IUserService>();
            userService.Verify("username", "password").Returns(default(User));

            context.Request.Method = "POST";
            context.Request.Path = PATH;
            context.Request.ContentType = "application/x-www-form-urlencoded";
            context.Request.Form = GetFormCollection();

            await middleware.Invoke(context, userService);

            Assert.Equal(400, context.Response.StatusCode);
        }

        [Fact]
        public void Should_Skip_Processig()
        {
            var requestDelegate = Substitute.For<RequestDelegate>();
            var middleware = new TokenProviderMiddleware(requestDelegate, Options.Create(new TokenProviderOptions()));
            var context = new DefaultHttpContext();

            middleware.Invoke(context, null);

            var calls = requestDelegate.ReceivedWithAnyArgs(1);
        }

        private FormCollection GetFormCollection()
        {
            return new FormCollection(new Dictionary<string, StringValues>() {
                { "username", new StringValues("username")},
                { "password", new StringValues("password")}
            });
        }
    }
}