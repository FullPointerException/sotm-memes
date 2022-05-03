using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class AuraMookCardController : CardController
    {
        public AuraMookCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
            base.AddThisCardControllerToList(CardControllerListType.MakesIndestructible);
        }

        // Hero ongoings in play are indestructible
        public override bool AskIfCardIsIndestructible(Card card)
        {
            return card.IsHero && card.IsOngoing && card.IsInPlayAndHasGameText;
        }
    }
}
