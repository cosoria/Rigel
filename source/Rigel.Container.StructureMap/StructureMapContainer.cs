using StructureMap;

namespace Rigel.Container.StructureMap
{
    public class StructureMapContainer : Rigel.Container.IContainer
    {
        public TDependency GetInstance<TDependency>()
        {
            return ObjectFactory.GetInstance<TDependency>();
        }

        public void Dispose()
        {
            ObjectFactory.Container.Dispose(); // ???
        }

        //private readonly global::StructureMap.IContainer _container;

        //public StructureMapContainer(global::StructureMap.IContainer container)
        //{
        //    _container = container;
        //}

        //public TDependency GetInstance<TDependency>()
        //{
        //    return _container.GetInstance<TDependency>();
        //}
    }
}
