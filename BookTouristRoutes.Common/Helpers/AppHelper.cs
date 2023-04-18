namespace BookTouristRoutes.Common.Helpers;

public class AppHelper
{
  private static readonly Random Random = new ();

  private const string RandomPrefix = "R";

  public static string GenerateRandomPassword(int length)
  {
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
    return new string(Enumerable.Repeat(chars, length)
      .Select(s => s[Random.Next(s.Length)]).ToArray());
  }

  public static string GenerateRandomUrl(int length = 10)
  {
    const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    var random = new Random();
    return "https://example.com/" + new string(Enumerable.Repeat(chars, length)
      .Select(s => s[random.Next(s.Length)]).ToArray());
  }

  public static string GenerateRandomName()
  {
    return $"{RandomPrefix}{RandomizeCharacters(7)}";
  }

  public static string GenerateRandomEmail()
  {
    const string chars = "abcdefghijklmnopqrstuvwxyz";
    var username = new string(Enumerable.Repeat(chars, 8)
      .Select(s => s[Random.Next(s.Length)]).ToArray());

    var domain = new string(Enumerable.Repeat(chars, 5)
      .Select(s => s[Random.Next(s.Length)]).ToArray());

    var tld = new string(Enumerable.Repeat(chars, 3)
      .Select(s => s[Random.Next(s.Length)]).ToArray());

    return $"{username}@{domain}.{tld}";
  }

  private static string RandomizeCharacters(int lenght)
  {
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    var stringChars = new char[lenght];
    for (var i = 0; i < stringChars.Length; i++)
    {
      stringChars[i] = chars[Random.Next(chars.Length)];
    }

    return new string(stringChars);
  }
}
