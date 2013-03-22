using Rigel.Logging;

namespace Rigel.SampleBatchApp
{
    public class DoSomething : IDoSomething
    {
        public DoSomething(ILogger logger)
        {
        }

        public void Run()
        {
            // do something
        }
    }
}