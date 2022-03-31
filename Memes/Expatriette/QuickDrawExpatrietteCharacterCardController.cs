using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;

namespace Memes.Expatriette
{
	public class QuickDrawExpatrietteCharacterCardController : HeroCharacterCardController
	{
		public QuickDrawExpatrietteCharacterCardController(Card card, TurnTakerController turnTakerController)
			: base(card, turnTakerController)
		{
		}

		public overried IEnumerator UseIncapacitatedAbility(int index)
		{
			switch(index)
			{
				case 0:
					// One player may play a card.
					IEnumerator playCoroutine = SelectHeroToPlayCard(this.DecisionMaker);
					if(this.UseUnityCoroutines)
					{
						yield return this.GameController.StartCoroutine(coroutine);
					}
					else
					{
						this.GameController.ExhaustCoroutine(coroutine);
					}
					break;
				case 1:
					// One hero may use a power.
					IEnumerator powerCoroutine = SelectHeroToUsePower(this.DecisionMaker, cardSource: this.GetCardSource());
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
					IEnumerator drawCoroutine = SelectHeroToDrawCard(this.DecisionMaker);
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
			// Put ammo cards from you hand and discard pile into play. Use a power"
			MoveCardDestination playArea = new MoveCardDestination(this.HeroTurnTaker.PlayArea);
			IEnumerable<Card> allAmmo = FindCardsWhere(new LinqCardCriterial((Card c) => c.Owner == this.TurnTaker && c.IsAmmo && (c.IsInTrash || c.IsInHand)))

			IEnumerator moveCoroutine = this.GameController.MoveCards(this.TurnTakerController, allAmmo, (Card c) => playArea, false, true, false);
			if(this.UseUnityCoroutines)
			{
				yield return this.GameController.StartCoroutine(moveCoroutine);
			}
			else
			{
				this.GameController.ExhaustCoroutine(moveCoroutine);
			}

			IEnumerator powerCoroutine = this.GameController.SelectAndUsePower(base.HeroTurnTakerController, cardSource: this.GetCardSource());
			if(this.UseUnityCoroutines)
			{
				yield return this.GameController.StartCoroutine(powerCoroutine);
			}
			else
			{
				this.GameController.ExhaustCoroutine(powerCoroutine);
			}
		}
	}
}
