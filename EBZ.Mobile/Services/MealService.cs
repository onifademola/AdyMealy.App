using EBZ.Mobile.Models;
using EBZ.Mobile.ServicesInterface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBZ.Mobile.Services
{
    public class MealService : IMealService
    {
        //GenericService _genericRepository = new GenericService();
        private readonly IGenericService _genericRepository;
        public MealService(IGenericService genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<AspUser> GetUser(string email)
        {
            string uri = Constants.BaseApiUrl + Constants.User + email;
            var customers = await _genericRepository.GetAsync<AspUser>(uri);
            return customers;
        }

        public async Task<List<MealQueue>> GetMealQueues(string email)
        {
            string uri = Constants.BaseApiUrl + Constants.MealQueues + email;
            var customers = await _genericRepository.GetAsync<List<MealQueue>>(uri);
            return customers;
        }

        public async Task<List<MealTransaction>> GetMealTransactionsToday(string email)
        {
            string uri = Constants.BaseApiUrl + Constants.MealTransactionsToday + email;
            var balance = await _genericRepository.GetAsync<List<MealTransaction>>(uri);
            return balance;
        }

        public async Task<List<MealTransaction>> GetMealTransactions(string email)
        {
            string uri = Constants.BaseApiUrl + Constants.MealTransactions + email;
            var balance = await _genericRepository.GetAsync<List<MealTransaction>>(uri);
            return balance;
        }
    }
}
