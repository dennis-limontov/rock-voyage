namespace RockVoyage
{
    public class UIActiveAllChildren : UIBaseParent
    {
        public override void Enter()
        {
            base.Enter();
            foreach (var child in children)
            {
                child.Enter();
            }
        }

        public override void Exit()
        {
            foreach (var child in children)
            {
                child.Exit();
            }
            base.Exit();
        }

        public override void Init(UIBaseParent parent = null)
        {
            base.Init(parent);
            foreach (var child in children)
            {
                child.Init(this);
            }
        }
    }
}