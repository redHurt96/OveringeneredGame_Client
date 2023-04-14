using _Project.Domain;

namespace _Project.Logic.Services
{
    internal class CharactersRepository
    {
        private Character _main;

        internal void Register(Character character) => 
            _main = character;

        internal Character Get() =>
            _main;
    }
}