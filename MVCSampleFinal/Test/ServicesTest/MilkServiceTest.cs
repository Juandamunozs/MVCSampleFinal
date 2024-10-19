using Domain;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Moq;
using Services;
using System.Collections.Generic;
using System.Linq;

namespace ServicesTest
{
    public class MIlkServiceTest
    {
        private MilkService milkService {  get; set; }
        //se hace mock de las clases de dependencia
        Mock<IMilkRepository> milkRepositoryMock { get; set; }
        Milk myMilk { get; set; }

        [SetUp]
        public void Setup()
        {
            myMilk = new Milk();
            myMilk.Id = Guid.NewGuid();
            //se implementa el mock y se hace setup  de los metodos requeridos para la prueba
            milkRepositoryMock = new Mock<IMilkRepository>();
            milkRepositoryMock.Setup(x => x.GetMilk(It.IsAny<Guid>())).Returns(myMilk);

             //no s epuede hacer mock de esta clase se instanci con los parametros requeridos
            Dictionary<string, string> inMemorySettings = new Dictionary<string, string> 
            {
              {"AllowedHosts", "*"},
              {"ConnectionStrings:Defaultconnection", "Server=localhost,1433;Database=ApiTestDb;user id=SA;password=Passw0rd1ns3c;TrustServerCertificate=True"},
                //...populate as needed for the test
            };
            
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            
            milkService = new MilkService(milkRepositoryMock.Object, configuration);
        }

        [Test]
        public void MilkService_Exist()
        {
            Assert.NotNull(milkService);
            var result = milkService.GetMilkExistences(Guid.NewGuid());
            Assert.That(result, Is.EqualTo(myMilk));
        }
    }
}