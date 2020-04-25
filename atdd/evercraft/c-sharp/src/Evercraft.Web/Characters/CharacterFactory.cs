using Evercraft.Web.Characters.Entities;
using Evercraft.Web.Characters.ViewModels;

namespace Evercraft.Web.Characters
{
    public class CharacterFactory
    {
        public CharacterEntity Create(CreateCharacterViewModel viewModel)
        {
            return new CharacterEntity
            {
                Name = viewModel.Name
            };
        }
    }
}