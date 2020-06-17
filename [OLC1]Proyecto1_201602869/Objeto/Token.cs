using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201602869.Objeto
{
    class Token
    {
        String lexema;
        String tipo;
        int linea;
        int columna;
        int numToken;

        public Token() {
        }

        public String getLexema() {
            return this.lexema;
        }
        public String getTipo() {
            return this.tipo;
        }
        public int getLinea() {
            return this.linea;
        }
        public int getColumna() {
            return this.columna;
        }
        public int getNumToken() {
            return this.numToken;
        }

        public void setLexema(String lexema) {
            this.lexema = lexema;
        }
        public void setTipo(String tipo) {
            this.tipo = tipo;
        }
        public void setLinea(int linea) {
            this.linea = linea;
        }
        public void setColumna(int columna) {
            this.columna = columna;
        }
        public void setNumToken(int numToken) {
            this.numToken = numToken;
        }

    }
}
