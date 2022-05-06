using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class MookWithABatCardController : MookWithACommonController
    {
        public MookWithABatCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController, DamageType.Melee)
        {
        }
    }
}