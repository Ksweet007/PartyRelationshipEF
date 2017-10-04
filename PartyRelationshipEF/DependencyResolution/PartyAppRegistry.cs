using StructureMap;

namespace PartyRelationshipEF.DependencyResolution
{
    public class PartyAppRegistry : Registry
    {
        public PartyAppRegistry()
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType<PartyProcessor>();
                scan.WithDefaultConventions();
            });
        }
    }
}
