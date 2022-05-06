using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class MookWithASmiteCardController : MookWithACommonController
    {
        public MookWithASmiteCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController, DamageType.Radiant)
        {
        }
    }
}