using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class MultitaskingCommonController : CardController
    {
        public MultitaskingCommonController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
            AddThisCardControllerToList(CardControllerListType.IncreasePhaseActionCount);
        }

        public override void AddTriggers()
        {
            // You may use an additional power each turn
            base.AddAdditionalPhaseActionTrigger((TurnTaker tt) => tt == this.TurnTaker, Phase.UsePower, 1);
        }
    }
}