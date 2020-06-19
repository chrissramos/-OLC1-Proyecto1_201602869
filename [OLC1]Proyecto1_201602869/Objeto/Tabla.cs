using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201602869.Objeto
{
    class Tabla
    {
        String nombre;
        ArrayList columnas;

        public Tabla() { }

        public void setNombre(String nombre) {
            this.nombre = nombre;
        }
        public void setColumnas(ArrayList columnas) {
            this.columnas = columnas;
        }
        public String getNombre() {
            return this.nombre;
        }
        public ArrayList getColumnas() {
            return this.columnas;
        }

    }
}
