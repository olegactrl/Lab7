using System;
using System.Collections.Generic;

namespace Lab7_4_
{
    public class TaskScheduler<TTask, TPriority>
    {
        public delegate void TaskExecution(TTask task);

        private class TaskWithPriority
        {
            public TTask Task { get; set; }
            public TPriority Priority { get; set; }
        }

        private readonly PriorityQueue<TaskWithPriority> taskQueue;
        private readonly TaskExecution taskExecutor;

        public TaskScheduler(TaskExecution executor)
        {
            taskQueue = new PriorityQueue<TaskWithPriority>();
            taskExecutor = executor;
        }

        public void AddTask(TTask task, Func<TTask, TPriority> prioritySelector)
        {
            var taskWithPriority = new TaskWithPriority
            {
                Task = task,
                Priority = prioritySelector(task)
            };

            taskQueue.Enqueue(taskWithPriority, taskWithPriority.Priority);
        }

        public void ExecuteNext()
        {
            if (taskQueue.Count > 0)
            {
                var taskWithPriority = taskQueue.Dequeue();
                taskExecutor(taskWithPriority.Task);
            }
            else
            {
                Console.WriteLine("No tasks in the queue.");
            }
        }
    }

    // Priority Queue implementation (Min Heap)
    public class PriorityQueue<T>
    {
        private readonly List<T> heap;
        private readonly Dictionary<T, int> indexDict;
        private readonly IComparer<T> comparer;

        public int Count => heap.Count;

        public PriorityQueue(IComparer<T> comparer = null)
        {
            this.heap = new List<T>();
            this.indexDict = new Dictionary<T, int>();
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public void Enqueue(T item, TPriority priority)
        {
            heap.Add(item);
            indexDict[item] = heap.Count - 1;
            HeapifyUp(heap.Count - 1);
        }

        public T Dequeue()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Queue is empty.");

            T item = heap[0];
            Swap(0, heap.Count - 1);
            heap.RemoveAt(heap.Count - 1);
            indexDict.Remove(item);
            HeapifyDown(0);

            return item;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (IsHigherPriority(heap[parent], heap[index]))
                    break;

                Swap(parent, index);
                index = parent;
            }
        }

        private void HeapifyDown(int index)
        {
            int leftChild, rightChild, highestPriority;

            while (true)
            {
                leftChild = 2 * index + 1;
                rightChild = 2 * index + 2;
                highestPriority = index;

                if (leftChild < heap.Count && IsHigherPriority(heap[leftChild], heap[highestPriority]))
                    highestPriority = leftChild;

                if (rightChild < heap.Count && IsHigherPriority(heap[rightChild], heap[highestPriority]))
                    highestPriority = rightChild;

                if (highestPriority == index)
                    break;

                Swap(index, highestPriority);
                index = highestPriority;
            }
        }

        private void Swap(int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;

            indexDict[heap[i]] = i;
            indexDict[heap[j]] = j;
        }

        private bool IsHigherPriority(T a, T b)
        {
            return comparer.Compare(a, b) > 0;
        }
    }
}
