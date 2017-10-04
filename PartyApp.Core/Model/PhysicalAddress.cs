using PartyApp.Core.Enum;

namespace PartyApp.Core.Model
{
    public class PhysicalAddress : EntityBase
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string AddressCheck { get; set; }
        public string Apartment { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public int? CountryTypeId { get; set; }
        public string CRMGUID { get; set; }
        public virtual PhysicalAddressTypeValues PhysicalAddressType { get; set; }
        public string Suite { get; set; }
        public string StateOrProv { get; set; }
        public int? StateTypeId { get; set; }
        public string ZipCode { get; set; }

        //Reference Properties
        public int? PartyId { get; set; }
        public Party Party { get; set; }
    }
}
