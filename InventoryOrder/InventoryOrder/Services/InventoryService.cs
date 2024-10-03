using InventoryOrder.Models.intity;
using InventoryOrder.Repository;


public class InventoryService
{
    private readonly IRepository<Product> _productRepository;

    public InventoryService(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public bool IncreaseStock(int productId, int quantity)
    {
        var product = _productRepository.GetById(productId);
        if (product != null)
        {
            product.QuantityInStock += quantity;
            _productRepository.Update(product);
            _productRepository.Save();
            return true;
        }
        return false;
    }

    public bool DecreaseStock(int productId, int quantity)
    {
        var product = _productRepository.GetById(productId);
        if (product != null && product.QuantityInStock >= quantity)
        {
            product.QuantityInStock -= quantity;
            _productRepository.Update(product);
            _productRepository.Save();
            return true;
        }
        return false;
    }
}
