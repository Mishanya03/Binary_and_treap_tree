using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Sort
{
    // Сортировка Merge
    public static void MergeSort<T>(T[] list) where T : IComparable
    {
        MergeSort(list, 0, list.Length - 1);
    }
    // Рекурсивный метод сортировки MergeSort
    private static void MergeSort<T>(T[] list, int left, int right) where T : IComparable
    {
        if (left < right)
        {
            int middle = (left + right) / 2;
            MergeSort(list, left, middle);          // Рекурсивный вызов MergeSort для левой половины массива
            MergeSort(list, middle + 1, right);     // Рекурсивный вызов MergeSort для правой половины массива
            Merge(list, left, middle, right);        // Слияние двух отсортированных половин массива
        }
    }

    // Метод слияния двух отсортированных половин массива
    private static void Merge<T>(T[] list, int left, int middle, int right) where T : IComparable
    {
        int lengthLeft = middle - left + 1;
        int lengthRight = right - middle;
        T[] leftArray = new T[lengthLeft];
        T[] rightArray = new T[lengthRight];
        Array.Copy(list, left, leftArray, 0, lengthLeft);               // Копирование левой половины во временный массив
        Array.Copy(list, middle + 1, rightArray, 0, lengthRight);       // Копирование правой половины во временный массив
        int i = 0;
        int j = 0;
        int k = left;
        while (i < lengthLeft && j < lengthRight)
        {
            if (leftArray[i].CompareTo(rightArray[j]) <= 0)             // Сравнение элементов левой и правой половин
            {
                list[k++] = leftArray[i++];                             // Присвоение меньшего элемента в исходный массив
            }
            else
            {
                list[k++] = rightArray[j++];
            }
        }
        while (i < lengthLeft)
        {
            list[k++] = leftArray[i++];                                 // Добавление оставшихся элементов левой половины в исходный массив
        }
        while (j < lengthRight)
        {
            list[k++] = rightArray[j++];                                // Добавление оставшихся элементов правой половины в исходный массив
        }
    }

}