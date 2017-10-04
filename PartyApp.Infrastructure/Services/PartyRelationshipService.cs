using PartyApp.Core.Enum;
using PartyApp.Core.Interfaces;
using PartyApp.Core.Model;

namespace PartyApp.Infrastructure.Services
{
    public class PartyRelationshipService : IPartyRelationshipService
    {
        public void SetBirthPlace(Party party, string[] userInput)
        {
            var position = PositionTypeValues.BirthLocation;

            //Create Relationship
            var birthPlaceRelationship = SetPartyRelationship(party, position);

            //Create PhysicalAddress and attach Relationship
            AddAddress(party, birthPlaceRelationship, userInput);

            party.ChildPartyRelationships.Add(birthPlaceRelationship);
            
        }

        public void SetDeathPlace(Party party, string[] userInput)
        {
            var position = PositionTypeValues.DeathLocation;

            //Create Relationship
            var deathPlaceRelationship = SetPartyRelationship(party, position);

            //Create PhysicalAddress and attach Relationship
            AddAddress(party, deathPlaceRelationship, userInput);

            party.ChildPartyRelationships.Add(deathPlaceRelationship);
        }

        private void AddAddress(Party party, PartyRelationship locationRelationship, string[] addressValues)
        {
            var locationAddress = new PhysicalAddress
            {
                Party = party,
                PhysicalAddressType = PhysicalAddressTypeValues.PrimaryAddress,
                City = addressValues[0],
                StateOrProv = addressValues[1],
                Country = addressValues[2]
            };
            locationRelationship.ChildRole = party;
            locationRelationship.ChildRole.PhysicalAddresses.Add(locationAddress);
        }

        private PartyRelationship SetPartyRelationship(Party party, PositionTypeValues position)
        {
            return new PartyRelationship
            {
                ChildPosition = position,
                RelationshipType = RelationshipTypeValues.Individual,
                ChildRole = new Party { PartyTypeId = PartyType.Organization },
                ParentRole = party
            };
        }



    }
}
