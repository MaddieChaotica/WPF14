using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFLab14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Method to perform Quick Sort on an array
        private static void Quick_Sort(int[] arr, int left, int right)
        {
            // Check if there are elements to sort
            if (left < right)
            {
                // Find the pivot index
                int pivot = Partition(arr, left, right);

                // Recursively sort elements on the left and right of the pivot
                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }
        }

        // Method to partition the array
        private static int Partition(int[] arr, int left, int right)
        {
            // Select the pivot element
            int pivot = arr[left];

            // Continue until left and right pointers meet
            while (true)
            {
                // Move left pointer until a value greater than or equal to pivot is found
                while (arr[left] < pivot)
                {
                    left++;
                }

                // Move right pointer until a value less than or equal to pivot is found
                while (arr[right] > pivot)
                {
                    right--;
                }

                // If left pointer is still smaller than right pointer, swap elements
                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    // Return the right pointer indicating the partitioning position
                    return right;
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public List<int> GetNums()
        {
            List<int> list = new List<int>();

            String nums = ara.Text;

            string[] split = nums.Split();
            foreach (var s in split)
            {
                list.Add(int.Parse(s));
            }
            

            return list;
        } 

        private void bubbleSort_Click(object sender, RoutedEventArgs e)
        {
            List<int> ints = new List<int>();
            ints = GetNums();
            int t;
            for (int p = 0; p <= ints.Count - 2; p++) // Outer loop for passes
            {
                for (int i = 0; i <= ints.Count - 2; i++) // Inner loop for comparison and swapping
                {
                    if (ints[i] > ints[i + 1]) // Checking if the current element is greater than the next element
                    {
                        t = ints[i + 1]; // Swapping elements if they are in the wrong order
                        ints[i + 1] = ints[i];
                        ints[i] = t;
                    }
                }
            }
            ara.Clear();
            for (int i = 0; i < ints.Count; i++)
            {
                ara.Text = ara.Text + ints[i] + ' ';
            }
        }

        private void binarySort_Click(object sender, RoutedEventArgs e)
        {

            List<int> ints = new List<int>();
            ints = GetNums();

            int[] array = ints.ToArray();

            for (int i = 1; i < array.Length; i++)
            {
                int x = array[i];

                // Find location to insert using
                // binary search
                int j = Math.Abs(
                    Array.BinarySearch(array,
                                       0, i, x) + 1);

                // Shifting array to one location right
                System.Array.Copy(array, j,
                                  array, j + 1,
                                  i - j);

                // Placing element at its correct
                // location
                array[j] = x;
            }
            ara.Clear();
            for (int i = 0; i < array.Length; i++)
            {
                ara.Text = ara.Text + array[i] + ' ';
            }
        }

        private void quickSort_Click(object sender, RoutedEventArgs e)
        {
            ;
            int[] array = GetNums().ToArray();

            Quick_Sort(array, 0, array.Length-1);

            ara.Clear();

            for (int i = 0; i < array.Length; i++)
            {
                ara.Text = ara.Text + array[i] + ' ';
            }

        }

        private void binarySearch_Click(object sender, RoutedEventArgs e)
        {
            List<int> ints = new List<int>();
            ints = GetNums();

            int key = int.Parse(searchedFor.Text);

            int index = (ints.BinarySearch(key));

            string fuckthis = index.ToString();

             ara.Clear();
            for (int i = 0; i < ints.Count; i++)
            {
                ara.Text = ara.Text + ints[i] + ' ';
            }
            MessageBox.Show("Index of search element = " + fuckthis);
        }
    }
}
