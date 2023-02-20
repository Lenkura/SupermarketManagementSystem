using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewProductsByCategoryID
    {
        IEnumerable<Product> Execute(int CategoryID);
    }
}