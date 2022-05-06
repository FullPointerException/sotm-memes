using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class MookWithALaserCardController : MookWithACommonController
    {
        public MookWithALaserCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController, DamageType.Energy)
        {
        }
    }
}