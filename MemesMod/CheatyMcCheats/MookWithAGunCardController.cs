using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class MookWithAGunCardController : MookWithACommonController
    {
        public MookWithAGunCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController, DamageType.Projectile)
        {
        }
    }
}