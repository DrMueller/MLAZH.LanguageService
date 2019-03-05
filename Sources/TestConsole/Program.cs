using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlazh.LanguageService.Translations.Areas.Models;
using Mmu.Mlazh.LanguageService.Translations.Areas.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;

namespace Mmu.Mlazh.LanguageService.TestConsole
{
    internal class Program
    {
        private static Dictionary<ConsoleKey, Action> _inputs;
        private static ITranslationService _service;

        private static void EvaluateInput()
        {
            var key = Console.ReadKey();
            _inputs[key.Key].Invoke();
            EvaluateInput();
        }

        private static void Main()
        {
            ContainerInitializationService.CreateInitializedContainer(
                new ContainerConfiguration(typeof(Program).Assembly, "Mmu.Mlazh.LanguageService", true));

            _service = ServiceLocatorSingleton.Instance.GetService<ITranslationService>();

            _inputs = new Dictionary<ConsoleKey, Action>
            {
                { ConsoleKey.D1, RunAutoTranslate },
                { ConsoleKey.D2, RunTargetedTranslate }
            };

            EvaluateInput();
        }

        private static void ReportResults(IReadOnlyCollection<TranslationResult> results)
        {
            Console.WriteLine();
            Console.Write(string.Join(string.Empty, results.Select(f => f.CreateOverview())));
        }

        private static void RunAutoTranslate()
        {
            Task.Run(
                async () =>
                {
                    try
                    {
                        var results = await _service.AutoTranslateAsync(
                            new AutoDetectLanguageTranslationRequest(
                                new List<string>
                                {
                                    "en",
                                    "de",
                                    "fr"
                                },
                                new List<string>
                                {
                                    "Hello World",
                                    "Luke, ich bin dein Vater"
                                }));

                        ReportResults(results);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Debugger.Break();
                    }
                });
        }

        private static void RunTargetedTranslate()
        {
            Task.Run(
                async () =>
                {
                    try
                    {
                        var results = await _service.TranslateAsync(
                            new TargetedSourceLanguageTranslationRequest(
                                new List<string> { "en", "fr" },
                                new List<string>
                                {
                                    "en",
                                    "de",
                                    "fr"
                                },
                                new List<string>
                                {
                                    "Hello World",
                                    "Luke, ich bin dein Vater"
                                }));

                        ReportResults(results);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Debugger.Break();
                    }
                });
        }
    }
}