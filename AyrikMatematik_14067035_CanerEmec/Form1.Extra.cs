using AyrıkMaAyrikMatematik_14067035_CanerEmectematik;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AyrikMatematik_14067035_CanerEmec
{
    public partial class Form1
    {
        public Chart ChartGeneral { get; set; }
        public RichTextBox RichTextBoxGeneral { get; set; }
        public Methods SelectedMethod { get; set; }

        private ErrorProvider errorProvider = new ErrorProvider();
        private int inputControlWidth;

        public void Prepare4Method(int idx)
        {
            inputControlWidth = gboxInput.Width - 2 * cmbMethods.Location.X - 15;

            switch (idx)
            {
                case 0:
                    SelectedMethod = Methods.NewtonRaphson;
                    Prepare4NewtonRaphson();
                    Prepare4Output();
                    Prepare4Run();
                    break;
                case 1:
                    SelectedMethod = Methods.Secant;
                    Prepare4Secant();
                    Prepare4Output();
                    Prepare4Run();
                    break;
                case 2:
                    SelectedMethod = Methods.SimpleIteration;
                    Prepare4SimpleIteration();
                    Prepare4Output();
                    Prepare4Run();
                    break;
                case 3:
                    SelectedMethod = Methods.FalsePosition;
                    Prepare4FalsePosition();
                    Prepare4Output();
                    Prepare4Run();
                    break;
                case 4:
                    SelectedMethod = Methods.BiSection;
                    Prepare4BiSection();
                    Prepare4Output();
                    Prepare4Run();
                    break;
                case 5:
                    SelectedMethod = Methods.MatrixInverse;
                    Prepare4MatrixInverse();
                    Prepare4Output2();
                    Prepare4Run();
                    break;
                case 6:
                    SelectedMethod = Methods.Graphical;
                    Prepare4Graphical();
                    Prepare4Output();
                    Prepare4Run();
                    break;
                case 7:
                    SelectedMethod = Methods.GaussElimination;
                    Prepare4GaussElimination();
                    Prepare4Output2();
                    Prepare4Run();
                    break;
                case 8:
                    SelectedMethod = Methods.GaussJordanElimination;
                    Prepare4GaussJordanElimination();
                    Prepare4Output2();
                    Prepare4Run();
                    break;
                case 9:
                    SelectedMethod = Methods.Simpson13;
                    Prepare4Simpson_13();
                    Prepare4Output2();
                    Prepare4Run();
                    break;
                case 10:
                    SelectedMethod = Methods.Simpson38;
                    Prepare4Simpson_38();
                    Prepare4Output2();
                    Prepare4Run();
                    break;
                case 11:
                    SelectedMethod = Methods.Trapezoidal;
                    Prepare4Trapezoidal();
                    Prepare4Output2();
                    Prepare4Run();
                    break;
                case 12:
                    SelectedMethod = Methods.Jacobi;

                    Prepare4Jacobi();
                    Prepare4Output();
                    Prepare4Run();
                    break;
                case 13:
                    SelectedMethod = Methods.GaussSeidel;

                    Prepare4GaussSeidel();
                    Prepare4Output();
                    Prepare4Run();
                    break;
                default:
                    break;
            }
        }

        private void Prepare4GaussSeidel()
        {
            gboxInput.Controls.Clear();

            Label lbl1 = new Label()
            {
                Text = "Enter Matrix A As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, 20),
                AutoSize = true
            };

            TextBox txbox1 = new TextBox()
            {
                Name = "txbox1",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl1.Location.Y + lbl1.Height)
            };

            Label lbl2 = new Label()
            {
                Text = "Enter Vector C As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox1.Location.Y + txbox1.Height + 20),
                AutoSize = true
            };

            TextBox txbox2 = new TextBox()
            {
                Name = "txbox2",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl2.Location.Y + lbl2.Height)
            };

            Label lbl3 = new Label()
            {
                Text = "Enter Size (N=?)",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox2.Location.Y + txbox2.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown3 = new NumericUpDown()
            {
                Name = "numupdown1",
                Width = inputControlWidth,
                Minimum = 0,
                Increment = (decimal)1,
                Location = new Point(lbl1.Location.X, lbl3.Location.Y + lbl3.Height)
            };

            Label lbl4 = new Label()
            {
                Text = "Enter Epsilon",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown3.Location.Y + numupdown3.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown4 = new NumericUpDown()
            {
                Name = "numupdown2",
                Width = inputControlWidth,
                DecimalPlaces = 10,
                Minimum = 0,
                Increment = (decimal)0.00001,
                Location = new Point(lbl1.Location.X, lbl4.Location.Y + lbl4.Height)
            };

            Label lbl5 = new Label()
            {
                Text = "Enter Max. Iteration",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown4.Location.Y + numupdown4.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown5 = new NumericUpDown()
            {
                Name = "numupdown3",
                Width = inputControlWidth,
                Minimum = 0,
                Increment = (decimal)1,
                Location = new Point(lbl1.Location.X, lbl5.Location.Y + lbl5.Height)
            };


            gboxInput.Controls.Add(lbl1);
            gboxInput.Controls.Add(txbox1);
            gboxInput.Controls.Add(lbl2);
            gboxInput.Controls.Add(txbox2);
            gboxInput.Controls.Add(lbl3);
            gboxInput.Controls.Add(numupdown3);
            gboxInput.Controls.Add(lbl4);
            gboxInput.Controls.Add(numupdown4);
            gboxInput.Controls.Add(lbl4);
            gboxInput.Controls.Add(numupdown4);
            gboxInput.Controls.Add(lbl5);
            gboxInput.Controls.Add(numupdown5);
        }

        private void Prepare4Jacobi()
        {
            gboxInput.Controls.Clear();

            Label lbl1 = new Label()
            {
                Text = "Enter Matrix A As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, 20),
                AutoSize = true
            };

            TextBox txbox1 = new TextBox()
            {
                Name = "txbox1",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl1.Location.Y + lbl1.Height)
            };

            Label lbl2 = new Label()
            {
                Text = "Enter Vector C As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox1.Location.Y + txbox1.Height + 20),
                AutoSize = true
            };

            TextBox txbox2 = new TextBox()
            {
                Name = "txbox2",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl2.Location.Y + lbl2.Height)
            };

            Label lbl3 = new Label()
            {
                Text = "Enter Size (N=?)",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox2.Location.Y + txbox2.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown3 = new NumericUpDown()
            {
                Name = "numupdown1",
                Width = inputControlWidth,
                Minimum = 0,
                Increment = (decimal)1,
                Location = new Point(lbl1.Location.X, lbl3.Location.Y + lbl3.Height)
            };

            Label lbl4 = new Label()
            {
                Text = "Enter Epsilon",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown3.Location.Y + numupdown3.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown4 = new NumericUpDown()
            {
                Name = "numupdown2",
                Width = inputControlWidth,
                DecimalPlaces = 10,
                Minimum = 0,
                Increment = (decimal)0.00001,
                Location = new Point(lbl1.Location.X, lbl4.Location.Y + lbl4.Height)
            };

            Label lbl5 = new Label()
            {
                Text = "Enter Max. Iteration",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown4.Location.Y + numupdown4.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown5 = new NumericUpDown()
            {
                Name = "numupdown3",
                Width = inputControlWidth,
                Minimum = 0,
                Increment = (decimal)1,
                Location = new Point(lbl1.Location.X, lbl5.Location.Y + lbl5.Height)
            };


            gboxInput.Controls.Add(lbl1);
            gboxInput.Controls.Add(txbox1);
            gboxInput.Controls.Add(lbl2);
            gboxInput.Controls.Add(txbox2);
            gboxInput.Controls.Add(lbl3);
            gboxInput.Controls.Add(numupdown3);
            gboxInput.Controls.Add(lbl4);
            gboxInput.Controls.Add(numupdown4);
            gboxInput.Controls.Add(lbl4);
            gboxInput.Controls.Add(numupdown4);
            gboxInput.Controls.Add(lbl5);
            gboxInput.Controls.Add(numupdown5);
        }

        private void Prepare4NewtonRaphson()
        {
            gboxInput.Controls.Clear();

            Label lbl1 = new Label()
            {
                Text = "Enter Function As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, 20),
                AutoSize = true
            };

            TextBox txbox1 = new TextBox()
            {
                Name = "txbox1",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl1.Location.Y + lbl1.Height)
            };

            Label lbl2 = new Label()
            {
                Text = "Enter Epsilon",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox1.Location.Y + txbox1.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown2 = new NumericUpDown()
            {
                Name = "numupdown1",
                Width = inputControlWidth,
                Minimum = 0,
                DecimalPlaces = 10,
                Increment = (decimal)0.0000001,
                Location = new Point(lbl1.Location.X, lbl2.Location.Y + lbl2.Height)
            };

            Label lbl3 = new Label()
            {
                Text = "Enter Initial Value",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown2.Location.Y + numupdown2.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown3 = new NumericUpDown()
            {
                Name = "numupdown2",
                Width = inputControlWidth,
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Increment = (decimal)0.1,
                DecimalPlaces =2,
                Location = new Point(lbl1.Location.X, lbl3.Location.Y + lbl3.Height)
            };

            gboxInput.Controls.Add(lbl1);
            gboxInput.Controls.Add(txbox1);
            gboxInput.Controls.Add(lbl2);
            gboxInput.Controls.Add(numupdown2);
            gboxInput.Controls.Add(lbl3);
            gboxInput.Controls.Add(numupdown3);
        }

        private void Prepare4Secant()
        {
            gboxInput.Controls.Clear();

            Label lbl1 = new Label()
            {
                Text = "Enter Function As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, 20),
                AutoSize = true
            };

            TextBox txbox1 = new TextBox()
            {
                Name = "txbox1",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl1.Location.Y + lbl1.Height)
            };

            Label lbl2 = new Label()
            {
                Text = "Enter Epsilon",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox1.Location.Y + txbox1.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown2 = new NumericUpDown()
            {
                Name="numupdown1",
                Width = inputControlWidth,
                Minimum = 0,
                DecimalPlaces = 10,
                Increment = (decimal)0.0000001,
                Location = new Point(lbl1.Location.X, lbl2.Location.Y + lbl2.Height)
            };

            Label lbl3 = new Label()
            {
                Text = "Enter X_0 Value",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown2.Location.Y + numupdown2.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown3 = new NumericUpDown()
            {
                Name = "numupdown2",
                Width = inputControlWidth,
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Increment = (decimal)0.1,
                DecimalPlaces = 2,
                Location = new Point(lbl1.Location.X, lbl3.Location.Y + lbl3.Height)
            };

            Label lbl4 = new Label()
            {
                Text = "Enter X_1 Value",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown3.Location.Y + numupdown3.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown4 = new NumericUpDown()
            {
                Name = "numupdown3",
                Width = inputControlWidth,
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Increment = (decimal)0.1,
                DecimalPlaces = 2,
                Location = new Point(lbl1.Location.X, lbl4.Location.Y + lbl4.Height)
            };

            gboxInput.Controls.Add(lbl1);
            gboxInput.Controls.Add(txbox1);
            gboxInput.Controls.Add(lbl2);
            gboxInput.Controls.Add(numupdown2);
            gboxInput.Controls.Add(lbl3);
            gboxInput.Controls.Add(numupdown3);
            gboxInput.Controls.Add(lbl4);
            gboxInput.Controls.Add(numupdown4);
        }

        private void Prepare4SimpleIteration()
        {
            gboxInput.Controls.Clear();

            Label lbl1 = new Label()
            {
                Text = "Enter First Function As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, 20),
                AutoSize = true
            };

            TextBox txbox1 = new TextBox()
            {
                Name = "txbox1",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl1.Location.Y + lbl1.Height)
            };

            Label lbl2 = new Label()
            {
                Text = "Enter Second Function As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox1.Location.Y + txbox1.Height + 20),
                AutoSize = true
            };

            TextBox txbox2 = new TextBox()
            {
                Name="txbox2",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl2.Location.Y + lbl2.Height)
            };

            Label lbl3 = new Label()
            {
                Text = "Enter Epsilon",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox2.Location.Y + txbox2.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown3 = new NumericUpDown()
            {
                Name="numupdown1",
                Width = inputControlWidth,
                Minimum = 0,
                DecimalPlaces = 10,
                Increment = (decimal)0.0000001,
                Location = new Point(lbl1.Location.X, lbl3.Location.Y + lbl3.Height)
            };

            Label lbl4 = new Label()
            {
                Text = "Enter X_0 Value",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown3.Location.Y + numupdown3.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown4 = new NumericUpDown()
            {
                Name = "numupdown2",
                Width = inputControlWidth,
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Increment = (decimal)0.1,
                DecimalPlaces = 2,
                Location = new Point(lbl1.Location.X, lbl4.Location.Y + lbl4.Height)
            };


            gboxInput.Controls.Add(lbl1);
            gboxInput.Controls.Add(txbox1);
            gboxInput.Controls.Add(lbl2);
            gboxInput.Controls.Add(txbox2);
            gboxInput.Controls.Add(lbl3);
            gboxInput.Controls.Add(numupdown3);
            gboxInput.Controls.Add(lbl4);
            gboxInput.Controls.Add(numupdown4);
        }

        private void Prepare4FalsePosition()
        {
            gboxInput.Controls.Clear();

            Label lbl1 = new Label()
            {
                Text = "Enter Function As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, 20),
                AutoSize = true
            };

            TextBox txbox1 = new TextBox()
            {
                Name = "txbox1",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl1.Location.Y + lbl1.Height)
            };

            Label lbl2 = new Label()
            {
                Text = "Enter Epsilon",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox1.Location.Y + txbox1.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown2 = new NumericUpDown()
            {
                Name="numupdown1",
                Width = inputControlWidth,
                Minimum = 0,
                DecimalPlaces = 10,
                Increment = (decimal)0.0000001,
                Location = new Point(lbl1.Location.X, lbl2.Location.Y + lbl2.Height)
            };

            Label lbl3 = new Label()
            {
                Text = "Enter X_left Value",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown2.Location.Y + numupdown2.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown3 = new NumericUpDown()
            {
                Name="numupdown2",
                Width = inputControlWidth,
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Increment = (decimal)0.1,
                DecimalPlaces = 2,
                Location = new Point(lbl1.Location.X, lbl3.Location.Y + lbl3.Height)
            };

            Label lbl4 = new Label()
            {
                Text = "Enter X_rigth Value",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown3.Location.Y + numupdown3.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown4 = new NumericUpDown()
            {
                Name="numupdown3",
                Width = inputControlWidth,
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Increment = (decimal)0.1,
                DecimalPlaces = 2,
                Location = new Point(lbl1.Location.X, lbl4.Location.Y + lbl4.Height)
            };

            gboxInput.Controls.Add(lbl1);
            gboxInput.Controls.Add(txbox1);
            gboxInput.Controls.Add(lbl2);
            gboxInput.Controls.Add(numupdown2);
            gboxInput.Controls.Add(lbl3);
            gboxInput.Controls.Add(numupdown3);
            gboxInput.Controls.Add(lbl4);
            gboxInput.Controls.Add(numupdown4);
        }

        private void Prepare4BiSection()
        {
            gboxInput.Controls.Clear();

            Label lbl1 = new Label()
            {
                Text = "Enter Function As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, 20),
                AutoSize = true
            };

            TextBox txbox1 = new TextBox()
            {
                Name="txbox1",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl1.Location.Y + lbl1.Height)
            };

            Label lbl2 = new Label()
            {
                Text = "Enter Epsilon",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox1.Location.Y + txbox1.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown2 = new NumericUpDown()
            {
                Name="numupdown1",
                Width = inputControlWidth,
                Minimum = 0,
                DecimalPlaces = 10,
                Increment = (decimal)0.0000001,
                Location = new Point(lbl1.Location.X, lbl2.Location.Y + lbl2.Height)
            };

            Label lbl3 = new Label()
            {
                Text = "Enter X_left Value",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown2.Location.Y + numupdown2.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown3 = new NumericUpDown()
            {
                Name="numupdown2",
                Width = inputControlWidth,
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Increment = (decimal)0.1,
                DecimalPlaces = 2,
                Location = new Point(lbl1.Location.X, lbl3.Location.Y + lbl3.Height)
            };

            Label lbl4 = new Label()
            {
                Text = "Enter X_rigth Value",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown3.Location.Y + numupdown3.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown4 = new NumericUpDown()
            {
                Name="numupdown3",
                Width = inputControlWidth,
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Increment = (decimal)0.1,
                DecimalPlaces = 2,
                Location = new Point(lbl1.Location.X, lbl4.Location.Y + lbl4.Height)
            };

            gboxInput.Controls.Add(lbl1);
            gboxInput.Controls.Add(txbox1);
            gboxInput.Controls.Add(lbl2);
            gboxInput.Controls.Add(numupdown2);
            gboxInput.Controls.Add(lbl3);
            gboxInput.Controls.Add(numupdown3);
            gboxInput.Controls.Add(lbl4);
            gboxInput.Controls.Add(numupdown4);
        }

        private void Prepare4Graphical()
        {
            gboxInput.Controls.Clear();

            Label lbl1 = new Label()
            {
                Text = "Enter Function As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, 20),
                AutoSize = true
            };

            TextBox txbox1 = new TextBox()
            {
                Name="txbox1",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl1.Location.Y + lbl1.Height)
            };

            Label lbl2 = new Label()
            {
                Text = "Enter Epsilon",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox1.Location.Y + txbox1.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown2 = new NumericUpDown()
            {
                Name="numupdown1",
                Width = inputControlWidth,
                Minimum = 0,
                DecimalPlaces = 10,
                Increment = (decimal)0.0000001,
                Location = new Point(lbl1.Location.X, lbl2.Location.Y + lbl2.Height)
            };

            Label lbl3 = new Label()
            {
                Text = "Enter X_0 Value",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown2.Location.Y + numupdown2.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown3 = new NumericUpDown()
            {
                Name="numupdown2",
                Width = inputControlWidth,
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Increment = (decimal)0.1,
                DecimalPlaces = 2,
                Location = new Point(lbl1.Location.X, lbl3.Location.Y + lbl3.Height)
            };

            Label lbl4 = new Label()
            {
                Text = "Enter D_x Value",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown3.Location.Y + numupdown3.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown4 = new NumericUpDown()
            {
                Name="numupdown3",
                Width = inputControlWidth,
                Minimum = 0,
                DecimalPlaces = 10,
                Increment = (decimal)0.0000001,
                Maximum = decimal.MaxValue,
                Location = new Point(lbl1.Location.X, lbl4.Location.Y + lbl4.Height)
            };

            gboxInput.Controls.Add(lbl1);
            gboxInput.Controls.Add(txbox1);
            gboxInput.Controls.Add(lbl2);
            gboxInput.Controls.Add(numupdown2);
            gboxInput.Controls.Add(lbl3);
            gboxInput.Controls.Add(numupdown3);
            gboxInput.Controls.Add(lbl4);
            gboxInput.Controls.Add(numupdown4);
        }

        private void Prepare4MatrixInverse()
        {
            gboxInput.Controls.Clear();

            Label lbl1 = new Label()
            {
                Text = "Enter Matrix As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, 20),
                AutoSize = true
            };

            TextBox txbox1 = new TextBox()
            {
                Name="txbox1",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl1.Location.Y + lbl1.Height)
            };

            Label lbl2 = new Label()
            {
                Text = "Enter Matrix Size (NxN, N=?)",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox1.Location.Y + txbox1.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown2 = new NumericUpDown()
            {
                Name="numupdown1",
                Width = inputControlWidth,
                Minimum = 0,
                Increment = (decimal)1,
                Location = new Point(lbl1.Location.X, lbl2.Location.Y + lbl2.Height)
            };


            gboxInput.Controls.Add(lbl1);
            gboxInput.Controls.Add(txbox1);
            gboxInput.Controls.Add(lbl2);
            gboxInput.Controls.Add(numupdown2);
        }

        private void Prepare4GaussElimination()
        {
            gboxInput.Controls.Clear();

            Label lbl1 = new Label()
            {
                Text = "Enter Matrix A As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, 20),
                AutoSize = true
            };

            TextBox txbox1 = new TextBox()
            {
                Name="txbox1",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl1.Location.Y + lbl1.Height)
            };

            Label lbl2 = new Label()
            {
                Text = "Enter Vector C As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox1.Location.Y + txbox1.Height + 20),
                AutoSize = true
            };

            TextBox txbox2 = new TextBox()
            {
                Name="txbox2",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl2.Location.Y + lbl2.Height)
            };

            Label lbl3 = new Label()
            {
                Text = "Enter Size (N=?)",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox2.Location.Y + txbox2.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown3 = new NumericUpDown()
            {
                Name="numupdown1",
                Width = inputControlWidth,
                Minimum = 0,
                Increment = (decimal)1,
                Location = new Point(lbl1.Location.X, lbl3.Location.Y + lbl3.Height)
            };


            gboxInput.Controls.Add(lbl1);
            gboxInput.Controls.Add(txbox1);
            gboxInput.Controls.Add(lbl2);
            gboxInput.Controls.Add(txbox2);
            gboxInput.Controls.Add(lbl3);
            gboxInput.Controls.Add(numupdown3);

        }

        private void Prepare4GaussJordanElimination()
        {
            gboxInput.Controls.Clear();

            Label lbl1 = new Label()
            {
                Text = "Enter Matrix A As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, 20),
                AutoSize = true
            };

            TextBox txbox1 = new TextBox()
            {
                Name="txbox1",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl1.Location.Y + lbl1.Height)
            };

            Label lbl2 = new Label()
            {
                Text = "Enter Vector C As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox1.Location.Y + txbox1.Height + 20),
                AutoSize = true
            };

            TextBox txbox2 = new TextBox()
            {
                Name="txbox2",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl2.Location.Y + lbl2.Height)
            };

            Label lbl3 = new Label()
            {
                Text = "Enter Size (N=?)",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox2.Location.Y + txbox2.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown3 = new NumericUpDown()
            {
                Name="numupdown1",
                Width = inputControlWidth,
                Minimum = 0,
                Increment = (decimal)1,
                Location = new Point(lbl1.Location.X, lbl3.Location.Y + lbl3.Height)
            };


            gboxInput.Controls.Add(lbl1);
            gboxInput.Controls.Add(txbox1);
            gboxInput.Controls.Add(lbl2);
            gboxInput.Controls.Add(txbox2);
            gboxInput.Controls.Add(lbl3);
            gboxInput.Controls.Add(numupdown3);

        }

        private void Prepare4Simpson_13()
        {
            gboxInput.Controls.Clear();

            Label lbl1 = new Label()
            {
                Text = "Enter Function As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, 20),
                AutoSize = true
            };

            TextBox txbox1 = new TextBox()
            {
                Name="txbox1",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl1.Location.Y + lbl1.Height)
            };

            Label lbl2 = new Label()
            {
                Text = "Enter Lower Bound ",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox1.Location.Y + txbox1.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown2 = new NumericUpDown()
            {
                Name="numupdown1",
                Width = inputControlWidth,
                DecimalPlaces = 2,
                Minimum = decimal.MinValue,
                Increment = (decimal)0.1,
                Location = new Point(lbl1.Location.X, lbl2.Location.Y + lbl2.Height)
            };

            Label lbl3 = new Label()
            {
                Text = "Enter Upper Bound ",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown2.Location.Y + numupdown2.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown3 = new NumericUpDown()
            {
                Name="numupdown2",
                Width = inputControlWidth,
                DecimalPlaces = 2,
                Minimum = decimal.MinValue,
                Increment = (decimal)0.1,
                Location = new Point(lbl1.Location.X, lbl3.Location.Y + lbl3.Height)
            };

            Label lbl4 = new Label()
            {
                Text = "Enter N ",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown3.Location.Y + numupdown3.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown4 = new NumericUpDown()
            {
                Name = "numupdown3",
                Width = inputControlWidth,
                DecimalPlaces = 2,
                Minimum = decimal.MinValue,
                Increment = (decimal)0.1,
                Location = new Point(lbl1.Location.X, lbl4.Location.Y + lbl4.Height)
            };

            gboxInput.Controls.Add(lbl1);
            gboxInput.Controls.Add(txbox1);
            gboxInput.Controls.Add(lbl2);
            gboxInput.Controls.Add(numupdown2);
            gboxInput.Controls.Add(lbl3);
            gboxInput.Controls.Add(numupdown3);
            gboxInput.Controls.Add(lbl4);
            gboxInput.Controls.Add(numupdown4);
        }

        private void Prepare4Simpson_38()
        {
            gboxInput.Controls.Clear();

            Label lbl1 = new Label()
            {
                Text = "Enter Function As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, 20),
                AutoSize = true
            };

            TextBox txbox1 = new TextBox()
            {
                Name="txbox1",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl1.Location.Y + lbl1.Height)
            };

            Label lbl2 = new Label()
            {
                Text = "Enter Lower Bound ",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox1.Location.Y + txbox1.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown2 = new NumericUpDown()
            {
                Name="numupdown1",
                Width = inputControlWidth,
                DecimalPlaces = 2,
                Minimum = decimal.MinValue,
                Increment = (decimal)0.1,
                Location = new Point(lbl1.Location.X, lbl2.Location.Y + lbl2.Height)
            };

            Label lbl3 = new Label()
            {
                Text = "Enter Upper Bound ",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown2.Location.Y + numupdown2.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown3 = new NumericUpDown()
            {
                Name="numupdown2",
                Width = inputControlWidth,
                DecimalPlaces = 2,
                Minimum = decimal.MinValue,
                Increment = (decimal)0.1,
                Location = new Point(lbl1.Location.X, lbl3.Location.Y + lbl3.Height)
            };
            Label lbl4 = new Label()
            {
                Text = "Enter N ",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown3.Location.Y + numupdown3.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown4 = new NumericUpDown()
            {
                Name = "numupdown3",
                Width = inputControlWidth,
                DecimalPlaces = 2,
                Minimum = decimal.MinValue,
                Increment = (decimal)0.1,
                Location = new Point(lbl1.Location.X, lbl4.Location.Y + lbl4.Height)
            };

            gboxInput.Controls.Add(lbl1);
            gboxInput.Controls.Add(txbox1);
            gboxInput.Controls.Add(lbl2);
            gboxInput.Controls.Add(numupdown2);
            gboxInput.Controls.Add(lbl3);
            gboxInput.Controls.Add(numupdown3);
            gboxInput.Controls.Add(lbl4);
            gboxInput.Controls.Add(numupdown4);
        }

        private void Prepare4Trapezoidal()
        {
            gboxInput.Controls.Clear();

            Label lbl1 = new Label()
            {
                Text = "Enter Function As String..",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, 20),
                AutoSize = true
            };

            TextBox txbox1 = new TextBox()
            {
                Name="txbox1",
                Width = inputControlWidth,
                Multiline = true,
                Location = new Point(lbl1.Location.X, lbl1.Location.Y + lbl1.Height)
            };

            Label lbl2 = new Label()
            {
                Text = "Enter Lower Bound ",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, txbox1.Location.Y + txbox1.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown2 = new NumericUpDown()
            {
                Name="numupdown1",
                Width = inputControlWidth,
                DecimalPlaces = 2,
                Minimum = decimal.MinValue,
                Increment = (decimal)0.1,
                Location = new Point(lbl1.Location.X, lbl2.Location.Y + lbl2.Height)
            };

            Label lbl3 = new Label()
            {
                Text = "Enter Upper Bound ",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown2.Location.Y + numupdown2.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown3 = new NumericUpDown()
            {
                Name="numupdown2",
                Width = inputControlWidth,
                DecimalPlaces = 2,
                Minimum = decimal.MinValue,
                Increment = (decimal)0.1,
                Location = new Point(lbl1.Location.X, lbl3.Location.Y + lbl3.Height)
            };

            Label lbl4 = new Label()
            {
                Text = "Enter N ",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(cmbMethods.Location.X, numupdown3.Location.Y + numupdown3.Height + 20),
                AutoSize = true
            };

            NumericUpDown numupdown4 = new NumericUpDown()
            {
                Name = "numupdown3",
                Width = inputControlWidth,
                DecimalPlaces = 2,
                Minimum = decimal.MinValue,
                Increment = (decimal)0.1,
                Location = new Point(lbl1.Location.X, lbl4.Location.Y + lbl4.Height)
            };

            gboxInput.Controls.Add(lbl1);
            gboxInput.Controls.Add(txbox1);
            gboxInput.Controls.Add(lbl2);
            gboxInput.Controls.Add(numupdown2);
            gboxInput.Controls.Add(lbl3);
            gboxInput.Controls.Add(numupdown3);
            gboxInput.Controls.Add(lbl4);
            gboxInput.Controls.Add(numupdown4);
        }

        private void Prepare4Output()
        {
            gboxOutput.Controls.Clear();

            ChartArea chartArea = new ChartArea("ChartArea1");
            Legend legend = new Legend("Legend1");
            chartArea.AxisX.Title = "Iteration";
            chartArea.AxisY.Title = "Error";

            ChartGeneral = new Chart()
            {
                Location = new Point(10, 20),
                Size = new Size(gboxOutput.Width - 20, gboxOutput.Height - 150),
                BackColor = Color.Gray,
                Text = "Error - Iteration Graph",
            };

            ChartGeneral.ChartAreas.Add(chartArea);
            ChartGeneral.Legends.Add(legend);

            ChartGeneral.Series.Add(new Series("Error")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderWidth = 2
            }) ;

            RichTextBoxGeneral = new RichTextBox()
            {
                Location = new Point(ChartGeneral.Location.X, ChartGeneral.Location.Y + ChartGeneral.Height + 20),
                Size = new Size(ChartGeneral.Width, gboxOutput.Height - ChartGeneral.Height - 60),
                BackColor = Color.DarkGray,
                ForeColor = Color.DarkRed,
            };

            gboxOutput.Controls.Add(ChartGeneral);
            gboxOutput.Controls.Add(RichTextBoxGeneral);

        }

        private void Prepare4Output2()
        {
            gboxOutput.Controls.Clear();

            RichTextBoxGeneral = new RichTextBox()
            {
                Location = new Point(20, 20),
                Size = new Size(gboxOutput.Width - 40, gboxOutput.Height - 40),
                BackColor = Color.DarkGray,
                ForeColor = Color.DarkRed,
            };

            gboxOutput.Controls.Add(RichTextBoxGeneral);
        }

        private void Prepare4Run()
        {
            gboxRun.Controls.Clear();

            Button btn1 = new Button()
            {
                Text = "Check And Run",
                Location = new Point(20, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Width = gboxRun.Width - 40
            };

            btn1.Click += BtnRun_Click;

            gboxRun.Controls.Add(btn1);
        }

        private double[] InitVector(String str)
        {
            List<double> Matrix_ = new List<double>();
            str = str.Trim();
            string[] strArr = str.Split(' ');

            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i].Length > 0)
                {
                    Matrix_.Add(Convert.ToDouble(strArr[i]));
                    
                }
            }

            return Matrix_.ToArray();
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            string A = "", H = "", C = "";
            double eps, initVal, x0, x1, xleft, xright, dx, ub, lb;
            int n, maxIter;

            double[] AVec, HVec;

            switch (SelectedMethod)
            {
                case Methods.NewtonRaphson:
                    if (gboxInput.Controls.Count > 0)
                    {
                        A = (gboxInput.Controls.Find("txbox1", false)[0] as TextBox).Text;
                        eps = (double)(gboxInput.Controls.Find("numupdown1", false)[0] as NumericUpDown).Value;
                        initVal = (double)(gboxInput.Controls.Find("numupdown2", false)[0] as NumericUpDown).Value;

                        try
                        {
                            AVec = InitVector(A);
                            //run
                            NewtonRaphson newtonRaphson = new NewtonRaphson(AVec, eps, initVal);
                            newtonRaphson.OnNotify += NewtonRaphson_OnNotify;
                            NewtonRaphson.Result result = newtonRaphson.Solve();

                            RichTextBoxGeneral.Text += "<<< ROOT IS " + result.x_i_plus_1 + " >>>";
                        }
                        catch
                        {
                            errorProvider.SetError(gboxInput.Controls.Find("txbox1", false)[0], "Please Enter Correct Format!!");
                        }
                    }
                    break;
                case Methods.Secant:
                    if (gboxInput.Controls.Count > 0)
                    {
                        A = (gboxInput.Controls.Find("txbox1", false)[0] as TextBox).Text;
                        eps = (double)(gboxInput.Controls.Find("numupdown1", false)[0] as NumericUpDown).Value;
                        x0 = (double)(gboxInput.Controls.Find("numupdown2", false)[0] as NumericUpDown).Value;
                        x1 = (double)(gboxInput.Controls.Find("numupdown3", false)[0] as NumericUpDown).Value;

                        try
                        {
                            AVec = InitVector(A);

                            Secant secant = new Secant(AVec, eps, x0, x1);
                            secant.OnNotify += Secant_OnNotify;
                            Secant.Result result = secant.Solve();

                            RichTextBoxGeneral.Text += "<<< ROOT IS " + result.x2 + " >>>";
                        }
                        catch
                        {
                            errorProvider.SetError(gboxInput.Controls.Find("txbox1", false)[0], "Please Enter Correct Format!!");
                        }
                    }
                    break;
                case Methods.SimpleIteration:
                    if (gboxInput.Controls.Count > 0)
                    {
                        A = (gboxInput.Controls.Find("txbox1", false)[0] as TextBox).Text;
                        H = (gboxInput.Controls.Find("txbox2", false)[0] as TextBox).Text;
                        eps = (double)(gboxInput.Controls.Find("numupdown1", false)[0] as NumericUpDown).Value;
                        x0 = (double)(gboxInput.Controls.Find("numupdown2", false)[0] as NumericUpDown).Value;

                        try
                        {
                            AVec = InitVector(A);
                            HVec = InitVector(H);

                            SimpleIteration simpleIteration = new SimpleIteration(AVec, HVec, eps, x0);
                            simpleIteration.OnNotify += SimpleIteration_OnNotify;
                            SimpleIteration.Result result = simpleIteration.Solve();//sorunlu

                            //RichTextBoxGeneral.Text += "<<< ROOT IS " + result.gx + " >>>"; //sorunlu
                        }
                        catch
                        {
                            errorProvider.SetError(gboxInput.Controls.Find("txbox1", false)[0], "Please Enter Correct Format!!");
                            errorProvider.SetError(gboxInput.Controls.Find("txbox2", false)[0], "Please Enter Correct Format!!");
                        }
                    }
                    break;
                case Methods.FalsePosition:
                    if (gboxInput.Controls.Count > 0)
                    {
                        A = (gboxInput.Controls.Find("txbox1", false)[0] as TextBox).Text;
                        eps = (double)(gboxInput.Controls.Find("numupdown1", false)[0] as NumericUpDown).Value;
                        xleft = (double)(gboxInput.Controls.Find("numupdown2", false)[0] as NumericUpDown).Value;
                        xright = (double)(gboxInput.Controls.Find("numupdown3", false)[0] as NumericUpDown).Value;

                        try
                        {
                            AVec = InitVector(A);

                            FalsePosition falsePosition = new FalsePosition(AVec, eps, xleft, xright);
                            falsePosition.OnNotify += FalsePosition_OnNotify;
                            FalsePosition.Result result = falsePosition.Solve();

                            RichTextBoxGeneral.Text += "<<< ROOT IS " + result.x_center + " >>>";
                        }
                        catch
                        {
                            errorProvider.SetError(gboxInput.Controls.Find("txbox1", false)[0], "Please Enter Correct Format!!");
                        }
                    }
                    break;
                case Methods.BiSection:
                    if (gboxInput.Controls.Count > 0)
                    {
                        A = (gboxInput.Controls.Find("txbox1", false)[0] as TextBox).Text;
                        eps = (double)(gboxInput.Controls.Find("numupdown1", false)[0] as NumericUpDown).Value;
                        xleft = (double)(gboxInput.Controls.Find("numupdown2", false)[0] as NumericUpDown).Value;
                        xright = (double)(gboxInput.Controls.Find("numupdown3", false)[0] as NumericUpDown).Value;

                        try
                        {
                            AVec = InitVector(A);

                            BiSection biSection = new BiSection(AVec, eps, xleft, xright);
                            biSection.OnNotify += BiSection_OnNotify;
                            BiSection.Result result = biSection.Solve();

                            RichTextBoxGeneral.Text += "<<< ROOT IS " + result.x_center + " >>>";

                        }
                        catch
                        {
                            errorProvider.SetError(gboxInput.Controls.Find("txbox1", false)[0], "Please Enter Correct Format!!");
                        }

                    }
                    break;
                case Methods.Graphical:
                    if (gboxInput.Controls.Count > 0)
                    {
                        A = (gboxInput.Controls.Find("txbox1", false)[0] as TextBox).Text;
                        eps = (double)(gboxInput.Controls.Find("numupdown1", false)[0] as NumericUpDown).Value;
                        x0 = (double)(gboxInput.Controls.Find("numupdown2", false)[0] as NumericUpDown).Value;
                        dx = (double)(gboxInput.Controls.Find("numupdown3", false)[0] as NumericUpDown).Value;

                        try
                        {
                            AVec = InitVector(A);

                            Graphical graphical = new Graphical(AVec, eps, x0, dx);
                            graphical.OnNotify += Graphical_OnNotify;
                            Graphical.Result result = graphical.Solve();

                            RichTextBoxGeneral.Text += "<<< ROOT IS " + result.root + " >>>";
                        }
                        catch
                        {
                            errorProvider.SetError(gboxInput.Controls.Find("txbox1", false)[0], "Please Enter Correct Format!!");
                        }
                    }
                    break;
                case Methods.MatrixInverse:
                    if (gboxInput.Controls.Count > 0)
                    {
                        A = (gboxInput.Controls.Find("txbox1", false)[0] as TextBox).Text;
                        n = (int)(gboxInput.Controls.Find("numupdown1", false)[0] as NumericUpDown).Value;

                        int N = n;
                        double[,] B = new double[N, N];
                        double[,] adj = new double[N, N]; // To store adjoint of [,]A 
                        double[,] inv = new double[N, N]; // To store inverse of [,]A 

                        Matrix matrix = new Matrix(B, n, A);

                        RichTextBoxGeneral.Text += "Input matrix is :\n";
                        RichTextBoxGeneral.Text += matrix.display(B);

                        RichTextBoxGeneral.Text += "\nThe Adjoint is :\n";
                        matrix.adjoint(B, adj);
                        RichTextBoxGeneral.Text += matrix.display(adj);

                        RichTextBoxGeneral.Text += "\nThe Inverse is :\n";
                        if (matrix.inverse(B, inv))
                            RichTextBoxGeneral.Text += matrix.display(inv);
                    }
                    break;
                case Methods.GaussElimination:
                    if (gboxInput.Controls.Count > 0)
                    {
                        A = (gboxInput.Controls.Find("txbox1", false)[0] as TextBox).Text;
                        C = (gboxInput.Controls.Find("txbox2", false)[0] as TextBox).Text;
                        n = (int)(gboxInput.Controls.Find("numupdown1", false)[0] as NumericUpDown).Value;

                        GaussElimination gaussElimination = new GaussElimination(n, A, C);
                        gaussElimination.OnNotify += GaussElimination_OnNotify;
                        GaussElimination.Result result = gaussElimination.Solve();

                        RichTextBoxGeneral.Text += "<<< RESULT IS >>>\n" + display(result.result);

                    }
                    break;
                case Methods.GaussJordanElimination:
                    if (gboxInput.Controls.Count > 0)
                    {
                        A = (gboxInput.Controls.Find("txbox1", false)[0] as TextBox).Text;
                        C = (gboxInput.Controls.Find("txbox2", false)[0] as TextBox).Text;
                        n = (int)(gboxInput.Controls.Find("numupdown1", false)[0] as NumericUpDown).Value;

                        GaussJordanElimination gaussJordanElimination = new GaussJordanElimination(n, A, C);
                        gaussJordanElimination.OnNotify += GaussJordanElimination_OnNotify;
                        GaussJordanElimination.Result result = gaussJordanElimination.Solve();

                        RichTextBoxGeneral.Text += "<<< RESULT IS >>>\n" + display(result.result);
                    }
                    break;
                case Methods.Simpson13:
                    if (gboxInput.Controls.Count > 0)
                    {
                        A = (gboxInput.Controls.Find("txbox1", false)[0] as TextBox).Text;
                        lb = (double)(gboxInput.Controls.Find("numupdown1", false)[0] as NumericUpDown).Value;
                        ub = (double)(gboxInput.Controls.Find("numupdown2", false)[0] as NumericUpDown).Value;
                        n = (int)(gboxInput.Controls.Find("numupdown3", false)[0] as NumericUpDown).Value;
                        try
                        {
                            AVec = InitVector(A);

                            Simpsons simpsons13 = new Simpsons(AVec, (int)lb, (int)ub, n);
                            double res = simpsons13.Solve(Simpsons.Rule.R_1Div3);

                            RichTextBoxGeneral.Text += "<<< RESULT IS " + res + " >>>\n";
                        }
                        catch
                        {
                            errorProvider.SetError(gboxInput.Controls.Find("txbox1", false)[0], "Please Enter Correct Format!!");
                        }
                    }
                    break;
                case Methods.Simpson38:
                    if (gboxInput.Controls.Count > 0)
                    {
                        A = (gboxInput.Controls.Find("txbox1", false)[0] as TextBox).Text;
                        lb = (double)(gboxInput.Controls.Find("numupdown1", false)[0] as NumericUpDown).Value;
                        ub = (double)(gboxInput.Controls.Find("numupdown2", false)[0] as NumericUpDown).Value;
                        n = (int)(gboxInput.Controls.Find("numupdown3", false)[0] as NumericUpDown).Value;

                        try
                        {
                            AVec = InitVector(A);

                            Simpsons simpsons13 = new Simpsons(AVec, (int)lb, (int)ub, n);
                            double res = simpsons13.Solve(Simpsons.Rule.R_3Div8);

                            RichTextBoxGeneral.Text += "<<< RESULT IS " + res + " >>>\n";
                        }
                        catch
                        {
                            errorProvider.SetError(gboxInput.Controls.Find("txbox1", false)[0], "Please Enter Correct Format!!");
                        }
                    }
                    break;
                case Methods.Trapezoidal:
                    if (gboxInput.Controls.Count > 0)
                    {
                        A = (gboxInput.Controls.Find("txbox1", false)[0] as TextBox).Text;
                        lb = (double)(gboxInput.Controls.Find("numupdown1", false)[0] as NumericUpDown).Value;
                        ub = (double)(gboxInput.Controls.Find("numupdown2", false)[0] as NumericUpDown).Value;
                        n = (int)(gboxInput.Controls.Find("numupdown3", false)[0] as NumericUpDown).Value;

                        try
                        {
                            AVec = InitVector(A);

                            Trapezoidal trapezoidal = new Trapezoidal(AVec, (int)lb, (int)ub, n);
                            double res = trapezoidal.Solve();

                            RichTextBoxGeneral.Text += "<<< RESULT IS " + res + " >>>\n";
                        }
                        catch
                        {
                            errorProvider.SetError(gboxInput.Controls.Find("txbox1", false)[0], "Please Enter Correct Format!!");
                        }
                    }
                    break;
                case Methods.GaussSeidel:
                    if (gboxInput.Controls.Count > 0)
                    {
                        A = (gboxInput.Controls.Find("txbox1", false)[0] as TextBox).Text;
                        C = (gboxInput.Controls.Find("txbox2", false)[0] as TextBox).Text;
                        n = (int)(gboxInput.Controls.Find("numupdown1", false)[0] as NumericUpDown).Value;
                        eps =(double) (gboxInput.Controls.Find("numupdown2", false)[0] as NumericUpDown).Value;
                        maxIter = (int)(gboxInput.Controls.Find("numupdown3", false)[0] as NumericUpDown).Value;

                        GaussSeidel gaussSeidel = new GaussSeidel(n, A, C, eps, maxIter);
                        gaussSeidel.OnNotify += GaussSeidel_OnNotify;
                        GaussSeidel.Result result = gaussSeidel.Solve();

                        RichTextBoxGeneral.Text += "<<< RESULT IS >>>\n" + display(result.result);

                    }
                    break;
                case Methods.Jacobi:
                    if (gboxInput.Controls.Count > 0)
                    {
                        A = (gboxInput.Controls.Find("txbox1", false)[0] as TextBox).Text;
                        C = (gboxInput.Controls.Find("txbox2", false)[0] as TextBox).Text;
                        n = (int)(gboxInput.Controls.Find("numupdown1", false)[0] as NumericUpDown).Value;
                        eps = (double)(gboxInput.Controls.Find("numupdown2", false)[0] as NumericUpDown).Value;
                        maxIter = (int)(gboxInput.Controls.Find("numupdown3", false)[0] as NumericUpDown).Value;

                        Jacobi jacobi = new Jacobi(n, A, C, eps, maxIter);
                        jacobi.OnNotify += Jacobi_OnNotify;
                        Jacobi.Result result = jacobi.Solve();

                        RichTextBoxGeneral.Text += "<<< RESULT IS >>>\n" + display(result.result);

                    }
                    break;
                default:
                    break;
            }
        }

        private void Jacobi_OnNotify(object sender, Jacobi.JacobiEventArgs e)
        {
            ChartGeneral.Series[0].Points.AddXY(e.Result.iter_no, e.Result.err);
            RichTextBoxGeneral.Text += e.Result.iter_no + " >> \tError:: " + e.Result.err + "\n";
            RichTextBoxGeneral.Text += display(e.Result.result) + "\n\n";
        }

        private void GaussSeidel_OnNotify(object sender, GaussSeidel.GSeidelEventArgs e)
        {
            ChartGeneral.Series[0].Points.AddXY(e.Result.iter_no, e.Result.err);
            RichTextBoxGeneral.Text += e.Result.iter_no + " >> \tError:: " + e.Result.err + "\n";
            RichTextBoxGeneral.Text += display(e.Result.result) + "\n\n";
        }

        private void GaussJordanElimination_OnNotify(object sender, GaussJordanElimination.GJEEventArgs e)
        {
            RichTextBoxGeneral.Text += e.Result.iter_no + " >> " + e.Result.explanation + "\n";
            RichTextBoxGeneral.Text += display(e.Result.matAC) + "\n\n";
        }

        public string display(double[,] A)
        {
            int N = A.GetUpperBound(0) + 1;
            string str = "";
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    str += String.Format("{0:F4}\t", A[i, j]);
                }
                str += "\n";
            }
            return str;
        }

        public string display(double[] A)
        {
            int N = A.Length;
            string str = "";
            for (int i = 0; i < N; i++)
            {
                str += String.Format("{0:F4}\t", A[i]);
            }
            str += "\n";

            return str;
        }

        private void GaussElimination_OnNotify(object sender, GaussElimination.GEEventArgs e)
        {
            RichTextBoxGeneral.Text += e.Result.iter_no + " >> " + e.Result.explanation + "\n";
            RichTextBoxGeneral.Text += display(e.Result.matAC) + "\n\n";
        }

        private void Graphical_OnNotify(object sender, Graphical.SEventArgs e)
        {
            ChartGeneral.Series[0].Points.AddXY(e.Result.iter_no, e.Result.err1);
            RichTextBoxGeneral.Text += "<< Iteration " + e.Result.iter_no + " >>  \n" +
                                       "X_0 \t:: " + e.Result.x0 + "\n" +
                                       "F_0 \t:: " + e.Result.f0 + "\n" +
                                       "Error \t:: " + e.Result.err1 + "\n\n";
        }

        private void BiSection_OnNotify(object sender, BiSection.BSEventArgs e)
        {
            ChartGeneral.Series[0].Points.AddXY(e.Result.iter_no, e.Result.err1);
            RichTextBoxGeneral.Text += "<< Iteration " + e.Result.iter_no + " >>  \n" +
                                       "X_left \t:: " + e.Result.x_left + "\n" +
                                       "X_center \t:: " + e.Result.x_center + "\n" +
                                       "X_rigth \t:: " + e.Result.x_rigth + "\n" +
                                       "Fa \t:: " + e.Result.fa + "\n" +
                                       "Fb \t:: " + e.Result.fb + "\n" +
                                       "Fc \t:: " + e.Result.fc + "\n" +
                                       "Error \t:: " + e.Result.err1 + "\n\n";
        }

        private void FalsePosition_OnNotify(object sender, FalsePosition.FPEventArgs e)
        {
            ChartGeneral.Series[0].Points.AddXY(e.Result.iter_no, e.Result.err1);
            RichTextBoxGeneral.Text += "<< Iteration " + e.Result.iter_no + " >>  \n" +
                                       "X_left \t:: " + e.Result.x_left + "\n" +
                                       "X_center \t:: " + e.Result.x_center + "\n" +
                                       "X_rigth \t:: " + e.Result.x_rigth + "\n" +
                                       "Fa \t:: " + e.Result.fa + "\n" +
                                       "Fb \t:: " + e.Result.fb + "\n" +
                                       "Fc \t:: " + e.Result.fc + "\n" +
                                       "Error \t:: " + e.Result.err1 + "\n\n";
        }

        private void SimpleIteration_OnNotify(object sender, SimpleIteration.SIEventArgs e)///????????
        {
        }

        private void Secant_OnNotify(object sender, Secant.SEventArgs e)
        {
            ChartGeneral.Series[0].Points.AddXY(e.Result.iter_no, e.Result.err1);
            RichTextBoxGeneral.Text += "<< Iteration " + e.Result.iter_no + " >>  \n" +
                                       "X_0 \t:: " + e.Result.x0 + "\n" +
                                       "X_1 \t:: " + e.Result.x1 + "\n" +
                                       "X_2 \t:: " + e.Result.x2 + "\n" +
                                       "F0 \t:: " + e.Result.f0 + "\n" +
                                       "F1 \t:: " + e.Result.f1 + "\n" +
                                       "F2 \t:: " + e.Result.f2 + "\n" +
                                       "Error \t:: " + e.Result.err1 + "\n\n";
        }

        private void NewtonRaphson_OnNotify(object sender, NewtonRaphson.NREventArgs e)
        {
            ChartGeneral.Series[0].Points.AddXY(e.Result.iter_no, e.Result.err);
            RichTextBoxGeneral.Text += "<< Iteration " + e.Result.iter_no + " >>  \n" +
                                       "X_i+1 \t:: " + e.Result.x_i_plus_1 + "\n" +
                                       "X_i \t:: " + e.Result.x_i + "\n" +
                                       "F \t:: " + e.Result.F + "\n" +
                                       "dF \t:: " + e.Result.dF + "\n" +
                                       "Error \t:: " + e.Result.err + "\n\n"; 
        }

        public enum Methods
        {
            NewtonRaphson,
            Secant,
            SimpleIteration,
            FalsePosition,
            BiSection,
            Graphical,
            MatrixInverse,
            GaussElimination,
            GaussJordanElimination,
            Simpson13,
            Simpson38,
            Trapezoidal,
            Jacobi,
            GaussSeidel
        }
    }
}
