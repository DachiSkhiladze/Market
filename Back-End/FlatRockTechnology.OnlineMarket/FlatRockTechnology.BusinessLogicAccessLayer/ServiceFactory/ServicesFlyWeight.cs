using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory.Abstractions;
using FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.Services.Base.Abstractions;

namespace FlatRockTechnology.OnlineMarket.BusinessLogicAccessLayer.ServiceFactory
{
    public class ServicesFlyWeight : IServicesFlyweight
    {
        private Dictionary<Type, object> iservices { get; set; } = new Dictionary<Type, object>();
        public ServicesFlyWeight(IServiceProvider services)
        {
            IEnumerable<Type> types = typeof(IFlyWeight)
                                       .GetInterfaces()
                                        .Where(o => o.GetInterfaces().Length >= 1); // Adding all super interfaces of IFlyweight
            foreach (var type in types)
            {

                var service = services.GetService(type);
                iservices.Add(type, service);
            }
        }

        public T GetService<T>() where T : IBaseService
        {
            var service = (T)iservices[typeof(T)];
            return service;
        }
    }
}
