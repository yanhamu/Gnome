using Gnome.Api.AuthenticationMiddleware;
using Gnome.Core.Model.Database;
using Gnome.Core.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class TokenProviderMiddlewareTests
    {
        [Fact]
        public async void Should_Return_Bad_Request_Response()
        {
            TokenProviderMiddleware middleware = GetMiddleware();

            var context = new DefaultHttpContext();
            context.Request.Method = "GET";
            context.Request.Path = TokenProviderOptionFactory.PATH;

            await middleware.Invoke(context, null);

            Assert.Equal(400, context.Response.StatusCode);
        }

        private TokenProviderMiddleware GetMiddleware()
        {
            return new TokenProviderMiddleware(null, Options.Create(TokenProviderOptionFactory.Create()));
        }

        [Fact]
        public async void Should_Generate_Token()
        {
            var middleware = GetMiddleware();
            var context = new DefaultHttpContext();

            var userService = Substitute.For<IUserService>();
            userService.Verify("username", "password").Returns(new User()
            {
                Email = "user@email.com",
                Id = new Guid("af330cca-4715-4005-8da1-e1505d24aa2c")
            });

            context.Request.Method = "POST";
            context.Request.Path = TokenProviderOptionFactory.PATH;
            context.Request.ContentType = "application/x-www-form-urlencoded";
            context.Request.Form = GetFormCollection();

            await middleware.Invoke(context, userService);

            Assert.Equal(200, context.Response.StatusCode);
        }

        [Fact]
        public async void Should_Not_Generate_Token()
        {
            var middleware = GetMiddleware();
            var context = new DefaultHttpContext();
            var userService = Substitute.For<IUserService>();
            userService.Verify("username", "password").Returns(default(User));

            context.Request.Method = "POST";
            context.Request.Path = TokenProviderOptionFactory.PATH;
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