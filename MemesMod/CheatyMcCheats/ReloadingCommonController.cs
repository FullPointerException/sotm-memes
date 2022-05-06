using System.Collections;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class ReloadingCommonController : CardController
    {
        public ReloadingCommonController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
            AddThisCardControllerToList(CardControllerListType.IncreasePhaseActionCount);
        }

        public override void AddTriggers()
        {
            // You may draw an additional card each turn
            base.AddAdditionalPhaseActionTrigger((TurnTaker tt) => tt == this.TurnTaker, Phase.DrawCard, 1);
        }

        public override IEnumerator UsePower(int index = 0)
        {
            // Draw a card
            var drawRoutine = this.DrawCard(this.HeroTurnTaker);
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