using Rigel.Batch;
using Rigel.Batch.Arguments;
using Rigel.Container;

namespace Rigel.SampleBatchApp
{
    [BatchExecutable("SampleBatch")]
    public class SampleBatchApplication : BaseBatchApplication
    {
        public override string BatchName
        {
            get { return "SampleBatch"; }
        }

        #region Arguments

        protected SampleBatchArguments _batchArguments = new SampleBatchArguments();

        public override CommonBatchArguments BatchArguments
        {
            get { return _batchArguments; }
        }

        public class SampleBatchArguments : CommonBatchArguments
        {
            // define custom attributes here
        }

        #endregion

        public override void RunBatch()
        {
            // where to initialize static gateways???

            var doSomething = IoC.GetInstance<IDoSomething>();

            doSomething.Run();
        }

        protected override void CreateContainer()
        {
            new SampleAppBootstrapper().BootstrapStructureMap();
        }
    }
}
