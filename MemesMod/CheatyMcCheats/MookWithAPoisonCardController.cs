using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class MookWithAPoisonCardController : MookWithACommonController
    {
        public MookWithAPoisonCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController, DamageType.Toxic)
        {
        }
    }
}