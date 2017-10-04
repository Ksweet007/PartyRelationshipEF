using PartyRelationshipEF.DependencyResolution;
using PartyRelationshipEF.Interfaces;
using System;

namespace PartyRelationshipEF
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = IoC.Initialize();

            var app = container.GetInstance<Application>();
            app.Run();
            Console.ReadLine();
        }
    }

    public class Application
    {
        private readonly IPartyProcessor _partyService;
        private readonly IContentProcessor _contentProcessor;

        public Application(IPartyProcessor partyService, IContentProcessor contentProcessor)
        {
            _partyService = partyService;
            _contentProcessor = contentProcessor;
        }

        public void Run()
        {
            //_partyService.RunApp();
            _contentProcessor.RunApp();
        }

    }
}
