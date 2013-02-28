using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rigel.Batch;
using Rigel.Batch.Arguments;

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
            // do something
        }
    }
}
