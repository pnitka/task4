using System;
using System.Collections.Generic;

class Program
{
    // 11
    public static bool FindPath(int[,] maze, int x, int y, List<(int, int)> path)
    {
        if (x < 0 || y < 0 || x >= maze.GetLength(0) || y >= maze.GetLength(1) || maze[x, y] == 1)
            return false;

        if (path.Contains((x, y))) 
            return false;

        path.Add((x, y));

        if (maze[x, y] == 2)
            return true;

        // Рекурсивные вызовы для движения в четырех направлениях
        if (FindPath(maze, x + 1, y, path) || 
            FindPath(maze, x - 1, y, path) || 
            FindPath(maze, x, y + 1, path) || 
            FindPath(maze, x, y - 1, path))
            return true;

        path.Remove((x, y)); // Удаляем клетку из пути, если она не приводит к цели
        return false;
    }

    // 12
    public static int[] QuickSort(int[] arr)
    {
        if (arr.Length <= 1)
            return arr;

        int pivot = arr[arr.Length / 2];
        var left = Array.FindAll(arr, x => x < pivot);
        var middle = Array.FindAll(arr, x => x == pivot);
        var right = Array.FindAll(arr, x => x > pivot);

        return QuickSort(left).Concat(middle).Concat(QuickSort(right)).ToArray();
    }

    // 13
    public class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public static int FindMinimum(TreeNode node)
    {
        if (node.Left == null)
            return node.Value;
        return FindMinimum(node.Left);
    }

    // 14
    public static int BinarySearch(int[] arr, int target, int left, int right)
    {
        if (left > right)
            return -1; 

        int mid = (left + right) / 2;

        if (arr[mid] == target)
            return mid;
        else if (arr[mid] < target)
            return BinarySearch(arr, target, mid + 1, right);
        else
            return BinarySearch(arr, target, left, mid - 1);
    }

    // 15
    public static void InorderTraversal(TreeNode node)
    {
        if (node != null)
        {
            InorderTraversal(node.Left);
            Console.Write(node.Value + " ");
            InorderTraversal(node.Right);
        }
    }

    static void Main(string[] args)
    {
        int[,] maze = {
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 0 },
            { 0, 0, 0, 1, 2 },
            { 0, 1, 0, 0, 0 }
        };
        List<(int, int)> path = new List<(int, int)>();
        if (FindPath(maze, 0, 0, path))
        {
            Console.WriteLine("Path found:");
            foreach (var step in path)
                Console.WriteLine(step);
        }
        else
        {
            Console.WriteLine("No path found.");
        }

        int[] arr = { 3, 6, 8, 10, 1, 2, 1 };
        Console.WriteLine("Sorted array: " + string.Join(", ", QuickSort(arr)));

        TreeNode root = new TreeNode(5);
        root.Left = new TreeNode(3);
        root.Right = new TreeNode(7);
        root.Left.Left = new TreeNode(2);
        root.Left.Right = new TreeNode(4);
        Console.WriteLine("Minimum element in BST: " + FindMinimum(root));

        int target = 10;
        int index = BinarySearch(arr, target, 0, arr.Length - 1);
        Console.WriteLine("Index of " + target + ": " + index);

        Console.WriteLine("Inorder Traversal of BST:");
        InorderTraversal(root);
    }
}
