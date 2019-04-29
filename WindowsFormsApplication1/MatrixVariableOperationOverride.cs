using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class MatrixVariableOperationOverride : MatrixVariableOperation
    {
        public MatrixVariableOperationOverride(int[,] m1, int[,] m2) : base(m1, m2) { 

        }

        public override decimal[] Overrider(){
            return Operation(MatrixVariableOperation.OPERATION_2);
        }
    }
}
