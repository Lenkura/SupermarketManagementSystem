using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetCategoryByIDUseCase
    {
        Category Execute(int CategoryId);
    }
}