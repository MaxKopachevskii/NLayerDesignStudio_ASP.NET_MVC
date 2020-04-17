using ASP.NET_NLayerDesignStudio.BLL.Interfaces;
using ASP.NET_NLayerDesignStudio.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_NLayaerDesignStudio.WEB.Util
{
    public class StudioModule : NinjectModule
    {
            public override void Load()
            {
                Bind<IStudioService>().To<StudioService>();
            }
    }
}
