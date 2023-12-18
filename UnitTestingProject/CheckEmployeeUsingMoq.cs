using BlogDAL;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingProject
{
    [TestFixture]
    public class CheckEmployeeUsingMoq
    {
        [Test, Ignore("Skipping this test for now")]
        public void checkEmployeeExistWithMoq()
        {
            EmpInfo emp = new EmpInfo
            {
                Name = "ABC",
                EmailId = "As@gmail.com",
                PassCode = "234231",
                DateOfJoining = DateTime.Now,
            };
            var fakeObject = new Mock<IEmpRepository>();
            fakeObject.Setup(x => x.GetEmpInfoByEmialId(It.IsAny<string>())).Returns(emp);
            var res= fakeObject.Object.GetEmpInfoByEmialId("As@gmail.com");
            Assert.That(res, Is.EqualTo(emp));
        }
        [Test, Ignore("Skipping this test for now")]
        public void CheckEmployeeCreate()
        {
            EmpInfo emp = new EmpInfo
            {
                Name = "ABC",
                EmailId = "As@gmail.com",
                PassCode = "234231",
                DateOfJoining = DateTime.Now,
            };
            var fakeObject = new Mock<IEmpRepository>();
       fakeObject.Setup(x => x.AddEmpInfoTest(It.IsAny<EmpInfo>())).Returns((EmpInfo e) => e);
            var result = fakeObject.Object.AddEmpInfoTest(emp);

            // Assert
            Assert.That(result, Is.EqualTo(emp));
        }


        [Test]
       public void CheckEmployeeDeleteWithMoq()
        {
            // Arrange
            int empIdToDelete = 1; // Assuming 1 is the existing employee's ID

            var fakeRepository = new Mock<IEmpRepository>();
            fakeRepository.Setup(x => x.DeleteEmpInfoTest(It.IsAny<int>())).Returns(true); // 
            var result = fakeRepository.Object.DeleteEmpInfoTest(empIdToDelete);

            // Assert
            Assert.That(result, Is.EqualTo(true));
        }
    }
}
