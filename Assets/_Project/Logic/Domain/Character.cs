using UnityEngine;

namespace _Project.Domain
{
    public class Character
    {
        private Vector3 _position;

        public Character(Vector3 position) => 
            _position = position;

        public void Move(Vector3 delta) => 
            _position += delta;
    }
}
