namespace UseCases.UseCaseInterfaces
{
    public interface IRecordTransactionsUseCase
    {
        void Execute(string cashiername, int productID, int qty);
    }
}