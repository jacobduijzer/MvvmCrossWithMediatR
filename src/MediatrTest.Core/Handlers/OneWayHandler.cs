using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrTest.Core.Models;

namespace MediatrTest.Core.Handlers
{
    public class OneWayHandler : AsyncRequestHandler<OneWay>
    {
        public OneWayHandler()
        {
        }

        protected override Task Handle(OneWay request, CancellationToken cancellationToken)
        {
            System.Diagnostics.Debug.WriteLine(request.Message);

            return Task.FromResult(true);
        }
    }
}
