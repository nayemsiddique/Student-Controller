using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Student.Repository;
using Student.Services;

namespace Student
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
//            services.AddHostedService(stu)
//            services.AddDbContext<DataContext>(x =>
//                x.Us("jdbc:mysql://remotemysql.com:3306/DM09DFvZG3?user=DM09DFvZG3&password=pROXC363tF"));
//            
            services.AddDbContext<StudentRepository>(options =>
                options.UseSqlServer("server=DESKTOP-I721Q7J\\NAYEM;Database=um;Trusted_Connection=True;MultipleActiveResultSets=true;",
                    
                    b => b.MigrationsAssembly("Student")));
            services.AddControllers();
            services.AddScoped<IStudentService, StudentServices>();
            services.AddCors();
//            services.AddScoped<IStudentRepository, StudentRepository>();
//            services.AddTransient(typeof(IStudentRepository), typeof(StudentRepository));

//            services.AddSingleton<IStudentRepository, StudentRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
//            app.UseAuthorization();
//            Console.WriteLine(env.EnvironmentName);
//            app.UseMvc();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}