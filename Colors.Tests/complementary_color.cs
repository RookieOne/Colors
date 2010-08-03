using System.Windows.Media;
using NUnit.Framework;

namespace Colors.Tests
{
    [TestFixture]
    public class complementary_color
    {
        [Test]
        public void complementary_test1()
        {
            var originalColor = Color.FromArgb(255, 50, 50, 50);
            var complementaryColor = originalColor.GetComplementary();

            complementaryColor.A.ShouldBe<byte>(255);
            complementaryColor.R.ShouldBe<byte>(50);
            complementaryColor.G.ShouldBe<byte>(50);
            complementaryColor.B.ShouldBe<byte>(50);
        }

        [Test]
        public void complementary_test2()
        {
            var originalColor = Color.FromArgb(255, 0, 100, 150);
            var complementaryColor = originalColor.GetComplementary();

            complementaryColor.A.ShouldBe<byte>(255);
            complementaryColor.R.ShouldBe<byte>(205);
            complementaryColor.G.ShouldBe<byte>(205);
            complementaryColor.B.ShouldBe<byte>(205);
        }

        [Test]
        public void complementary_test3()
        {
            var originalColor = Color.FromArgb(255, 255, 0, 100);
            var complementaryColor = originalColor.GetComplementary();

            complementaryColor.A.ShouldBe<byte>(255);
            complementaryColor.R.ShouldBe<byte>(205);
            complementaryColor.G.ShouldBe<byte>(205);
            complementaryColor.B.ShouldBe<byte>(205);
        }
    }
}