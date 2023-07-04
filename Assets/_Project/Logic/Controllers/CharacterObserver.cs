using RH_Utilities.Extensions;
using UnityEngine;

namespace _Project.Controllers
{
    internal class CharacterObserver : MonoBehaviour
    {
        public void Setup(CreateCharacterMessage from) => 
            transform.position = from.Position.ToUnity();
    }
}