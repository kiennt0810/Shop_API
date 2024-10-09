namespace Shop_API.ViewModels
{
    public class LoginResponse
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        public string[]? Role { get; set; }
        public bool? isFirstLogin { get; set; }
    }
}
