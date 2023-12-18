using BlogDAL;
using BlogDAL.Repository;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingProject
{
    [TestFixture]
    public class CheckEmployeeTest
    {
        [Test]
        public void checkEmployeeExist()
        {
            var obj = new EmpRepository(new BlogDbContext());
            var res = obj.GetEmpInfoByEmialId("user2@example.com");
            Assert.That(res, Is.Not.Null);
        }
        [Test, Ignore("Skipping this test for now")]
        public void checkEmployeeCreate()
        {
            EmpInfo emp = new EmpInfo
            {
                Name = "ABC",
                EmailId = "As@gmail.com",
                PassCode = "234231",
                DateOfJoining = DateTime.Now,
            };
            var obj = new BlogDbContext();
            EmpInfo res = obj.EmpInfos.Add(emp);
            obj.SaveChanges();
            ClassicAssert.AreEqual(emp.Name, res.Name);
            ClassicAssert.AreEqual(emp.EmailId, res.EmailId);
        }
        [Test, Ignore("Skipping this test for now")]
        public void CheckEmployeeUpdate()
        {
            // Arrange
            var obj = new EmpRepository(new BlogDbContext());
            var existingEmployee = obj.GetEmpInfoById(1);
            Assert.That(existingEmployee, Is.Not.Null);
            existingEmployee.Name = "NewName";
            existingEmployee.EmailId = "new@email.com";
            existingEmployee.PassCode = "newpass";
            existingEmployee.DateOfJoining = DateTime.Now;
            obj.UpdateEmpInfo(existingEmployee);
            EmpInfo result = obj.GetEmpInfoById(1);

            Assert.That(result, Is.Not.Null);
            ClassicAssert.AreEqual(result.Name, existingEmployee.Name);
            ClassicAssert.AreEqual(result.EmailId, existingEmployee.EmailId);
        }
        [Test]
        public void DeleteEmpInfoExistingEmployee()
        {
            var obj = new BlogDbContext();
            var existingEmployee = obj.EmpInfos.Find(1);
             var result=obj.EmpInfos.Remove(existingEmployee);
            Assert.That(result, Is.Not.Null);
            ClassicAssert.AreEqual(result.Name, existingEmployee.Name);
            ClassicAssert.AreEqual(result.EmailId, existingEmployee.EmailId);
        }
    }
}
