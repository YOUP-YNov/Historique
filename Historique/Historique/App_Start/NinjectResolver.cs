using System.Web.Http.Dependencies;
using Historique.Business.Mapper;
using Historique.DAL.DAL;
using Historique.Mapper;
using Ninject;
using Historique = Historique.DAL.DAL.Historique;

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
            this._kernel.Bind<IHistoriqueApiService>().To<HistoriqueApiService>();
            this._kernel.Bind<IHistoriqueBll>().To<HistoriqueBll>();
            this._kernel.Bind<IHistorique>().To<DAL.DAL.Historique>();
        }
    }
}