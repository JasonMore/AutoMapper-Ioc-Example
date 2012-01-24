using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Extensions.Conventions;

namespace IMapperPOC.Service.Infrustructure
{
    public static class AppStart
    {
        public static void RegisterAssemblies(IKernel kernel)
        {
			//there are better ways to getting the namespace of the mappers, but this is the most straightforward in the POC
        	const string mapperNamespace = "IMapperPOC.Service.Mappers";

            var scanner = new AssemblyScanner();
			scanner.WhereTypeIsNotInNamespace(mapperNamespace);
            scanner.FromCallingAssembly();
            scanner.BindWith<DefaultBindingGenerator>();
            kernel.Scan(scanner);

            var mapScanner = new AssemblyScanner();
            mapScanner.FromCallingAssembly();
			mapScanner.WhereTypeIsInNamespace(mapperNamespace);
            mapScanner.BindWith<DefaultBindingGenerator>();

            //only create the mappers once since AutoMapper registration has a lot of overhead.
            mapScanner.InSingletonScope();
            kernel.Scan(mapScanner);
        }
    }
}
