using _Project.Controllers;
using UniRx;
using Zenject;

namespace _Project
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            MessageBroker messageBroker = new();

            Container.Bind<IMessagePublisher>().FromInstance(messageBroker).AsSingle().NonLazy();
            Container.Bind<IMessageReceiver>().FromInstance(messageBroker).AsSingle().NonLazy();
            Container.Bind<SocketConnection>().AsSingle().NonLazy();
            
            BindControllers();
        }

        private void BindControllers()
        {
            Container.Bind<CreateCharacterQuery>().AsSingle().NonLazy();
            Container.Bind<MoveCharacterCommand>().AsSingle().NonLazy();
        }
    }
}