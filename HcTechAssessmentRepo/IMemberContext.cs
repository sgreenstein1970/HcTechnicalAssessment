using System;
using Microsoft.EntityFrameworkCore;

namespace HcTechAssessmentRepo
{
    public interface IMemberContext: IDisposable
    {
        DbSet<Member> Members { get; set; }

        
    }
}