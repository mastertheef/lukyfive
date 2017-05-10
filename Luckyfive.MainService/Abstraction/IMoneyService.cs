using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luckyfive.DTO;

namespace Luckyfive.MainService.Abstraction
{
    public interface IMoneyService
    {
        /// <summary>
        /// Check if outgoing pool has the needed ammount
        /// </summary>
        /// <param name="amount"></param>
        bool CheckMoneyPool(decimal amount);

        /// <summary>
        /// Requests needed ammount to be sent to outgoing pool
        /// </summary>
        /// <param name="amount"></param>
        void RequestForRaedy(decimal amount);

        /// <summary>
        /// Sends money from outgoing pool to owners and company 
        /// </summary>
        /// <param name="readyAdvs"></param>
        void FinishReady(List<AdvertismentDTO> readyAdvs);
    }
}
