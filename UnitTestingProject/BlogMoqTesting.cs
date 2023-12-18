using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlogDAL;
using BlogDAL.Repository;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace UnitTestingProject
{
    [TestFixture]
    public class BlogMoqTesting
    {
      
        [Test]
        public void AddBlog_Test()
        {
            // Arrange
            var blogInfo = new BlogInfo
            {
                BlogInfoId = 1,
                Title = "Title 1",
                Subject = "Subject 1",
                DateOfCreation = DateTime.Now,
                BlogUrl = "url1",
                Employee = new EmpInfo
                {
                    Name = "XYZ",
                    EmailId = "XYZ@gmail.com",
                    PassCode = "234231",
                    DateOfJoining = DateTime.Now,
                }
            };

            var fakeObject = new Mock<IBlogReposotiry>();
            fakeObject.Setup(x => x.AddBlogInfoTest(It.IsAny<BlogInfo>())).Returns(blogInfo);
            // Act
           var result=  fakeObject.Object.AddBlogInfoTest(blogInfo);

            Assert.That(result, Is.EqualTo(blogInfo));
        }

        [Test]
        public void checkEmployeeExistWithMoq()
        {
            var blogInfo = new BlogInfo
            {
                BlogInfoId = 1,
                Title = "Title 1",
                Subject = "Subject 1",
                DateOfCreation = DateTime.Now,
                BlogUrl = "url1",
                Employee = new EmpInfo
                {
                    Name = "XYZ",
                    EmailId = "XYZ@gmail.com",
                    PassCode = "234231",
                    DateOfJoining = DateTime.Now,
                }
            };
            var fakeObject = new Mock<IBlogReposotiry>();
            fakeObject.Setup(x => x.GetBlogInfoById(It.IsAny<int>())).Returns(blogInfo);
            var res = fakeObject.Object.GetBlogInfoById(1);
            Assert.That(res, Is.EqualTo(blogInfo));
        }

        [Test]
        public void DeleteBlogTest()
        {
            var blogInfo = new BlogInfo
            {
                BlogInfoId = 1,
                Title = "Title 1",
                Subject = "Subject 1",
                DateOfCreation = DateTime.Now,
                BlogUrl = "url1",
                Employee = new EmpInfo
                {
                    Name = "XYZ",
                    EmailId = "XYZ@gmail.com",
                    PassCode = "234231",
                    DateOfJoining = DateTime.Now,
                }
            };
            var fakeObject = new Mock<IBlogReposotiry>();
     fakeObject.Setup(x => x.DeleteBlogInfoTest(It.IsAny<BlogInfo>())).Returns((BlogInfo e) => e);
            var result = fakeObject.Object.DeleteBlogInfoTest(blogInfo);

            // Assert
            Assert.That(result, Is.EqualTo(blogInfo));
        }


    }
}
