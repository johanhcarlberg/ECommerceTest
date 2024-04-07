using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Bunit;
using ECommerceTest.Frontend.Components.Pages;
using Microsoft.Extensions.DependencyInjection;
using ECommerceTest.Shared;
using ECommerceTest.Shared.Dtos;
using ECommerceTest.Frontend.Services;
using Moq;
using AngleSharp.Dom;

namespace ECommerceTest.Tests
{
	public class ProductsComponentTest : TestContext
	{
		Mock<IProductService<ProductDto>> _productServiceMock;
		[Fact]
		public void ProductsComponentRendersCorrectly()
		{
			_productServiceMock = new Mock<IProductService<ProductDto>>();
			Services.AddSingleton<IProductService<ProductDto>>(_productServiceMock.Object);
			// Act
			var cut = RenderComponent<Products>();

			// Assert
			var header = cut.Find("h3");
			header.MarkupMatches("<h3>Products</h3>");
		}
	}
}
