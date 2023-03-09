using Microsoft.AspNetCore.Mvc;
using Moq;
using MoqProject.Controllers;
using MoqProject.Services;

namespace MoqTest
{
    public class Tests
    {
        private WebsiteController controller;
        private Mock<IAllowEditService> allowEditService;
        private Mock<IWebsiteService> websiteService;
        private Mock<IPostEditService> postEditService;

        private Mock<ILoginInfo> loginInfo;
        private List<Post> posts;

        [SetUp]
        public void Setup()
        {

            websiteService = new Mock<IWebsiteService>();
            allowEditService = new Mock<IAllowEditService>();
            postEditService = new Mock<IPostEditService>();

            // arrange
            loginInfo = new Mock<ILoginInfo>();
            
            posts = new List<Post>()
            {
              new Mock<Post>().Object
            };
            
            websiteService.Setup(c => c.Posts()).Returns(posts.AsEnumerable());

            controller = new WebsiteController(websiteService.Object, postEditService.Object, allowEditService.Object);
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            allowEditService.Setup(p => p.CanUserEdit(loginInfo.Object.Role)).Returns(true);

            // act
            var result = controller.EditPosts(loginInfo.Object);

            // assert

            postEditService.Verify(s => s.Edit(posts.AsEnumerable()), Times.Once());

            Assert.That(result, Is.EqualTo("edit success"));
        }

        [Test]
        public void ShouldReturnFail()
        {
            allowEditService.Setup(p => p.CanUserEdit(loginInfo.Object.Role)).Returns(false);


            // act
            var result = controller.EditPosts(loginInfo.Object);

            // assert

            postEditService.Verify(s => s.Edit(posts.AsEnumerable()), Times.Never());
            Assert.That(result, Is.EqualTo("edit fail"));
        }
    }
}