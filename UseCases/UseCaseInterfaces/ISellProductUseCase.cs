namespace UseCases.UseCaseInterfaces
{
    public interface ISellProductUseCase
    {
        void Execute(string cashiername, int productID, int sellQty);
    }
}