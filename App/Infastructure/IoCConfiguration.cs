using System;
using System.Collections.Generic;
using StructureMap;

namespace Kata.App.Infastructure
{
    public class IoCConfiguration
    {
        public static void ConfigureObjectFactory()
        {
            configureDependencies();
        }

        public static IContainer BuildContainer()
        {
            return configureDependencies();
        }

        private static IContainer configureDependencies()
        {
            var assembliesToScan = new List<string>
            {
                "Kata.App",
                "Kata.ConsoleClient"
            };
            var customMappings = new List<Action<ConfigurationExpression>>
            {
                // (x => x.For<AbilityToSpeak>().Use<ClassC>()) // Custom Mapping Example
            };

            configureObjectFactory(assembliesToScan, customMappings);
            var container = configureContainer(assembliesToScan, customMappings);
            return container;
        }

        private static void configureObjectFactory(List<string> assemblies, List<Action<ConfigurationExpression>> customMappings)
        {
            ObjectFactory.Configure(x =>
            {
                x.Scan(scan =>
                {
                    scan.LookForRegistries();
                    assemblies.ForEach(scan.Assembly);
                    scan.WithDefaultConventions();
                });
                customMappings.ForEach(mapping => mapping(x));
            });
        }

        private static IContainer configureContainer(List<string> assemblies, List<Action<ConfigurationExpression>> customMappings)
        {
            return new Container(x =>
            {
                x.Scan(scan =>
                {
                    scan.LookForRegistries();
                    assemblies.ForEach(scan.Assembly);
                    scan.WithDefaultConventions();
                });
                customMappings.ForEach(mapping => mapping(x));
            });

        }
    }
}