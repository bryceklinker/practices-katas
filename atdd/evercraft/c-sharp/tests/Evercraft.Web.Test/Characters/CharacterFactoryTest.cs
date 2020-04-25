using Evercraft.Web.Characters;
using Evercraft.Web.Characters.ViewModels;
using Xunit;

namespace Evercraft.Web.Test.Characters
{
    public class CharacterFactoryTest
    {
        [Fact]
        public void WhenCharacterCreatedThenCharacterNameSet()
        {
            var character = new CharacterFactory().Create(new CreateCharacterViewModel
            {
                Name = "bob"
            });

            Assert.Equal("bob", character.Name);
        }
    }
}