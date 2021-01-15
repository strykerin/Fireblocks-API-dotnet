using System;

namespace Fireblocks.Exceptions
{
    public class FireblocksException : Exception
    {
        public FireblocksException(string message, Exception exception) 
                                        : base (message, exception)
        {
        }
        public FireblocksException(string message) : base (message)
        {
        }
    }
}
