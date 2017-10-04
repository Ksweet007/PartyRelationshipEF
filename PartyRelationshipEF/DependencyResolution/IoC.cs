using PartyApp.IoC;
using StructureMap;

namespace PartyRelationshipEF.DependencyResolution
{
    public class IoC
    {
        public static IContainer Initialize()
        {
            var container = new Container(c =>
            {
                c.AddRegistry<PartyAppRegistry>();
                c.AddRegistry<MainRegistry>();
            });

            return container;
        }
    }
}
