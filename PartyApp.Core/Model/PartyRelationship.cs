using PartyApp.Core.Enum;

namespace PartyApp.Core.Model
{
    public class PartyRelationship : EntityBase
    {
        public PositionTypeValues? ChildPosition { get; set; }
        public PositionTypeValues? ParentPosition { get; set; }
        public RelationshipTypeValues RelationshipType { get; set; }
        public int Sequence { get; set; }
        public string UserChildRole { get; set; }

        //Reference Properties

        public int ChildRoleID { get; set; }
        public int ParentRoleID { get; set; }
        public virtual Party ChildRole { get; set; }
        public virtual Party ParentRole { get; set; }


        //public int ParentRoleId { get; set; }
        //public int ChildRoleId { get; set; }
        //public virtual Party ChildRole { get; set; }
        //public virtual Party ParentRole { get; set; }
    }
}
