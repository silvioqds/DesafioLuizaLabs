using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.LuizaLabs.Infra.IOC
{
    public class ModuleIOC : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIOC.Loader(builder);
        }

    }
}
