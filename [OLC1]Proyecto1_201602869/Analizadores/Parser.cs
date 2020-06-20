using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OLC1_Proyecto1_201602869.Analizadores
{
    class Parser
    {

        // listas para tablas
        public static ArrayList listaTablas = new ArrayList();
        

        //clase de analizador sintactico
        Objeto.Token preanalisis;
        int numPreanalisis;
        int cantidadTablas = 0;
        public void parsear() {
            if (Scanner.listaTokens.Count == 0)
            {
                MessageBox.Show("Lista Tokens Vacia");
            }
            else {
                preanalisis = (Objeto.Token)Scanner.listaTokens[0];
                numPreanalisis = 0;

                //llamar a primer metodo de inicio de gramatica
                inicio();
            }
            
        }

        public void inicio() {
            comandos();
            MessageBox.Show("Analisis Sintactico Completo");
            
        }
        

        public void comandos()
        {

            int numero = preanalisis.getNumToken();
            //MessageBox.Show("El numero es: " + numero);
            // aqui va con ifs
            if (preanalisis.getNumToken() == 19)
            {
                emparejar(19);// crear
                emparejar(20);//tabla
                //MessageBox.Show("nombre de la tabla a crear: " + preanalisis.getLexema());
                // tiene que ser objeto tabla
                Objeto.Tabla tablaNueva = new Objeto.Tabla();
                tablaNueva.setNombre(preanalisis.getLexema());
                ArrayList lista = new ArrayList();
                tablaNueva.setColumnas(lista);
                listaTablas.Add(tablaNueva);
                emparejar(18); // identificador
                
                // este identificador es el nombre de la tabla

                //Objeto.Tabla nuevaT = new Objeto.Tabla();
                
                emparejar(1);// parentesis abre
                columnaC();
                masColumnaC();
                emparejar(2);// parentesis cierra
                emparejar(5);//punto y coma
                comandos();
                cantidadTablas++;


            }
            else if (preanalisis.getNumToken() == 25)
            { // insertar
                //INSERTAR EN Estudiantes VALORES(0,”Pepito Gímenez”,’02/02/2012’);
                emparejar(25); // insertar
                emparejar(26);// en 
                emparejar(18);// id
                emparejar(27);//valores
                emparejar(1);//par (
                insertarUno();
                insertarDos();
                emparejar(2);//par)
                emparejar(5);//punto y coma
                comandos();
            }
            else if (preanalisis.getNumToken() == 28)//seleccionar 
            {

            }
            else if (preanalisis.getNumToken() == 34)//eliminar 
            {

            }
            else if (preanalisis.getNumToken() == 35)// actualizar
            {

            }
            else
            {

            }
        }
        public void insertarUno() {
            if (preanalisis.getNumToken() == 12) { // entero
                emparejar(12);// entero
                
            }
            else if (preanalisis.getNumToken() == 17)
            { // cadena
                emparejar(17);// cadena
            }
            else if (preanalisis.getNumToken() == 15)
            { // fecha
                emparejar(15);// fecha
            }
            else if (preanalisis.getNumToken() == 14)
            { // flotante
                emparejar(14);// flotante
            }
        }
        public void insertarDos() {
            if (preanalisis.getNumToken() == 6)
            {
                //MessageBox.Show("otro valor");
                emparejar(6);//coma
                insertarUno();
                insertarDos();
            }
            else { }
        }
        public void columnaC() {
            Objeto.Columna col = new Objeto.Columna();
            col.setNombreCol(preanalisis.getLexema());
            Objeto.Tabla tablaTemp = (Objeto.Tabla)listaTablas[listaTablas.Count - 1];
            ArrayList valoresC = new ArrayList();
            col.setValores(valoresC);
            //tablaTemp.setColumnas(col);
            ArrayList colTemp = tablaTemp.getColumnas();

            colTemp.Add(col);
            tablaTemp.setColumnas(colTemp); // actualizar columnas 

            //listaTablas[listaTablas.Count - 1] = tablaTemp; // actualizar tabla 
            emparejar(18);//id nombre columna
            tipoC();
        }
        public void masColumnaC() {
            if (preanalisis.getNumToken() == 6)
            {
                emparejar(6);// coma;
                columnaC();
                masColumnaC();
            }
            else {
            }
           
            
        }
        public void tipoC() {

            Objeto.Tabla tablaTemp = (Objeto.Tabla)listaTablas[listaTablas.Count - 1];
            ArrayList listaColumnas = tablaTemp.getColumnas();
            Objeto.Columna columna = (Objeto.Columna)listaColumnas[listaColumnas.Count - 1];


            if (preanalisis.getNumToken() == 21) { // entero
                //MessageBox.Show("Se asignara entero a:" + columna.getNombreCol());
                columna.setTipo("entero");
                listaColumnas[listaColumnas.Count - 1] = columna;
                emparejar(21);
            }
            else if (preanalisis.getNumToken() == 22) { // cadena
                //MessageBox.Show("Se asignara cadena a:" + columna.getNombreCol());
                columna.setTipo("cadena");
                emparejar(22);
            }
            else if (preanalisis.getNumToken() == 23) // fecha
            { // cadena
                //MessageBox.Show("Se asignara fecha a:" + columna.getNombreCol());
                columna.setTipo("fecha");
                emparejar(23);
            }
            else if (preanalisis.getNumToken() == 24) // flotante
            { // cadena
               
                //MessageBox.Show("Se asignara flotante a:" + columna.getNombreCol());
                columna.setTipo("flotante");
                emparejar(24);
            }
        }

     
        public void emparejar(int numToken) {
            
            if (numToken == preanalisis.getNumToken())
            {
                // si se esperaba eso, esta bien, no se hace nada
            }
            else {
                //error sintactico
                //MessageBox.Show("Se esperaba: " + tokenTipo + " y viene:" + preanalisis.getTipo() + " en:" + numPreanalisis);
                // crear error y guardarlo en lista errores
                MessageBox.Show("Error sintactico, Se esperaba : " + numToken + " vino:" + preanalisis.getNumToken());
            }
            if (numPreanalisis < Scanner.listaTokens.Count) {
                numPreanalisis += 1;
                try
                {
                    preanalisis = (Objeto.Token)Scanner.listaTokens[numPreanalisis];
                }
                catch (Exception e)
                {

                    
                }
            }
        }

    }
}
