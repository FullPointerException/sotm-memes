using System.Collections;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class RapidDeploymentCommonController : CardController
    {
        public RapidDeploymentCommonController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
            AddThisCardControllerToList(CardControllerListType.IncreasePhaseActionCount);
        }

        public override void AddTriggers()
        {
            // You may play an additional card each turn
            base.AddAdditionalPhaseActionTrigger((TurnTaker tt) => tt == this.TurnTaker, Phase.PlayCard, 1);
        }

        public override IEnumerator UsePower(int index = 0)
        {
            // Play a card
            var playRoutine = this.SelectAndPlayCardFromHand(this.HeroTurnTakerController, false);
            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(playRoutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(playRoutine);
            }
        }
    }
}