using _Project.Logic.Services;
using UnityEngine;

namespace _Project.Services
{
    internal class CreateCharacterService : ICreateCharacterService
    {
        private readonly CharactersFactory _factory;

        internal CreateCharacterService(CharactersFactory factory) => 
            _factory = factory;

        public void Execute(Vector3 position) =>
            _factory.Execute(position);
    }
}