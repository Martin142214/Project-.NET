using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

//namespace WebApplication1.Controllers
//{
    //public class TradeServices : Controller
    //{
    //    public async Task createWealth(Transaction transaction)

    //    {

//            int symbolId = transaction.Trade.SymbolId;

//            string userId = transaction.UserId;

//            string action = transaction.Trade.Action.ToString();

//            _logger.LogWarning(action);

//            var wealth = await isWealthOwner(symbolId, userId);

//            _logger.LogWarning("Wealth is null??????????????" + wealth);

//            if (wealth != null)

//            {

//                _logger.LogWarning("Inside createWealth  if block: " + transaction.TransactionType.ToString().ToUpper());

//                if (transaction.Trade.Action.ToString().ToUpper() == "BUY")

//                {

//                    wealth.Quantity = wealth.Quantity + transaction.Trade.Quantity;

//                    wealth.UpdatedDate = DateTime.Now;

//                    await _dbContext.SaveChangesAsync();

//                }

//                else if (transaction.Trade.Action.ToString().ToUpper() == "SELL")

//                {

//                    _logger.LogWarning("Inside createWealth SELL if block qty: " + wealth.Quantity + " tras: " + transaction.Trade.Quantity);

//                    if (transaction.Trade.Quantity <= wealth.Quantity)

//                    {

//                        wealth.Quantity = wealth.Quantity - transaction.Trade.Quantity;

//                        wealth.UpdatedDate = DateTime.Now;

//                        await _dbContext.SaveChangesAsync();

//                    }

//                    else

//                    {

//                        //we had to check it before. 

//                        // Not happens 

//                        // ajax and jQuery already implemented. It will not happen if user doesn't have share enough.

//                    }

//                }

//            }

//            else

//            {

//                Wealth tempWealth = new Wealth();

//                tempWealth.CreationDate = DateTime.Now;

//                tempWealth.UpdatedDate = DateTime.Now;

//                tempWealth.Quantity = transaction.Trade.Quantity;

//                tempWealth.SymbolId = transaction.Trade.SymbolId;

//                tempWealth.UserId = transaction.UserId;

//                await CreateWealth(tempWealth);
//            }
//}
