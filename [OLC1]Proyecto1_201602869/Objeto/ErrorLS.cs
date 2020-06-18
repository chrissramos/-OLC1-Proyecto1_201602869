using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201602869.Objeto
{
    class ErrorLS
    {
        String tipo;
        
        String lexema;
        int linea;
        int columna;

        public ErrorLS() { }


        
        public String getLexema()
        {
            return this.lexema;
        }
        public String getTipo()
        {
            return this.tipo;
        }
        public int getLinea()
        {
            return this.linea;
        }
        public int getColumna()
        {
            return this.columna;
        }

      

        public void setLexema(String lexema)
        {
            this.lexema = lexema;
        }
        public void setTipo(String tipo)
        {
            this.tipo = tipo;
        }
        public void setLinea(int linea)
        {
            this.linea = linea;
        }
        public void setColumna(int columna)
        {
            this.columna = columna;
        }
      

    }
}
