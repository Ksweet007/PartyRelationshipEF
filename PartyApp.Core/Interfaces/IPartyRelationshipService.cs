using PartyApp.Core.Model;

namespace PartyApp.Core.Interfaces
{
    public interface IPartyRelationshipService
    {
        void SetBirthPlace(Party party, string[] userInput);
        void SetDeathPlace(Party party, string[] userInput);
    }
}
