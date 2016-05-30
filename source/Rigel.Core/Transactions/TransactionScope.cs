using System.Transactions;

namespace Rigel.Core.Transactions
{
    public static class ScopeFactory
    {
        public static TransactionScope CreateScope()
        {
            var transactionOptions = new TransactionOptions
                                         {
                                             IsolationLevel = IsolationLevel.ReadCommitted,
                                             Timeout = TransactionManager.MaximumTimeout
                                         };

            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }
    }
}