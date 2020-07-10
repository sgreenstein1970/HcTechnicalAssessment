using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HcTechAssessmentRepo
{
    public class MemberRepository : IMemberRepository
    {
        private IMemberContext db;
        public MemberRepository(IMemberContext DB)
        {
            db = DB;
        }

        public List<Member> GetAllMembers()
        {
            var memberList = from m in db.Members select m;
            return memberList.ToList<Member>();
        }
        public List<Member> GetMembersByName(string searchString)
        {
            var likeExpression = string.Format("%{0}%", searchString);
            var memberList = from m in db.Members where m.LastName.Contains(searchString) || m.FirstName.Contains(searchString) select m;
            return memberList.ToList<Member>();
        }



    }
}
