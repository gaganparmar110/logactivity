using RxWeb.Core.Data;
using FBRxweb.BoundedContext.Main;

namespace FBRxweb.UnitOfWork.Main
{
    public class LogActivitiesUow : BaseUow, ILogActivitiesUow
    {
        public LogActivitiesUow(ILogActivitiesContext context, IRepositoryProvider repositoryProvider) : base(context, repositoryProvider) { }
    }

    public interface ILogActivitiesUow : ICoreUnitOfWork { }
}


