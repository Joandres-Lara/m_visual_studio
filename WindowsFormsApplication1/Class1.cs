using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class MatrixMultiply
    {
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
        public MatrixMultiply(int[,] matrix1, int[,] matrix2) {
            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
        }

        public float[] Multiply() {
            //
            // Aquí se puede usar
            // tanto la longitud de la matriz de
            // índices de la primera matriz o de la segunda
            // ambas tienen la misma longitud
            float[] resultOperation = new float[4]{0,0,0,0};

            for (int i = 0; i < this.indexesMatrix1.Length; i++){
                int[] indexesMatrix1 = this.indexesMatrix1[i];
                int[] indexesMatrix2 = this.indexesMatrix2[i];

                //
                // Los índices de las matrices empiezan
                // en 0
                int x1 = indexesMatrix1[0] - 1;
                int y1 = indexesMatrix1[1] - 1;

                int x2 = indexesMatrix2[0] - 1;
                int y2 = indexesMatrix2[1] - 1;

                float currentIndexMultiplyResult = this.matrix1[x1, y1] * this.matrix2[x2, y2];

                resultOperation[i] = currentIndexMultiplyResult;
            }

            return resultOperation;
        }
    }
}
