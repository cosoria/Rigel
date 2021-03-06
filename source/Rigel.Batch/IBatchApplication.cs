using Rigel.Batch.Arguments;
using Rigel.Logging;

namespace Rigel.Batch
{
    public interface IBatchApplication
    {
        int InvokeBatch();
        CommonBatchArguments BatchArguments { get; }
        string BatchName { get; }
        ILogger Logger { get; }
    }
}