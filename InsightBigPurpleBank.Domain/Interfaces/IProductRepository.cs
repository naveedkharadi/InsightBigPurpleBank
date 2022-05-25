using InsightBigPurpleBank.Domain.Models;
using System.Threading.Tasks;

namespace InsightBigPurpleBank.Domain.Interfaces
{
    public interface IProductRepository
    {
        public Task<ResponseBankingProductList> GetProducts();
    }
}