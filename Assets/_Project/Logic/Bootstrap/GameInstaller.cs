using _Project.Controllers;
using _Project.Framework;
using _Project.Services;
using Zenject;

namespace _Project.Bootstrap
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            Container
                .AddServices()
                .AddControllers()
                .AddFramework();
    }
}