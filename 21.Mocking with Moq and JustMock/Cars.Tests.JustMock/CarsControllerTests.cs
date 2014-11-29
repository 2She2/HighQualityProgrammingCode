namespace Cars.Tests.JustMock
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using System.Collections.Generic;
    using Cars.Models;

    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        // New tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ControllerDetailOfMinus1ShouldThrowArgumentNullException()
        {
            controller.Details(-1);
        }

        [TestMethod]
        public void ControllerDetailsOf1ShouldReturnCarWithId1()
        {
            var model = (Car)GetModel(() => this.controller.Details(1));

            Assert.AreEqual(1, model.Id); 
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void SearchForCarShouldReturnBMW()
        {
            var models = (ICollection<Car>)GetModel(() => this.controller.Search("some search"));

            Assert.AreEqual("BMW", models.First().Make);
        }

        [TestMethod]
        public void SearchForCarShouldReturn2Bmws()
        {
            var models = (ICollection<Car>)GetModel(() => this.controller.Search("some search"));

            Assert.AreEqual(2, models.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SearchByEmptyOrNullStringShouldThrowException()
        {
            this.controller.Search("");
        }

        [TestMethod]
        public void OrderCarsByMakeShouldReturFirstCarAudiLastOpel()
        {
            var cars = (ICollection<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual("Audi", cars.First().Make);
            Assert.AreEqual("Opel", cars.Last().Make);
        }

        [TestMethod]
        public void OrderCarsByYearShouldReturnFirstCarAudiLastOpel()
        {
            var cars = (ICollection<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(2005, cars.First().Year);
            Assert.AreEqual(2010, cars.Last().Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OrderByInvalidParameterShouldThrowArgumentNullException()
        {
            this.controller.Sort("ivalid sort");
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }

        [TestMethod]
        public void CreateCarsControllerWithoutParameter()
        {
            new CarsController();
        }
    }

}
