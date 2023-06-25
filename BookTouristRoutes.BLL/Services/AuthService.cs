using AutoMapper;
using BookTouristRoutes.BLL.Interfaces.JWT;
using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.BLL.Services.Base;
using BookTouristRoutes.Common.Auth;
using BookTouristRoutes.Common.Builders;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Exceptions;
using BookTouristRoutes.Common.Helpers;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Services;

public class AuthService : BaseService<IUserRepository, User>, IAuthService
{
  private readonly IJwtFactory _jwtFactory;
  private readonly IUserService _userService;
  private readonly IRefreshTokenRepository _refreshTokenRepository;

  public AuthService(
    IUserRepository repository,
    IUserService userService,
    IMapper mapper,
    IJwtFactory jwtFactory,
    IRefreshTokenRepository refreshTokenRepository) : base(repository, mapper)
  {
    _jwtFactory = jwtFactory;
    _userService = userService;
    _refreshTokenRepository = refreshTokenRepository;
  }

  public async Task<AuthUserDto> Authorize(LoginUserDto loginUserDto)
  {
    var userEntity = await _userService.Get(loginUserDto.Email);

    if (!SecurityHelper.ValidatePassword(loginUserDto.Password, userEntity.Password, userEntity.Salt))
      throw new InvalidUserCredentialsException();

    var token = await GenerateAccessToken(userEntity.Id, userEntity.Name, userEntity.Email);
    var user = _mapper.Map<UserDto>(userEntity);

    return GlobalBuilder.BuildAuthUserDto(user, token);
  }

  public async Task<AccessTokenDto> GenerateAccessToken(int userId, string userName, string email)
  {
    var token = _jwtFactory.GenerateRefreshToken();
    var refreshTokenEntity = GlobalBuilder.BuildRefreshToken(token, userId);

    await _refreshTokenRepository.CreateAsync(refreshTokenEntity);

    var accessToken = await _jwtFactory.GenerateAccessToken(userId, userName, email);

    return GlobalBuilder.BuildAccessTokenDto(accessToken, token);
  }

  public async Task<AccessTokenDto> RefreshToken(RefreshTokenDto dto)
  {
    var userId = _jwtFactory.GetUserIdFromToken(dto.AccessToken, dto.SigningKey);
    var userEntity = await _userService.Get(userId);

    var rToken = await _refreshTokenRepository.FirstOrDefaultAsync(t =>
      t.Token == dto.RefreshToken &&
      t.UserId == userId);

    if (rToken is null)
      throw new InvalidTokenException("refresh");

    if (!rToken.IsActive)
      throw new ExpiredRefreshTokenException();

    var jwtToken = await _jwtFactory.GenerateAccessToken(userEntity.Id, userEntity.Name, userEntity.Email);
    var refreshToken = _jwtFactory.GenerateRefreshToken();

    await _refreshTokenRepository.RemoveTokenAsync(rToken);

    var entity = GlobalBuilder.BuildRefreshToken(refreshToken, userEntity.Id);
    await _refreshTokenRepository.CreateAsync(entity);

    return GlobalBuilder.BuildAccessTokenDto(jwtToken, refreshToken);
  }

  public async Task RevokeRefreshToken(string refreshToken, int userId)
  {
    var rToken = await _refreshTokenRepository.FirstOrDefaultAsync(t => t.Token == refreshToken && t.UserId == userId);

    if (rToken is null)
    {
      throw new InvalidTokenException("refresh");
    }

    await _refreshTokenRepository.DeleteAsync(rToken);
  }

  public async Task<int> GetUserIdFromToken()
  {
    var refreshToken = await _refreshTokenRepository.FirstOrDefaultAsync(x => x.Expires > DateTime.Now);

    if (refreshToken is null)
    {
      throw new InvalidTokenException("access");
    }

    return refreshToken.UserId;
  }
}
