using PartyApp.Core.Model;
using System;
using System.Linq;
using static System.Console;

namespace PartyRelationshipEF.ConsoleLoggers
{
    public static class Writer
    {
        public static void Prompt(string message)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("");
            Write(message);

            ResetColor();
        }

        public static void BuildPartyOutput(Party party)
        {
            ForegroundColor = ConsoleColor.Green;

            DisplayPartyNames(party);
            DisplayPartyPhysicalAddresses(party);
            DisplayPartyVirtualAddresses(party);

            ResetColor();
        }

        private static void DisplayPartyNames(Party party)
        {
            WriteLine($"Names Found - {party.Names.Count}");
            WriteLine("");

            if (!party.Names.Any()) { return; }

            foreach (var name in party.Names)
            {
                WriteLine(">>> Name");
                WriteLine("");
                WriteLine($"Type:   {name.NameType}");
                WriteLine($"Prefix: {name.Prefix}");
                WriteLine($"First:  {name.FirstName}");
                WriteLine($"Middle: {name.MiddleName}");
                WriteLine($"Last:   {name.LastName}");
                WriteLine($"Suffix: {name.Suffix}");
                WriteLine("");
            }
        }

        private static void DisplayPartyPhysicalAddresses(Party party)
        {
            WriteLine($"Physical Addresses Found - {party.PhysicalAddresses.Count}");
            WriteLine("");

            if (!party.PhysicalAddresses.Any()) { return; }

            foreach (var physAdd in party.PhysicalAddresses)
            {
                WriteLine(">>> Physical Address");
                WriteLine("");
                WriteLine($"Add:    {physAdd.Address1}");
                WriteLine($"City:   {physAdd.City}");
                WriteLine($"State:  {physAdd.StateOrProv}");
                WriteLine($"Zip:    {physAdd.ZipCode}");
                WriteLine("");
            }
        }

        private static void DisplayPartyVirtualAddresses(Party party)
        {
            WriteLine($"Virtual Addresses Found - {party.VirtualAddresses.Count} ");
            WriteLine("");

            if (!party.VirtualAddresses.Any()) { return; }

            foreach (var virAdd in party.VirtualAddresses)
            {
                WriteLine(">>> Virtual Address");
                WriteLine("");
                WriteLine($"Type:   {virAdd.VirtualAddressType}");
                WriteLine($"Desc:   {virAdd.Description}");
                
            }
        }
    }
}
