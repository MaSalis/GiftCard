using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCard.Core.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Msg { get; set; }
        public double Amount { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
