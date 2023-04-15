using Newtonsoft.Json;

namespace BookTouristRoutes.Common.Auth;

public class RefreshTokenDto
{
  public RefreshTokenDto()
  {
    SigningKey = "MySuperSecretKey";
  }

  public string AccessToken { get; set; }
  public string RefreshToken { get; set; }

  [JsonIgnore]
  public string SigningKey { get; private set; }
}
