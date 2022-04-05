using System;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;

namespace Memes.MigrantCoder
{
    public class MigrantCoderTurnTakerController : HeroTurnTakerController
    {
        public MigrantCoderTurnTakerController(TurnTaker turnTaker, GameController gameController)
            : base(turnTaker, gameController)
        {
        }
    }
}
