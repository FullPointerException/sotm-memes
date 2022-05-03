using System.Collections;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class HealingCardController : CardController
    {
        public HealingCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
        }

        public override void AddTriggers()
        {
            // At the end of your turn, each hero target gains 1 HP
            base.AddEndOfTurnTrigger((TurnTaker turnTaker) => turnTaker == this.TurnTaker, AllHeroTargetsGainHP, TriggerType.GainHP);
        }

        public override IEnumerator UsePower(int index = 0)
        {
            // Each hero target gains 1 HP
            var healAmount = this.GetPowerNumeral(0, 1);
            var healRoutine = this.GameController.GainHP(this.HeroTurnTakerController, (Card c) => c.IsTarget && c.IsInPlayAndHasGameText && c.IsHero, healAmount, cardSource: this.GetCardSource());
            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(healRoutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(healRoutine);
            }
        }

        private IEnumerator AllHeroTargetsGainHP(PhaseChangeAction phaseChangeAction)
        {
            var healRoutine = this.GameController.GainHP(this.HeroTurnTakerController, (Card c) => c.IsTarget && c.IsInPlayAndHasGameText && c.IsHero, 1, cardSource: this.GetCardSource());
            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(healRoutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(healRoutine);
            }
        }
    }
}