
using Domain;

namespace MvcSample.Models.MilkModels
{
    public class CowModel
    {
        public Guid Id { get; set; }
        public string Race { get; set; }
        public MilkModel Milk { get; set; }
    }


    public class CowsModel
    {
        public IList<CowModel> Cows { get; set; } = new List<CowModel>();
    }
}
