using System.Collections;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class CheatyMcCheatsCharacterCardController : CharacterCardController
    {
        public CheatyMcCheatsCharacterCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
        }

        public override IEnumerator UsePower(int index = 0)
        {
            // Play the top card of your deck...
            var playRoutine = this.GameController.PlayTopCard(this.HeroTurnTakerController, this.TurnTakerController, cardSource: this.GetCardSource());
            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(playRoutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(playRoutine);
            }

            // ... {CheatyMcCheats} gains 2 HP
            var hpToRestore = this.GetPowerNumeral(0, 2);
            var healRoutine = this.GameController.GainHP(this.Card, hpToRestore, cardSource: this.GetCardSource());
            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(healRoutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(healRoutine);
            }
        }

        public override IEnumerator UseIncapacitatedAbility(int index)
        {
            var heroes = new LinqTurnTakerCriteria((TurnTaker turnTaker) => turnTaker.IsHero && !turnTaker.IsIncapacitatedOrOutOfGame && this.GameController.IsTurnTakerVisibleToCardSource(turnTaker, this.GetCardSource()));
            switch (index)
            {

                case 0:
                    {
                        // Each player may play a card
                        var playCardsDecision = new SelectTurnTakersDecision(this.GameController, this.DecisionMaker, heroes, SelectionType.PlayCard, allowAutoDecide: true, cardSource: this.GetCardSource());
                        var playRoutine = this.GameController.SelectTurnTakersAndDoAction(
                            playCardsDecision,
                            (turnTaker) => this.GameController.SelectAndPlayCardFromHand(this.FindHeroTurnTakerController(turnTaker.ToHero()), true, cardSource: this.GetCardSource()));
                        if (base.UseUnityCoroutines)
                        {
                            yield return base.GameController.StartCoroutine(playRoutine);
                        }
                        else
                        {
                            base.GameController.ExhaustCoroutine(playRoutine);
                        }
                        break;
                    }
                case 1:
                    {
                        // Each hero may use a power
                        var usePowerDecision = new SelectTurnTakersDecision(this.GameController, this.DecisionMaker, heroes, SelectionType.UsePower, allowAutoDecide: true, cardSource: this.GetCardSource());
                        var usePowerRoutine = this.GameController.SelectTurnTakersAndDoAction(
                            usePowerDecision,
                            (turnTaker) => this.GameController.SelectAndUsePower(this.FindHeroTurnTakerController(turnTaker.ToHero()), true, cardSource: this.GetCardSource()));
                        if (base.UseUnityCoroutines)
                        {
                            yield return base.GameController.StartCoroutine(usePowerRoutine);
                        }
                        else
                        {
                            base.GameController.ExhaustCoroutine(usePowerRoutine);
                        }
                        break;
                    }
                case 2:
                    {
                        // Revive a hero and restore them to 1 HP.
                        break;
                        // TODO
                    }
            }
        }
    }
}