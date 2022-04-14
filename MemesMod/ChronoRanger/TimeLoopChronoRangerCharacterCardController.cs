using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;

namespace Memes.ChronoRanger
{
	public class TimeLoopChronoRangerCharacterCardController : HeroCharacterCardController
	{
		public TimeLoopChronoRangerCharacterCardController(Card card, TurnTakerController turnTakerController)
			: base(card, turnTakerController)
		{
		}

		public override IEnumerator UseIncapacitatedAbility(int index)
		{
			switch(index)
			{
				case 0:
					// One player may play a card.
					IEnumerator playCoroutine = this.SelectHeroToPlayCard(this.DecisionMaker);
					if(this.UseUnityCoroutines)
					{
						yield return this.GameController.StartCoroutine(playCoroutine);
					}
					else
					{
						this.GameController.ExhaustCoroutine(playCoroutine);
					}
					break;
				case 1:
					// One hero may use a power.
					IEnumerator powerCoroutine = this.GameController.SelectHeroToUsePower(this.DecisionMaker, cardSource: this.GetCardSource());
					if(this.UseUnityCoroutines)
					{
						yield return this.GameController.StartCoroutine(powerCoroutine);
					}
					else
					{
						this.GameController.ExhaustCoroutine(powerCoroutine);
					}
					break;
				case 2:
					// One player may draw a card.
					IEnumerator drawCoroutine = this.GameController.SelectHeroToDrawCard(this.DecisionMaker);
					if(this.UseUnityCoroutines)
					{
						yield return this.GameController.StartCoroutine(drawCoroutine);
					}
					else
					{
						this.GameController.ExhaustCoroutine(drawCoroutine);
					}
					break;
			}
		}

		public override IEnumerator UsePower(int index = 0)
		{
            // Play a card...
            var playRoutine = this.SelectAndPlayCardFromHand(this.HeroTurnTakerController, optional: false);
            if(this.UseUnityCoroutines)
			{
				yield return this.GameController.StartCoroutine(playRoutine);
			}
			else
			{
				this.GameController.ExhaustCoroutine(playRoutine);
			}

            // ... Use a power...
            var powerRoutine = this.SelectAndUsePower(this, optional: false);
            if (this.UseUnityCoroutines)
            {
                yield return this.GameController.StartCoroutine(powerRoutine);
            }
            else
            {
                this.GameController.ExhaustCoroutine(powerRoutine);
            }

            // ... Draw a card.
            var drawRoutine = this.DrawCard(this.HeroTurnTaker, optional: false);
            if (this.UseUnityCoroutines)
            {
                yield return this.GameController.StartCoroutine(drawRoutine);
            }
            else
            {
                this.GameController.ExhaustCoroutine(drawRoutine);
            }
        }
	}
}
