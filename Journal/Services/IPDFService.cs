using Journal.Models;

namespace Journal.Services
{
    public interface IPDFService
    {
        byte[] GeneratePdf(JournalEntry entry);
    }
}
