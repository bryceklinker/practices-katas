using System.Linq;
using System.Threading.Tasks;
using Evercraft.Web.Characters.Entities;
using Evercraft.Web.Characters.ViewModels;
using Evercraft.Web.Common.Storage;
using Microsoft.EntityFrameworkCore;

namespace Evercraft.Web.Characters
{
    public class GetAllCharactersHandler
    {
        private readonly EvercraftContext _context;

        public GetAllCharactersHandler(EvercraftContext context)
        {
            _context = context;
        }

        public async Task<CharacterViewModel[]> Handle()
        {
            return await _context.Set<CharacterEntity>()
                .Select(c => new CharacterViewModel
                {
                    Name = c.Name
                })
                .ToArrayAsync();
        }
    }
}