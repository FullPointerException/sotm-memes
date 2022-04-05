using System;
using Handelabra;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;

namespace Memes.JustAField
{
	public class VeryTallGrassCardController: CardController
	{
		public VeryTallGrassCardController(Card card, TurnTakerController turnTakerController)
			: base(card, turnTakerController)
		{
		}

		public override void AddTriggers()
		{
			// When this card is destroyed, play a Tall Grass from the environment trash.
			this.AddWhenDestroyedTrigger(new Func<DestroyCardAction, IEnumerator>(this.OnDestroyResponse), TriggerType.PlayCard);
		}

		private IEnumerator OnDestroyResponse(DestroyCardAction dca)
		{
            // Play a Tall Grass from the environment trash.
            var environmentPlayArea = new MoveCardDestination(this.TurnTaker.PlayArea);
            var coroutine = this.GameController.SelectCardsFromLocationAndMoveThem(
                this.DecisionMaker,
                this.TurnTaker.Trash,
                1,
                1,
                new LinqCardCriteria((Card c) => c.Identifier == "TallGrass" && c.IsInTrash),
                environmentPlayArea.ToEnumerable<MoveCardDestination>(),
                isPutIntoPlay: false,
                playIfMovingToPlayArea: true,
                shuffleAfterwards: false,
                optional: false,
                autoDecideCard: true,
                allowAutoDecide: true,
                selectionType: SelectionType.MoveCardToPlayArea,
                cardSource: this.GetCardSource());

            if (this.UseUnityCoroutines)
            {
                yield return this.GameController.StartCoroutine(coroutine);
            }
            else
            {
                this.GameController.ExhaustCoroutine(coroutine);
            }
        }
	}
}