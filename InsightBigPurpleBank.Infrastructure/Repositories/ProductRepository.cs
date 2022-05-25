using InsightBigPurpleBank.Domain.Interfaces;
using InsightBigPurpleBank.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightBigPurpleBank.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<ResponseBankingProductList> GetProducts()
        {
            //TODO: to be fetched from some data source
            var products = new List<BankingProduct>();
            products.Add(new BankingProduct()
            {
                ProductId = "123",
                Description = "Hello World",
                ProductCategory = Domain.Enums.BankingProductCategory.BUSINESS_LOANS,
            });
            var sampleProductsList = new ResponseBankingProductList()
            {
                Data = new ProductsData()
                {
                    Products = products
                },
                Links = new Links()
                {

                },
                Meta = new Meta()
                {

                }
            };
            return await Task.Run(() => sampleProductsList); 
        }
    }
}
