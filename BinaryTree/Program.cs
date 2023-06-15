class Test
{
    //Тест бинароного дерева
    public static void TestBinaryTree1()
    {
        Console.WriteLine("\n-------- Проверка бинарного дерева --------");
        BinaryTree<string> binaryTree = new BinaryTree<string>();
        binaryTree.Add(10, "efv");
        binaryTree.Add(15, "tge");
        binaryTree.Add(5, "ggg");
        binaryTree.Add(1, "asd");
        binaryTree.Add(7, "ert");
        binaryTree.Add(21, "jkg");
        Console.WriteLine("Корень = {0}", binaryTree.Root);
        binaryTree.View();
        Console.WriteLine("Сбалансированность дерева: {0}", binaryTree.IsBalanced());
        Console.WriteLine("\nМинимальный узел: {0}", binaryTree.NodeMin());
        Console.WriteLine("Максимальный узел: {0}", binaryTree.NodeMax());
        Console.WriteLine("\nУдаление по ключю 10:");
        binaryTree.DeleteNode(10);
        Console.WriteLine("Сбалансированность дерева: {0}", binaryTree.IsBalanced());
        binaryTree.View();
        Console.WriteLine("----------");
        Console.WriteLine("Добавим несколько узлов:");
        binaryTree.Add(4, "a");
        binaryTree.Add(3, "e");
        binaryTree.Add(1, "j");
        binaryTree.View();
        Console.WriteLine("Сбалансированность дерева: {0}", binaryTree.IsBalanced());
        Console.WriteLine("----------\nСбалансированное дерево:");
        binaryTree.BalanceTree();
        Console.WriteLine("Сбалансированность дерева: {0}", binaryTree.IsBalanced());
        binaryTree.View();
        Console.WriteLine("----------");
        binaryTree.PrintDepths();
        Console.WriteLine("----------");
        binaryTree.PrintTree();
        Console.WriteLine("----------");
        binaryTree.ViewFromMax();
        Console.WriteLine("----------");
        binaryTree.ViewFromMin();
    }
    // Тест на балансировку бинарного дерева
    public static void TestBinaryTree2()
    {
        Console.WriteLine("\n----- Проверка балансировки бинарного дерева -----");
        BinaryTree<string> binaryTree = new BinaryTree<string>();
        binaryTree.Add(20, "root");
        binaryTree.Add(10, "");
        binaryTree.Add(30, "");
        binaryTree.Add(23, "");
        binaryTree.Add(24, "");
        binaryTree.Add(25, "");
        binaryTree.Add(5, "");
        binaryTree.Add(8, "");
        binaryTree.Add(6, "");
        binaryTree.PrintTree();
        Console.WriteLine("Сбалансированность дерева: {0}", binaryTree.IsBalanced());
        Console.WriteLine("----------\nСбалансированное дерево:");
        binaryTree.BalanceTree();
        binaryTree.PrintTree();
        Console.WriteLine("Сбалансированность дерева: {0}", binaryTree.IsBalanced());
    }
    // Тест декартового дерева
    public static void TestTreapTree()
    {
        Console.WriteLine("\n-------- Проверка декартового дерева --------");
        TreapTree<string> tree = new TreapTree<string>();

        // Добавление узлов
        tree.Add(8, "1", 100);
        tree.Add(3, "2", 10);
        tree.Add(7, "3", 1);
        tree.Add(2, "4", 15);
        tree.Add(4, "5", 5);
        tree.Add(6, "6");
        tree.Add(8, "7", 12);

        // Вывод дерева
        Console.WriteLine("Декартово дерево:");
        tree.View1();

        // Поиск узла
        int keyToFind = 4;
        TreapNode<string> foundNode = tree.Find(keyToFind);
        if (foundNode != null)
            Console.WriteLine($"Найден узел с ключом {keyToFind}: {foundNode}");
        else
            Console.WriteLine($"Узел с ключом {keyToFind} не найден");

        // Удаление узла
        int keyToDelete = 7;
        tree.Delete(keyToDelete);
        Console.WriteLine($"Узел с ключом {keyToDelete} удален");

        // Вывод дерева после удаления
        Console.WriteLine("Декартово дерево после удаления:");
        tree.View1();
        Console.WriteLine("----------");
        tree.View2();
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Test.TestBinaryTree1();
        Test.TestBinaryTree2();
        Test.TestTreapTree();

        Console.ReadKey();
    }
}