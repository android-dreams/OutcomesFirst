using AutoMapper;
using OutcomesFirst.Models;
using OutcomesFirst.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomesFirst
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Referral, ReferralViewModel>();
            CreateMap<ReferralViewModel, Referral>();

            CreateMap<Submission, SubmissionViewModel>();
            CreateMap<SubmissionViewModel, Submission>();

            CreateMap<ArchiveReferral, ArchiveReferralViewModel>();
            CreateMap<ArchiveReferralViewModel, ArchiveReferral>();
        }

    }
}
