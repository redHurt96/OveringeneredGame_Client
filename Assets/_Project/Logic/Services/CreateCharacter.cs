using _Project.Logic.Services;
using Zenject;

namespace _Project.Services
{
    public static class DependencyInjection
    {
        public static DiContainer AddServices(this DiContainer container)
        {
            container.Bind<ICreateCharacterService>().To<CreateCharacterService>().AsSingle().NonLazy();
            container.Bind<CharactersFactory>().AsSingle();
            container.Bind<CharactersRepository>().AsSingle();

            return container;
        }
    }
}
