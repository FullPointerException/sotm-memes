using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class SwordCommonController : CardController
    {
        public SwordCommonController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
        }

        public override void AddTriggers()
        {
            // Increase damage dealt by hero targets by 1
            base.AddIncreaseDamageTrigger((DealDamageAction dda) => dda.DamageSource.IsHero && dda.DamageSource.IsTarget, 1);
        }
    }
}