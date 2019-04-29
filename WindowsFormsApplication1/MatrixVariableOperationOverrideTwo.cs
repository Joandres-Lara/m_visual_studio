using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class MatrixVariableOperationOverrideTwo : MatrixVariableOperation
    {
        public MatrixVariableOperationOverrideTwo(int[,] m1, int[,] m2) : base(m1, m2) { }

        public override decimal[] Overrider(){
            return Operation(OPERATION_3);
        }
    }
}
