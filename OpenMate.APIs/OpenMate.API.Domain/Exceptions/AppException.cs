namespace OpenMate.API.Domain.Exceptions
{
    public class AppException : Exception
    {
        private string _Mgs;
        public AppException(string msg) 
        {
            _Mgs = msg;
        }

        public override string Message => _Mgs;
    }
}
