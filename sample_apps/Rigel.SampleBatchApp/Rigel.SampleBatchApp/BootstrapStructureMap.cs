using System;
using System.Collections.Generic;
using Rigel.Container;
using Rigel.Container.StructureMap;
using Rigel.Logging;
using StructureMap;

namespace Rigel.SampleBatchApp
{
    public class SampleAppBootstrapper : IBootstrapper
    {
        public void BootstrapStructureMap()
        {
            // ObjectFactory.Initialize will clear anything existing in the container
            // ObjectFactory.Configure will append to it
            ObjectFactory.Initialize(x =>
                                         {
                                             x.For<ILogger>().Use<ConsoleLogger>();

               // x.ForRequestedType<IRepository>().Use<Repository>()
               //.WithCtorArg("connectionString").EqualTo("a connection string");1

                //x.For<ISessionFactory>().Singleton().Use(_sessionFactory);

                //x.AddRegistry<SampleBatchRegistry>();

                x.Scan(y =>
                           {
                               y.TheCallingAssembly();
                               y.IncludeNamespaceContainingType<SampleAppBootstrapper>();
                               //x.ExcludeNamespaceContainingType<ISecurityDataService>();
                               y.WithDefaultConventions();
                           });
            });
            IoC.Initialize(new StructureMapContainer());
        }
    }

    //public class SampleBatchRegistry : Registry
    //{
    //    public SampleBatchRegistry()
    //    {
    //        Scan(x =>
    //        {
    //            x.TheCallingAssembly();
    //            x.WithDefaultConventions();
    //        });

    //        //For<IPlaceRepository>().Use<AllPlaces>();
    //    }
    //}

}