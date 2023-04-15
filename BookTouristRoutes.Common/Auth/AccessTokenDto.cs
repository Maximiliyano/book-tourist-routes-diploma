namespace BookTouristRoutes.Common.Auth;

public sealed class AccessTokenDto
{
  private AccessToken AccessToken { get; }
  private string RefreshToken { get; }

  public AccessTokenDto (AccessToken accessToken, string refreshToken)
  {
    AccessToken = accessToken;
    RefreshToken = refreshToken;
  }
}
