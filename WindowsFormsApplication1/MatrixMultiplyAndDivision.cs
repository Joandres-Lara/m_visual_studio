using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class MatrixMultiplyAndDivision
    {
        public const int DIVISION_TYPE = 0;
        public const int MULTIPLY_TYPE = 1;
        public const int SQUARE_TYPE = 2;
        public const int INVERSE_SQUARE = 3;
        //
        // Estás son las matrices que
        // se van a multiplicar
        public int[,] matrix1;
        public int[,] matrix2;

        //
        // Contiene los índices que se van
        // a multiplicar
        // Códificados,
        // x , y
        // Matriz real: 
        // y
        // ^
        // |----------------
        // |   | x |   |   |
        // |----------------
        // |   |   | x |   |
        // |----------------
        // |   | x | x |   |
        // -----------------> x
        //
        public int[][] indexesMatrix1 = new int [][]{
            new int[]{1, 2},
            new int[]{3, 1},
            new int[]{4, 1},
            new int[]{4, 2}
        };

        //
        // Matriz real
        // y
        // ^
        // |----------------
        // |   |   | x |   |
        // |----------------
        // | x |   |   |   |
        // |----------------
        // |   |   | x |   |
        // |----------------
        // |   | x |   |   |
        // -----------------> x
        public int[][] indexesMatrix2 = new int [][]{
            new int[]{1, 3},
            new int[]{2, 1},
            new int[]{3, 3},
            new int[]{4, 2}
        };

        //
        // Cada que se instancia un objeto se le debe pasar las
        // matrices, para evitar errores, vamos agregar una bandera
        // que llene de ceros los espacios de las matrices en dónde
        // no se haya proporcionado ningún número.
        public MatrixMultiplyAndDivision(int[,] matrix1, int[,] matrix2) {
            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
        }

        //
        // Cambié los tipos para poder
        // ver en la salida, el número con
        // valores decimales.
        public decimal[] Operation(int operationType) {
            //
            // Aquí se puede usar
            // tanto la longitud de la matriz de
            // índices de la primera matriz o de la segunda
            // ambas tienen la misma longitud
            decimal[] resultOperation = new decimal[4] { 0, 0, 0, 0 };

            for (int i = 0; i < this.indexesMatrix1.Length; i++)
            {
                int[] indexesMatrix1 = this.indexesMatrix1[i];
                int[] indexesMatrix2 = this.indexesMatrix2[i];

                //
                // Los índices de las matrices empiezan
                // en 0
                int x1 = indexesMatrix1[0] - 1;
                int y1 = indexesMatrix1[1] - 1;

                int x2 = indexesMatrix2[0] - 1;
                int y2 = indexesMatrix2[1] - 1;

                decimal currentResultOperation = 0;
                int factor1 = this.matrix1[x1, y1];
                int factor2 = this.matrix2[x2, y2];

                switch(operationType){
                    case MULTIPLY_TYPE:
                        currentResultOperation = factor1 * factor2;
                    break;
                    case DIVISION_TYPE:
                        currentResultOperation = Decimal.Divide(factor1, factor2);
                    break;
                    case SQUARE_TYPE:
                        currentResultOperation = (decimal)Math.Sqrt(factor1);
                    break;
                    case INVERSE_SQUARE:
                        //
                        // Obtener la raíz cuadrada del primer elemento
                        // sobre la elevación al cuadrado
                        currentResultOperation = (decimal)(Math.Sqrt(factor1)/(factor1*factor1));
                    break;
                    default: throw new Exception("Can´t not use this operation");
                }

                resultOperation[i] = currentResultOperation;
            }

            return resultOperation;
        }

        virtual public decimal[] Multiply() {
            return Operation(MULTIPLY_TYPE);
        }

        virtual public decimal[] Division() {
            return Operation(DIVISION_TYPE);
        }
    }
}
