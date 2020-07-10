using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HcTechAssessmentRepo;
using Microsoft.EntityFrameworkCore;


namespace HcTechAssessmentTests
{
    public class MemberTestContext
    {
  

        public MemberContext GetMemberContext()
        {


            var builder = new DbContextOptionsBuilder<MemberContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryMemberDB")
                .Options;

            var dbContext = new MemberContext(builder);
            return dbContext;

        
        
        }
    }
}
