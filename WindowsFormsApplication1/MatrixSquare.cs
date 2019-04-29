using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class MatrixSquare : MatrixMultiplyAndDivision
    {
        public MatrixSquare(int[,] m1, int[,] m2) : base(m1, m2) { }

        public override decimal[] Multiply(){
            return Operation(MatrixMultiplyAndDivision.SQUARE_TYPE);
        }

        public override decimal[] Division(){
            return Operation(MatrixMultiplyAndDivision.INVERSE_SQUARE);
        }
    }
}
