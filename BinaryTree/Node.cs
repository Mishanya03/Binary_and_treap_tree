// Класс TreapNode представляет узел декартового дерева.
// Декартово дерево является комбинацией двух структур данных: двоичного дерева поиска и бинарной кучи.
// Он содержит ключ, значение и приоритет узла, а также ссылки на его левое и правое поддеревья.

class TreapNode<T> where T : IComparable
{
    public int Key { get; } // Ключ узла
    public T Value { get; } // Значение узла
    public int Priority { get; } // Приоритет узла
    public TreapNode<T> Left { get; set; } // Левое поддерево
    public TreapNode<T> Right { get; set; } // Правое поддерево

    public TreapNode(int key, T value, int priority)
    {
        Key = key;
        Value = value;
        Priority = priority;
    }

    // Переопределение метода ToString для удобного вывода информации об узле.
    public override string ToString()
    {
        // Формируем информацию о левом и правом поддереве.
        string leftNodeInfo = Left != null ? $"({Left.Key}:{Left.Priority})" : "null";
        string rightNodeInfo = Right != null ? $"({Right.Key}:{Right.Priority})" : "null";

        return $"({Key}:{Priority}) = {Value}, Left = {leftNodeInfo}, Right = {rightNodeInfo}";
    }

}

// Класс Node представляет узел обычного двоичного дерева.
// Он содержит ссылки на его левое, правое поддеревья и родительский узел,
// а также ключ и значение узла.

class Node<T>
{
    public Node<T> Left { get; set; } // Левое поддерево
    public Node<T> Right { get; set; } // Правое поддерево
    public Node<T> Parent { get; set; } // Родительский узел
    public T Value { get; set; } // Значение узла
    public int Key { get; set; } // Ключ узла

    public Node(int key, T value)
    {
        Key = key;
        Value = value;
        Left = null;
        Right = null;
        Parent = null;
    }

    public Node()
    {
        Key = 0;
        Value = default(T);
        Left = null;
        Right = null;
        Parent = null;
    }

    // Переопределение метода ToString для удобного вывода информации об узле.
    public override string ToString()
    {
        // Формируем строку с информацией о ключе и значении узла.
        string str = $"({Key}: {Value})";

        // Добавляем информацию о родительском узле, если он существует.
        if (Parent != null)
            str += $" parent={Parent.Key}";

        // Добавляем информацию о левом узле, если он существует.
        if (Left != null)
            str += $" left={Left.Key}";

        // Добавляем информацию о правом узле, если он существует.
        if (Right != null)
            str += $" right={Right.Key}";

        return str;
    }

}