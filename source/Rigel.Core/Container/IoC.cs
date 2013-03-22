﻿using System;

namespace Rigel.Container
{
    public class IoC
    {
        private static IContainer _container;
        public static IContainer Container
        {
            get { return _container; }
        }

        public static bool IsInitialized { get; set; }

        public static void Initialize(IContainer container)
        {
            if(IsInitialized)
            {
                throw new InvalidOperationException("container already initialized");
            }

            _container = container;
            IsInitialized = true;
        }
        
        public static void Reset(IContainer container)
        {
            _container = null;
        }

        public static TDependency GetInstance<TDependency>()
        {
            if(!IsInitialized)
            {
                throw new InvalidOperationException("please initialize container");
            }

            TDependency service;

            try
            {
                service = _container.GetInstance<TDependency>();
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(
                    "ObjectFactory has not been initialized; " + "I was trying to retrieve " + typeof(TDependency),
                    ex);
            }
            //catch (ActivationException ex)
            //{
            //    throw new ActivationException(
            //        "The needed dependency of type " + typeof(TDependency).Name +
            //        " could not be located with the ServiceLocator. You'll need to register it with " +
            //        "the Common Service Locator (CSL) via your IoC's CSL adapter. " + ex.Message, ex);
            //}

            return service;
        }
    }
}
