﻿using System;
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

using CSCalculator;
using CSCalculator.Core;

namespace CSCalculatorGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ExpressionBuilder Builder;
        private Memory MemoryHandler;

        public MainWindow()
        {
            InitializeComponent();

            Builder = new ExpressionBuilder();
            Builder.Initialize();

            MemoryHandler = new Memory();
            MemoryHandler.Initialize();
        }

        private void UpdateExpression()
        {
            ResultBox.Content = Builder.GetReadableExpression();
        }

        private void UpdateHistory()
        {
            CExpression ExprA = new CExpression();

            MemoryHandler.Grab(0, ref ExprA);

            StringBuilder ExprABuilder = new StringBuilder(Builder.ToReadableExpression(ExprA.Expr));
            ExprABuilder.Append(" = ");
            ExprABuilder.Append(Builder.ToReadableExpression(ExprA.Result));

            // If There's an Expression in A, then Load B with A.
            if ((string)HistoryBoxA.Content != "")
            {
                CExpression ExprB = new CExpression();

                MemoryHandler.Grab(1, ref ExprB);

                StringBuilder ExprBBuilder = new StringBuilder(Builder.ToReadableExpression(ExprB.Expr));
                ExprBBuilder.Append(" = ");
                ExprBBuilder.Append(Builder.ToReadableExpression(ExprB.Result));

                HistoryBoxB.Content = ExprBBuilder.ToString();
            }

            HistoryBoxA.Content = ExprABuilder.ToString();
        }

        private void Numpad_0_Click(object sender, RoutedEventArgs e)
        {
            Builder.Add('0');

            UpdateExpression();
        }

        private void Numpad_1_Click(object sender, RoutedEventArgs e)
        {
            Builder.Add('1');

            UpdateExpression();
        }

        private void Numpad_2_Click(object sender, RoutedEventArgs e)
        {
            Builder.Add('2');

            UpdateExpression();
        }

        private void Numpad_3_Click(object sender, RoutedEventArgs e)
        {
            Builder.Add('3');

            UpdateExpression();
        }

        private void Numpad_4_Click(object sender, RoutedEventArgs e)
        {
            Builder.Add('4');

            UpdateExpression();
        }

        private void Numpad_5_Click(object sender, RoutedEventArgs e)
        {
            Builder.Add('5');

            UpdateExpression();
        }

        private void Numpad_6_Click(object sender, RoutedEventArgs e)
        {
            Builder.Add('6');

            UpdateExpression();
        }

        private void Numpad_7_Click(object sender, RoutedEventArgs e)
        {
            Builder.Add('7');

            UpdateExpression();
        }

        private void Numpad_8_Click(object sender, RoutedEventArgs e)
        {
            Builder.Add('8');

            UpdateExpression();
        }

        private void Numpad_9_Click(object sender, RoutedEventArgs e)
        {
            Builder.Add('9');

            UpdateExpression();
        }

        private void Numpad_Decimal_Click(object sender, RoutedEventArgs e)
        {
            Builder.Add('.');

            UpdateExpression();
        }

        private void Operation_Negate_Click(object sender, RoutedEventArgs e)
        {
            Builder.Add((char)Symbols.Negate);

            UpdateExpression();
        }

        private void Operation_Add_Click(object sender, RoutedEventArgs e)
        {
            Builder.TryAddOffAnswer((char)Symbols.Add, MemoryHandler);

            UpdateExpression();
        }

        private void Operation_Subtract_Click(object sender, RoutedEventArgs e)
        {
            Builder.TryAddOffAnswer((char)Symbols.Subtract, MemoryHandler);

            UpdateExpression();
        }

        private void Operation_Multiply_Click(object sender, RoutedEventArgs e)
        {
            Builder.TryAddOffAnswer((char)Symbols.Multiply, MemoryHandler);

            UpdateExpression();
        }

        private void Operation_Divide_Click(object sender, RoutedEventArgs e)
        {
            Builder.TryAddOffAnswer((char)Symbols.Divide, MemoryHandler);

            UpdateExpression();
        }

        private void Numpad_Exponential_Click(object sender, RoutedEventArgs e)
        {
            Builder.Add((char)Symbols.Exponential);

            UpdateExpression();
        }

        private void Command_Execute_Click(object sender, RoutedEventArgs e)
        {
            Builder.Format();

            string Expression = Builder.GetExpression();

            if (Expression != "")
            {
                string Result = CSCalculator.Core.Application.Solve(Expression).ToString();
                ResultBox.Content = Result;

                MemoryHandler.Add(new CExpression(Builder.GetExpression(), Result));

                UpdateHistory();

                Builder.Clear();
            }
        }

        private void Command_Delete_Click(object sender, RoutedEventArgs e)
        {
            Builder.RemoveLast();

            UpdateExpression();
        }

        private void Command_AllClear_Click(object sender, RoutedEventArgs e)
        {
            Builder.Clear();

            UpdateExpression();
        }

        private void Numpad_Parenthese_Left_Click(object sender, RoutedEventArgs e)
        {
            Builder.Add('(');

            UpdateExpression();
        }

        private void Numpad_Parenthese_Right_Click(object sender, RoutedEventArgs e)
        {
            Builder.Add(')');

            UpdateExpression();
        }

        private void Operation_Caret_Click(object sender, RoutedEventArgs e)
        {
            Builder.TryAddOffAnswer((char)Symbols.Caret, MemoryHandler);

            UpdateExpression();
        }

        private void Operation_Square_Click(object sender, RoutedEventArgs e)
        {
            Builder.TryAddOffAnswer((char)Symbols.Caret, MemoryHandler);
            Builder.Add('2');

            UpdateExpression();
        }

        private void Operation_Cube_Click(object sender, RoutedEventArgs e)
        {
            Builder.TryAddOffAnswer((char)Symbols.Caret, MemoryHandler);
            Builder.Add('3');

            UpdateExpression();
        }
    }
}
