using System.Web.Http.Dependencies;
using Historique.Business.Mapper;
using Ninject;

namespace Historique.App_Start
{
    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;

            AddDependenciesBindings();
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }

        private void AddDependenciesBindings()
        {
            this._kernel.Bind<IHistoriqueAnalyticService>().To<HistoricAnalyticService>();
        }
    }
}