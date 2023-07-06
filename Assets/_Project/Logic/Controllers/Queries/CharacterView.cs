using UnityEngine;

namespace _Project.Controllers.Queries
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int _run = Animator.StringToHash("Run");

        public void Move(Vector3 to)
        {
            transform.position = to;
            _animator.SetBool(_run, true);
        }

        public void Rotate(Vector3 to) => 
            transform.forward = to;

        public void Stop() => 
            _animator.SetBool(_run, false);
    }
}