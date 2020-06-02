using Shouldly;
using Xunit;

namespace Todos.Models.Tests
{
    public class TodosControllerTests
    {
        [Fact]
        public void Should_TitleCase_WhenStringIsSingleCharacter()
        {
            var singleCharacterString = ToDo.ToTitleCase("h");

            singleCharacterString.ShouldBe("H");
        }
        [Fact]
        public void Should_TitleCase_WhenStringIsMultipleCharacter()
        {
            var MultipleCharacterString = ToDo.ToTitleCase("hello world!");

            MultipleCharacterString.ShouldBe("Hello World!");
        }
        [Fact]
        public void Should_TitleCase_WhenStringStartsOrEndsWithSpaces()
        {
            var StartsOrEndsWithSpacesString = ToDo.ToTitleCase("   hello   world! ");

            StartsOrEndsWithSpacesString.ShouldBe("   Hello   World! ");
        }
        [Fact]
        public void Should_TitleCase_WhenStringContainsConsecutiveSpacesBetweenWords()
        {
            var ContainsConsecutiveSpacesBetweenWordsString = ToDo.ToTitleCase("hello    world!");

            ContainsConsecutiveSpacesBetweenWordsString.ShouldBe("Hello    World!");
        }
    }
}
