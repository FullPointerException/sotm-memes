using System.Collections;
using System.Linq;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class AuraBurstCardController: CardController 
    {
        public AuraBurstCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
            SpecialStringMaker.ShowNumberOfCardsInPlay(new LinqCardCriteria((Card c) => (c.IsHero && c.IsOngoing)));
        }

        public override IEnumerator UsePower(int index = 0)
        {
            //{CheatyMcCheats} deals 1 target X energy damage, where X is the number of hero ongoing cards play...
            var numberOfTargets = this.GetPowerNumeral(0, 1);
            var allHeroOngoings = new LinqCardCriteria(new LinqCardCriteria((Card c) => (c.IsHero && c.IsOngoing && c.IsInPlayAndHasGameText)));
            var damageAmount = this.FindCardsWhere(allHeroOngoings).Count();
            var damageRoutine = this.GameController.SelectTargetsAndDealDamage(
                this.DecisionMaker,
                new DamageSource(this.GameController, this.CharacterCard),
                damageAmount,
                DamageType.Energy, 
                numberOfTargets, 
                false, 
                numberOfTargets, 
                cardSource: this.GetCardSource());
            if (this.UseUnityCoroutines)
            {
                yield return this.GameController.StartCoroutine(damageRoutine);
            }
            else
            {
                this.GameController.ExhaustCoroutine(damageRoutine);
            }

            //...Destroy all hero ongoing cards.
            var destroyRoutine = this.GameController.DestroyCards(this.DecisionMaker, allHeroOngoings);
            if (this.UseUnityCoroutines)
            {
                yield return this.GameController.StartCoroutine(destroyRoutine);
            }
            else
            {
                this.GameController.ExhaustCoroutine(destroyRoutine);
            }
        }
    }
}
