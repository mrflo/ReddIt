using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReddIt;
using ReddIt.API.Controllers;
using ReddIt.Model;
using ReddIt.API.Providers;
using System.Threading.Tasks;
using ReddIt.API.Models;
using ReddIt.Provider;
using System.Web.Http.Hosting;
using System.Net;

namespace ReddIt.API.Tests.Controllers
{
    [TestClass]
    public class RedditControllerTest
    {
        [TestMethod]
        public void RedditAPI()
        {
            RedditReader rp = new RedditReader();

            var result = rp.Get();
            //Assert 100 items
            Assert.IsNotNull(result);
            Assert.AreEqual(100, result.data.children.Count());
        }

        [TestMethod]
        public void GetByAuthors()
        {
            // Arrange
            ReddItController controller = new ReddItController()
            {
                //Initialise controller RequestMessage
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration()  } }
                }
            };

            // Act
            string domain = "youtube.com";
            var response = controller.Get(domain);
            var result = response.Content.ReadAsAsync<IEnumerable<AuthorModel>>().Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(result);
        }
    }
}
