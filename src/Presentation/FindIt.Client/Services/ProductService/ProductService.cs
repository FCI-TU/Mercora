using System.Net.Http.Json;
using FindIt.Shared.DTOs;
using FindIt.Shared.ProductDtos;
using FindIt.Shared.Response;
using FindIt.Shared.Specifications.ProductSpecifications;

namespace FindIt.Client.Services.ProductService;
public class ProductService(IHttpClientFactory _httpClientFactory) : IProductService
{
	private readonly HttpClient httpClient = _httpClientFactory.CreateClient("Auth");
	
	public string Message { get; set; } = "Loading products...";

	public ProductParameters SpecificationParameters { get; set; } = new();

	public PaginationToReturn<ProductResponse>? ProductsResponse { get; set; }

	public List<BrandResponse> Brands { get; set; } = [];

	public List<CategoryResponse> Categories { get; set; } = [];

	public async Task GetProductsAsync()
	{
		var uri = "api/v1/Product?pageIndex=" + SpecificationParameters.PageIndex;

		uri += "&brandId=" + SpecificationParameters.BrandId;

		uri += "&categoryId=" + SpecificationParameters.CategoryId;

		if (!string.IsNullOrWhiteSpace(SpecificationParameters.Sort))
			uri += "&sort=" + SpecificationParameters.Sort;

		if (!string.IsNullOrWhiteSpace(SpecificationParameters.Search))
			uri += "&search=" + SpecificationParameters.Search;

		var response = await httpClient.GetFromJsonAsync<PaginationToReturn<ProductResponse>>(uri);

		ProductsResponse = response ?? null;
	}

	public async Task<List<ProductResponse>> GetFeaturedProductsAsync()
	{
		var response = await httpClient.GetFromJsonAsync<List<ProductResponse>>("api/v1/Product/featured");

		return response ?? [];
	}

	public async Task<ProductResponse?> GetProductAsync(int id)
	{
		var response = await httpClient.GetAsync($"api/v1/Product/{id}");

		if (response.IsSuccessStatusCode is false)
		{
			var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();

			Message = errorResponse?.Message ?? "Product not fount";

			return null;
		}

		var product = await response.Content.ReadFromJsonAsync<ProductResponse>();

		return product;
	}

	public async Task<List<string>> GetProductSearchSuggestions(string searchText)
	{
		var response = await httpClient.GetFromJsonAsync<List<string>>($"api/v1/Product/SearchSuggestions/{searchText}");

		return response ?? [];
	}

	public async Task GetBrandsAsync()
	{
		var response = await httpClient.GetFromJsonAsync<List<BrandResponse>>("api/brand");

		Brands =  response ?? [];

		Brands.Insert(0, new BrandResponse
		{
			Id = 0,
			Name = "All",
			ImageCover = ""
		});
	}

	public async Task GetCategoriesAsync()
	{
		var response = await httpClient.GetFromJsonAsync<List<CategoryResponse>>("api/category");

		Categories = response ?? [];

		Categories.Insert(0, new CategoryResponse { Id = 0, Name = "All" });
	}

}