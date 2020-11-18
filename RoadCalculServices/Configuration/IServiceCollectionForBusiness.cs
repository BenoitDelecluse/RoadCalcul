using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadCalculServices.Configuration
{
    public interface IServiceCollectionForBusiness
    {        void RegisterDependencies(IServiceCollection services);
    }
}
