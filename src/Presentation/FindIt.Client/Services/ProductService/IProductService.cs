﻿using FindIt.Shared.DTOs;
using FindIt.Shared.ProductDtos;
using FindIt.Shared.Specifications.ProductSpecifications;

namespace FindIt.Client.Services.ProductService;
public interface IProductService
{
	public string Message { get; set; }
	public ProductParameters SpecificationParameters { get; set; }

	public PaginationToReturn<ProductResponse>? ProductsResponse { get; set; }

	public List<BrandResponse> Brands { get; set; }

	public List<CategoryResponse> Categories { get; set; }
	Task GetProductsAsync();
	Task<List<ProductResponse>> GetFeaturedProductsAsync();
	Task<ProductResponse?> GetProductAsync(int id);
	Task<List<string>> GetProductSearchSuggestions(string searchText);

	Task GetBrandsAsync();
	Task GetCategoriesAsync();
}