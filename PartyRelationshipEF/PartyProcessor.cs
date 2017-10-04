using PartyApp.Core.Enum;
using PartyApp.Core.Interfaces;
using PartyApp.Core.Model;
using PartyRelationshipEF.Interfaces;
using System;
using System.Collections.Generic;
using static PartyRelationshipEF.ConsoleLoggers.ConsoleLogger;
using static PartyRelationshipEF.ConsoleLoggers.Writer;
using static System.Console;

namespace PartyRelationshipEF
{
    public class PartyProcessor : IPartyProcessor
    {
        private readonly IPartyRepository _partyrepo;
        private readonly IPartyRelationshipService _partyRelationshipService;

        public PartyProcessor(IPartyRepository partyRepo, IPartyRelationshipService partyRelationshipService)
        {
            _partyrepo = partyRepo;
            _partyRelationshipService = partyRelationshipService;
        }

        public void RunApp()
        {
            Prompt("1 - Add Party");
            Prompt("2 - Lookup Party");
            WriteLine("");

            var userSelection = ReadLine();

            if (userSelection == "1")
            {
                var party = new Party
                {
                    PartyTypeId = PartyType.Individual
                };

                int gender = 1;

                var primaryNameInput = GetSplitInput("Enter Full Name: Prefix,First,Middle,Last,Suffix");
                SetPrimaryName(party, primaryNameInput);
                WriteLine("");

                var birthDate = GetPartyDate("Enter BirthDate MM/DD/YYYY");
                SetDate(party, birthDate, EventTypeValues.Birthday);
                WriteLine("");

                var deathDate = GetPartyDate("Enter DeathDate MM/DD/YYYY");
                SetDate(party, deathDate, EventTypeValues.Death);
                WriteLine("");

                var residenceInput = GetSplitInput("Enter Residence: Address1,City,State,Zip,Country");
                SetResidence(party, residenceInput);
                WriteLine("");

                var birthPlaceInput = GetSplitInput("Enter BirthPlace: City,State,Country");
                _partyRelationshipService.SetBirthPlace(party, birthPlaceInput);
                WriteLine("");

                var deathPlaceInput = GetSplitInput("Enter DeathPlace: City,State,Country");
                _partyRelationshipService.SetDeathPlace(party, deathPlaceInput);

                //Save a Subject after saving the party
                _partyrepo.Save(party);
            }
            else
            {
                Prompt("Enter a PartyId to lookup: ");
                //int partyId = Int32.TryParse(ReadLine(), out partyId) ? partyId : 0;
                int partyId = 9416799;
                LookUpParty(partyId);
            }
        }

        private void SetPrimaryName(Party party, string[] splitName)
        {
            var primaryName = new Name
            {
                NameType = NameTypeValues.PrimaryName,
                Prefix = splitName[0],
                FirstName = splitName[1],
                MiddleName = splitName[2],
                LastName = splitName[3],
                Suffix = splitName[4],
                Party = party,
                PartyType = PartyType.Individual
            };

            party.Names.Add(primaryName);
        }

        private string[] GetSplitInput(string message)
        {
            Prompt(message);
            WriteLine("");

            var enteredBirthPlace = ReadLine();
            return enteredBirthPlace.Split(',');
        }

        private void SetResidence(Party party, string[] splitAddress)
        {
            var residence = new PhysicalAddress
            {
                Address1 = splitAddress[0],
                City = splitAddress[1],
                StateOrProv = splitAddress[2],
                ZipCode = splitAddress[3],
                Country = splitAddress[4],
                Party = party,
                PhysicalAddressType = PhysicalAddressTypeValues.PrimaryAddress
            };

            party.PhysicalAddresses.Add(residence);
        }

        private DateTime? GetPartyDate(string message)
        {
            Prompt(message);

            var dateInput = ReadLine();

            return DateTime.TryParse(dateInput, out DateTime partyDate) ? partyDate : (DateTime?)null;
        }

        private void SetDate(Party party, DateTime? eventDate, EventTypeValues eventType)
        {
            var date = new PartyDate
            {
                DateType = eventType,
                CalendarType = CalendarType.Gregorian,
                CalendarStartDate = eventDate
            };

            date.SetStartDateString(eventDate);
            party.PartyDates.Add(date);
        }

        private void LookUpParty(int partyId)
        {
            var party = _partyrepo.GetById(partyId);

            WriteLine("");
            Log($"Result For PartyId {partyId}", ConsoleColor.Red);
            WriteLine("");

            BuildPartyOutput(party);
        }
    }
}
