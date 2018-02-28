using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        public void ConfigureServices(IServiceCollection services)
        {   
            //Di register using assembly -> aspnet core     
            var asseblies = GetLoadedAssemblies().SelectMany(x => x.DefinedTypes);
            
            var diComponents = asseblies.Where(a => a.GetTypeInfo().GetCustomAttributes().OfType<IDiComponent>().Any());

            foreach(var type in diComponents)
            {
                var interfaceType = type.GetInterface("I" + type.Name);
                services.Add(new ServiceDescriptor(interfaceType, type, ServiceLifetime.Transient));

                Console.WriteLine("Assembly registered ... " +  type.Name);
            }
             
            services.AddMvc();
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
 
            assemblies = DependencyContext.Default.GetDefaultAssemblyNames().Where(a => a.Name.StartsWith("online.")).Select(a => Assembly.Load(a));
 
            return assemblies.ToArray();
        }
        
    }
}
