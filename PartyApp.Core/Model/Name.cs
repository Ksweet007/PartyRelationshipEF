using PartyApp.Core.Enum;

namespace PartyApp.Core.Model
{
    public class Name : EntityBase
    {
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public virtual NameTypeValues NameType { get; set; }
        public string OrgName { get; set; }
        public string Prefix { get; set; }
        public PartyType PartyType { get; set; }
        public string Suffix { get; set; }

        //Reference Properties
        public int PartyId { get; set; }
        public virtual Party Party { get; set; }
    }
}
