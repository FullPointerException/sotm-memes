using System;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;

namespace Memes.DevStream
{
    public class FertilizerCardController: CardController
    {
        public FertilizerCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
        }

        /*public override IEnumerator Play()
        {
            //  Put all Grass cards from the environment trash into play.
            var coroutine = this.GameController.MoveCards(
                this.DecisionMaker,
                new LinqCardCriteria((Card c) => c.DoKeywordsContain("grass") && c.IsInTrash && c.IsEnvironment),
                new Func<Card, Location>((Card c) => this.TurnTaker.PlayArea),
                autoDecide: true,
                moveCardDisplay: MoveCardDisplay.OnlyIfNoMatches,
                cardSource: this.GetCardSource());

            if (this.UseUnityCoroutines)
            {
                yield return this.GameController.StartCoroutine(coroutine);
            }
            else
            {
                this.GameController.ExhaustCoroutine(coroutine);
            }
        }*/
    }
}
