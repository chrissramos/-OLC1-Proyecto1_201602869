using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201602869.Objeto
{
    class Columna
    {
        String nombreCol;
        String tipo;
        ArrayList valores;
        public Columna() {
        }

        public void setNombreCol(String nombreCol) {
            this.nombreCol = nombreCol;
        }
        public void setValores(ArrayList valores) {
            this.valores = valores;
        }
        public void setTipo(String tipo)
        {
            this.tipo = tipo;
        }
        public String getTipo()
        {
            return this.tipo;
        }
        public String getNombreCol() {
            return this.nombreCol;
        }
        public ArrayList getValores() {
            return this.valores;
        }
    }
}
