namespace SharedLibrary.Responses
{
    public record LoginResponse(bool Success, string Message = null!, string Token = null!, string RefreshToken = null!);

}
