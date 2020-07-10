using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HcTechAssessmentRepo;
using Microsoft.EntityFrameworkCore;
using Moq;
using HCAssesmentAPI.Controllers;

namespace HcTechAssessmentTests
{
    [TestClass]
    public class MVCApiControllerTest
    {
        private MemberContext _memberContext;
        [TestInitialize]
        public void Setup()
        {
            _memberContext = new MemberTestContext().GetMemberContext();
        }

        [TestMethod]
        public void TestMemberGetAll()
        {
            var repo = new Mock<IMemberRepository>();
            repo.Setup(m => m.GetAllMembers()).Returns(new List<Member> {
             new Member{ Id=1, FirstName="Steve", LastName="Smith",BirthDate=new DateTime(1999,4,3) }
            ,new Member{ Id=2, FirstName="Nina", LastName="Jones",BirthDate=new DateTime(1999,5,3) }
            ,new Member{ Id=3, FirstName="Alex", LastName="Gains",BirthDate=new DateTime(1999,6,3) }

            }) ;
            var Controller = new MembersController(_memberContext, repo.Object);
            var result = Controller.Get();
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod]
        public void TestMemberGetByName()
        {
            var repo = new Mock<IMemberRepository>();
            repo.Setup(m => m.GetMembersByName("S")).Returns(new List<Member> {
             new Member{ Id=1, FirstName="Steve",LastName="Smith",BirthDate=new DateTime(1999,4,3) }
            ,new Member{ Id=2, FirstName="Nina" ,LastName="Jones",BirthDate=new DateTime(1987,5,4) }
            ,new Member{ Id=3, FirstName="Alex" ,LastName="Gains",BirthDate=new DateTime(1922,6,5) }
            });
            var Controller = new MembersController(_memberContext, repo.Object);
            var result = Controller.Get("S");
            Assert.AreEqual(result.Count(), 3);
        }
    }
}
