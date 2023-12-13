namespace RockVoyage
{
    public class CommonUIController : UIBaseParent
    {
        public override void Init(UIBaseParent parent, HouseInfo houseInfo)
        {
            base.Init(parent, houseInfo);
            foreach (var child in children)
            {
                child.Exit();
            }
        }
    }
}
