using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        //Amacımız cache varlığını kontrol etmek, yok ise eklemek.
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}"); //key oluşturacağımız metodu bulmaya çalışıyor. invocation-> metot
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; //Eğer parametre değeri var ise ona gider, yoksa null döndürür
            if (_cacheManager.IsAdd(key)) //Bellekte var mı diye bak
            {
                invocation.ReturnValue = _cacheManager.Get(key); //Metodu hiç çalıştırmadan geri döndür
                return;
            }
            invocation.Proceed(); //Cache yoksa invocation'u devam ettirir, yani metot devam eder.
            _cacheManager.Add(key, invocation.ReturnValue, _duration); //Cache eklenir
        }
    }
}