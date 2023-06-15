using System;

class TreapTree<T> where T : IComparable
{
    private TreapNode<T> root;   // Корень дерева
    private Random random;   // Генератор случайных чисел

    public TreapTree()
    {
        random = new Random();
    }

    // Добавление узла в дерево
    public void Add(int key, T value)
    {
        int priority = random.Next();
        TreapNode<T> newNode = new TreapNode<T>(key, value, priority);

        if (root == null)
        {
            root = newNode;
            return;
        }

        Split(root, key, out TreapNode<T> left, out TreapNode<T> right);
        newNode.Left = left;
        newNode.Right = right;
        root = newNode;
    }

    public void Add(int key, T value, int priority)
    {
        TreapNode<T> newNode = new TreapNode<T>(key, value, priority);

        if (root == null)
        {
            root = newNode;
            return;
        }

        Split(root, key, out TreapNode<T> left, out TreapNode<T> right);
        newNode.Left = left;
        newNode.Right = right;
        root = newNode;
    }

    // Удаление узла из дерева
    public void Delete(int key)
    {
        root = Delete(root, key);
    }

    // Поиск узла по ключу
    public TreapNode<T> Find(int key)
    {
        return FindNode(root, key);
    }

    // Рекурсивное удаление узла из дерева
    private TreapNode<T> Delete(TreapNode<T> node, int key)
    {
        if (node == null)
            return null;

        if (key < node.Key)
        {
            node.Left = Delete(node.Left, key);
            return node;
        }
        else if (key > node.Key)
        {
            node.Right = Delete(node.Right, key);
            return node;
        }

        return Merge(node.Left, node.Right);
    }

    // Рекурсивный поиск узла по ключу
    private TreapNode<T> FindNode(TreapNode<T> node, int key)
    {
        if (node == null || node.Key == key)
            return node;

        if (key < node.Key)
            return FindNode(node.Left, key);
        else
            return FindNode(node.Right, key);
    }

    // Разделение дерева по ключу
    private void Split(TreapNode<T> node, int key, out TreapNode<T> left, out TreapNode<T> right)
    {
        if (node == null)
        {
            left = null;
            right = null;
        }
        else if (key < node.Key)
        {
            Split(node.Left, key, out left, out TreapNode<T> tempRight);
            right = node;
            right.Left = tempRight;
        }
        else
        {
            Split(node.Right, key, out TreapNode<T> tempLeft, out right);
            left = node;
            left.Right = tempLeft;
        }
    }

    // Слияние двух деревьев
    private TreapNode<T> Merge(TreapNode<T> left, TreapNode<T> right)
    {
        if (left == null)
            return right;
        if (right == null)
            return left;

        if (left.Priority > right.Priority)
        {
            left.Right = Merge(left.Right, right);
            return left;
        }
        else
        {
            right.Left = Merge(left, right.Left);
            return right;
        }
    }

    // Вывод дерева в горизонтальной форме
    public void View1() => PrintTree1(root, "");

    private void PrintTree1(TreapNode<T> node, string indent, bool last = true)
    {
        if (node != null)
        {
            Console.Write(indent);
            Console.Write(last ? "└──" : "├──");
            Console.WriteLine(node);

            indent += last ? "    " : "│   ";
            PrintTree1(node.Left, indent, node.Right == null);
            PrintTree1(node.Right, indent);
        }
    }

    // Вывод дерева в вертикальной форме
    public void View2() => PrintTree2(root, "");

    private void PrintTree2(TreapNode<T> node, string indent, bool last = true)
    {
        if (node != null)
        {
            Console.Write(indent);
            Console.Write(last ? "└─" : "├─");
            Console.WriteLine(node);

            indent += last ? "   " : "│  ";
            PrintTree2(node.Right, indent, false);
            PrintTree2(node.Left, indent);
        }
    }
}
