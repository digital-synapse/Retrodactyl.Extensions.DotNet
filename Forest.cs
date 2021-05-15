using System;
using System.Collections.Generic;
using System.Text;

namespace Retrodactyl.Extensions.DotNet
{
    public class Forest<T>
    {
        public Forest()
        {
            Root = new Node();
            Floor = Root.Children;
        }

        public List<Node> Floor { get; private set; }
        public Node Root { get; private set; }

        public class Node
        {
            public Node(T value = default(T), Node parent = null)
            {
                Value = value;
                Children = new List<Node>();
                Parent = parent;
            }
            public T Value { get; private set; }

            public Node Parent { get; private set; }
            public List<Node> Children { get; private set; }

            public Node AddChild(T value)
            {
                var child = new Node(value, this);
                Children.Add(child);
                return child;
            }
        }
    }
}
