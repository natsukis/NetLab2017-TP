using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Services.Crud;
using Services.Models;

namespace UnitTestService
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]

        public void CrearEmpleado()

        {

            //Arrange

            var country = new CountryModel()
            {

                CountryName = "Argentina",


            };

            var auxShift = new ShiftModel()
            {

                Name ="Mañana",

                InitialHour =5,

                EndingHour =12
        };

            var empleado = new EmployeeModel()
            {
                FirstName = "Pedro",

                LastName = "Testing",

                Country = country,

                EntryDate = DateTime.Today,

                CurrentShift = auxShift,

                ValueByHour = 50

            };



            //Act

            var crud = new CrudEmployee();
            crud.Create(empleado);



            //Assert

            Assert.Fail();

           

        }


        /*
        [TestMethod]

        public void ProbarSumaEnterosDebeDevolverUnEntero()

        {

            //Arrange

            var calculadora = new Calculadora();



            //Act

            var suma = calculadora.Agregar(10, 60);



            //Assert

            Assert.IsInstanceOfType(suma, typeof(int));

            Assert.IsTrue(suma > 0);

        }



        [TestMethod]

        public void ProbarSumaNegativosDebeDevolverNegativo()

        {

            //Arrange

            var calculadora = new Calculadora();



            //Act

            var suma = calculadora.Agregar(-59, -1);



            //Assert

            Assert.IsInstanceOfType(suma, typeof(int));

            Assert.IsTrue(suma < 0);

        }

    */

    }
}
