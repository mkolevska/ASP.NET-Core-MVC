using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransactionApp.Data;
using TransactionApp.Models;

namespace TransactionApp.Controllers
{
    public class TransactionControllercs : Controller
    {
        public TransactionDbContext _db;
        public TransactionControllercs(TransactionDbContext db)
        {
            _db = db;
        }
      
        public async Task<IActionResult> Index()
        {
           List<Transaction>? transactions = await _db?.Transactions?.ToListAsync();
            if (transactions != null)
            {

                return View(transactions);
            }
            return View();
        }
     
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(AddTransaction newtransaction)
        {
            var random = new Random();
            var transaction = new Transaction()
            {
              
              AccountNumber = newtransaction.AccountNumber,
              BeficiaryName = newtransaction.BeficiaryName,
              BankName = newtransaction.BankName,
              SWITCode = newtransaction.SWITCode,
              Amount = newtransaction.Amount,
              Date = DateTime.Now
              
            };
            
           await _db.Transactions.AddAsync(transaction);
          await  _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]

        public async Task<IActionResult> EditTransaction(int id)
        {
            var transaction = await _db.Transactions
                 .FirstOrDefaultAsync(x => x.TransactionId == id);
            if (transaction != null)
            {
                var editTransaction = new EditTransaction()
                {
                    TransactionId = transaction.TransactionId,
                    AccountNumber = transaction.AccountNumber,
                    BeficiaryName = transaction.BeficiaryName,
                    BankName = transaction.BankName,
                    SWITCode = transaction.SWITCode,
                    Amount = transaction.Amount,
                    Date = transaction.Date
                };
               
                return await Task.Run(() => View("Edit",editTransaction));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditTransaction(EditTransaction editedTransaction)
        {
            var transaction = await _db.Transactions
                .FindAsync(editedTransaction.TransactionId);
            if (transaction != null)
            {

                    transaction.BeficiaryName = editedTransaction.BeficiaryName;
                transaction.BankName = editedTransaction.BankName;
                transaction.Amount = editedTransaction.Amount;
                transaction.Date = editedTransaction.Date;
                transaction.SWITCode = editedTransaction.SWITCode;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task< IActionResult> Delete(EditTransaction edit)
        {
            var transaction = await _db.Transactions
                .FindAsync(edit.TransactionId);
            if(transaction != null)
            {
                _db.Transactions.Remove(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
           
        


    }
}
