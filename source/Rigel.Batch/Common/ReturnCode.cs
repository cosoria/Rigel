namespace Rigel.Batch.Common
{
    public struct ReturnCodeValue
    {
        public const int Success = 0;
        public const int Failure = 1;
        public const int PartialFailure = 100;
    }

    public class ReturnCode
    {
        private static ReturnCode _instance;
        private int _currentState;

        private ReturnCode()
        {
            _currentState = ReturnCodeValue.Success;
        }

        public static ReturnCode Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReturnCode();
                }
                return _instance;
            }
        }

        public int Value
        {
            get { return _currentState; }
        }

        public void Fail()
        {
            _currentState = ReturnCodeValue.Failure;
        }

        public void PartiallyFail()
        {
            if (_currentState != ReturnCodeValue.Failure)
            {
                _currentState = ReturnCodeValue.PartialFailure;
            }
        }

        public void Reset()
        {
            _currentState = ReturnCodeValue.Success;
        }

        public bool HasFailed()
        {
            return _currentState == ReturnCodeValue.Failure;
        }
    }
}
