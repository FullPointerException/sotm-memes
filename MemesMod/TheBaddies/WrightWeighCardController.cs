using System;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;

namespace Memes.TheBaddies
{
    public class WrightWeighCardController : CardController
    {
        public WrightWeighCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
        }

        public override void AddTriggers()
        {
            // At the end of the villain turn, each villain target regains H HP.
            AddEndOfTurnTrigger(tt => tt == this.TurnTaker, p => this.GameController.GainHP(this.DecisionMaker, card => card.IsVillainTarget, H, cardSource: GetCardSource()), TriggerType.GainHP);
        }
    }
}
