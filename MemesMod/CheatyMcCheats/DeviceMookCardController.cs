using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class DeviceMookCardController: CardController
    {
        public DeviceMookCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
            base.AddThisCardControllerToList(CardControllerListType.MakesIndestructible);
        }

        // Hero equipments in play are indestructible
        public override bool AskIfCardIsIndestructible(Card card)
        {
            return card.IsHero && this.IsEquipment(card) && card.IsInPlayAndHasGameText;
        }
    }
}