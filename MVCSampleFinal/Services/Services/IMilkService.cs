using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IMilkService
    {
        void AddMilkExistences(Milk milk);
        IList<Cow> GetCows();
        Milk GetMilkExistences(Guid id);
    }
}
