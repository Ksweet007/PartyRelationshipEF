using PartyApp.Core.Model;
using System.Collections.Generic;

namespace PartyApp.Core.Interfaces
{
    public interface IPartyRepository
    {
        Party GetById(int partyId);
        IList<PartyRelationship> GetChildRelationShipsById(int partyId);
        IList<PartyRelationship> GetParentRelationShipsById(int partyId);
        Party Save(Party partyToSave);
    }
}
