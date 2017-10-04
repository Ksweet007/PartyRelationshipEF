using PartyApp.Core.Enum;

namespace PartyApp.Core.Model
{
    public class VirtualAddress : EntityBase
    {
        public string Description { get; set; }
        public virtual VirtualAddressTypes VirtualAddressType { get; set; }

        //Reference Properties
        public int? PartyId { get; set; }
    }
}
