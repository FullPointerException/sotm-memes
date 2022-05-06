using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class MookWithAMicCardController : MookWithACommonController
    {
        public MookWithAMicCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController, DamageType.Sonic)
        {
        }
    }
}