using OutcomesFirst.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutcomesFirst.Repository
{
    public interface IReferralRepository :  ICRUDRepository<Referral>
    {
        //Task<IEnumerable<Referral>> GetReferrals();
    }
}
