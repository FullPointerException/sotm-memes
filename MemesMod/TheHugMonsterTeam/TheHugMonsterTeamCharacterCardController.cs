﻿using System;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.TheHugMonsterTeam
{
    public class TheHugMonsterTeamCharacterCardController : VillainTeamCharacterCardController
    {
        public TheHugMonsterTeamCharacterCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
        }
    }
}
