using AutoMapper;
using HackerNewsAPI.AutoMapperProfiles;
using HackerNewsAPI.Data;
using HackerNewsAPI.Modal;
using HackerNewsAPI.Modal.DTO;
using HackerNewsAPI.Service;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;

namespace HackerUnitTesting
{
    [TestFixture]
    public class HackerNewsServiceUnitTests
    {
        private Mock<IHackerNewsAPIData> _hackerNewsApiMock;
        private Mock<IMemoryCacheService> _memoryCacheMock;
        private IMapper _mapper;
        MapperConfiguration _config;

        private HackerNewsService _hackerNewsService;

        [SetUp]
        public void Setup()
        {
            _config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>());

            _mapper = _config.CreateMapper();

            _memoryCacheMock = new Mock<IMemoryCacheService>();
            _hackerNewsApiMock = new Mock<IHackerNewsAPIData>();

            _hackerNewsService = new HackerNewsService(_hackerNewsApiMock.Object, _memoryCacheMock.Object, _mapper);

        }


        [Test]
        public void WhenSourceToDestinationTest()
        {
            var sourceObj = new Story()
            {
                By= "ms",
            };



            var mappedObj = _mapper.Map<StoryDTO>(sourceObj);

            Assert.IsNotNull(mappedObj);
            Assert.That(mappedObj.Author, Is.EqualTo(sourceObj.By));
        }


        [Test]
        public async Task WhenGetStories_returnStories()
        {
            List<StoryDTO> expectedResult = new List<StoryDTO>() { new StoryDTO() { Author = "ms" } };

            _memoryCacheMock.Setup(x => x.GetDataFromMemoryCache<It.IsAnyType>(It.IsAny<string>())).Returns<It.IsAnyType>(null);
            
            _hackerNewsApiMock.Setup(x => x.GetListOfNewStories()).ReturnsAsync(new List<int> { 1 });
            _hackerNewsApiMock.Setup(x => x.GetStoryById(It.IsAny<int>())).ReturnsAsync(new Story() { By="ms" });

            _memoryCacheMock.Setup(x=>x.SetupInMemoryInMemoryCache<It.IsAnyType>(It.IsAny<It.IsAnyType>(), It.IsAny<string>(),It.IsAny<DateTimeOffset>()));

            var stories = await _hackerNewsService.GetNewStories();


            Assert.IsNotNull(stories);
            Assert.That(stories.Count(), Is.EqualTo(1));
            Assert.That(stories.First().Author, Is.EqualTo("ms"));
            Assert.That(stories.First().Author, Is.EqualTo("ms"));
        }
    }
}