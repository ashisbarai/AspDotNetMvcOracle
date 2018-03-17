using AspDotNetMvcOracle.DataAccess;
using AspDotNetMvcOracle.Employees;
using Autofac;
using Autofac.Integration.Mvc;

namespace AspDotNetMvcOracle
{
    public class Bootstrapper
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterType<Database>().As<IDatabase>().InstancePerRequest();
            builder.RegisterType<EmployeeReader>().InstancePerRequest();
            builder.RegisterType<EmployeeCreator>().InstancePerRequest();

            return builder.Build();
        }
    }
}