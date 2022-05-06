using System.Collections;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class PollutionMookCardController : CardController
    {
        public PollutionMookCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
        }

        public override void AddTriggers()
        {
            // At the end of your turn, {PollutionMook} deals each environment target 1 Toxic damage.
            base.AddEndOfTurnTrigger((TurnTaker turnTaker) => turnTaker == this.TurnTaker, this.DamageEnvironment, TriggerType.DealDamage);
        }

        public override IEnumerator UsePower(int index = 0)
        {
            // Destroy 1 environment target
            var destroyRoutine = this.GameController.SelectAndDestroyCard(this.HeroTurnTakerController, new LinqCardCriteria((Card c) => c.IsEnvironment && c.IsInPlayAndHasGameText), false);

            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(destroyRoutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(destroyRoutine);
            }
        }

        private IEnumerator DamageEnvironment(PhaseChangeAction phaseChangeAction)
        {
            var damageRoutine = this.GameController.DealDamage(
                this.HeroTurnTakerController, 
                this.Card, 
                (Card c) => c.IsEnvironmentTarget && c.IsInPlayAndHasGameText, 
                1, 
                DamageType.Toxic, 
                cardSource: this.GetCardSource());
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