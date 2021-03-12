/*
 * Author: Group 30 (William Armstrong / Jeffrey Belford / Youngmin Chung)
 * Date: Apr 9, 2020
 * Filename: Conversion.cs
 * Description: Each conversion process should be encapsulated within a public class. Choose an appropriate name for each class.
 *              PostConvert class convert to infix to postfix
 *              PreConvert class convert to infix to prefix
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Project2_Group_30
{
    public class Conversion
    {

        // check the input value is operator or not 
        private bool IsOperator(char C)
        {
            return (C == '-' || C == '+' || C == '*' || C == '/');
        }

        //check if it's an operand
        private bool IsOperand(char c)
        {
            return (c >= 48 && c <= 57);
        }

        // check priority the right way
        private int GetPriority(char C)
        {
            if (C == '-' || C == '+')
                return 1;
            else if (C == '*' || C == '/')
                return 2;
            return 0;
        }

        public string PostConvert(string expression)
        {
            List<char> item = new List<char>();
            item.AddRange(expression);
            var result = "";
            var stack = new Stack<char>();
            foreach (var i in item)
            {
                // check the each char is an operand, add it to output.  
                if (char.IsLetterOrDigit(i))
                {
                    result += i;
                }
                // check the each char is an '(', push it to the stack.  
                else if (i == '(')
                {
                    stack.Push(i);
                }
                // check the each char is an ')', pop and output from the stack until an '(' is up.  
                else if (i == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        result += stack.Pop();
                    }

                    if (stack.Count > 0 && stack.Peek() != '(')
                    {
                        throw new ArgumentException("Invalid Expression");
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else // check each char is an operator
                {
                    while (stack.Count > 0 && GetPriority(i) <= GetPriority(stack.Peek()))
                    {
                        result += stack.Pop();
                    }
                    stack.Push(i);
                }
            }
            // pop all the operators from the stack  
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }
            return result;
        }

        public string PreConvert(string expression)
        {
            // stack for operators
            Stack<char> operators = new Stack<char>();
            // stack for operators. 
            Stack<string> operands = new Stack<string>();

            foreach (var i in expression)
            {
                // check the each char is an '(', push it to the operators stack.  
                if (i == '(')
                {
                    operators.Push(i);
                }

                // check the each char is an ')', pop and output from the stack until an '(' is up.
                else if (i == ')')
                {
                    while (operators.Count != 0 &&
                           operators.Peek() != '(')
                    {
                        // 1st operand  
                        string op1 = operands.Peek();
                        operands.Pop();
                        // 2nd operand
                        string op2 = operands.Peek();
                        operands.Pop();
                        // operator  
                        char op = operators.Peek();
                        operators.Pop();
                        // combine operands and operator  
                        string tmp = op + op2 + op1;
                        operands.Push(tmp);
                    }
                    // Pop opening bracket
                    operators.Pop();
                }
                // check current char is an operand or not. If it is, push it into operands stack.  
                else if (!IsOperator(i))
                {
                    operands.Push(i + "");
                }
                // check current char is an operator or not. If it is, push it into operators stack
                // after popping high priority operators from operators stack and pushing result in operands stack.  
                else
                {
                    while (operators.Count != 0 &&
                           GetPriority(i) <=
                           GetPriority(operators.Peek()))
                    {

                        string op1 = operands.Peek();
                        operands.Pop();

                        string op2 = operands.Peek();
                        operands.Pop();

                        char op = operators.Peek();
                        operators.Pop();

                        string tmp = op + op2 + op1;
                        operands.Push(tmp);
                    }
                    operators.Push(i);
                }
            }

            // Pop operators from operators stack until it is empty and  
            // operation in add result of each pop operands stack.  
            while (operators.Count != 0)
            {
                // 1st operand  
                string op1 = operands.Peek();
                operands.Pop();
                // 2nd operand
                string op2 = operands.Peek();
                operands.Pop();
                // operator  
                char op = operators.Peek();
                operators.Pop();
                // combine operands and operator 
                string tmp = op + op2 + op1;
                operands.Push(tmp);
            }
            return operands.Peek();
        }
    }
}
