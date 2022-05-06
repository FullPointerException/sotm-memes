using System.Collections;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class MookWithACommonController : CardController
    {
        public MookWithACommonController(Card card, TurnTakerController turnTakerController, DamageType damageType)
            : base(card, turnTakerController)
        {
            this.damageType = damageType;
        }

        public override void AddTriggers()
        {
            // At the end of your turn, {MookWithAX} deals the nonhero target with the lowest HP 1 {type} damage.
            base.AddEndOfTurnTrigger((TurnTaker turnTaker) => turnTaker == this.TurnTaker, this.DealLowestHPTargetDamage, TriggerType.DealDamage);
        }

        private IEnumerator DealLowestHPTargetDamage(PhaseChangeAction phaseChangeAction)
        {
            var damageRoutine = this.DealDamageToLowestHP(this.Card, 1, (Card c) => c.IsVillainTarget && c.IsInPlayAndHasGameText, (Card c) => 1, damageType);
            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(damageRoutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(damageRoutine);
            }
        }

        private readonly DamageType damageType;
    }
}