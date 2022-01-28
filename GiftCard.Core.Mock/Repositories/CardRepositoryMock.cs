using GiftCard.Core.Entities;
using GiftCard.Core.Mock.Storage;
using GiftCard.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCard.Core.Mock.Repositories
{
    public class CardRepositoryMock : ICardRepository
    {
        public void Create(Card card)
        {
            var IdNewCard = MockStorage.Cards.Max(x => x.Id)+1;
            MockStorage.Cards.Add(card);

        }

        public void Delete(Card card)
        {
            var cardIsInStorage = MockStorage.Cards.FirstOrDefault(c=>c.Id == card.Id);
            MockStorage.Cards.Remove(card);
        }

        public IList<Card> FetchAll()
        {
            return MockStorage.Cards.ToList();
        }

        public void Update(Card cardToUpdate, Card cardUpdated)
        {
            var existingCard = MockStorage.Cards.FirstOrDefault(c=>c.Id == cardUpdated.Id);

            MockStorage.Cards.Remove(cardToUpdate);
            MockStorage.Cards.Add(cardUpdated);
        }
    }
}
