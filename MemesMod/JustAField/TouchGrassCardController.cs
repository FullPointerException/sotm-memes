using System;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;

namespace Memes.DevStream
{
    public class TouchGrassCardController : CardController
    {
        public TouchGrassCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
        }

        public override IEnumerator Play()
        {
            //  Play the top card of the environment deck.
            var coroutine = this.GameController.PlayTopCardOfLocation(this.DecisionMaker, this.TurnTaker.Deck, cardSource: this.GetCardSource());

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
