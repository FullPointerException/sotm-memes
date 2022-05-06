using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class ShieldCommonController : CardController
    {
        public ShieldCommonController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
        }

        public override void AddTriggers()
        {
            // Reduce damage dealt to hero targets by 1
            base.AddReduceDamageTrigger((Card c) => c.IsInPlayAndHasGameText && c.IsHero && c.IsTarget, 1);
        }
    }
}