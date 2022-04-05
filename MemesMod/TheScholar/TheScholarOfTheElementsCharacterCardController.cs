using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;

namespace Memes.TheScholar
{
	public class TheScholarOfTheElementsCharacterCardController : HeroCharacterCardController
	{
		public TheScholarOfTheElementsCharacterCardController(Card card, TurnTakerController turnTakerController)
			: base(card, turnTakerController)
		{
		}

		public override IEnumerator UseIncapacitatedAbility(int index)
		{
			switch(index)
			{
				case 0:
					// One player may play a card.
					IEnumerator playCoroutine = SelectHeroToPlayCard(this.DecisionMaker);
					if(this.UseUnityCoroutines)
					{
						yield return this.GameController.StartCoroutine(playCoroutine);
					}
					else
					{
						this.GameController.ExhaustCoroutine(playCoroutine);
					}
					break;
				case 1:
					// One hero may use a power.
					IEnumerator powerCoroutine = this.GameController.SelectHeroToUsePower(this.DecisionMaker, cardSource: this.GetCardSource());
					if(this.UseUnityCoroutines)
					{
						yield return this.GameController.StartCoroutine(powerCoroutine);
					}
					else
					{
						this.GameController.ExhaustCoroutine(powerCoroutine);
					}
					break;
				case 2:
					// One player may draw a card.
					IEnumerator drawCoroutine = this.GameController.SelectHeroToDrawCard(this.DecisionMaker);
					if(this.UseUnityCoroutines)
					{
						yield return this.GameController.StartCoroutine(drawCoroutine);
					}
					else
					{
						this.GameController.ExhaustCoroutine(drawCoroutine);
					}
					break;
			}
		}

		public override IEnumerator UsePower(int index = 0)
		{
			// Deal 1 target 1 damage of each damage type.
			var numTargets = GetPowerNumeral(0, 1);
			var damageAmount = GetPowerNumeral(1, 1);

            /*List<DealDamageAction> damagesList = new List<DealDamageAction>() {
				new DealDamageAction(this.GetCardSource(), new DamageSource(this.GameController, this.Card), null, damageAmount, DamageType.Cold),
				new DealDamageAction(this.GetCardSource(), new DamageSource(this.GameController, this.Card), null, damageAmount, DamageType.Energy),
				new DealDamageAction(this.GetCardSource(), new DamageSource(this.GameController, this.Card), null, damageAmount, DamageType.Fire),
				new DealDamageAction(this.GetCardSource(), new DamageSource(this.GameController, this.Card), null, damageAmount, DamageType.Infernal),
				new DealDamageAction(this.GetCardSource(), new DamageSource(this.GameController, this.Card), null, damageAmount, DamageType.Lightning),
				new DealDamageAction(this.GetCardSource(), new DamageSource(this.GameController, this.Card), null, damageAmount, DamageType.Melee),
				new DealDamageAction(this.GetCardSource(), new DamageSource(this.GameController, this.Card), null, damageAmount, DamageType.Projectile),
				new DealDamageAction(this.GetCardSource(), new DamageSource(this.GameController, this.Card), null, damageAmount, DamageType.Psychic),
				new DealDamageAction(this.GetCardSource(), new DamageSource(this.GameController, this.Card), null, damageAmount, DamageType.Radiant),
				new DealDamageAction(this.GetCardSource(), new DamageSource(this.GameController, this.Card), null, damageAmount, DamageType.Sonic),
				new DealDamageAction(this.GetCardSource(), new DamageSource(this.GameController, this.Card), null, damageAmount, DamageType.Toxic)
			};

			Card target = null;

			IEnumerator damageCoroutine = this.GameController.DealMultipleInstancesOfDamage(damagesList, (Card c) => c == target), ;
			if(this.UseUnityCoroutines)
			{
				yield return this.GameController.StartCoroutine(coroutine);
			}
			else
			{
				this.GameController.ExhaustCoroutine(coroutine);
			}*/
            return this.DoNothing();
		}
	}
}
