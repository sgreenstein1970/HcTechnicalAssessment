using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HcTechAssessment
{
    public static class MemberProxy
    {        
        public static List<Member> GetMemberList()
        {
            var returnList = new List<Member>();
            using (var db = new MemberContext())
            {
                var memberDA = new MemberDataAccess(db);
                returnList= memberDA.GetAllMembers();
                
            }
            return returnList;
        }
        public static List<Member> GetMemberList(string searchString)
        {
            var returnList = new List<Member>();
            using (var db = new MemberContext())
            {
                var memberDA = new MemberDataAccess(db);
                returnList = memberDA.GetMembersByName(searchString);
            }
            return returnList;
        }
    }
}
