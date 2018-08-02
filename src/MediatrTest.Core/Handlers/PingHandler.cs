using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrTest.Core.Models;

namespace MediatrTest.Core.Handlers
{
    public class PingHandler : IRequestHandler<Ping, Pong>
    {
        public PingHandler()
        {
        }

        public async Task<Pong> Handle(Ping request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Pong { Message = request.Message + " Pong" });
        }
    }
}
