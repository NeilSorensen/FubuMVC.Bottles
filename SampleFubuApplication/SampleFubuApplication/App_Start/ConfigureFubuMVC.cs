using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core;

namespace SampleFubuApplication.App_Start
{
    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            Actions.IncludeClassesSuffixedWithController();

            Routes.RootAtAssemblyNamespace();
        }
    }
}