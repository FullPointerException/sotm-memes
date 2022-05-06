using System.Collections;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class TakeAnotherTurnCardController : CardController
    {
        public TakeAnotherTurnCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
        }

        public override IEnumerator Play()
        {
            // You may play a card...
            var playRoutine = this.SelectAndPlayCardFromHand(this.HeroTurnTakerController);
            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(playRoutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(playRoutine);
            }
            // ... You may use a power...
            var powerRoutine = this.SelectAndUsePower(this.CharacterCardController);
            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(powerRoutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(powerRoutine);
            }
            // ... You may draw a card
            var drawRoutine = this.DrawCard(this.HeroTurnTaker, true);
            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(drawRoutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(drawRoutine);
            }
        }
    }
}