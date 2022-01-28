using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiftCard.Core.Entities;

namespace GiftCard.Core.Repositories
{
    public interface ICardRepository
    {
        IList<Card> FetchAll();


        void Create(Card card);

        void Update(Card cardToUpdate, Card cardUpdated);

        void Delete(Card card);
    }
}
