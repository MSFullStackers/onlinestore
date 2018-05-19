using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Online.Model;
using Stwo.Core;

namespace onlinestore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<OnlineshopdataContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
             
            //Di register using assembly -> aspnet core     
            var asseblies = GetLoadedAssemblies()
                                .SelectMany(x => x.DefinedTypes.Where(dt => !dt.IsAbstract && dt.IsClass && !dt.IsInterface));

            var dmComponents = asseblies.Where(a => a.GetTypeInfo().GetCustomAttributes().OfType<IDmComponent>().Any());

            var builder = new ContainerBuilder();

            foreach (var type in dmComponents)
            {
                var typeInterface = type.GetTypeInfo().ImplementedInterfaces.First(i => i.Name.Contains(type.Name));

                // TODO : Get type scope and assign to the life time 
                // var typeScope = type.GetTypeInfo().GetCustomAttributes().First();

                // Autofac registration     
                // builder.RegisterType(type).As(typeInterface);
                // .net core registration 
                services.Add(new ServiceDescriptor(typeInterface, type, ServiceLifetime.Transient));
                Console.WriteLine("Assembly registered ... " + type.Name + " Interface " + typeInterface.Name);
            }

            //builder.Build();
            // Create the IServiceProvider based on the container.
            return null;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Cors
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowCredentials();
                builder.AllowAnyOrigin(); // For anyone access.
                //corsBuilder.WithOrigins("http://localhost:5000"); // for a specific url.
            });

            app.UseMvc();
        }

        private static Assembly[] GetLoadedAssemblies()
        {
            IEnumerable<Assembly> assemblies = null;
            var dependencyAssemblies = Enumerable.Empty<Assembly>();

            assemblies = DependencyContext.Default.GetDefaultAssemblyNames()
                                          .Where(a => a.Name.StartsWith("IFormer.")
                                                || a.Name.StartsWith("Stwo."))
                                          .Select(a => Assembly.Load(a));

            return assemblies.ToArray();
        }

    }
}
