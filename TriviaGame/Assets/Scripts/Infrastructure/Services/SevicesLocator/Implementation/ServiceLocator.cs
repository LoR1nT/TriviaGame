using System;
using System.Collections.Generic;

namespace Infrastructure.Services.SevicesLocator.Implementation
{
    public class ServiceLocator
    {
        private static ServiceLocator _instance = null;
        private Dictionary<Type, IService> _cachedServices = null; 

        public static ServiceLocator Container
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceLocator();
                }

                return _instance;
            }
        }

        public ServiceLocator()
        {
            _cachedServices = new Dictionary<Type, IService>();
        }

        public TService Register<TService>(TService implementation) where TService : class, IService
        {
            if (_cachedServices.ContainsKey(typeof(TService)))
                return _cachedServices[typeof(TService)] as TService;
            
            _cachedServices.Add(typeof(TService), implementation);

            return implementation;
        }

        public TService Single<TService>() where TService : class, IService
        {
            return _cachedServices[typeof(TService)] as TService;
        }
    }
}