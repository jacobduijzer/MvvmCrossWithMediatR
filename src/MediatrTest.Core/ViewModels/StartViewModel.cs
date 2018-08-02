using System;
using System.Threading.Tasks;
using MediatR;
using MediatrTest.Core.Models;
using MvvmCross.Commands;

namespace MediatrTest.Core.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        private readonly IMediator _mediator;

        public StartViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IMvxAsyncCommand PingCommand => new MvxAsyncCommand(PingAsync);

        public IMvxAsyncCommand OneWayCommand => new MvxAsyncCommand(OneWayAsync);

        private string _pingResult;
        public string PingResult
        {
            get => _pingResult;
            set => SetProperty(ref _pingResult, value);
        }

        private string _oneWayResult;
        public string OneWayResult
        {
            get => _oneWayResult;
            set => SetProperty(ref _oneWayResult, value);
        }

        private async Task PingAsync()
        {
            var result = await _mediator.Send(new Ping { Message = "Ping" })
                                        .ConfigureAwait(false);

            PingResult = result.Message;
        }

        private async Task OneWayAsync()
        {
            try
            {
                await _mediator.Send(new OneWay("One way test"))
                           .ConfigureAwait(false);

                OneWayResult = "OneWayHandler executed, no errors";
            }
            catch (Exception ex)
            {
                OneWayResult = "OneWayHandler executed, there were errors!";
            }
        }
    }
}