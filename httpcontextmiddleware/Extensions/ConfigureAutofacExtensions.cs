using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HttpContextMiddleware.Extensions
{
    public static class ConfigureAutofacExtensions
    {
        public static IServiceProvider ConfigureAutoFac(this IServiceCollection services)
        {
            var container = new ContainerBuilder();
            container.Populate(services);

            return new AutofacServiceProvider(container.Build());
        }
    }
}
