using System.Linq;
using System.Threading.Tasks;
using Evercraft.Web.Characters;
using Evercraft.Web.Characters.Entities;
using Evercraft.Web.Common.Storage;
using Evercraft.Web.Test.Support;
using Xunit;

namespace Evercraft.Web.Test.Characters
{
    public class GetAllCharactersHandlerTest
    {
        private readonly EvercraftContext _context;
        private readonly GetAllCharactersHandler _handler;

        public GetAllCharactersHandlerTest()
        {
            _context = EvercraftContextFactory.Create();
            _handler = new GetAllCharactersHandler(_context);
        }

        [Fact]
        public async Task WhenExecutedThenReturnsAllCharacters()
        {
            _context.Add(new CharacterEntity {Name = "bill"});
            _context.Add(new CharacterEntity {Name = "bill"});
            _context.Add(new CharacterEntity {Name = "bill"});
            await _context.SaveChangesAsync();
            
            var viewModels = await _handler.Handle();
            Assert.Equal(3, viewModels.Length);
        }

        [Fact]
        public async Task WhenExecutedThenMapsEntityToViewModelProperties()
        {
            _context.Add(new CharacterEntity
            {
                Name = "someone"
            });
            await _context.SaveChangesAsync();

            var viewModel = (await _handler.Handle()).Single();
            Assert.Equal("someone", viewModel.Name);
        }
    }
}