namespace KanesKitchenServer.Responses
{
    public record LoginResponse(bool Success, string Message, string Token, string RefreshToken);

}
