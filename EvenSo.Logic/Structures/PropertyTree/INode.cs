using System.Xml.Linq;

namespace EvenSo.Logic.Structures.PropertyTree
{
    public interface INode<T> where T : INode<T>
    {
        T? Parent { get; }

        IEnumerable<T> Children { get; }

        IEnumerable<T> Branch 
        {
            get
            {
                INode<T>? node = this;
                do
                {
                    yield return (T)node;
                    node = node.Parent;
                } while (node is not null);
            }
        }
    }
}
