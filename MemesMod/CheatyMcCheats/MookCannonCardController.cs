using System.Collections;
using System.Linq;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class MookCannonCardController : CardController
    {
        public MookCannonCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
        }

        public override IEnumerator UsePower(int index = 0)
        {
            // {CheatyMcCheats} deals 1 target X energy damage, where X is the number of hero non-character targets in play.
            var numTargets = GetPowerNumeral(0, 1);
            var damageAmount = this.FindCardsWhere(new LinqCardCriteria((Card c) => c.IsInPlayAndHasGameText && c.IsHero && c.IsTarget && !c.IsCharacter)).Count();
            var damageRoutine = this.GameController.SelectTargetsAndDealDamage(
                this.HeroTurnTakerController,
                new DamageSource(this.GameController, this.CharacterCard),
                damageAmount,
                DamageType.Energy,
                1,
                false,
                1,
                cardSource: this.GetCardSource());
            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(damageRoutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(damageRoutine);
            }

            // ... {MookCannon} Deals each hero non-character target X energy damage.
            var recoilRoutine = this.GameController.DealDamage(
                this.HeroTurnTakerController,
                this.Card, 
                (Card c) => c.IsInPlayAndHasGameText && c.IsHero && c.IsTarget && !c.IsCharacter, 
                damageAmount, 
                DamageType.Energy, 
                cardSource: this.GetCardSource());
            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(recoilRoutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(recoilRoutine);
            }
        }
    }
}