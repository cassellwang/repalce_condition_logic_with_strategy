using NUnit.Framework;

namespace repalce_condition_logic_with_strategy
{
    [TestFixture]
    public class CartTests
    {
        //private readonly string blackCat = "black cat";
        private ICart cart;
        //private readonly string hsinchu = "hsinchu";
        //private readonly string postOffice = "post office";

        [Test]
        public void black_cat_with_light_weight()
        {
            cart = new BlackCat(5);
            double shippingFee = cart.shippingFee();
            feeShouldBe(150, shippingFee);
        }

        [Test]
        public void black_cat_with_heavy_weight()
        {
            cart = new BlackCat(50);
            double shippingFee = cart.shippingFee();
            feeShouldBe(500, shippingFee);
        }

        [Test]
        public void hsinchu_with_small_size()
        {
            cart = new HsinchuCat(30, 20, 10);
            double shippingFee = cart.shippingFee();
            feeShouldBe(144, shippingFee);
        }

        [Test]
        public void hsinchu_with_huge_size()
        {
            cart = new HsinchuCat(100, 20, 10);
            double shippingFee = cart.shippingFee();
            feeShouldBe(480, shippingFee);
        }

        [Test]
        public void post_office_by_weight()
        {
            cart = new PostOfficeCat(100, 20, 10, 3);
            double shippingFee = cart.shippingFee();
            feeShouldBe(110, shippingFee);
        }

        [Test]
        public void post_office_by_size()
        {
            cart = new PostOfficeCat(100, 20, 10, 300);
            double shippingFee = cart.shippingFee();
            feeShouldBe(440, shippingFee);
        }

        private void feeShouldBe(double expected, double shippingFee)
        {
            Assert.AreEqual(expected, shippingFee);
        }
    }
}