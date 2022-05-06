using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class MookWithATaserCardController : MookWithACommonController
    {
        public MookWithATaserCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController, DamageType.Lightning)
        {
        }
    }
}