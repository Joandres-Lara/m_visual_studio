using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class MatrixVariableOperation
    {
        public const int OPERATION_1 = 0;
        public const int OPERATION_2 = 1;
        public const int OPERATION_3 = 2;
        public const int OPERATION_4 = 4;
        //
        // Contiene los índices que se van
        // a multiplicar
        // Códificados,
        // x , y
        // Matriz real: 
        // y
        // ^
        // |----------------
        // |   | 1 |   | 2 |
        // |----------------
        // |   |   | 3 |   |
        // -----------------> x
        //
        public int[][] indexesMatrix1 = new int[][]{ 
            new int[]{1, 2},
            new int[]{1, 4},
            new int[]{2, 3}
        };

        //
        // Contiene los índices que se van
        // a multiplicar
        // Códificados,
        // x , y
        // Matriz real: 
        // y
        // ^
        // |------------------------
        // |   |   |   | 1 |   | 2 |
        // |------------------------
        // |   |   |   | 3 |   |   |
        // |------------------------
        // |   |   |   | 1 |   | 3 |
        // --------------------------> x
        //
        // Está matriz, controlará todas las operaciones
        // por ser la de longitud mayor
        public int[][] indexesMatrix2 = new int[][]{ 
            new int[]{1, 4, 1},
            new int[]{3, 4, 1},
            new int[]{1, 6, 2},
            new int[]{2, 4, 3},
            new int[]{3, 6, 3}
        };

        protected int[,] matrix1;
        protected int[,] matrix2;

        public MatrixVariableOperation(int[,] matrix1, int[,] matrix2) {
            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
        }

        public int[][] GetValuesByOperation() {
            int[][] output = (int[][])Array.CreateInstance(typeof(int[]), this.indexesMatrix2.Length);

            for (int i = 0; i < this.indexesMatrix2.Length; i++) {
                int[] indexesControl = this.indexesMatrix2[i];

                int x1 = indexesControl[0] - 1;
                int y1 = indexesControl[1] - 1;

                int indexByOtherMatrix = indexesControl[2] - 1;

                int x2 = this.indexesMatrix1[indexByOtherMatrix][0] - 1;
                int y2 = this.indexesMatrix1[indexByOtherMatrix][1] - 1;

                int factor1 = this.matrix2[x1, y1];
                int factor2 = this.matrix1[x2, y2];

                output[i] = new int[]{ factor1, factor2 };
            }

            return output;
        }

        public decimal[] Operation(int operationType){
            int[][] valuesOperation = GetValuesByOperation();
            decimal[] output = (decimal[])Array.CreateInstance(typeof(System.Decimal), 5);
            for(int index = 0; index < valuesOperation.Length; index++ ) {
                int factor1 = valuesOperation[index][0];
                int factor2 = valuesOperation[index][1];
                switch (operationType) { 
                    case OPERATION_1:
                        //
                        // Multiplicación
                        output[index] = factor1*factor2;
                    break;
                    case OPERATION_2:
                        //
                        // Suma y raíz cuadrada
                        output[index] = (decimal)(Math.Sqrt(factor1 + factor2));
                    break;
                    case OPERATION_3:
                        //
                        // Operación inversa del primer método
                        output[index] = (decimal)(factor1/factor2);
                    break;
                    case OPERATION_4:
                        //
                        // Sólo raíz cuadrada
                        output[index] = (decimal)(Math.Sqrt(factor1));
                    break;
                    default: throw new Exception("{typeOperation} not supported");
                }
            }
            return output;
        }

        virtual public decimal[] Overrider() {
            return Operation(OPERATION_1);
        }
    }
}
