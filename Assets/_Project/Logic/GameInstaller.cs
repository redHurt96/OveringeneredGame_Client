using _Project.Controllers;
using _Project.Repositories;
using _Project.Services;
using UniRx;
using Zenject;

namespace _Project
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            MessageBroker messageBroker = new();

            Container.Bind<IMessagePublisher>().FromInstance(messageBroker).AsSingle();
            Container.Bind<IMessageReceiver>().FromInstance(messageBroker).AsSingle();

            BindServices();
            BindControllers();
            BindFramework();
        }

        private void BindServices()
        {
            Container.Bind<CharactersViewsRepository>().AsSingle();
            Container.Bind<CharacterViewFactory>().AsSingle();
        }

        private void BindControllers()
        {
            Container.Bind<CreateCharacterQuery>().AsSingle().NonLazy();
            Container.Bind<MoveCharacterQuery>().AsSingle().NonLazy();
            Container.Bind<MoveCharacterCommand>().AsSingle().NonLazy();
            Container.Bind<RemoveCharacterQuery>().AsSingle().NonLazy();
        }

        private void BindFramework()
        {
            Container.Bind<SocketConnection>().AsSingle().NonLazy();
            Container.Bind<InputSystem>().AsSingle().NonLazy();
        }
    }
}