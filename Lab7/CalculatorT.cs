using System;

namespace Lab7
{
    public class Calculator<T>
    {
        public delegate T Add_Delegate(T a, T b);
        public delegate T Subtract_Delegate(T a, T b);
        public delegate T Multiply_Delegate(T a, T b);
        public delegate T Divide_Delegate(T a, T b);

        public Add_Delegate Add { get; set; }
        public Subtract_Delegate Subtract { get; set; }
        public Multiply_Delegate Multiply { get; set; }
        public Divide_Delegate Divide { get; set; }

        public Calculator(Add_Delegate add, Subtract_Delegate subtract, Multiply_Delegate multiply, Divide_Delegate divide)
        {
            Add = add;
            Subtract = subtract;
            Multiply = multiply;
            Divide = divide;
        }

        public T Addition(T a, T b) => Add(a, b);
        public T Subtraction(T a, T b) => Subtract(a, b);
        public T Multiplication(T a, T b) => Multiply(a, b);
        public T Division(T a, T b) => Divide(a, b);
    }
}
