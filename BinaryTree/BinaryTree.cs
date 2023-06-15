using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BinaryTree<T> where T : IComparable
{
    public Node<T> Root { get; private set; }

    public BinaryTree()
    {
        Root = null;
    }

    // Добавление узла в дерево
    public void Add(int key, T value)
    {
        if (Root == null)
        {
            Root = new Node<T>(key, value);
            return;
        }

        Node<T> currentNode = SearchPlace(key);

        if (currentNode.Key == key)
        {
            currentNode.Value = value;
        }
        else
        {
            Node<T> newNode = new Node<T>(key, value);
            if (key > currentNode.Key)
                currentNode.Right = newNode;
            else
                currentNode.Left = newNode;
            newNode.Parent = currentNode;
        }
    }

    // Поиск узла по ключу
    public Node<T> SearchByKey(int key)
    {
        Node<T> currentNode = Root;
        while (currentNode != null)
        {
            if (currentNode.Key == key)
                return currentNode;
            else if (key > currentNode.Key)
                currentNode = currentNode.Right;
            else
                currentNode = currentNode.Left;
        }
        return null;
    }

    private Node<T> SearchPlace(int key)
    {
        Node<T> currentNode = Root;
        while (true)
        {
            if (currentNode.Key == key)
                return currentNode;
            else if (key > currentNode.Key)
            {
                if (currentNode.Right != null)
                    currentNode = currentNode.Right;
                else
                    return currentNode;
            }
            else
            {
                if (currentNode.Left != null)
                    currentNode = currentNode.Left;
                else
                    return currentNode;
            }
        }
    }

    // Поиск узла с минимальным ключом
    public Node<T> NodeMin() => FindMin(Root);

    // Поиск узла с максимальным ключом
    public Node<T> NodeMax() => FindMax(Root);

    // Вывод дерева на экран
    public void View() => ViewTree(Root, 0);

    private void ViewTree(Node<T> currentNode, int level)
    {
        if (currentNode != null)
        {
            ViewTree(currentNode.Left, level + 1);
            Console.WriteLine(currentNode + " level=" + level);
            ViewTree(currentNode.Right, level + 1);
        }
    }

    // Вывод узлов дерева с указанием уровня
    public void PrintDepths() => PrintDepths(Root, 0);

    private void PrintDepths(Node<T> currentNode, int level)
    {
        if (currentNode != null)
        {
            Console.WriteLine(currentNode + " level=" + level);
            PrintDepths(currentNode.Left, level + 1);
            PrintDepths(currentNode.Right, level + 1);
        }
    }

    // Вывод дерева на экран с отступами для наглядности
    public void PrintTree() => PrintTree(Root, 0);

    private void PrintTree(Node<T> currentNode, int level)
    {
        if (currentNode == null)
        {
            return;
        }

        PrintTree(currentNode.Right, level + 1);
        Console.Write(new string(' ', level * 4));
        Console.WriteLine(currentNode);
        PrintTree(currentNode.Left, level + 1);
    }
    // Метод для просмотра дерева, начиная с минимального значения
    public void ViewFromMin()
    {
        Node<T> currentNode = FindMin(Root);
        while (Next(currentNode) != null)
        {
            Console.WriteLine(currentNode);
            currentNode = Next(currentNode);
        }
        Console.WriteLine(currentNode);
    }

    // Метод для просмотра дерева, начиная с максимального значения
    public void ViewFromMax()
    {
        Node<T> currentNode = FindMax(Root);
        while (Prev(currentNode) != null)
        {
            Console.WriteLine(currentNode);
            currentNode = Prev(currentNode);
        }
        Console.WriteLine(currentNode);
    }

    // Метод для получения следующего узла в порядке обхода
    public Node<T> Next(Node<T> t)
    {
        if (t != null)
        {
            if (t.Right != null)
                return FindMin(t.Right);

            Node<T> y = t.Parent;
            while (y != null && t == y.Right)
            {
                t = y;
                y = y.Parent;
            }
            return y;
        }
        return null;
    }

    // Метод для получения предыдущего узла в порядке обхода
    public Node<T> Prev(Node<T> node)
    {
        if (node != null)
        {
            if (node.Left != null)
                return FindMax(node.Left);

            Node<T> y = node.Parent;
            while (y != null && node == y.Left)
            {
                node = y;
                y = y.Parent;
            }
            return y;
        }
        return null;
    }

    // Метод для поиска узла с минимальным значением ключа, начиная с узла node
    public Node<T> FindMin(Node<T> node)
    {
        while (node.Left != null)
            node = node.Left;

        return node;
    }

    // Метод для поиска узла с максимальным значением ключа, начиная с узла node
    public Node<T> FindMax(Node<T> node)
    {
        while (node.Right != null)
            node = node.Right;

        return node;
    }

    // Удаление узла
    public void DeleteNode(int key)
    {
        Node<T> currentNode = SearchByKey(key);
        if (currentNode == null)
        {
            return;
        }

        // Удаляемый узел не имеет детей
        if (currentNode.Left == null && currentNode.Right == null)
        {
            // Удаляемый узел - корень дерева
            if (currentNode.Parent == null)
            {
                Root = null;
            }
            else
            {
                if (currentNode.Parent.Left == currentNode)
                    currentNode.Parent.Left = null;
                else
                    currentNode.Parent.Right = null;
            }
        }
        // Удаляемый узел имеет только одного ребенка
        else if (currentNode.Left == null || currentNode.Right == null)
        {
            Node<T> child = currentNode.Left ?? currentNode.Right;
            if (currentNode.Parent == null)
            {
                Root = child;
                child.Parent = null;
            }
            // Подключаем ребенка к родителю удаляемого узла
            else
            {
                if (currentNode.Parent.Left == currentNode)
                    currentNode.Parent.Left = child;
                else
                    currentNode.Parent.Right = child;
                child.Parent = currentNode.Parent;
            }
        }
        else
        {
            // Удаляемый узел имеет двух детей
            DeleteTwoChild(currentNode);
        }
    }

    // Балансировка дерева
    public void BalanceTree() => BalanceNodes(Root);

    // Балансировка с удалением
    private void DeleteTwoChild(Node<T> currentNode)
    {
        List<int> listKey = new List<int>();
        ListKeyNodes(currentNode, listKey);
        listKey.Remove(currentNode.Key);
        SortListKey(listKey);
        List<int> newListKey = BalanceList(listKey);

        BinaryTree<T> newTree = new BinaryTree<T>();
        foreach (int key in newListKey)
        {
            Node<T> tmp = SearchByKey(key);
            newTree.Add(tmp.Key, tmp.Value);
        }
        if (currentNode.Parent == null)
        {
            Root = newTree.Root;
        }
        else if (currentNode.Parent.Left == currentNode)
        {
            currentNode.Parent.Left = newTree.Root;
        }
        else if (currentNode.Parent.Right == currentNode)
        {
            currentNode.Parent.Right = newTree.Root;
        }
    }

    // Балансировка узла
    private void BalanceNodes(Node<T> currentNode)
    {
        List<int> listKey = new List<int>(); // Создаем список для хранения ключей
        ListKeyNodes(currentNode, listKey);
        SortListKey(listKey); // Вызываем функции для заполнения списка и его сортировки в порядке возрастания
        /* Создаем новый список и заполняем его ключами в таком порядке, 
         * чтобы при вызове ключей по порядку и заполнения дерева, дерево получалось сбалансированным*/
        List<int> newListKey = BalanceList(listKey);

        BinaryTree<T> newTree = new BinaryTree<T>();
        foreach (int key in newListKey)
        {
            Node<T> tmp = SearchByKey(key);
            newTree.Add(tmp.Key, tmp.Value);
        }
        // Вставка нового дерева в узел
        if (currentNode.Parent == null)
        {
            Root = newTree.Root;
        }
        else if (currentNode.Parent.Left == currentNode)
        {
            currentNode.Parent.Left = newTree.Root;
        }
        else if (currentNode.Parent.Right == currentNode)
        {
            currentNode.Parent.Right = newTree.Root;
        }
    }

    // Создание сбалансированного списка ключей
    private List<int> BalanceList(List<int> listKey)
    {
        // Создаем список и вставляем ключ из середины входящего списка
        List<int> newListKey = new List<int>();
        newListKey.Add(listKey[listKey.Count / 2]);
        listKey.RemoveAt(listKey.Count / 2);
        // Разбиение списка на 2 части - правую и левую
        List<int> listLeft = new List<int>();
        for (int i = 0; i < listKey.Count / 2; i++)
        {
            listLeft.Add(listKey[0]);
            listKey.RemoveAt(0);
        }
        // Выполняется сбалансировка ключей
        BalanceListKey(newListKey, listLeft, listKey);
        return newListKey;
    }

    // Сбалансирование ключей
    private void BalanceListKey(List<int> newListKey, List<int> listLeft, List<int> listRight)
    {
        // Если левый список не пустой, то вытаскиваем ключ и добавляем в сбалансированный список
        if (listLeft.Count > 0)
        {
            int n = listLeft.Count / 2;
            newListKey.Add(listLeft[n]);
            listLeft.RemoveAt(n);
        }
        // Если правый список не пустой, то вытаскиваем ключ и добавляем в сбалансированный список
        if (listRight.Count > 0)
        {
            int m = listRight.Count / 2;
            newListKey.Add(listRight[m]);
            listRight.RemoveAt(m);
        }
        // Пока списки правых и левых частей не пусты, будет выполнятся сбалансирование ключей
        if (listLeft.Count > 0 || listRight.Count > 0)
        {
            BalanceListKey(newListKey, listLeft, listRight);
        }
    }

    // Сортировка списка ключей
    private List<int> SortListKey(List<int> list)
    {
        int[] listKey = new int[list.Count];
        for (int i = 0; i < list.Count; i++)
        {
            listKey[i] = list[i];
        }
        Sort.MergeSort(listKey);
        for (int i = 0; i < listKey.Length; i++)
        {
            list[i] = listKey[i];
        }
        return list;
    }

    // Создает список ключей и заполняет его
    private void ListKeyNodes(Node<T> currentNode, List<int> listKey)
    {
        if (listKey == null)
        {
            listKey = new List<int>();
        }
        listKey.Add(currentNode.Key);
        if (currentNode.Right != null)
        {
            ListKeyNodes(currentNode.Right, listKey);
        }
        if (currentNode.Left != null)
        {
            ListKeyNodes(currentNode.Left, listKey);
        }
    }

    // Проверка сбалансированности дерева
    public bool IsBalanced() => CheckBalanceNode(Root);

    // Проверка сбалансированности узла
    private bool CheckBalanceNode(Node<T> currentNode)
    {
        // Если узел пуст, то узел сбалансированный
        if (currentNode == null)
            return true;
        // Вычисление правых и левых высот
        int heightLeft = GetHeight(currentNode.Left);
        int heightRight = GetHeight(currentNode.Right);
        // Вычисление разницы высот
        int heightDiff = Math.Abs(heightLeft - heightRight);
        // Если разница высот превышает 1, узел не сбалансированный
        if (heightDiff > 1)
            return false;

        return CheckBalanceNode(currentNode.Left) && CheckBalanceNode(currentNode.Right);
    }

    private int GetHeight(Node<T> node)
    {
        // Узел пуст, высота = 0
        if (node == null)
            return 0;

        // Вычисление правых и левых высот
        int heightLeft = GetHeight(node.Left);
        int heightRight = GetHeight(node.Right);

        return Math.Max(heightLeft, heightRight) + 1;
    }

    // Удаление дерева
    public void Clean()
    {
        Root = null;
    }

}
