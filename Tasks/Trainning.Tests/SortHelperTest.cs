using Algorithm.Sort;
using Xunit;

namespace Trainning.Tests
{
    public class SortHelperTest
    {
        [Fact]
        public void BubbleTest()
        {
            int[] input = { 90, 76, 45, 93, 68, 13, 98 };
            SortHelper.Bubble(input);
            int[] expected = { 13, 45, 68, 76, 90, 93, 98 };
            for (int index = 0; index < input.Length; index++)
            {
                Assert.Equal(input[index], expected[index]);
            }
        }
    }
}