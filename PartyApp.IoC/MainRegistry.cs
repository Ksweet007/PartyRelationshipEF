using PartyApp.Core.Interfaces;
using PartyApp.Infrastructure.Data;
using StructureMap;

namespace PartyApp.IoC
{
    public class MainRegistry : Registry
    {
        public MainRegistry()
        {
            Scan(scan =>
            {
                scan.LookForRegistries();
                scan.TheCallingAssembly();
                scan.AssemblyContainingType<PartyRepository>(); //PartyApp.Infastructure
                scan.AssemblyContainingType<IPartyRepository>(); //PartyApp.Core
                scan.WithDefaultConventions();
            });
        }
    }
}
