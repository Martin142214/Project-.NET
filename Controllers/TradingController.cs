using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

//namespace WebApplication1.Controllers
//{
//    public class TradingController : Controller
//    {
       

//            private readonly UserManager<IdentityUser> _userManager;

//            private readonly AppDbContext _context;

//            private readonly TradeServices _tradeHelper;

//            private readonly ILogger _logger;

//            public TradingController(

//                AppDbContext context,

//                UserManager<IdentityUser> userManager,

//                TradeServices tradeHelper,

//                ILogger<TradingController> logger)

//            {

//                //constructor injection to get a dependency.

//                _context = context;

//                _userManager = userManager;

//                _tradeHelper = tradeHelper;

//                _logger = logger;

//            }



//            [HttpGet]

//            public async Task<IActionResult> Index()

//            {

//                string userId = _userManager.GetUserId(HttpContext.User);

//                var TradeDbContext = _context.Trades.Include(t => t.Symbol).Include(t => t.User)

//                .Where(t => t.UserId == userId);

//                return View(await TradeDbContext.ToListAsync());

//            }

//            [HttpGet]

//            public IActionResult Create(string symbol, string price)

//            {

//                if (string.IsNullOrWhiteSpace(symbol))

//                {

//                    ViewData["SymbolId"] = new SelectList(_context.TickerSymbols.OrderBy(s => s.Symbol).Where(s => s.isEnabled == true), "Id", "Symbol");

//                }

//                else

//                {

//                    ViewData["SymbolId"] = new SelectList(_context.TickerSymbols.OrderBy(s => s.Symbol).Where(s => s.isEnabled == true && s.Symbol == symbol), "Id", "Symbol");

//                    ViewData["Price"] = price;

//                }

//                return View();

//            }



//            [HttpPost]

//            [ValidateAntiForgeryToken]

//            public async Task<IActionResult> Create([Bind("Id,UserId,SymbolId,Quantity,Price,Action,CreationDate,Comment,Status,Reserved")] Trade trade)

//            {

//                if (ModelState.IsValid)

//                {

//                    trade.UserId = _userManager.GetUserId(HttpContext.User);

//                    trade.CreationDate = DateTime.Now;

//                    trade.Status = TradeStatus.Approved;

//                    _context.Add(trade);

//                    await _context.SaveChangesAsync();



//                    //creating a transaction to pay or get paid for the trade. can be set status too? but

//                    // right now all will be set to approved because there is try-catch on all transactions and trade

//                    Transaction transaction = new Transaction();

//                    transaction = await _tradeHelper.createTradeTransaction(trade);

//                    await _tradeHelper.updateUserCashBalance(transaction);

//                    _logger.LogWarning("Before Wealth creation" + transaction.TransactionType);

//                    await _tradeHelper.createWealth(transaction);



//                    return RedirectToAction(nameof(Index));

//                }

//                ViewData["SymbolId"] = new SelectList(_context.TickerSymbols.Where(s => s.isEnabled == true), "Id", "Symbol", trade.SymbolId);

//                return View(trade);

//            }

//            [HttpGet]

//            public async Task<IActionResult> Details(int? id)

//            {

//                if (id == null)

//                {

//                    return NotFound();

//                }

//                string userId = _userManager.GetUserId(HttpContext.User);

//                var trade = await _context.Trades

//                    .Include(t => t.Symbol)

//                    .Include(t => t.User)

//                    .Where(t => t.UserId == userId)

//                    .FirstOrDefaultAsync(m => m.Id == id);

//                if (trade == null)

//                {

//                    return NotFound();

//                }



//                return View(trade);

//            }
//        }
//}