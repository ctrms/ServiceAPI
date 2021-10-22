using Boyner.API.Utilities.Interceptors;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace Boyner.API.CrossCuttingConcerns.Aspect
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
