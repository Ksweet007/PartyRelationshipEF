using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using PartyApp.Core.Model;

namespace PartyApp.Infrastructure.Data.Contexts
{
    public class PartyDbContext : DbContext
    {
        public PartyDbContext()
            : base("MeMConnectionString")
        {
        }

        //Party
        public virtual DbSet<Name> Names { get; set; }
        public virtual DbSet<Party> Parties { get; set; }
        public virtual DbSet<PartyRelationship> PartyRelationships { get; set; }
        public virtual DbSet<PartyDate> PartyDates { get; set; }
        public virtual DbSet<PhysicalAddress> PhysicalAddresses { get; set; }
        public virtual DbSet<VirtualAddress> VirtualAddresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("core");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Party
            EfMapName(modelBuilder);
            EfMapParty(modelBuilder);
            EfMapPartyDates(modelBuilder);
            EfMapPartyRelationship(modelBuilder);
            EfMapPhysicalAddress(modelBuilder);
            EfMapVirtualAddress(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void EfMapName(DbModelBuilder modelBuilder)
        {
            var name = modelBuilder.Entity<Name>();

            name
                .HasKey(k => k.Id);

            name
                .Property(p => p.NameType)
                .HasColumnName("NameTypeId");

            name
                .Property(p => p.PartyType)
                .HasColumnName("PartyTypeId");

            name
                .Property(p => p.Id)
                .HasColumnName("NameId");
        }

        private static void EfMapParty(DbModelBuilder modelBuilder)
        {
            var party = modelBuilder.Entity<Party>();

            party
                .HasKey(k => k.Id);

            party
                .Property(p => p.Id)
                .HasColumnName("PartyId");

            party
                .HasMany(e => e.Names)
                .WithRequired()
                .HasForeignKey(k => k.PartyId);

            party
                .HasMany(e => e.PhysicalAddresses)
                .WithOptional()
                .HasForeignKey(k => k.PartyId);

            party
                .HasMany(e => e.VirtualAddresses)
                .WithOptional()
                .HasForeignKey(k => k.PartyId);

            party
                .HasMany(e => e.PartyDates)
                .WithOptional()
                .HasForeignKey(k => k.PartyId);

            party
                .HasMany(e => e.ChildPartyRelationships)
                .WithRequired(e => e.ChildRole)
                .HasForeignKey(e => e.ChildRoleID);

            party
                .HasMany(e => e.ParentPartyRelationships)
                .WithRequired(e => e.ParentRole)
                .HasForeignKey(e => e.ParentRoleID);
        }

        private static void EfMapPartyRelationship(DbModelBuilder modelBuilder)
        {
            var partyRelationship = modelBuilder.Entity<PartyRelationship>();

            partyRelationship
                .HasKey(k => k.Id);

            partyRelationship
                .Property(p => p.Id)
                .HasColumnName("PartyRelationshipId");

            partyRelationship
                .Property(p => p.ChildPosition)
                .HasColumnName("ChildPositionId");

            partyRelationship
                .Property(p => p.ParentPosition)
                .HasColumnName("ParentPositionId");

            partyRelationship
                .Property(p => p.RelationshipType)
                .HasColumnName("PartyRelationshipTypeId");

            partyRelationship
                .Property(p => p.Sequence)
                .HasColumnName("SeqNumber");

        }

        private static void EfMapPartyDates(DbModelBuilder modelBuilder)
        {
            var partyDate = modelBuilder.Entity<PartyDate>();

            partyDate
                .ToTable("DateCalendarAssoc", "core")
                .HasKey(k => k.Id);

            partyDate
                .Property(p => p.Id)
                .HasColumnName("DateCalendarAssocId");

            partyDate
                .Property(p => p.DateType)
                .HasColumnName("EventTypeId");

            partyDate
                .Property(p => p.CalendarType)
                .HasColumnName("CalendarTypeId");                        
        }

        private static void EfMapPhysicalAddress(DbModelBuilder modelBuilder)
        {
            var physAdd = modelBuilder.Entity<PhysicalAddress>();

            physAdd
                .HasKey(k => k.Id);

            physAdd
                .Property(p => p.Id)
                .HasColumnName("PhysicalAddressId");

            physAdd
                .Property(p => p.PhysicalAddressType)
                .HasColumnName("PhysicalAddressTypeId");
        }

        private static void EfMapVirtualAddress(DbModelBuilder modelBuilder)
        {
            var virAdd = modelBuilder.Entity<VirtualAddress>();

            virAdd
                .HasKey(k => k.Id);

            virAdd
                .Property(p => p.Id)
                .HasColumnName("VirtualAddressId");

            virAdd
                .Property(p => p.Description)
                .HasColumnName("VirtualAddress");

            virAdd
                .Property(p => p.VirtualAddressType)
                .HasColumnName("VirtualAddressTypeId");
        }
    }
}
