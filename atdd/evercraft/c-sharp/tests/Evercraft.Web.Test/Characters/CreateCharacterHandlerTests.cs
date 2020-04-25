using System.Threading.Tasks;
using Evercraft.Web.Characters;
using Evercraft.Web.Characters.Entities;
using Evercraft.Web.Characters.ViewModels;
using Evercraft.Web.Common.Storage;
using Evercraft.Web.Test.Support;
using Xunit;

namespace Evercraft.Web.Test.Characters
{
    public class CreateCharacterHandlerTests
    {
        private readonly EvercraftContext _context;
        private readonly CreateCharacterHandler _handler;

        public CreateCharacterHandlerTests()
        {
            _context = EvercraftContextFactory.Create();
            _handler = new CreateCharacterHandler(_context);
        }

        [Fact]
        public async Task WhenCharacterCreatedThenCharacterIsAddedToTheDatabase()
        {
            await _handler.Handle(new CreateCharacterViewModel {Name = "Bob"});
            
            Assert.Single(_context.Set<CharacterEntity>());
        }
    }
}