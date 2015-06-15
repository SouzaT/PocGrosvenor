using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grosvenor.Business;

namespace Grosvenor.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        private Restaurant restaurantDomain;

        [TestInitialize()]
        public void InitializeVariables()
        {
            restaurantDomain = new Grosvenor.Business.Restaurant();
        }

        [TestMethod]
        public void InputMornigCompleteOrder()
        {
            var input = "morning, 1, 2, 3";
            var expectedValue = "eggs, toast, coffee";
            var resultInput1 = restaurantDomain.DishOrder(input);
            Assert.AreEqual(string.Join(", ", resultInput1), expectedValue.Trim());
        }

        [TestMethod]
        public void InputMornigCompleteOrderWithUpperCase()
        {
            var input = "Morning, 1, 2, 3";
            var expectedValue = "eggs, toast, coffee";
            var resultInput1 = restaurantDomain.DishOrder(input);
            Assert.AreEqual(string.Join(", ", resultInput1), expectedValue.Trim());
        }

        [TestMethod]
        public void InputMorningCompleteMixedDishesOrder()
        {
            var input = "morning, 2, 1, 3";
            var expectedValue = "eggs, toast, coffee";

            var resultInput2 = restaurantDomain.DishOrder(input);

            Assert.AreEqual(string.Join(", ", resultInput2), expectedValue.Trim());
        }

        [TestMethod]
        public void InputMorningWithInvalidDish()
        {
            var input = "morning, 1, 2, 3, 4";
            var expectedValue = "eggs, toast, coffee, error";

            var resultInput3 = restaurantDomain.DishOrder(input);

            Assert.AreEqual(string.Join(", ", resultInput3), expectedValue.Trim());
        }

        [TestMethod]
        public void InputMotningWithMultipleAllowedDish()
        {
            var input = "morning, 1, 2, 3, 3, 3";
            var expectedValue = "eggs, toast, coffee(x3)";

            var resultInput4 = restaurantDomain.DishOrder(input);

            Assert.AreEqual(string.Join(", ", resultInput4), expectedValue.Trim());
        }

        [TestMethod]
        public void InputCompleteNightOrder()
        {
            var input = "night, 1, 2, 3, 4";
            var expectedValue = "steak, potato, wine, cake";

            var resultInput5 = restaurantDomain.DishOrder(input);

            Assert.AreEqual(string.Join(", ", resultInput5), expectedValue.Trim());
        }

        [TestMethod]
        public void InputCompleteNightOrderWithUpperCase()
        {
            var input = "Night, 1, 2, 3, 4";
            var expectedValue = "steak, potato, wine, cake";

            var resultInput5 = restaurantDomain.DishOrder(input);

            Assert.AreEqual(string.Join(", ", resultInput5), expectedValue.Trim());
        }
        [TestMethod]
        public void InputNightOrderWithMultipleAllwedDish()
        {
            var input = "night, 1, 2, 2, 4";
            var expectedValue = "steak, potato(x2), cake";

            var resultInput6 = restaurantDomain.DishOrder(input);

            Assert.AreEqual(string.Join(", ", resultInput6), expectedValue.Trim());
        }

        [TestMethod]
        public void InputNIghtOrderWithInvalidDishOption()
        {
            var input = "night, 1, 2, 3, 5";
            var expectedValue = "steak, potato, wine, error";
            var resultInput7 = restaurantDomain.DishOrder(input);

            Assert.AreEqual(string.Join(", ", resultInput7), expectedValue.Trim());
        }

        [TestMethod]
        public void InputNightOrderWithMultipleNotAllowedDish()
        {
            var input = "night, 1, 1, 2, 3, 5";
            var expectedValue = "steak, error";
            var resultInput8 = restaurantDomain.DishOrder(input);

            Assert.AreEqual(string.Join(", ", resultInput8), expectedValue.Trim());
        }
    }
}
