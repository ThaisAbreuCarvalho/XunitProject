using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using XunitTest.Utilities;

namespace XunitTest.Courses
{
    public class CoursesTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly string _name;
        private readonly double _hours;
        private readonly TargetPublic _public;
        private readonly double _price;

        public CoursesTest(ITestOutputHelper outputHelper)
        {
            _testOutputHelper = outputHelper;
            _testOutputHelper.WriteLine("Executando teste de cursos");
            _name = "Informatics";
            _hours = 80;
            _public = TargetPublic.student;
            _price = 950;
        }

        public void Dispose()
        {
            _testOutputHelper.WriteLine("teste finalizado");
        }

        [Fact(DisplayName = "ShouldCreateCourse")]
        public void ShouldCreate()
        {
            //arrange
            var expectedCourse = new
            {
                Name = _name,
                Hours = _hours,
                TargetPublic = _public,
                Price = _price
            };

            //act
            var course = new Course(expectedCourse.Name, expectedCourse.Hours, expectedCourse.TargetPublic, expectedCourse.Price);

            //assert
            expectedCourse.ToExpectedObject().ShouldMatch(course);
        }

        [Theory(DisplayName = "ValidateName")]
        [InlineData("")]
        [InlineData(null)]
        public void NameShouldNotBeNullOrEmpty(string invalidName)
        {
            //arrange
            var expectedCourse = new
            {
                Name = _name,
                Hours = _hours,
                TargetPublic = TargetPublic.student,
                Price = _price
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
             new Course(invalidName, _hours, _public, _price)
            ).MessageValidation("Nome inválido");
        }

        [Theory(DisplayName = "ValidateCourseHours")]
        [InlineData(0)]
        [InlineData(-2)]
        public void CourseHoursShouldNotBeLessThanOne(double hours)
        {
            //arrange
            var expectedCourse = new
            {
                Name = _name,
                Hours = _hours,
                TargetPublic = _public,
                Price = _price
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
             new Course(_name, hours, _public, _price)
            ).MessageValidation("Carga horária inválida");
        }

        [Theory(DisplayName = "ValidatePrice")]
        [InlineData(-2)]
        [InlineData(-0.2)]
        public void PriceShouldNotBeNegative(double invalidPrice)
        {
            //arrange
            var expectedCourse = new
            {
                Name = _name,
                Hours = _hours,
                TargetPublic = _public,
                Price = _price
            };

            //Assert
            Assert.Throws<ArgumentException>(() =>
             new Course(_name, _hours, _public, invalidPrice)
            ).MessageValidation("Preço inválido");
        }
    }

    internal enum TargetPublic
    {
        student = 1,
        undergrad = 2,
        employed = 3,
        entrepreneur = 4
    }

    internal class Course
    {
        public string Name { get; private set; }
        public double Hours { get; private set; }
        public TargetPublic TargetPublic { get; private set; }
        public double Price { get; private set; }

        public Course(string name, double hours, TargetPublic targetPublic, double price)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Nome inválido");

            if (hours <= 1)
                throw new ArgumentException("Carga horária inválida");
            
            if (price <= 0)
                throw new ArgumentException("Preço inválido");

            this.Name = name;
            this.Hours = hours;
            this.TargetPublic = targetPublic;
            this.Price = price;
        }
    }
}
