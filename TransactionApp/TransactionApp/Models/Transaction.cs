using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionApp.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
     
        public string AccountNumber { get; set; }
        
        public string BeficiaryName { get; set; }
       
        public string BankName { get; set; }
       
        public string SWITCode { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }

    }
}
