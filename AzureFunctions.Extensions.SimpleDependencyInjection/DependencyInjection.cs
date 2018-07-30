﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AzureFunctions.Extensions.SimpleDependencyInjection
{
    public static class DependencyInjection
    {
        private static IServiceProvider serviceProvider;

        public static bool IsInitialized { get; private set; } = false;

         static void ConfigureContainer()
        {
            if (!IsInitialized)
            {
                var configTypes = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(asm => asm.GetTypes().Where(type => type.GetInterface("IContainerConfigurator") == typeof(IContainerConfigurator)))
                    .ToList();

                if (configTypes.Count() == 0)
                {
                    throw new InvalidOperationException($"{nameof(DependencyInjection)} could not locate {nameof(IContainerConfigurator)}");
                }
                else if (configTypes.Count > 1)
                {
                    throw new InvalidOperationException($"{nameof(DependencyInjection)} found multiple {nameof(IContainerConfigurator)}");
                }
                IContainerConfigurator configurator = null;
                try
                {
                    configurator = (IContainerConfigurator) Activator.CreateInstance(configTypes.Single());
                }
                catch (Exception exn)
                {
                    throw new InvalidOperationException($"{nameof(DependencyInjection)} could not create instance of {nameof(IContainerConfigurator)}", exn);
                }
                var services = new ServiceCollection();
                configurator.Configure(services);
                serviceProvider = services.BuildServiceProvider();
                IsInitialized = true;
            }
        }

        public static IServiceProvider Provider
        {
            get
            {
                if (!IsInitialized)
                {
                    ConfigureContainer();
                }
                return serviceProvider;
            }
        }
    }
}
