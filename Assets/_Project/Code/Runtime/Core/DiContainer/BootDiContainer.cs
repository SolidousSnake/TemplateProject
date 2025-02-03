using _Project.Code.Runtime.Core.Bootstrapper;
using VContainer;
using VContainer.Unity;

namespace _Project.Code.Runtime.Core.DiContainer
{
    public class BootDiContainer : DiContainerBase
    {
        protected override void AddDependencies(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BootSceneBootstrapper>();
        }
    }
}