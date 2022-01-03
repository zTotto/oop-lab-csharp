namespace DelegatesAndEvents
{
    using System;

    /// <summary>
    /// The runnable entrypoint of the exercise.
    /// </summary>
    public class Program
    {
        /// <inheritdoc cref="Program" />
        public static void Main()
        {
            bool c1, c2, c3;
            IObservableList<int> list = new ObservableList<int>() { 1, 2, 3 };

            c1 = c2 = c3 = false;

            list.ElementInserted += (lst, value, index) =>
            {
                if (lst == list && value == 4 && index == 3)
                {
                    c1 = true;
                }
                else
                {
                    c1 = false;
                }
            };
            Console.WriteLine(c1);

            list.Add(4);
            Console.WriteLine(c1);
            Console.WriteLine(list.ToString());

            list.ElementRemoved += (lst, value, index) =>
            {
                if (lst == list && value == 2 && index == 1)
                {
                    c2 = true;
                }
                else
                {
                    c2 = false;
                }
            };
            Console.WriteLine(c2);

            list.Remove(2);
            Console.WriteLine(c2);
            Console.WriteLine(list.ToString());

            list.ElementChanged += (lst, value, oldValue, index) =>
            {
                if (lst == list && value == 6 && oldValue == 1 && index == 0)
                {
                    c3 = true;
                }
                else
                {
                    c3 = false;
                }
            };
            Console.WriteLine(c3);

            list[0] = 6;
            Console.WriteLine(c3);
            Console.WriteLine(list.ToString());

            if (!(c1 && c2 && c3))
            {
                throw new Exception("Wrong implementation");
            }

            Console.WriteLine("Ok");
        }
    }
}
