﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCard.WPF.Messaging
{
    public class ShowUpdateCardMessage
    {
        public GiftCard.Core.Entities.Card Entity { get; set; }
    }
}
