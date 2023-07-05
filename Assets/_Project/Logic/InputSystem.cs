using System;
using RH_Utilities.Extensions;
using UniRx;
using UnityEngine;
using static UniRx.Observable;
using static UnityEngine.Input;

namespace _Project
{
    public class InputSystem : IDisposable
    {
        private string _characterId;
        
        private readonly CompositeDisposable _disposable;
        private readonly IMessagePublisher _publisher;

        public InputSystem(IMessagePublisher publisher)
        {
            _publisher = publisher;
            _disposable = new();

            EveryUpdate()
                .Subscribe(Tick)
                .AddTo(_disposable);
        }

        public void Setup(string characterId) => 
            _characterId = characterId;

        public void Dispose() =>
            _disposable.Dispose();

        private void Tick(long frame)
        {
            Vector3 input = new Vector3(
                    GetAxis("Horizontal"),
                    0f,
                    GetAxis("Vertical"))
                .normalized;

            if (input != Vector3.zero)
                _publisher.Publish(new MoveMessage
                {
                    CharacterId = _characterId,
                    Direction = input.ToNumerics(),
                });
        }
    }
}