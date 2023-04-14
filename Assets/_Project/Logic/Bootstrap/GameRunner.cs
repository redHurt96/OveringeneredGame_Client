using _Project.Framework;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Bootstrap
{
    public class GameRunner : MonoBehaviour
    {
        private SocketConnection _connection;
        private CompositeDisposable _disposable;

        [Inject]
        private void Construct(SocketConnection connection)
        {
            _connection = connection;
            _disposable = new();
        }

        private void Start()
        {
            _connection.Execute();
            _connection.AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}