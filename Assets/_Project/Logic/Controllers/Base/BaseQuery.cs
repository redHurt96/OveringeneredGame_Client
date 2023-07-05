using System;
using UniRx;

namespace _Project.Controllers.Base
{
    public abstract class BaseQuery<T> : IDisposable
    {
        private readonly CompositeDisposable _disposable;

        protected BaseQuery(IMessageReceiver receiver) =>
            receiver
                .Receive<T>()
                .Subscribe(OnReceive)
                .AddTo(_disposable = new());

        public void Dispose() => 
            _disposable.Dispose();

        protected abstract void OnReceive(T message);
    }
}