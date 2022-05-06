using System.Collections;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class MookWithAFlamethrowerCardController : MookWithACommonController
    {
        public MookWithAFlamethrowerCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController, DamageType.Fire)
        {
        }
    }
}