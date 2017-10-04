using PartyApp.Core.Enum;
using System.Collections.Generic;

namespace PartyApp.Core.Model
{
    public class Party : EntityBase
    {
        public PartyType PartyTypeId { get; set; }

        public string AuthToken { get; set; }
        public bool? Deceased { get; set; }
        public int? GenderId { get; set; }
        public int? OrgTypeId { get; set; }
        public string ReligionDisplayName { get; set; }
        public int? ReligionTypeId { get; set; }
        public string UserName { get; set; }
        public int? SourceID { get; set; }

        //Reference Properties
        public virtual IList<Name> Names { get; set; } = new List<Name>();
        public virtual IList<PartyDate> PartyDates { get; set; } = new List<PartyDate>();
        public virtual IList<PhysicalAddress> PhysicalAddresses { get; set; } = new List<PhysicalAddress>();
        public virtual IList<VirtualAddress> VirtualAddresses { get; set; } = new List<VirtualAddress>();

        //Give me all Children of Party should be anything on the Relationship table where the Parent id is the party
        public virtual IList<PartyRelationship> ParentPartyRelationships { get; set; } = new List<PartyRelationship>();
        public virtual IList<PartyRelationship> ChildPartyRelationships { get; set; } = new List<PartyRelationship>();

    }
}
