using UnityEngine;

namespace _Project.Logic.Services
{
    internal class CharactersFactory
    {
        private readonly CharactersRepository _repository;

        public CharactersFactory(CharactersRepository repository) => 
            _repository = repository;

        internal void Execute(Vector3 position) => 
            _repository.Register(new(position));
    }
}