using MSA.Phase2.Backend.Services;
using MSA.Phase2.Backend.Models;

namespace MSA.Phase2.UnitTesting
{
    public class TestLocations
    {
        private Location location;
        [SetUp]
        public void Setup()
        {
            LocationService.Add(new Backend.Models.Location { Name = "location", Lat = -2.3, Lng = 3.4 });
            location = new Location { Name = "location", Lat = 0, Lng = 0 };
        }

        [Test]
        public void TestAddAndGetAll()
        {
            Assert.That(LocationService.GetAll().Count, Is.EqualTo(3));
            Assert.That(LocationService.GetAll()[2].Name, Is.EqualTo("location"));
            Assert.That(LocationService.GetAll()[1].Name, Is.EqualTo("Hamilton"));
            Assert.That(LocationService.GetAll()[2].Lat, Is.EqualTo(-2.3));
        }

        [Test]
        public void TestGet()
        {
            Assert.That(LocationService.Get("location")?.Lat, Is.EqualTo(-2.3));
            Assert.That(LocationService.Get("Does not exist"), Is.Null);
        }

        [Test]
        public void TestAdd()
        {
            Assert.That(LocationService.Add(location), Is.False);
            Assert.That(LocationService.GetAll().Count, Is.EqualTo(3));
        }

        [Test]
        public void TestUpdate()
        {
            Assert.That(LocationService.Update(location), Is.True);
            Assert.That(LocationService.Get("location")?.Lat, Is.EqualTo(0));
        }

        [Test]
        public void TestDelete()
        {
            LocationService.Delete("Hamilton");
            Assert.That(LocationService.GetAll().Count, Is.EqualTo(2));
        }
    }
}