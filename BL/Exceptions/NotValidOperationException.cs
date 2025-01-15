using AutoMapper;

namespace BL.Exceptions
{
    public class NotValidOperationException : Exception
    {
        public NotValidOperationException(string mes) : base(mes)
        {
            
        }

        public NotValidOperationException()
        {
            
        }
    }
}
