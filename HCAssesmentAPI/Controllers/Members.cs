using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HcTechAssessmentRepo;
using Microsoft.Ajax.Utilities;
using Unity;


namespace HCAssesmentAPI.Controllers
{
    public class MembersController : ApiController
    {
        IUnityContainer container;
        IMemberRepository MemberRepository;
        IMemberContext MemberContext;


        public MembersController(IMemberContext memberContext, IMemberRepository memberRepository )
        {
            this.MemberContext = memberContext;
            this.MemberRepository = memberRepository;
        }
        // GET: api/Members
        [Route("api/Members")]
        [HttpGet]
        public IEnumerable<HcTechAssessmentRepo.Member> Get()
        {
            var returnList = new List<HcTechAssessmentRepo.Member>();
            returnList = MemberRepository.GetAllMembers();
            return returnList;
        }

        [Route("api/Members/{searchMember}")]
        [HttpGet]
        public IEnumerable<HcTechAssessmentRepo.Member> Get(string searchMember)
        {
            var returnList = new List<HcTechAssessmentRepo.Member>();
            returnList = MemberRepository.GetMembersByName(searchMember);
            return returnList;
        }

        // POST: api/Members
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Members/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Members/5
        public void Delete(int id)
        {
        }
    }
}
