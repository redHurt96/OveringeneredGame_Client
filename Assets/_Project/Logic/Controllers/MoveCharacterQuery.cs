using System;
using RH_Utilities.Extensions;
using UniRx;
using UnityEngine;

namespace _Project.Controllers
{
    public class MoveCharacterQuery : MonoBehaviour
    {
        private CompositeDisposable _disposable;

        [SerializeField] private bool wasInput;
        [SerializeField] private long lastInputTick;

        public void Setup(IMessageReceiver receiver)
        {
            _disposable = new();
            
            receiver
                .Receive<UpdatePositionMessage>()
                .Subscribe(MoveCharacter)
                .AddTo(_disposable);
        }

        private void Update()
        {
            if (Input.GetAxisRaw("Horizontal").ApproximatelyEqual(0f)
                && Input.GetAxisRaw("Vertical").ApproximatelyEqual(0f)
                && wasInput)
            {
                wasInput = false;
                lastInputTick = DateTime.Now.Ticks;
            }
            else if (!Input.GetAxisRaw("Horizontal").ApproximatelyEqual(0f)
                     || !Input.GetAxisRaw("Vertical").ApproximatelyEqual(0f))
            {
                wasInput = true;
                lastInputTick = DateTime.Now.Ticks;
            }
        }

        public void Dispose() => 
            _disposable.Dispose();

        private void MoveCharacter(UpdatePositionMessage message)
        {
            float delay = (DateTime.Now.Ticks - message.Tick)/(float)TimeSpan.TicksPerSecond;
            Debug.Log($"Seconds delay = {delay}, Delay from input = {(DateTime.Now.Ticks - lastInputTick)/(float)TimeSpan.TicksPerSecond}");
            
            transform.position = message.Position.ToUnity();
        }
    }
}