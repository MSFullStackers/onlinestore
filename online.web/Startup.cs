using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using online.core;

namespace onlinestore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {   
            services.AddMvc();

            //Di register using assembly -> aspnet core     
            var asseblies = GetLoadedAssemblies()
                                .SelectMany(x => x.DefinedTypes.Where(dt => !dt.IsAbstract && dt.IsClass && !dt.IsInterface));

            var diComponents = asseblies.Where(a => a.GetTypeInfo().GetCustomAttributes().OfType<IDiComponent>().Any());

             var builder = new ContainerBuilder();

            foreach (var type in diComponents)
            {
                var typeInterface = type.GetTypeInfo().ImplementedInterfaces.First(i => i.Name.Contains(type.Name));

                // TODO : Get type scope and assign to the life time 
                var typeScope = type.GetTypeInfo().GetCustomAttributes().First();

                // Autofac registration     
                //builder.RegisterInstance(typeInterface).As(type);

                // .net core registration 
                services.Add(new ServiceDescriptor(typeInterface, type, ServiceLifetime.Transient));

                Console.WriteLine("Assembly registered ... " + type.Name + " Interface " + typeInterface.Name);
            } 
           
            // var container = builder.Build();
            // return container.Resolve<IServiceProvider>();  
            return null;           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private static Assembly[] GetLoadedAssemblies()
        {
            IEnumerable<Assembly> assemblies = null;
            var dependencyAssemblies = Enumerable.Empty<Assembly>();

            assemblies = DependencyContext.Default.GetDefaultAssemblyNames()
                                          .Where(a => a.Name.StartsWith("online."))
                                          .Select(a => Assembly.Load(a));
 
            return assemblies.ToArray();
        }
        
    }
}
