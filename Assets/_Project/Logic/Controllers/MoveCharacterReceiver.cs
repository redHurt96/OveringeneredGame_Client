using System;
using UniRx;

namespace _Project.Controllers
{
    public class MoveCharacterReceiver : IDisposable
    {
        private readonly CompositeDisposable _disposable;
        private readonly IMessageReceiver _messageReceiver;

        public MoveCharacterReceiver(IMessageReceiver messageReceiver)
        {
            _messageReceiver = messageReceiver;
            _disposable = new();
            
        }

        public void Dispose()
        {
        }
    }
}