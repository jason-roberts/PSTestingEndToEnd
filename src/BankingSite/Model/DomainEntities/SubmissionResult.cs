using System.Collections.Generic;

namespace BankingSite.Model.DomainEntities
{
    public class SubmissionResult
    {
        public int? ReferenceNumber { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}