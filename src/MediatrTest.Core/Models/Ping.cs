using MediatR;

namespace MediatrTest.Core.Models
{
    public class Ping : IRequest<Pong>
    {
        public string Message { get; set; }
    }
}
