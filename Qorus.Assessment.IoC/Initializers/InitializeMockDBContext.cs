using Microsoft.Extensions.DependencyInjection;
using Qorus.Assessment.Data.Contexts;

namespace Qorus.Assessment.IoC.Initializers
{
    public class InitializeMockDBContext
    {
        public static void InitializeMockDBContexts(IServiceCollection services)
        {
            MockContext.ConfigureMockContext(services);
        }
    }
}
