using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miniwd.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MiniwdTests
{
    [TestClass]
    public class FlatTests
    {
        public static IList<ValidationResult> Validate(object model)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, results, true);
            if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);
            return results;
        }

        [TestMethod]
        public void AllFieldsFilledOutTest()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void KindOfOperationTest()
        {
            var model = new Flat()
            {
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Prosze podaæ typ oferty", results[0].ErrorMessage);
        }

        [TestMethod]
        public void KindOfSpaceTest()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podaæ typ nieruchomoœci", results[0].ErrorMessage);
        }

        [TestMethod]
        public void RoomsAmountTest1()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podaæ liczbê pokoi z oferty wiêksz¹ ni¿ 1", results[0].ErrorMessage);
        }

        [TestMethod]
        public void RoomsAmountTest2()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 0,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podaæ liczbê pokoi z oferty wiêksz¹ ni¿ 1", results[0].ErrorMessage);
        }

        [TestMethod]
        public void BathroomsAmountTest1()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podaæ liczbê ³azienek wiêksz¹ ni¿ 1", results[0].ErrorMessage);
        }

        [TestMethod]
        public void BathroomsAmountTest2()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 0,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podaæ liczbê ³azienek wiêksz¹ ni¿ 1", results[0].ErrorMessage);
        }

        [TestMethod]
        public void LocationRatingTest1()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                Size = 120,
                Price = 230,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Prosze wybraæ ocenê lokalizacji mieszkania/pokoju z oferty", results[0].ErrorMessage);
        }

        [TestMethod]
        public void LocationRatingTest2()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 0,
                Size = 120,
                Price = 230,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Prosze wybraæ ocenê lokalizacji mieszkania/pokoju z oferty", results[0].ErrorMessage);
        }

        [TestMethod]
        public void SizeTest()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Price = 230,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podaæ metra¿ wiêkszy ni¿ 1", results[0].ErrorMessage);
        }

        [TestMethod]
        public void SizeTest2()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 0,
                Price = 230,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podaæ metra¿ wiêkszy ni¿ 1", results[0].ErrorMessage);
        }

        [TestMethod]
        public void PriceTest1()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podaæ cenê z oferty wiêksz¹ ni¿ 1z³", results[0].ErrorMessage);
        }

        [TestMethod]
        public void PriceTest2()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 0,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podaæ cenê z oferty wiêksz¹ ni¿ 1z³", results[0].ErrorMessage);
        }

        [TestMethod]
        public void StandardTest1()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê wybraæ standard pokoju/mieszkania z oferty", results[0].ErrorMessage);
        }

        [TestMethod]
        public void StandardTest2()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Standard = 0,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê wybraæ standard pokoju/mieszkania z oferty", results[0].ErrorMessage);
        }

        [TestMethod]
        public void FloorTest1()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Standard = 4,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void FloorTest2()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Standard = 4,
                Floor = -1,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podaæ piêtro wiêksze lub równe 0", results[0].ErrorMessage);
        }

        [TestMethod]
        public void CityTest()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Standard = 4,
                Floor = 2,
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê wybraæ miejscowoœæ", results[0].ErrorMessage);
        }

        [TestMethod]
        public void UserRoomsAmountTest1()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 2,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podaæ preferowan¹ liczbê pokoi wiêksz¹ lub równ¹ 1", results[0].ErrorMessage);
        }

        [TestMethod]
        public void UserRoomsAmountTest2()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 2,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 0,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podaæ preferowan¹ liczbê pokoi wiêksz¹ lub równ¹ 1", results[0].ErrorMessage);
        }

        [TestMethod]
        public void UserPriceTest1()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 23,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podac preferowan¹ cenê wiêksz¹ ni¿ 1z³", results[0].ErrorMessage);
        }

        [TestMethod]
        public void UserPriceTest2()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 23,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 0,
                UserStandard = 3,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podac preferowan¹ cenê wiêksz¹ ni¿ 1z³", results[0].ErrorMessage);
        }

        [TestMethod]
        public void UserStandardTest1()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Standard = 2,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podaæ preferowany standard pokoju/mieszkania", results[0].ErrorMessage);
        }

        [TestMethod]
        public void UserStandardTest2()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 5,
                Size = 120,
                Price = 230,
                Standard = 3,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 0,
                UserLocationRating = 4
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Proszê podaæ preferowany standard pokoju/mieszkania", results[0].ErrorMessage);
        }

        [TestMethod]
        public void UserLocationRatingTest1()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 3,
                Size = 120,
                Price = 230,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Prosze podaæ preferowan¹ ocenê lokalizacji mieszkania/pokoju", results[0].ErrorMessage);
        }

        [TestMethod]
        public void UserLocationRatingTest2()
        {
            var model = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                BathroomsAmount = 1,
                LocationRating = 4,
                Size = 120,
                Price = 230,
                Standard = 4,
                Floor = 2,
                City = "Warszawa",
                UserRoomsAmount = 2,
                UserPrice = 123,
                UserStandard = 3,
                UserLocationRating = 0
            };

            var results = Validate(model);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Prosze podaæ preferowan¹ ocenê lokalizacji mieszkania/pokoju", results[0].ErrorMessage);
        }

        [TestMethod]
        public void EmptyFlatTest()
        {
            var model = new Flat();

            var results = Validate(model);

            Assert.AreEqual(13, results.Count);
        }
    }
}
