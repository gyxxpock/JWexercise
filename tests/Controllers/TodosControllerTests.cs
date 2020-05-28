using Shouldly;
using Xunit;

namespace Exercise.Todos.Controllers.Tests
{
    public class TodosControllerTests
    {
        [Fact]
        public void Should_TitleCase_WhenStringIsSingleCharacter()
        {
            var singleCharacterString = TodosController.ToTitleCase("h");

            singleCharacterString.ShouldBe("H");
        }
        [Fact]
        public void Should_TitleCase_WhenStringIsMultipleCharacter()
        {
            var MultipleCharacterString = TodosController.ToTitleCase("hello world!");

            MultipleCharacterString.ShouldBe("Hello World!");
        }
        [Fact]
        public void Should_TitleCase_WhenStringStartsOrEndsWithSpaces()
        {
            var StartsOrEndsWithSpacesString = TodosController.ToTitleCase("   hello   world! ");

            StartsOrEndsWithSpacesString.ShouldBe("   Hello   World! ");
        }
        [Fact]
        public void Should_TitleCase_WhenStringContainsConsecutiveSpacesBetweenWords()
        {
            var ContainsConsecutiveSpacesBetweenWordsString = TodosController.ToTitleCase("hello    world!");

            ContainsConsecutiveSpacesBetweenWordsString.ShouldBe("Hello    World!");
        }
    }
}
