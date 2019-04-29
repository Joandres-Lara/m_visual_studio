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
    public partial class Form2 : Form
    {
        public const int STRING_VALIDATION = 0;
        public const int INT_VALIDATION = 1;

        public string[] OPERATIONS_STRING = new string[]{
            "Multiplicación: ",
            "Suma y raíz: ",
            "División: ",
            "Raíz: "
        };
        public Form2()
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

        public int[,] GetValuesOfMatrix1(){
            return GetValuesOfMatrix(
                new string[,]{
                    { m3_i0.Text, m3_i1.Text, m3_i2.Text, m3_i3.Text },
                    { m3_i4.Text, m3_i5.Text, m3_i6.Text, m3_i7.Text }
                }
            , 4, 2);
        }

        public int[,] GetValuesOfMatrix2() {
            return GetValuesOfMatrix(
                new string[,] { 
                    { m4_i0.Text, m4_i1.Text, m4_i2.Text, m4_i3.Text, m4_i4.Text, m4_i5.Text },
                    { m4_i6.Text, m4_i7.Text, m4_i8.Text, m4_i9.Text, m4_i10.Text, m4_i11.Text },
                    { m4_i12.Text, m4_i13.Text, m4_i14.Text, m4_i15.Text, m4_i16.Text, m4_i17.Text }, 
                }
            , 6, 3);
        }

        private void button1_Click(object sender, EventArgs e){
            int[,] valuesMatrix1 = GetValuesOfMatrix1();
            int[,] valuesMatrix2 = GetValuesOfMatrix2();

            panelResult2.Visible = true;
            panelResult2.Enabled = true;
            resultPrompt2.Text = "";


            decimal[] result = new decimal[]{};
            int typeOperation = 0;

            if (hasOperation1.Checked){
                typeOperation = 0;
                result = new MatrixVariableOperation(valuesMatrix1, valuesMatrix2).Overrider();
            } else if (hasOperation2.Checked) {
                typeOperation = 1;
                result = new MatrixVariableOperationOverride(valuesMatrix1, valuesMatrix2).Overrider();
            } else if(hasOperation3.Checked){
                typeOperation = 2;
                result = new MatrixVariableOperationOverrideTwo(valuesMatrix1, valuesMatrix2).Overrider();
            } else if(hasOperation4.Checked){
                typeOperation = 3;
                result = new MatrixVariableOperationOverrideThree(valuesMatrix1, valuesMatrix2).Overrider();
            }

            for (int indexResult = 0; indexResult < result.Length; indexResult++){
                resultPrompt2.Text += string.Concat(
                      OPERATIONS_STRING[typeOperation], result[indexResult].ToString("#.#######"), Environment.NewLine
                );
            }
 
        }
    }
}
