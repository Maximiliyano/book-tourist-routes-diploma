namespace BookTouristRoutes.Common.Auth;

public sealed class AccessTokenDto
{
  public AccessToken AccessToken { get; }
  public string RefreshToken { get; }

  public AccessTokenDto (AccessToken accessToken, string refreshToken)
  {
    AccessToken = accessToken;
    RefreshToken = refreshToken;
  }
}
