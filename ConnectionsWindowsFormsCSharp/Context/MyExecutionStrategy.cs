using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionsWindowsFormsCSharp.Context
{
    public class MyExecutionStrategy : DbExecutionStrategy
    {
        public MyExecutionStrategy(int maxRetryCount, TimeSpan maxDelay)
            : base(maxRetryCount, maxDelay)
        {
        }

        protected override bool ShouldRetryOn(Exception exception)
        {
            // Coloque aqui a lógica de quando você deseja retentar, por exemplo, se for uma exceção específica.
            return true;
        }
    }
}
