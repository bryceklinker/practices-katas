using System.Threading.Tasks;
using Evercraft.Web.Characters.ViewModels;
using Evercraft.Web.Common.Storage;

namespace Evercraft.Web.Characters
{
    public class CreateCharacterHandler
    {
        private readonly EvercraftContext _context;
        private readonly CharacterFactory _factory;

        public CreateCharacterHandler(EvercraftContext context)
        {
            _context = context;
            _factory = new CharacterFactory();
        }    

        public async Task Handle(CreateCharacterViewModel viewModel)
        {
            var character = _factory.Create(viewModel);
            _context.Add(character);
            await _context.SaveChangesAsync();
        }
    }
}