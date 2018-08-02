using MediatR;

namespace MediatrTest.Core.Models
{
    public class OneWay : IRequest
    {
        public string Message { get; }

        public OneWay(string message)
        {
            Message = message;
        }
    }
}
