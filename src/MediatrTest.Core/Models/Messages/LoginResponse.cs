namespace MediatrTest.Core.Models.Messages
{
    public class LoginResponse
    {
        public bool Succes { get; }

        public string Message { get; }

        private LoginResponse(bool success) => Succes = success;

        private LoginResponse(bool success, string message) 
            : this(success) => Message = message;

        public static LoginResponse WithStatus(bool success) 
        => new LoginResponse(success);

        public static LoginResponse WithStatusAndMessage(bool success, string message) 
        => new LoginResponse(success, message);
    }
}
