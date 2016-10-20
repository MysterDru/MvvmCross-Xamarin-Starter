using Autofac;
using Autofac.Core;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmTemplate.Platform
{
    public class AutofacMvxIocProvider : MvxSingleton<IMvxIoCProvider>, IMvxIoCProvider
    {
        private readonly IContainer _container;

        public AutofacMvxIocProvider(IContainer container)
        {
            if (container == null) throw new ArgumentNullException("container");
            _container = container;
        }

        public bool CanResolve<T>() where T : class
        {
            return _container.IsRegistered<T>();
        }

        public bool CanResolve(Type type)
        {
            return _container.IsRegistered(type);
        }

        public T Resolve<T>() where T : class
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }

        public T Create<T>() where T : class
        {
            return Resolve<T>();
        }

        public object Create(Type type)
        {
            return Resolve(type);
        }

        public T GetSingleton<T>() where T : class
        {
            return Resolve<T>();
        }

        public object GetSingleton(Type type)
        {
            return Resolve(type);
        }

        public bool TryResolve<T>(out T resolved) where T : class
        {
            return _container.TryResolve(out resolved);
        }

        public bool TryResolve(Type type, out object resolved)
        {
            return _container.TryResolve(type, out resolved);
        }

        public void RegisterType<TFrom, TTo>()
            where TFrom : class
            where TTo : class, TFrom
        {

            var cb = new ContainerBuilder();
            cb.RegisterType<TTo>().As<TFrom>().AsSelf();
            cb.Update(_container);
        }

        public void RegisterType(Type tFrom, Type tTo)
        {
            var cb = new ContainerBuilder();
            cb.RegisterType(tTo).As(tFrom).AsSelf();
            cb.Update(_container);
        }

        public void RegisterType<TInterface>(Func<TInterface> constructor) where TInterface : class
        {
            throw new NotImplementedException();
        }

        public void RegisterType(Type t, Func<object> constructor)
        {
            throw new NotImplementedException();
        }

        public void RegisterSingleton<TInterface>(TInterface theObject) where TInterface : class
        {
            var cb = new ContainerBuilder();
            cb.RegisterInstance(theObject).As<TInterface>().AsSelf().SingleInstance();
            cb.Update(_container);
        }

        public void RegisterSingleton(Type tInterface, object theObject)
        {
            var cb = new ContainerBuilder();
            cb.RegisterInstance(theObject).As(tInterface).AsSelf().SingleInstance();
            cb.Update(_container);
        }

        public void RegisterSingleton<TInterface>(Func<TInterface> theConstructor) where TInterface : class
        {
            var cb = new ContainerBuilder();
            cb.Register(cc => theConstructor()).As<TInterface>().AsSelf().SingleInstance();
            cb.Update(_container);
        }

        public void RegisterSingleton(Type tInterface, Func<object> theConstructor)
        {
            var cb = new ContainerBuilder();
            cb.Register(cc => theConstructor()).As(tInterface).AsSelf().SingleInstance();
            cb.Update(_container);
        }

        public T IoCConstruct<T>() where T : class
        {
            return (T)IoCConstruct(typeof(T));
        }

        public object IoCConstruct(Type type)
        {
            return Resolve(type);
        }

        public void CallbackWhenRegistered<T>(Action action)
        {
            CallbackWhenRegistered(typeof(T), action);
        }

        public void CallbackWhenRegistered(Type type, Action action)
        {
            _container.ComponentRegistry.Registered += (sender, args) => {
                if (args.ComponentRegistration.Services.OfType<TypedService>().Any(x => x.ServiceType == type))
                {
                    action();
                }
            };
        }
    }
}
