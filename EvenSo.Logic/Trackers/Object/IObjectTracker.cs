using EvenSo.Logic.Model.Event;
using EvenSo.Logic.Structures.Tree;

namespace EvenSo.Logic.Trackers
{
    internal interface IObjectTracker
    {
        void Track(object item);

        bool UnTrack(object item);

        IPropertyTree GetPropertyTree(object item);
    }
}
