using System.Collections.Generic;

namespace HcTechAssessmentRepo
{
    public interface IMemberRepository
    {
        List<Member> GetAllMembers();
        List<Member> GetMembersByName(string searchString);
    }
}