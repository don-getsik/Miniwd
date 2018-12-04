using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miniwd.Models;
using Miniwd.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniwdTests
{
    public class AiServiceTest
    {
        [TestMethod]
        public void AllFieldsFilledOutTest()
        {
            var flat = new Flat()
            {
                KindOfOperation = "K",
                KindOfSpace = "M",
                RoomsAmount = 4,
                LocationRating = 5,
                Size = 88,
                Price = 473088,
                Standard = 5,
                Floor = 3,
                City = "Poznań",
                UserRoomsAmount = 2,
                UserPrice = 532224,
                UserStandard = 1,
                UserLocationRating = 0
        };
            var aiservice = new AIService(flat);
            Boolean result = aiservice.BuyOrNot();

            Assert.AreEqual(true, result);
        }
    }
}
