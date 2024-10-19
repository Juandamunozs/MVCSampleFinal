using Domain;

namespace DomainTest
{
    public class MilkTest
    {
        private Milk milk {  get; set; }
        [SetUp]
        public void Setup()
        {
             milk = new Milk();
        }

        [Test]
        public void Milk_Exist()
        {
            Assert.NotNull(milk) ;
        }
    }
}