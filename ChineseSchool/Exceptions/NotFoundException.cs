using System.Net;

namespace ChineseSchool.Exceptions
{
    public class NotFoundException : ApiException
    {
        private const string DescriptionException = "Запись не найдена";
        private const int _statusCode = (int)HttpStatusCode.NotFound;

        public NotFoundException() : base(_statusCode, DescriptionException)
        {

        }

        public NotFoundException(string description) : base(_statusCode, description)
        {

        }
    }
}
