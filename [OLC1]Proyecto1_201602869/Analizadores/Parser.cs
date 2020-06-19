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
        public ArrayList listaTablas = new ArrayList();



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
            MessageBox.Show("Tablas Creadas: " + cantidadTablas);
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
                emparejar(18); // identificador
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
                emparejar(25);
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

        public void columnaC() {
            emparejar(18);//id
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
            if (preanalisis.getNumToken() == 21) { // entero
                emparejar(21);
            }
            else if (preanalisis.getNumToken() == 22) { // cadena
                emparejar(22);
            }
            else if (preanalisis.getNumToken() == 23) // fecha
            { // cadena
                emparejar(23);
            }
            else if (preanalisis.getNumToken() == 24) // flotante
            { // cadena
                emparejar(24);
            }

        }

        /*
        public void otraInstruccion() {
            comandos(); 
        }
        public void cuerpoCrear() {
            if (preanalisis.getNumToken() == 20) {
                emparejar(20);//tabla
                emparejar(18); // identificador
                emparejar(1);// parentesis abre 
            }
        }*/
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
