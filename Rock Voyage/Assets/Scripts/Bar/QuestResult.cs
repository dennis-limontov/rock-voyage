namespace RockVoyage
{
    public class QuestResult : UIActiveOneChild
    {
        public override void Dispose()
        {
            BarEvents.OnBeerQuestEndedWithResult -= BeerQuestEndedWithResultHandler;
            base.Dispose();
        }

        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            BarEvents.OnBeerQuestEndedWithResult += BeerQuestEndedWithResultHandler;
        }

        private void BeerQuestEndedWithResultHandler(bool result)
        {
            if (result)
            {
                GoToNext();
            }
        }
    }
}