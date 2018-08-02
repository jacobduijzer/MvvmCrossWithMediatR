using System.Threading.Tasks;
using MediatR;
using MediatrTest.Core.Models;
using MvvmCross;

namespace MediatrTest.Core.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        private readonly IMediator _mediator;

        public StartViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task Initialize()
        {
            await base.Initialize().ConfigureAwait(false);

            try
            {
                var result = await _mediator.Send(new Ping { Message = "Ping" })
                                            .ConfigureAwait(false);

                ErrorMessage = result.Message;
            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
            }
           
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }
    }
}