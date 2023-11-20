using System;
using System.Linq;

namespace RockVoyage
{
    public class UIActiveOneChild : UIBaseParent
    {
        protected int _currentIndex = -1;
        protected UIBase CurrentElement
            => (_currentIndex == -1) ? null : children[_currentIndex];

        public override void Enter()
        {
            base.Enter();
            GoToFirst();
        }

        public override void Exit()
        {
            CurrentElement?.Exit();
            base.Exit();
        }

        public override void Init(UIBaseParent parent = null)
        {
            base.Init(parent);
            foreach (var child in children)
            {
                child.Init(this);
                child.Exit();
            }
        }

        public virtual void GoTo(int index)
        {
            CurrentElement?.Exit();
            _currentIndex = index;
            CurrentElement.Enter();
        }

        public virtual void GoTo(string name)
        {
            GoTo(children.First(x => x.name.Equals(name)));
        }

        public virtual void GoTo(UIBase element)
        {
            GoTo(Array.IndexOf(children, element));
        }

        public virtual void GoToFirst()
        {
            GoTo(0);
        }

        public virtual void GoToNext()
        {
            GoTo(_currentIndex + 1);
        }

        public virtual void GoToPrevious()
        {
            GoTo(_currentIndex - 1);
        }
    }
}