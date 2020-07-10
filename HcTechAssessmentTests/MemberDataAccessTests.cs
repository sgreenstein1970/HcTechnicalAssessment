using Microsoft.VisualStudio.TestTools.UnitTesting;
using HcTechAssessmentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using HcTechAssessmentTests;
using System.Diagnostics;

namespace HcTechAssessmentRepo.Tests
{
    [TestClass()]
    public class MemberDataAccessTests
    {
        private  MemberContext _memberContext;
        

        [ TestInitialize ]
        public void Setup()
        {
                       
            _memberContext = new MemberTestContext().GetMemberContext();
            
            if (_memberContext.Members.Count<Member>() == 0)
            {
                var members = new List<Member> {
                new Member{ Id=1, BirthDate=new DateTime(1999,3,2), FirstName="Seth", LastName="Greenstein" }
                ,new Member{ Id=2, BirthDate=new DateTime(1980,7,4), FirstName="Alex", LastName="Smith" }
                ,new Member{ Id=3, BirthDate=new DateTime(1976,5,4), FirstName="Steve", LastName="Jones" }
                ,new Member{ Id=4, BirthDate=new DateTime(1995,3,4), FirstName="John", LastName="Smyth" }
                };
                    _memberContext.Members.AddRange(members);
                    _memberContext.SaveChanges();
            }

        }
        
        [TestMethod()]
        public void GetAllMembersTest()
        {
            var memberRepo = new MemberRepository(_memberContext);
            var result = memberRepo.GetAllMembers();
            Assert.AreEqual(result.Count, 4);
        }

        [TestMethod()]
        public void GetMembersByNameTest()
        {          

            var memberRepo = new MemberRepository(_memberContext);
            var result = memberRepo.GetMembersByName("h");
            Assert.AreEqual(result.Count, 3);

        }
    }
}