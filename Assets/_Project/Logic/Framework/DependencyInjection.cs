using UniRx;
using Zenject;

namespace _Project.Framework
{
    public static class DependencyInjection
    {
        public static DiContainer AddFramework(this DiContainer container)
        {
            MessageBroker messageBroker = new();

            container.Bind<IMessagePublisher>().FromInstance(messageBroker).AsSingle().NonLazy();
            container.Bind<IMessageReceiver>().FromInstance(messageBroker).AsSingle().NonLazy();
            container.Bind<SocketConnection>().AsSingle().NonLazy();

            return container;
        }
    }
}