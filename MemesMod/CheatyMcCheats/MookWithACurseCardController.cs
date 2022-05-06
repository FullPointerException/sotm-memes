using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class MookWithACurseCardController : MookWithACommonController
    {
        public MookWithACurseCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController, DamageType.Infernal)
        {
        }
    }
}