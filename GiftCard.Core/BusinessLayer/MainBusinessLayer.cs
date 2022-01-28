using GiftCard.Core.Entities;
using GiftCard.Core.Repositories;
using GiftCard.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCard.Core.BusinessLayer
{
    public class MainBusinessLayer
    {
        private ICardRepository _CardRepository;

        public MainBusinessLayer(ICardRepository cardRepo)
        {
            _CardRepository = cardRepo;

        }

        public IList<Card> FetchAllCards()
        {
            return _CardRepository.FetchAll();

        }

        public Response CreateCard(Card card)
        {
            
            if (card == null)
                return new Response { Success = false, Message = "Invalid data" };

            if (card.ExpirationDate < DateTime.Now)
                return new Response { Success = false, Message = "Invalida expiration date" };

           _CardRepository.Create(card);
           

            return new Response
            {
                Success = true,
                Message = "GiftCard created"
            };
        }

        public Response UpdateCard(Card card)
        {
            if (card == null)
                return new Response() { Success = false, Message = "Incorrect card" };

            var cardToUpdate = FetchAllCards().FirstOrDefault(x => x.Id == card.Id);

            _CardRepository.Update(cardToUpdate, card);

            return new Response() { Success = true, Message = "card updated" };

        }
        public Response DeleteCard(Card card)
        {
            if (card == null)
                return new Response { Success = false, Message = "Invalid card" };
            
            var cardToDelete = FetchAllCards().FirstOrDefault(x => x.Id == card.Id);
            if (cardToDelete == null)
                return new Response
                {
                    Success = false,
                    Message = $"No card with ID: {card.Id}"
                };
            _CardRepository.Delete(cardToDelete);

            return new Response { Success = true, Message = $"card deleted" };
        }

    }
    
}
