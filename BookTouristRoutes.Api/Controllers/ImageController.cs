using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.Common.BaseEntities;
using Microsoft.AspNetCore.Mvc;

namespace BookTouristRoutes.Api.Controllers;

[ApiController]
[Route("api/images")]
public class ImageController : BaseController
{
  private readonly IImageService _imageService;

  public ImageController(IImageService imageService)
  {
    _imageService = imageService;
  }

  [HttpGet("details")]
  public async Task<IActionResult> GetImageByUrl([FromQuery] string imageUrl)
  {
    var result = await _imageService.GetByUrl(imageUrl);

    if (result is null)
    {
      return NotFound($"Image with url: {imageUrl} not found!");
    }

    return Ok(result);
  }
}
