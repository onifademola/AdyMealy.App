using EBZ.Mobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBZ.Mobile.ServicesInterface
{
    public interface IMealService
    {
        Task<List<MealQueue>> GetMealQueues(string email);
        Task<List<MealTransaction>> GetMealTransactionsToday(string email);
        Task<List<MealTransaction>> GetMealTransactions(string email);

    }
}
