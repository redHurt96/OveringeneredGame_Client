using _Project.Logic.Services;
using UnityEngine;

namespace _Project.Services
{
    public class CharactersFactory
    {
        private readonly CharactersRepository _repository;

        internal CharactersFactory(CharactersRepository repository) => 
            _repository = repository;

        public void Execute(Vector3 position) => 
            _repository.Register(new(position));
    }
}