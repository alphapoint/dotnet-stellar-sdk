﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using stellar_dotnetcore_sdk.federation;
using stellar_dotnetcore_sdk.xdr;

namespace stellar_dotnetcore_unittest.federation
{
    [TestClass]
    public class FederationServerTest
    {
        private FederationServer _server;
        private HttpClient _httpClient;
        private Mock<FakeHttpMessageHandler> _fakeHttpMessageHandler;

        private HttpStatusCode _httpOk = HttpStatusCode.OK;

        private static string _successResponse = "{\"stellar_address\":\"bob*stellar.org\",\"account_id\":\"GCW667JUHCOP5Y7KY6KGDHNPHFM4CS3FCBQ7QWDUALXTX3PGXLSOEALY\"}";
        private static string _successResponseWithMemo = "{\"stellar_address\":\"bob*stellar.org\",\"account_id\":\"GCW667JUHCOP5Y7KY6KGDHNPHFM4CS3FCBQ7QWDUALXTX3PGXLSOEALY\", \"memo_type\": \"text\", \"memo\": \"test\"}";

        private HttpStatusCode _httpNotFound = HttpStatusCode.NotFound;
        private static string _notFoundResponse = "{\"code\":\"not_found\",\"message\":\"Account not found\"}";


        private static string _stellarToml = "FEDERATION_SERVER = \"https://api.stellar.org/federation\"";

        [TestInitialize]
        public void Setup()
        {
            _server = new FederationServer("https://api.stellar.org/federation", "stellar.org");

            _fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler>() { CallBase = true };
            _httpClient = new HttpClient(_fakeHttpMessageHandler.Object);
            _server.HttpClient = _httpClient;
        }

        private void When(HttpStatusCode httpStatusCode, string content)
        {
            _fakeHttpMessageHandler.Setup(a => a.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage
            {
                StatusCode = httpStatusCode,
                Content = new StringContent(content)
            });
        }

        [TestMethod]
        public async Task TestCreateForDomain()
        {
            When(_httpOk, _stellarToml);

            FederationServer server = await FederationServer.CreateForDomain("stellar.org");

            Assert.AreEqual(server.ServerUri, "https://api.stellar.org/federation");
            Assert.AreEqual(server.Domain, "stellar.org");

            _fakeHttpMessageHandler.Verify(a => a.Send(It.IsAny<HttpRequestMessage>()));

            Assert.AreEqual(new Uri("https://stellar.org/.well-known/stellar.toml"), _fakeHttpMessageHandler.Object.RequestUri);
        }

        [TestMethod]
        public async Task TestNameFederationSuccess()
        {
            When(_httpOk, _successResponse);

            FederationResponse response = await _server.ResolveAddress("bob*stellar.org");
            Assert.AreEqual(response.StellarAddress, "bob*stellar.org");
            Assert.AreEqual(response.AccountId, "GCW667JUHCOP5Y7KY6KGDHNPHFM4CS3FCBQ7QWDUALXTX3PGXLSOEALY");
            Assert.IsNull(response.MemoType);
            Assert.IsNull(response.Memo);
        }

        [TestMethod]
        public async Task TestNameFederationSuccessWithMemo()
        {
            When(_httpOk, _successResponseWithMemo);

            FederationResponse response = await _server.ResolveAddress("bob*stellar.org");
            Assert.AreEqual(response.StellarAddress, "bob*stellar.org");
            Assert.AreEqual(response.AccountId, "GCW667JUHCOP5Y7KY6KGDHNPHFM4CS3FCBQ7QWDUALXTX3PGXLSOEALY");
            Assert.AreEqual(response.MemoType, "text");
            Assert.AreEqual(response.Memo, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task TestNameFederationNotFound()
        {
            When(_httpNotFound, _notFoundResponse);

            var response = await _server.ResolveAddress("bob*stellar.org");
        }
    }

    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        public Uri RequestUri { get; private set; }

        public virtual HttpResponseMessage Send(HttpRequestMessage request)
        {
            throw new NotImplementedException();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            RequestUri = request.RequestUri;
            return await Task.FromResult(Send(request));
        }
    }
}