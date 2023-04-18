using RestSharp;

namespace BookTouristRoutes.Tests.Common.ApiEndpoints.Base;

public abstract class BaseApi
{
  private readonly RestClient _client;

  private readonly string _serviceUrl;

  public const string ContentType = "application/json";

  protected BaseApi(string baseUrl, string serviceUrl)
  {
    _serviceUrl = serviceUrl;
    _client = new RestClient(baseUrl);
  }

  #region Requests

  protected RestRequest CreatePutRequest<TPayload>(string url, TPayload payload = null)
    where TPayload : class
  {
    return CreateRequestWithServiceUrl(url, Method.Put, payload);
  }

  protected RestRequest CreatePutRequest(string url)
  {
    return CreateRequestWithServiceUrl(url, Method.Put);
  }

  protected RestRequest CreateGetRequest(string url)
  {
    return CreateRequestWithServiceUrl(url, Method.Get);
  }

  protected RestRequest CreatePostRequest<TPayload>(string url, TPayload payload = null, string contentType = ContentType)
    where TPayload : class
  {
    return CreateRequestWithServiceUrl(url, Method.Post, payload, contentType);
  }

  protected RestRequest CreateDeleteRequest(string url)
  {
    return CreateRequestWithServiceUrl(url, Method.Delete);
  }

  #endregion

  #region Core

  private RestRequest CreateRequestWithServiceUrl(string url, Method methodType, string contentType = ContentType)
  {
    return CreateRequest(CreateServiceUrl(url), methodType, contentType);
  }

  private RestRequest CreateRequestWithServiceUrl<TPayload>(string url, Method methodType, TPayload payload, string contentType = ContentType)
    where TPayload : class
  {
    return CreateRequest(CreateServiceUrl(url), methodType, payload, contentType);
  }

  private RestRequest CreateRequest<TPayload>(string url, Method methodType, TPayload payload, string contentType = ContentType)
    where TPayload : class
  {
    var restRequest = CreateRequest(url, methodType, contentType);

    restRequest.AddJsonBody(payload);

    return restRequest;
  }

  private RestRequest CreateRequest(string url, Method methodType, string contentType = ContentType)
  {
    var restRequest = BuildRestRequest(url, methodType);

    restRequest.AddHeader("content-type", contentType);

    return restRequest;
  }

  private string CreateServiceUrl(string url)
  {
    return Path.Combine(_serviceUrl, url);
  }

  #endregion

  #region ExecutionRequests

  protected async Task<RestResponse<TResponse>> ExecuteRequest<TResponse>(RestRequest request)
  {
    var result = await _client.ExecuteAsync<TResponse>(request);

    if (!result.IsSuccessful) // TODO change this approach
      result.Data = default;

    return result;
  }

  protected async Task<RestResponse> ExecuteRequest(RestRequest request)
  {
    var result = await _client.ExecuteAsync(request);
    if (result.ResponseStatus is ResponseStatus.Error)
      throw result.ErrorException;

    return result;
  }

  #endregion

  #region Builders

  private static RestRequest BuildRestRequest(string url, Method methodType) =>
    new ()
    {
      Resource = url,
      RequestFormat = DataFormat.Json,
      Method = methodType
    };

  #endregion
}
