using System;
using _Project.Controllers;
using _Project.Repositories;
using RH_Utilities.Extensions;
using UniRx;
using UnityEngine;
using static UniRx.Observable;
using static UnityEngine.Input;

namespace _Project
{
    public class InputSystem : IDisposable
    {
        private bool _isStopped = false;
        
        private readonly CompositeDisposable _disposable;
        private readonly IMessagePublisher _publisher;
        private readonly CharactersViewsRepository _repository;

        public InputSystem(IMessagePublisher publisher, CharactersViewsRepository repository)
        {
            _repository = repository;
            _publisher = publisher;
            _disposable = new();

            EveryUpdate()
                .Subscribe(Tick)
                .AddTo(_disposable);
        }
        public void Dispose() =>
            _disposable.Dispose();

        private void Tick(long frame)
        {
            if (_repository.HasLocalPlayer) 
                HandleInput();
        }

        private void HandleInput()
        {
            Vector3 input = new Vector3(
                    GetAxis("Horizontal"),
                    0f,
                    GetAxis("Vertical"))
                .normalized;

            if (input != Vector3.zero)
            {
                _isStopped = false;
                _publisher.Publish(new MoveMessage
                {
                    Direction = input.ToNumerics(),
                });
            }
            else if (!_isStopped)
            {
                _isStopped = true;
                _publisher.Publish(new StopMovementMessage());
            }
        }
    }
}