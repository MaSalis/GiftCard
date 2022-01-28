using GiftCard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCard.Core.Mock.Storage
{
    public class MockStorage
    {
        public static IList<Card> Cards { get; set; }

        public static void Initialize()
        {

            Cards = new List<Card>();


            Cards.Add(new Card
            {
                Id = 10,
                Sender = "mario rossi",
                Receiver = "sonia",
                Msg = "frfr",
                Amount = 2,
                ExpirationDate = new DateTime(2022, 2, 10)
            });
            Cards.Add(new Card
            {
                Id = 10,
                Sender = "giuseppe bianchi",
                Receiver = "luca verdi",
                Msg = "Buon compleanno",
                Amount = 50,
                ExpirationDate = new DateTime(2022, 2, 20)
            });
        }
    }
}