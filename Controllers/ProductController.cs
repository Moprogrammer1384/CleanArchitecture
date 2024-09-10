using System.Text.Json;
using AutoMapper;
using Catalog.API.Abstractions;
using Catalog.API.Application.Contract;
using Catalog.API.Application.Contract.Data;
using Catalog.API.Application.Dtos.Commons;
using Catalog.API.Application.Dtos.Products;
using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public class ProductController : ApiController
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductController(IProductRepository productRepository, IMapper mapper)
    {
        this._mapper = mapper;
        this._productRepository = productRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddProductAsync([FromBody] ProductForAddDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);

        await _productRepository.AddAsync(product);

        return Ok();
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<ProductDto>> GetProductByIdAsync([FromRoute] int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        var productDto = _mapper.Map<ProductDto>(product);
        return Ok(productDto);
    }

    [HttpGet("fliter")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> FliterProductsAsync
    ([FromQuery]FilterDataDto filterDto)
    {
        try
        {
            var filterData = _mapper.Map<FilterData>(filterDto);
            var pagedProducts = await _productRepository.FilterAsync(filterData);
            var result = _mapper.Map<IEnumerable<ProductDto>>(pagedProducts.Items);

            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(pagedProducts.Data));

            return Ok(result);

        }
        catch (System.Exception exp)
        {
            return BadRequest(exp.Message);
        }
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> SearchProductsAsync
    ([FromQuery]SearchDataDto searchDto)
    {
        try
        {
            var searchData = _mapper.Map<SearchData>(searchDto); 
            var pagedProducts = await _productRepository.SearchAsync(searchData);
            var result = _mapper.Map<IEnumerable<ProductDto>>(pagedProducts.Items);

            Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(pagedProducts.Data));

            return Ok(result);
        }
        catch (Exception exp)
        {
            return BadRequest(exp.Message);
        }
    }

    [HttpPut("{productId}")]
    public async Task<ActionResult<IEnumerable<Product>>> UpdateProductAsync(
        [FromRoute] int productId,
        [FromBody] ProductForUpdateDto productDto)
    {
        var product = await _productRepository.GetByIdAsync(productId);

        if(product is null)
        {
            return BadRequest($"Invalid product id {productId}");
        }

        _mapper.Map(productDto, product);

        await _productRepository.UpdateAsync(product);

        return Ok();
    }

    [HttpDelete("{productId}")]
    public async Task<ActionResult<IEnumerable<Product>>> DeleteProductAsync
    ([FromRoute] int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);

        if(product is null)
        {
            return BadRequest($"Invalid product id {productId}");
        }

        await _productRepository.DeleteAsync(product);

        return Ok();
    }
}
