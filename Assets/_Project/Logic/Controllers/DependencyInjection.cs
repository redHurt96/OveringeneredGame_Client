using Zenject;

namespace _Project.Controllers
{
    public static class DependencyInjection
    {
        public static DiContainer AddControllers(this DiContainer container)
        {
            container.Bind<CreateCharacterReceiver>().AsTransient().NonLazy();

            return container;
        }
    }
}