using System.Collections;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class LoudCommonController : CardController
    {
        public LoudCommonController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
        }

        public override void AddTriggers()
        {
            // At the end of your turn, {CheatyMcCheats} deals each villain target 1 Sonic damage
            base.AddEndOfTurnTrigger((TurnTaker turnTaker) => turnTaker == this.TurnTaker, this.DealVillainsDamage, TriggerType.DealDamage);
        }

        public override IEnumerator UsePower(int index = 0)
        {
            // {CheatyMcCheats} deals each villain target 1 Sonic damage
            var damageAmount = this.GetPowerNumeral(0, 1);
            var damageRoutine = this.DealDamage(this.CharacterCard, (Card c) => c.IsVillain && c.IsInPlayAndHasGameText, damageAmount, DamageType.Sonic);
            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(damageRoutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(damageRoutine);
            }
        }

        private IEnumerator DealVillainsDamage(PhaseChangeAction phaseChangeAction)
        {
            var damageRoutine = this.DealDamage(this.CharacterCard, (Card c) => c.IsVillain && c.IsInPlayAndHasGameText, 1, DamageType.Sonic);

            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(damageRoutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(damageRoutine);
            }
        }
    }
}