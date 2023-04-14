using UnityEngine;

namespace _Project.Services
{
    public interface ICreateCharacterService
    {
        void Execute(Vector3 position);
    }
}