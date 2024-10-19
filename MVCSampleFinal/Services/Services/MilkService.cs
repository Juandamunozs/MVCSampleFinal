using Domain;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MilkService : IMilkService
    {
        IMilkRepository MilkRepository { get; set; }
        IConfiguration configuration { get; set; }
        public  MilkService(IMilkRepository MilkRepository, IConfiguration configuration)
        {
            this.MilkRepository = MilkRepository;
            this.configuration = configuration;
        }
        public void AddMilkExistences(Milk milk)
        {
            var setting = configuration["Smtp:Server"];
            MilkRepository.Save(milk);
        }

        public Milk GetMilkExistences(Guid id)
        {
            Milk milk = MilkRepository.GetMilk(id);
            return milk;
        }

        public IList<Cow> GetCows()
        {
            return MilkRepository.GetCows();
        }
    }
}
