using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;

namespace Memes.MrFixer
{
	public class OnePunchMrFixerCharacterCardController : HeroCharacterCardController
	{
		public OnePunchMrFixerCharacterCardController(Card card, TurnTakerController turnTakerController)
			: base(card, turnTakerController)
		{
		}

		public overried IEnumerator UseIncapacitatedAbility(int index)
		{
			switch(index)
			{
				case 0:
					// One player may play a card.
					IEnumerator playCoroutine = SelectHeroToPlayCard(this.DecisionMaker);
					if(this.UseUnityCoroutines)
					{
						yield return this.GameController.StartCoroutine(coroutine);
					}
					else
					{
						this.GameController.ExhaustCoroutine(coroutine);
					}
					break;
				case 1:
					// One hero may use a power.
					IEnumerator powerCoroutine = SelectHeroToUsePower(this.DecisionMaker, cardSource: this.GetCardSource());
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
					IEnumerator drawCoroutine = SelectHeroToDrawCard(this.DecisionMaker);
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
			// {MrFixerCharacter} deals 1 target 999 melee amage.
			var numTargets = GetPowerNumeral(0, 1);
			var damageAmount = GetPowerNuemral(1, 999);

			IEnumerator coroutine = this.GameController.SelectTargetsAndDealDamage(
					this.DecisionMaker,
					new DamageSource(this.GameController, this.Card),
					damageAmount,
					DamageType.Melee,
					numTargets,
					false,
					numTargets,
					cardSource: GetCardSource());
			if(this.UseUnityCoroutines)
			{
				yield return this.GameController.StartCoroutine(coroutine);
			}
			else
			{
				this.GameController.ExhaustCoroutine(coroutine);
			}
		}
	}
}
