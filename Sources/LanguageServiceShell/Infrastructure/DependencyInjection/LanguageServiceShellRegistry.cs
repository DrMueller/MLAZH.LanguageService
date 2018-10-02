using StructureMap;

namespace Mmu.Mlazh.LanguageServiceShell.Infrastructure.DependencyInjection
{
    public class LanguageServiceShellRegistry : Registry
    {
        public LanguageServiceShellRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<LanguageServiceShellRegistry>();

                    scanner.WithDefaultConventions();
                });


        }
    }
}