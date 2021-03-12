/*
 * Author: Group 30 (William Armstrong / Jeffrey Belford / Youngmin Chung
 * Date: Apr 9, 2020
 * Filename: ExpressionEvaluation.cs
 * Description: Create a class called ExpressionEvaluation. This class will include the necessary methods to implement the evaluation processes.
 */

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project2_Group_30
{
    public class ExpressionEvaluation
    {
        private bool IsOperator(char C)
        {
            return (C == '-' || C == '+' || C == '*' || C == '/');
        }

        // Expression trees
        private static Expression<Func<double, double, double>> addUn = (num1, num2) => num1 + num2;
        private Func<double, double, double> add = addUn.Compile();

        private static Expression<Func<double, double, double>> subUn = (num1, num2) => num1 - num2;
        private Func<double, double, double> sub = subUn.Compile();

        private static Expression<Func<double, double, double>> multUn = (num1, num2) => num1 * num2;
        private Func<double, double, double> mult = multUn.Compile();

        private static Expression<Func<double, double, double>> divUn = (num1, num2) => num1 / num2;
        private Func<double, double, double> div = divUn.Compile();

        // evaluate postfix expression
        public string PostCalculate(string postfix)
        {
            List<char> postList = new List<char>();
            postList.AddRange(postfix);
            Stack<double> stack = new Stack<double>();

            for (int i = 0; i < postList.Count; i++)
            {
                if (!IsOperator(postList[i]))
                {
                    stack.Push(Convert.ToDouble(
                        Char.GetNumericValue(postList[i]))
                        );
                }
                else
                {
                    double temp1 = stack.Pop();
                    double temp2 = stack.Pop();

                    switch (postList[i])
                    {
                        case '*':
                            stack.Push(mult(temp2, temp1));
                            break;
                        case '-':
                            stack.Push(sub(temp2, temp1));
                            break;
                        case '+':
                            stack.Push(add(temp2, temp1));
                            break;
                        case '/':
                            stack.Push(div(temp2,temp1));
                            break;
                    }

                }
                Console.WriteLine(stack.ToString());
            }
            return stack.Pop().ToString();
        }

        // evaluate prefix expression
        public string PreCalculate(string Prefix)
        {
            List<char> preList = new List<char>();
            preList.AddRange(Prefix);
            preList.Reverse();
            Stack<double> stack = new Stack<double>();

            for (int i = 0; i < preList.Count; i++)
            {
                if(!IsOperator(preList[i]))
                {
                    stack.Push(Convert.ToDouble(
                        Char.GetNumericValue(preList[i]))
                        );
                }
                // Push operand to Stack 
                else
                {
                    double temp1 = stack.Pop();
                    double temp2 = stack.Pop();

                    switch (preList[i])
                    {
                        case '+':
                            stack.Push(add(temp1, temp2));
                            break;
                        case '-':
                            stack.Push(sub(temp1, temp2));
                            break;
                        case '*':
                            stack.Push(mult(temp1, temp2));
                            break;
                        case '/':
                            stack.Push(div(temp1, temp2));
                            break;
                    }
                }

            }

            return stack.Pop().ToString();
        }
    }
}