using VContainer;
using VContainer.Unity;

namespace _Project.Code.Runtime.Core.DiContainer
{
    public abstract class DiContainerBase : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            AddDependencies(builder);
        }

        protected abstract void AddDependencies(IContainerBuilder builder);
    }
}