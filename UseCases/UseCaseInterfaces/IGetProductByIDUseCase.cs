using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetProductByIDUseCase
    {
        Product Execute(int productID);
    }
}