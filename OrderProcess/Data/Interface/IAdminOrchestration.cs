using OrderProcess.Domain;

namespace OrderProcess.Data.Interface
{
    public interface IAdminOrchestration
    {
        AdminViewModel CollectAdminTicketandProductData();
    }
}