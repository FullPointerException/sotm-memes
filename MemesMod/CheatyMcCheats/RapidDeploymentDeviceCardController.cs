using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace Memes.CheatyMcCheats
{
    public class RapidDeploymentDeviceCardController : RapidDeploymentCommonController
    {
        public RapidDeploymentDeviceCardController(Card card, TurnTakerController turnTakerController)
            : base(card, turnTakerController)
        {
        }
    }
}