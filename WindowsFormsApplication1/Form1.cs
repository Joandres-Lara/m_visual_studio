using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public const int STRING_VALIDATION = 0;
        public const int INT_VALIDATION = 1;
        public Form1()
        {
            InitializeComponent();
        }

        //
        // Valida las entradas de texto
        // Acepta tipos
        private bool HasValidText(string str, int typeValidation = STRING_VALIDATION) {
            switch(typeValidation){
                case INT_VALIDATION:
                    int output = 0;
                    return int.TryParse(str, out output);
                case STRING_VALIDATION: return !(string.IsNullOrWhiteSpace(str) && string.IsNullOrEmpty(str));
                default: throw new Exception("{typeValidation} not suported!!");
            }
        }

        //
        // Valida el texto como número
        public bool HasValidInt(string str) {
            return HasValidText(str, INT_VALIDATION);
        }

        //
        // Convierte los valores de de una matriz
        // de tipo string, a valores de tipo int
        // si hay algún valor del texto que no es válida
        // lanzará una excepción
        public int[,] GetValuesOfMatrix(string[,] matrix, int x = 0, int y = 0) {
            //
            // Fuerza la conversión
            // y crea un array vacío con las dimensiones específicas
            int[,] output = (int[,])Array.CreateInstance(typeof(System.Int32), y, x);
            int positionX = x;
            int positionY = y;
            bool hasValidText = true;

            for( int index = 0; index < positionY; index++ ){
                int dimensionPosition = 0;
                while( dimensionPosition < positionX ){
                    string currentValue = matrix[index, dimensionPosition];
                    if (!HasValidInt(currentValue)) {
                        hasValidText = false;
                        break;
                    }
                    output[index, dimensionPosition] = int.Parse(currentValue);
                    dimensionPosition++;
                }

                if (!hasValidText) {
                    break;
                }
            }

            if (!hasValidText) {
                throw new Exception("Can't is a int");
            }

            return output;
        }

        //
        // Convierte los valores a
        // int
        public int[,] GetValuesOfMatrix1() {
            return GetValuesOfMatrix(
                new string[,]{
                    { m1_i0.Text, m1_i1.Text, m1_i2.Text },
                    { m1_i3.Text, m1_i4.Text, m1_i5.Text },
                    { m1_i6.Text, m1_i7.Text, m1_i8.Text },
                    { m1_i9.Text, m1_i10.Text, m1_i11.Text }
                }
            , 3, 4);
        }

        //
        // Convierte los valores a int
        public int[,] GetValuesOfMatrix2() {
            return GetValuesOfMatrix(
                new string[,] { 
                    { m2_i0.Text, m2_i1.Text, m2_i2.Text, m2_i3.Text },
                    { m2_i4.Text, m2_i5.Text, m2_i6.Text, m2_i7.Text },
                    { m2_i8.Text, m2_i9.Text, m2_i10.Text, m2_i11.Text },
                    { m2_i12.Text, m2_i13.Text, m2_i14.Text, m2_i15.Text }
                }
            , 4, 4);            
        }

        private void button1_Click(object sender, EventArgs e){

            int[,] matrix1 = GetValuesOfMatrix1();
            int[,] matrix2 = GetValuesOfMatrix2();

            resultPrompt.Text = "";
            panelResult.Visible = true;
            panelResult.Enabled = true;

            if ( optionMultiply.Checked ){
                MatrixMultiplyAndDivision objProd = new MatrixMultiplyAndDivision(matrix1, matrix2);

                decimal[] resultMultiply = objProd.Multiply();
                decimal[] resultDivision = objProd.Division();

                for(int indexResult = 0; indexResult < resultMultiply.Length; indexResult++){
                    resultPrompt.Text += string.Concat(
                          "Multiplicación: ", resultMultiply[indexResult].ToString("#.##"), " "
                        , "División: ", resultDivision[indexResult].ToString("#.##"), Environment.NewLine
                    );
                }
            }

            if( optionSquare.Checked ){
                MatrixSquare objProd2 = new MatrixSquare(matrix1, matrix2); 
                decimal[] resultOverrideMultiply = objProd2.Multiply();
                decimal[] resultOverrideDivision = objProd2.Division();

                for (int indexResult = 0; indexResult < resultOverrideMultiply.Length; indexResult++){
                    resultPrompt.Text += string.Concat(
                          "Raíz: ", resultOverrideMultiply[indexResult].ToString("#.#######"), " "
                        , "Potencia: ", resultOverrideDivision[indexResult].ToString("#.#######"), Environment.NewLine
                    );
                }
            }
        }
    }
}
