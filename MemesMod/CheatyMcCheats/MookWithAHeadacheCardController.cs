using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class MookWithAHeadacheCardController : MookWithACommonController
    {
        public MookWithAHeadacheCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController, DamageType.Psychic)
        {
        }
    }
}