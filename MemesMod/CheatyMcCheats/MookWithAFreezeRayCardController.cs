using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class MookWithAFreezeRayCardController : MookWithACommonController
    {
        public MookWithAFreezeRayCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController, DamageType.Cold)
        {
        }
    }
}