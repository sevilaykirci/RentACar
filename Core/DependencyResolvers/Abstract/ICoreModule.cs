using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolvers
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
