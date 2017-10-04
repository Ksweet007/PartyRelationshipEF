using PartyApp.Core.Interfaces;
using PartyApp.Core.Model;
using PartyApp.Infrastructure.Data.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PartyApp.Infrastructure.Data
{
    public class PartyRepository : IPartyRepository
    {
        private readonly PartyDbContext _db;

        public PartyRepository(PartyDbContext db)
        {
            _db = db;
        }

        public Party GetById(int partyId)
        {
            return _db.Parties
                .Include(p => p.Names)
                .Include(p => p.PhysicalAddresses)
                .Include(p => p.VirtualAddresses)
                .Include(p => p.PartyDates)
                .Include(p => p.ParentPartyRelationships)
                .Include(p => p.ChildPartyRelationships)
                .SingleOrDefault(p => p.Id == partyId);
        }

        public IList<PartyRelationship> GetChildRelationShipsById(int partyId)
        {
            return _db.PartyRelationships.Where(p => p.ChildRoleID == partyId).ToList();
        }

        public IList<PartyRelationship> GetParentRelationShipsById(int partyId)
        {
            return _db.PartyRelationships.Where(p => p.ParentRoleID == partyId).ToList();
        }

        public Party Save(Party partyToSave)
        {
            _db.Parties.Add(partyToSave);
            _db.SaveChanges();

            return partyToSave;
        }

    }
}
