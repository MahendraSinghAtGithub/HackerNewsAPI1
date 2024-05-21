using HackerNewsAPI.Controllers;
using HackerNewsAPI.Modal.DTO;
using HackerNewsAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerUnitTesting
{
    [TestFixture]
    public class HackerNewsControllerUnitTests
    {
        private Mock<IHackerNewsService> _hackerNewsSvc;
        private HackerNewsController _controller;
        private IList<StoryDTO> expertedResult;


        [SetUp]
        public void setup()
        {
            _hackerNewsSvc = new Mock<IHackerNewsService>();
            _controller= new HackerNewsController( _hackerNewsSvc.Object );
            expertedResult = new List<StoryDTO>() { new StoryDTO() { Author = "ms" }, new StoryDTO() { Author = "ms" } };
        }

        [Test]
        public async Task WhenReturngingData()
        {
            _hackerNewsSvc.Setup(_ => _.GetNewStories()).ReturnsAsync(expertedResult);

            var actualResult = await _controller.GetTopStories() as OkObjectResult;

            Assert.IsNotNull(actualResult);
            Assert.True(actualResult is OkObjectResult);
            Assert.AreEqual(2, (actualResult.Value as List<StoryDTO>).Count);
            Assert.True(actualResult.Value is List<StoryDTO>);
        }

        [Test]
        public async Task WhenHackerNewDataIsEmpty()
        {
            _hackerNewsSvc.Setup(_ => _.GetNewStories()).ReturnsAsync(new List<StoryDTO>());

            var actualResult = await _controller.GetTopStories() as OkObjectResult;

            Assert.IsNotNull(actualResult);
            Assert.True(actualResult is OkObjectResult);
            Assert.AreEqual(0, (actualResult.Value as List<StoryDTO>).Count);
            Assert.True(actualResult.Value is List<StoryDTO>);
        }
    }
}
