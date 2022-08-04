using Castle.DynamicProxy;
using System.Text;
using System.Collections.Generic;
using System;

using System.Reflection;

namespace Core.Utilities.Interceptors
{
  [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple = true,Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute:Attribute,IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
    
    
}