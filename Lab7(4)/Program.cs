namespace Lab7_4_
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Example usage
            TaskScheduler<string, int> scheduler = new TaskScheduler<string, int>(ExecuteTask);

            while (true)
            {
                Console.WriteLine("Enter a task (or 'exit' to quit):");
                string task = Console.ReadLine();

                if (task.ToLower() == "exit")
                    break;

                Console.WriteLine("Enter the priority of the task:");
                if (int.TryParse(Console.ReadLine(), out int priority))
                {
                    scheduler.AddTask(task, t => priority);
                }
                else
                {
                    Console.WriteLine("Invalid priority. Please enter a valid integer.");
                }
            }

            // Execute tasks until the queue is empty
            while (scheduler.Count > 0)
            {
                scheduler.ExecuteNext();
            }
        }

        static void ExecuteTask(string task)
        {
            Console.WriteLine($"Executing task: {task}");
        }
    }
    }
}