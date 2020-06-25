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

        // bandera recuperar
        bool banderaRecu = true;


        //VARIABLES PARA ELIMINAR
        String nombreDatoEliminar = "";
        String condicionalEliminar = "";

        float condicionEliminarNumeroDecimal = 0;
        int condicionEliminarNumeroEntero = 0;
        String condicionEliminarCadena = "";

        ArrayList listaO = new ArrayList();
        ArrayList listaY = new ArrayList(); 


        // listas para tablas
        public static ArrayList listaTablas = new ArrayList();



        String tablaInsertar = ""; // nombre de tabla actual a insertar
        String tablaEliminar = ""; // tabla para comando Eliminar
        

        // para actualizar
        String tablaActualizar = "";
        ArrayList listaCamposAct = new ArrayList();
        ArrayList listaValoresCamposAct = new ArrayList();
        String nombreDatoActualizar = "";
        float condicionActualizarNumeroDecimal = 0;
        int condicionActualizarNumeroEntero = 0;
        String condicionActualizarCadena = "";

        int contadorColumna = 0;

        // para seleccionar
        public static String tablaSeleccionar = "";
        public static ArrayList tablaSel = new ArrayList();
        public static bool todaTabla = false;
        public static bool comandoSeleccionar = false;

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

        public void eliminarRegistros() {

            ArrayList listaNoRep = new ArrayList();

            for (int i = 0; i < listaO.Count; i++)
            {


                int elemento = (int)listaO[i];
                Console.WriteLine("Elemento en lista 1: " + elemento );
                bool contiene = listaNoRep.Contains(elemento);
                if (contiene.Equals(false))
                {
                    listaNoRep.Add(elemento);
                }
                else { // si lo tiene
                }

            }
            for (int j = 0; j < listaNoRep.Count; j++)
            {
                int elemento = (int)listaNoRep[j];
                Console.WriteLine("Elemento en lista DOS: " + elemento);
                
            }


            for (int i = 0; i < listaTablas.Count; i++)
            {
                Objeto.Tabla tablaBuscar = (Objeto.Tabla)listaTablas[i];
                if (tablaBuscar.getNombre().Equals(tablaEliminar))
                {
                   
                   
                    ArrayList listaColumnas = tablaBuscar.getColumnas();

                    //ArrayList listaValoresColumna = columna.getValores();
                    for (int j = 0; j < listaColumnas.Count; j++)
                    {



                        Objeto.Columna columna = (Objeto.Columna)listaColumnas[j];
                        MessageBox.Show("Estamos en columna: " + columna.getNombreCol());

                        // 
                        ArrayList listaValores = columna.getValores();

                        for (int m = 0; m < listaNoRep.Count; m++)
                        {
                            int element = (int)listaNoRep[m];
                            for (int p = 0; p < listaValores.Count; p++)
                            {
                                if (element == p)
                                {
                                    listaValores[p] = "";
                                }
                            }
                        }


                        
                    }
                }
            }

            listaO.Clear();
        }

        public void actualizarRegistros() {
            // vamos a imprimir lo que se va a actualizar
            Console.WriteLine("Se va a actualizar la tabla: " + tablaActualizar + " Nuevos valores:");

            for (int i = 0; i < listaCamposAct.Count; i++)
            {
                Console.WriteLine(listaCamposAct[i] + " = " + listaValoresCamposAct[i]);
            }
            Console.WriteLine("Datos en lista O " + listaO.Count);
            ArrayList listaNoRep = new ArrayList();
            for (int i = 0; i < listaO.Count; i++)
            {


                int elemento = (int)listaO[i];
                Console.WriteLine("Elemento en lista 1: " + elemento);
                bool contiene = listaNoRep.Contains(elemento);
                if (contiene.Equals(false))
                {
                    listaNoRep.Add(elemento);
                }
                else
                { // si lo tiene
                }

            }
            for (int j = 0; j < listaNoRep.Count; j++)
            {
                int elemento = (int)listaNoRep[j];
                Console.WriteLine("Elemento en lista DOS: " + elemento);

            }

            for (int i = 0; i < listaTablas.Count; i++)
            {
                Objeto.Tabla tablaBuscar = (Objeto.Tabla)listaTablas[i];
                if (tablaBuscar.getNombre().Equals(tablaActualizar))
                {


                    ArrayList listaColumnas = tablaBuscar.getColumnas();
                    for (int p = 0; p < listaCamposAct.Count; p++)
                    {
                        String valorColumna = listaCamposAct[p].ToString();
                        String valorCelda = listaValoresCamposAct[p].ToString();
                        for (int j = 0; j < listaColumnas.Count; j++)
                        {
                            Objeto.Columna columna = (Objeto.Columna)listaColumnas[j];
                            //MessageBox.Show("Estamos en columna: " + columna.getNombreCol());
                            //int posicionAct = (int)listaNoRep[j];
                            if (valorColumna.Equals(columna.getNombreCol())) 
                            {
                                MessageBox.Show("columnas iguales " + columna.getNombreCol() + " y " + valorColumna);
                                ArrayList listaDatosColumna = columna.getValores();
                                for (int y = 0; y < listaNoRep.Count; y++)
                                {
                                    int posicionAct = (int)listaNoRep[y];
                                    listaDatosColumna[posicionAct] = valorCelda;
                                }
                                
                            }
                        }
                    }
                    //ArrayList listaValoresColumna = columna.getValores();
                    
                }
            }


            listaO.Clear();
        }

        public void seleccionTabla() {
            if (todaTabla.Equals(true))
            {
                for (int i = 0; i < listaTablas.Count; i++)
                {
                    Objeto.Tabla tablaActual = (Objeto.Tabla)Analizadores.Parser.listaTablas[i];
                    if (tablaActual.getNombre().Equals(tablaSeleccionar))
                    {
                        ArrayList listaColumnas = tablaActual.getColumnas();
                        
                        for (int j = 0; j < listaColumnas.Count; j++)
                        {
                            Objeto.Columna columna = (Objeto.Columna)listaColumnas[j];
                            

                        }
                    }
                }
            }
        }

        public void comandos()
        {
            banderaRecu = true;
            int numero = preanalisis.getNumToken();
            //MessageBox.Show("El numero es: " + numero);
            // aqui va con ifs
            if (preanalisis.getNumToken() == 19) // crear
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

                comandos(); //INS
                cantidadTablas++;


            }
            else if (preanalisis.getNumToken() == 25) // insertar
            { // insertar
                //INSERTAR EN Estudiantes VALORES(0,”Pepito Gímenez”,’02/02/2012’);
                emparejar(25); // insertar
                emparejar(26);// en 
                tablaInsertar = preanalisis.getLexema();
                //MessageBox.Show("Tabla a meter datos: " + tablaInsertar);
                emparejar(18);// id
                emparejar(27);//valores
                emparejar(1);//par (
                insertarUno();
                insertarDos();
                emparejar(2);//par)
                emparejar(5);//punto y coma
                contadorColumna = 0;
                tablaInsertar = "";
                comandos();
            }
            else if (preanalisis.getNumToken() == 28)//seleccionar 
            {
                emparejar(28);// seleccionar
                cuerpoSel();
                emparejar(30); // de
                tablaSeleccionar = preanalisis.getLexema();
                emparejar(18); // id nombre tabla
                emparejar(5); // ;
                comandoSeleccionar = true;
                //tablaSeleccionar = "";
                comandos();
            }
            else if (preanalisis.getNumToken() == 34)//eliminar 
            {
                emparejar(34);// eliminar
                emparejar(30);//de
                tablaEliminar = preanalisis.getLexema();
                emparejar(18); // identificador
                cuerpoEl();
                eliminarRegistros();
                emparejar(5);// ;
                tablaEliminar = "";
                comandos();
            }
            else if (preanalisis.getNumToken() == 35)// actualizar
            {
                emparejar(35); // actualizar
                tablaActualizar = preanalisis.getLexema();
                emparejar(18); //id
                emparejar(36); // establecer
                emparejar(1); // (
                actUno();
                actDos();
                emparejar(2); // )
                emparejar(31);// donde
                cuerpoAct();
                actualizarRegistros();
                emparejar(5);//
                tablaActualizar = "";
                comandos();

            }
            else
            {

            }
        }

        public void cuerpoSel() {
            if (preanalisis.getNumToken()==4)//*
            {
                todaTabla = true;

                emparejar(4);

            }
            else if (preanalisis.getNumToken()== 18)
            {
                
            }
        }

        public void actUno() {
            listaCamposAct.Add(preanalisis.getLexema());
            emparejar(18);//id nombre del campo que se buscara para actualizar
            emparejar(3);//=
            datoAct();
        }
        public void datoAct() {
            // aqui agarro el valor del campo que se busca actualizara
            listaValoresCamposAct.Add(preanalisis.getLexema());
            if (preanalisis.getNumToken() == 12)
            { // entero
                
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
        
        public void actDos() {
            if (preanalisis.getNumToken() == 6)
            {
                emparejar(6);// coma;
                actUno();
                actDos();
            }
            else
            {
            }
        }
        public void cuerpoAct() {
            if (preanalisis.getNumToken() == 18)
            { // id
                //nombreDatoEliminar = preanalisis.getLexema();
                nombreDatoActualizar = preanalisis.getLexema();
                emparejar(18);//id
                condicionales(); //condicionales
                datoActDos();
                cuerpoAct();
            }
            else if (preanalisis.getNumToken() == 32) // Y
            {

                emparejar(32);//Y 

                cuerpoAct();
            }
            else if (preanalisis.getNumToken() == 33) // O
            {

                emparejar(33);//O 
                              //nombreDatoEliminar = preanalisis.getLexema();

                cuerpoAct();
            }
            else {
            }
            

        }
        public void datoActDos()
        {// igual al valorcondicion
            if (preanalisis.getNumToken() == 12) //Digito entero
            {
                condicionActualizarNumeroEntero = Int32.Parse(preanalisis.getLexema());
                 //MessageBox.Show("Vamos a actualizar de tabla: " + tablaActualizar + " el campo:" + nombreDatoActualizar + " " + condicionalEliminar + " " + condicionActualizarNumeroEntero);
                emparejar(12);
            }
            else if (preanalisis.getNumToken() == 14) // flotante
            {
                condicionActualizarNumeroDecimal = float.Parse(preanalisis.getLexema());
                //MessageBox.Show("Vamos a actualizar de tabla: " + tablaActualizar + " el campo:" + nombreDatoActualizar + " " + condicionalEliminar + " " + condicionActualizarNumeroDecimal);
                emparejar(14);
            }
            else if (preanalisis.getNumToken() == 15) //fecha
            {
                condicionActualizarCadena = preanalisis.getLexema();
                //MessageBox.Show("Vamos a actualizar de tabla: " + tablaActualizar + " el campo:" + nombreDatoActualizar + " " + condicionalEliminar + " " + condicionActualizarCadena);
                emparejar(15);
            }
            else if (preanalisis.getNumToken() == 17) //cadena
            {
                condicionActualizarCadena = preanalisis.getLexema();
               // MessageBox.Show("Vamos a actualizar de tabla: " + tablaActualizar + " el campo:" + nombreDatoActualizar + " " + condicionalEliminar + " " + condicionActualizarCadena);
                

                emparejar(17);// cadena
            }
            else { }

            // vamos a recorrer la tabla y columnas para llenar listaO y luego trabajar en metodo actualizarRegistros()
            for (int i = 0; i < listaTablas.Count; i++)
            {
                Objeto.Tabla tablaBuscar = (Objeto.Tabla)listaTablas[i];
                
                if (tablaBuscar.getNombre().Equals(tablaActualizar))
                {
                   // MessageBox.Show("Estamos en tabla: " + tablaActualizar);
                    ArrayList listaColumnas = tablaBuscar.getColumnas();
                    for (int j = 0; j < listaColumnas.Count; j++)
                    {
                        Objeto.Columna columna = (Objeto.Columna)listaColumnas[j];
                        //MessageBox.Show("Estamos en columna: " + columna.getNombreCol());
                        if (columna.getNombreCol().Equals(nombreDatoActualizar))
                        {
                            ArrayList listaValoresColumna = columna.getValores();
                            for (int l = 0; l < listaValoresColumna.Count; l++)
                            {
                                String datoEnCol = listaValoresColumna[l].ToString();
                                //MessageBox.Show("Estamos en:" + datoEnCol);
                                if (columna.getTipo().Equals("cadena") || columna.getTipo().Equals("fecha"))
                                {
                                    if (condicionalEliminar.Equals("="))
                                    {
                                        if (datoEnCol.Equals(condicionActualizarCadena))
                                        {
                                            // /  //indiceRegistro = l;
                                             //MessageBox.Show("Se encontro registro IGUAL  en posicion: " + l + " dato que se busca: " + condicionEliminarCadena + " = " + datoEnCol);
                                            
                                            listaO.Add(l);
                                        }
                                    }
                                    else if (condicionalEliminar.Equals("!="))
                                    {
                                        if (!datoEnCol.Equals(condicionActualizarCadena))
                                        {
                                            //indiceRegistro = l;
                                           // MessageBox.Show("Se encontro registro No igual cadena o fecha a eliminar en posicion: " + l);
                                            
                                            listaO.Add(l);
                                        }
                                    }
                                }

                                else if ((columna.getTipo().Equals("flotante")))
                                {
                                    // ver > , < , >= , <=, = , != 
                                    if (condicionalEliminar.Equals(">"))
                                    {
                                        float datoCol = float.Parse(datoEnCol);
                                        if (datoCol > condicionActualizarNumeroDecimal)
                                        {
                                            //MessageBox.Show("Se encontro registro flotante a eliminar en posicion: " + l);
                                            
                                            listaO.Add(l);
                                        }
                                    }
                                    else if (condicionalEliminar.Equals("<"))
                                    {
                                        float datoCol = float.Parse(datoEnCol);
                                        if (datoCol < condicionActualizarNumeroDecimal)
                                        {
                                           // MessageBox.Show("Se encontro registro flotante a eliminar en posicion: " + l);
                                            
                                            listaO.Add(l);
                                        }
                                    }
                                    else if (condicionalEliminar.Equals(">="))
                                    {
                                        float datoCol = float.Parse(datoEnCol);
                                        if (datoCol >= condicionActualizarNumeroDecimal)
                                        {
                                             //MessageBox.Show("Se encontro registro flotante a eliminar en posicion: " + l);
                                            
                                            listaO.Add(l);
                                        }
                                    }
                                    else if (condicionalEliminar.Equals("<="))
                                    {
                                        float datoCol = float.Parse(datoEnCol);
                                        if (datoCol <= condicionActualizarNumeroDecimal)
                                        {
                                            // MessageBox.Show("Se encontro registro flotante a eliminar en posicion: " + l);
                                            
                                            listaO.Add(l);
                                        }
                                    }
                                    else if (condicionalEliminar.Equals("="))
                                    {
                                        float datoCol = float.Parse(datoEnCol);
                                        if (datoCol == condicionActualizarNumeroDecimal)
                                        {
                                            //indiceRegistro = l;
                                            // MessageBox.Show("Se encontro registro flotante a eliminar en posicion: " + l);
                                            
                                            listaO.Add(l);
                                        }
                                    }
                                    else if (condicionalEliminar.Equals("!="))
                                    {
                                        float datoCol = float.Parse(datoEnCol);
                                        if (datoCol != condicionActualizarNumeroDecimal)
                                        {
                                            //indiceRegistro = l;
                                            // MessageBox.Show("Se encontro registro flotante a eliminar en posicion: " + l);
                                            
                                            listaO.Add(l);
                                        }
                                    }
                                }
                                /// entero
                                else if (columna.getTipo().Equals("entero"))
                                {
                                    // ver > , < , >= , <=, = , != 
                                    if (condicionalEliminar.Equals(">"))
                                    {

                                        int datoCol = Int32.Parse(datoEnCol);
                                        if (datoCol > condicionActualizarNumeroEntero)
                                        {
                                            //MessageBox.Show("Se encontro registro entero a eliminar en posicion: " + l);
                                            
                                            listaO.Add(l);
                                        }
                                    }
                                    else if (condicionalEliminar.Equals("<"))
                                    {
                                        int datoCol = Int32.Parse(datoEnCol);
                                        if (datoCol < condicionActualizarNumeroEntero)
                                        {
                                            // MessageBox.Show("Se encontro registro entero a eliminar en posicion: " + l);
                                           
                                            listaO.Add(l);
                                        }
                                    }
                                    else if (condicionalEliminar.Equals(">="))
                                    {
                                        int datoCol = Int32.Parse(datoEnCol);
                                        if (datoCol >= condicionActualizarNumeroEntero)
                                        {
                                           // MessageBox.Show("Se encontro registro entero a eliminar en posicion: " + l);
                                            
                                            listaO.Add(l);
                                        }
                                    }
                                    else if (condicionalEliminar.Equals("<="))
                                    {
                                        int datoCol = Int32.Parse(datoEnCol);
                                        if (datoCol <= condicionActualizarNumeroEntero)
                                        {
                                            // MessageBox.Show("Se encontro registro entero a eliminar en posicion: " + l);
                                            
                                            listaO.Add(l);
                                        }
                                    }
                                    else if (condicionalEliminar.Equals("="))
                                    {
                                        int datoCol = Int32.Parse(datoEnCol);
                                        if (datoCol == condicionActualizarNumeroEntero)
                                        {
                                            //indiceRegistro = l;
                                           //  MessageBox.Show("Se encontro registro entero a eliminar en posicion: " + l);
                                            
                                            listaO.Add(l);
                                        }
                                    }
                                    else if (condicionalEliminar.Equals("!="))
                                    {
                                        int datoCol = Int32.Parse(datoEnCol);
                                        if (datoCol != condicionActualizarNumeroEntero)
                                        {
                                            //indiceRegistro = l;
                                            // MessageBox.Show("Se encontro registro entero a eliminar en posicion: " + l);
                                            
                                            listaO.Add(l);
                                        }
                                    }
                                }




                            }
                        }

                    }
                }
            }

        }
        
        public void valorCondicion() {
            if (preanalisis.getNumToken() == 12) //Digito entero
            {
                condicionEliminarNumeroEntero = Int32.Parse(preanalisis.getLexema());
               // MessageBox.Show("Vamos a eliminar de tabla: " + tablaEliminar + " el campo:" + nombreDatoEliminar + " " + condicionalEliminar + " " + condicionEliminarNumeroEntero);
                emparejar(12);
            }
            else if (preanalisis.getNumToken() == 14) // flotante
            {
                condicionEliminarNumeroDecimal = float.Parse(preanalisis.getLexema());
               // MessageBox.Show("Vamos a eliminar de tabla: " + tablaEliminar + " el campo:" + nombreDatoEliminar + " " + condicionalEliminar + " " + condicionEliminarNumeroDecimal);
                emparejar(14);
            }
            else if (preanalisis.getNumToken() == 15) //fecha
            {
                condicionEliminarCadena = preanalisis.getLexema();
               // MessageBox.Show("Vamos a eliminar de tabla: " + tablaEliminar + " el campo:" + nombreDatoEliminar + " " + condicionalEliminar + " " + condicionEliminarCadena);
                emparejar(15);
            }
            else if (preanalisis.getNumToken() == 17) //cadena
            {
                condicionEliminarCadena = preanalisis.getLexema();
              //  MessageBox.Show("Vamos a eliminar de tabla: " + tablaEliminar + " el campo:" + nombreDatoEliminar + " " + condicionalEliminar + " " + condicionEliminarCadena);
                // aqui eliminar :v 
                
                emparejar(17);// cadena
            }
            else { }

            // aqui se podria intentar el eliminar 1

            int indiceTabla = 0;
            int indiceRegistro = 0;
            ArrayList listaRegistros = new ArrayList();
            for (int i = 0; i < listaTablas.Count; i++)
            {
                Objeto.Tabla tablaBuscar = (Objeto.Tabla)listaTablas[i];
                if (tablaBuscar.getNombre().Equals(tablaEliminar))
                {
                    indiceTabla = i;
                    //MessageBox.Show("Vamos a eliminar todos los datos de: " + tablaBuscar.getNombre());
                    ArrayList listaColumnas = tablaBuscar.getColumnas();

                    //
                    for (int j = 0; j < listaColumnas.Count; j++)
                    {
                        Objeto.Columna columna = (Objeto.Columna)listaColumnas[j];

                      //  MessageBox.Show("Estamos en columna: " + columna.getNombreCol());
                        if (columna.getNombreCol().Equals(nombreDatoEliminar))
                        {
                            // estamos en la columna a eliminar
                            ArrayList listaValoresColumna = columna.getValores();
                            int posicionValor = 0;
                            for (int l = 0; l < listaValoresColumna.Count; l++)
                            {
                                
                                String datoEnCol = listaValoresColumna[l].ToString();
                               // MessageBox.Show("Estamos en:" + datoEnCol );
                                posicionValor++;
                                if (columna.getTipo().Equals("cadena") || columna.getTipo().Equals("fecha"))
                                {
                                    //ver el condicional = o !=
                                    if (condicionalEliminar.Equals("=")) {
                                        if (!datoEnCol.Equals(""))
                                        {
                                            if (datoEnCol.Equals(condicionEliminarCadena))
                                            {
                                                // /  //indiceRegistro = l;
                                                // MessageBox.Show("Se encontro registro IGUAL  en posicion: " + l + " dato que se busca: " + condicionEliminarCadena + " = " + datoEnCol);
                                                listaRegistros.Add(l);
                                                listaO.Add(l);
                                            }
                                        }
                                        
                                    } else if (condicionalEliminar.Equals("!=")) {
                                        if (!datoEnCol.Equals(""))
                                        {
                                            if (!datoEnCol.Equals(condicionEliminarCadena))
                                            {
                                                //indiceRegistro = l;
                                                //MessageBox.Show("Se encontro registro No igual cadena o fecha a eliminar en posicion: " + l);
                                                listaRegistros.Add(l);
                                                listaO.Add(l);
                                            }
                                        }
                                        
                                    }
                                    
                                }
                                else if (columna.getTipo().Equals("flotante")) {
                                    // ver > , < , >= , <=, = , != 
                                    if (condicionalEliminar.Equals(">"))
                                    {
                                        if (!datoEnCol.Equals(""))
                                        {
                                            float datoCol = float.Parse(datoEnCol);
                                            if (datoCol > condicionEliminarNumeroDecimal)
                                            {
                                                //MessageBox.Show("Se encontro registro flotante a eliminar en posicion: " + l);
                                                listaRegistros.Add(l);
                                                listaO.Add(l);
                                            }
                                        }
                                        
                                    }
                                    else if (condicionalEliminar.Equals("<"))
                                    {
                                        if (!datoEnCol.Equals(""))
                                        {
                                            float datoCol = float.Parse(datoEnCol);
                                            if (datoCol < condicionEliminarNumeroDecimal)
                                            {
                                                //MessageBox.Show("Se encontro registro flotante a eliminar en posicion: " + l);
                                                listaRegistros.Add(l);
                                                listaO.Add(l);
                                            }
                                        }
                                        
                                    }
                                    else if (condicionalEliminar.Equals(">="))
                                    {
                                        if (!datoEnCol.Equals(""))
                                        {
                                            float datoCol = float.Parse(datoEnCol);
                                            if (datoCol >= condicionEliminarNumeroDecimal)
                                            {
                                                // MessageBox.Show("Se encontro registro flotante a eliminar en posicion: " + l);
                                                listaRegistros.Add(l);
                                                listaO.Add(l);
                                            }
                                        }
                                        
                                    }
                                    else if (condicionalEliminar.Equals("<="))
                                    {
                                        if (!datoEnCol.Equals(""))
                                        {
                                            float datoCol = float.Parse(datoEnCol);
                                            if (datoCol <= condicionEliminarNumeroDecimal)
                                            {
                                                // MessageBox.Show("Se encontro registro flotante a eliminar en posicion: " + l);
                                                listaRegistros.Add(l);
                                                listaO.Add(l);
                                            }
                                        }
                                        
                                    }
                                    else if (condicionalEliminar.Equals("="))
                                    {
                                        if (!datoEnCol.Equals(""))
                                        {
                                            float datoCol = float.Parse(datoEnCol);
                                            if (datoCol == condicionEliminarNumeroDecimal)
                                            {
                                                //indiceRegistro = l;
                                                // MessageBox.Show("Se encontro registro flotante a eliminar en posicion: " + l);
                                                listaRegistros.Add(l);
                                                listaO.Add(l);
                                            }
                                        }
                                        
                                    }
                                    else if (condicionalEliminar.Equals("!="))
                                    {
                                        if (!datoEnCol.Equals(""))
                                        {
                                            float datoCol = float.Parse(datoEnCol);
                                            if (datoCol != condicionEliminarNumeroDecimal)
                                            {
                                                //indiceRegistro = l;
                                                // MessageBox.Show("Se encontro registro flotante a eliminar en posicion: " + l);
                                                listaRegistros.Add(l);
                                                listaO.Add(l);
                                            }
                                        }
                                        
                                    }
                                    

                                }
                                else if (columna.getTipo().Equals("entero")) {
                                    // ver > , < , >= , <=, = , != 
                                    if (condicionalEliminar.Equals(">"))
                                    {
                                        if (!datoEnCol.Equals(""))
                                        {
                                            int datoCol = Int32.Parse(datoEnCol);
                                            if (datoCol > condicionEliminarNumeroEntero)
                                            {
                                                //MessageBox.Show("Se encontro registro entero a eliminar en posicion: " + l);
                                                listaRegistros.Add(l);
                                                listaO.Add(l);
                                            }
                                        }
                                        
                                    }
                                    else if (condicionalEliminar.Equals("<"))
                                    {
                                        if (!datoEnCol.Equals(""))
                                        {
                                            int datoCol = Int32.Parse(datoEnCol);
                                            if (datoCol < condicionEliminarNumeroEntero)
                                            {
                                                // MessageBox.Show("Se encontro registro entero a eliminar en posicion: " + l);
                                                listaRegistros.Add(l);
                                                listaO.Add(l);
                                            }
                                        }
                                        
                                    }
                                    else if (condicionalEliminar.Equals(">="))
                                    {
                                        if (!datoEnCol.Equals(""))
                                        {
                                            int datoCol = Int32.Parse(datoEnCol);
                                            if (datoCol >= condicionEliminarNumeroEntero)
                                            {
                                                //MessageBox.Show("Se encontro registro entero a eliminar en posicion: " + l);
                                                listaRegistros.Add(l);
                                                listaO.Add(l);
                                            }
                                        }
                                        
                                    }
                                    else if (condicionalEliminar.Equals("<="))
                                    {
                                        if (!datoEnCol.Equals(""))
                                        {
                                            int datoCol = Int32.Parse(datoEnCol);
                                            if (datoCol <= condicionEliminarNumeroEntero)
                                            {
                                                // MessageBox.Show("Se encontro registro entero a eliminar en posicion: " + l);
                                                listaRegistros.Add(l);
                                                listaO.Add(l);
                                            }
                                        }
                                        
                                    }
                                    else if (condicionalEliminar.Equals("="))
                                    {
                                        if (!datoEnCol.Equals(""))
                                        {
                                            int datoCol = Int32.Parse(datoEnCol);
                                            if (datoCol == condicionEliminarNumeroEntero)
                                            {
                                                //indiceRegistro = l;
                                                // MessageBox.Show("Se encontro registro entero a eliminar en posicion: " + l);
                                                listaRegistros.Add(l);
                                                listaO.Add(l);
                                            }
                                        }
                                        
                                    }
                                    else if (condicionalEliminar.Equals("!="))
                                    {
                                        if (!datoEnCol.Equals(""))
                                        {
                                            int datoCol = Int32.Parse(datoEnCol);
                                            if (datoCol != condicionEliminarNumeroEntero)
                                            {
                                                //indiceRegistro = l;
                                                // MessageBox.Show("Se encontro registro entero a eliminar en posicion: " + l);
                                                listaRegistros.Add(l);
                                                listaO.Add(l);
                                            }
                                        }
                                        
                                    }
                                }
                               
                            }
                        }
                        // aqui borramos dato listacolumna [listaRegistros.get(valoresdentro)]
                        //ArrayList valoresVacios = new ArrayList();
                        //columna.setValores(valoresVacios);
                    }
                    // aqui es de eliminar en las columnas



                }
            }



        }
        public void condicionElim()
        {
            if (preanalisis.getNumToken() == 18)
            { // id
                nombreDatoEliminar = preanalisis.getLexema();
                emparejar(18);//id
                condicionales();
                valorCondicion();
                condicionElim();
            }
            else if (preanalisis.getNumToken() == 32) // Y
            {

                emparejar(32);//Y 
                //nombreDatoEliminar = preanalisis.getLexema();
                //emparejar(18);//id
                //condicionales();
                //valorCondicion();
                condicionElim();
            }
            else if (preanalisis.getNumToken() == 33) // O
            {

                emparejar(33);//O 
                              // nombreDatoEliminar = preanalisis.getLexema();
                              //emparejar(18);//id
                              //condicionales();
                              //valorCondicion();
                condicionElim();
            }
            ///MessageBox.Show("APAREZCOOO ");
        }
        public void cuerpoEl()
        {
            if (preanalisis.getNumToken() == 31)
            { // DONDE
                emparejar(31); // 'donde'
                condicionElim();

            }
            else
            {
                // aqui elimino todos los datos de la tabla
                int indiceTabla = 0;

                for (int i = 0; i < listaTablas.Count; i++)
                {
                    Objeto.Tabla tablaBuscar = (Objeto.Tabla)listaTablas[i];
                    if (tablaBuscar.getNombre().Equals(tablaEliminar))
                    {
                        indiceTabla = i;
                        // MessageBox.Show("Vamos a eliminar todos los datos de: " + tablaBuscar.getNombre());
                        ArrayList listaColumnas = tablaBuscar.getColumnas();

                        //ArrayList listaValoresColumna = columna.getValores();
                        for (int j = 0; j < listaColumnas.Count; j++)
                        {
                            Objeto.Columna columna = (Objeto.Columna)listaColumnas[j];
                            //MessageBox.Show("Estamos en columna: " + columna.getNombreCol());
                            // 
                            ArrayList valoresVacios = new ArrayList();
                            columna.setValores(valoresVacios);
                        }
                    }
                }


            }
        }

        public void condicionales()
        {
            if (preanalisis.getNumToken() == 10) //>
            {
                condicionalEliminar = preanalisis.getLexema();
                emparejar(10);
            }
            else if (preanalisis.getNumToken() == 11) //<
            {
                condicionalEliminar = preanalisis.getLexema();
                emparejar(10);
            }
            else if (preanalisis.getNumToken() == 8) //>=
            {
                condicionalEliminar = preanalisis.getLexema();
                emparejar(8);
            }
            else if (preanalisis.getNumToken() == 9) //<=
            {
                condicionalEliminar = preanalisis.getLexema();
                emparejar(9);// <=
            }
            else if (preanalisis.getNumToken() == 3)
            { // =
                condicionalEliminar = preanalisis.getLexema();
                emparejar(3); // =
            }
            else { }
        }
        public void insertarUno() {
            //aqui buscar tabla y columnas
            int indiceTabla = 0;

            for (int i = 0; i < listaTablas.Count; i++)
            {
                Objeto.Tabla tablaBuscar= (Objeto.Tabla)listaTablas[i];
                if (tablaBuscar.getNombre().Equals(tablaInsertar)) {
                    indiceTabla = i;
                }
            }
            Objeto.Tabla tablaU = (Objeto.Tabla)listaTablas[indiceTabla];
            
            ArrayList listaColumnas = tablaU.getColumnas();
            Objeto.Columna columna = (Objeto.Columna)listaColumnas[contadorColumna];
            ArrayList listaValoresColumna = columna.getValores();
            
            

            if (preanalisis.getNumToken() == 12) { // entero
                //MessageBox.Show("Se metera en columna, dato " + columna.getNombreCol() + preanalisis.getLexema());
                listaValoresColumna.Add(preanalisis.getLexema());
                columna.setValores(listaValoresColumna);
                contadorColumna++;
                emparejar(12);// entero
                
            }
            else if (preanalisis.getNumToken() == 17)
            { // cadena
                //MessageBox.Show("Se metera en columna, dato " + columna.getNombreCol() + preanalisis.getLexema());
                listaValoresColumna.Add(preanalisis.getLexema());
                columna.setValores(listaValoresColumna);
                contadorColumna++;
                emparejar(17);// cadena
            }
            else if (preanalisis.getNumToken() == 15)
            { // fecha
                //MessageBox.Show("Se metera en columna, dato " + columna.getNombreCol() + preanalisis.getLexema());
                listaValoresColumna.Add(preanalisis.getLexema());
                columna.setValores(listaValoresColumna);
                contadorColumna++;
                emparejar(15);// fecha
            }
            else if (preanalisis.getNumToken() == 14)
            { // flotante
               // MessageBox.Show("Se metera en columna, dato " + columna.getNombreCol() + preanalisis.getLexema());
                listaValoresColumna.Add(preanalisis.getLexema());
                columna.setValores(listaValoresColumna);
                contadorColumna++;
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
        public void recuperar() {
            while (preanalisis.getNumToken()!= 5)
            {
                if (numPreanalisis < Scanner.listaTokens.Count)
                {
                    numPreanalisis += 1;

                    preanalisis = (Objeto.Token)Scanner.listaTokens[numPreanalisis];
                    MessageBox.Show("Va consumiendo: " + preanalisis.getLexema());
                }
            }
            try
            {
                preanalisis = (Objeto.Token)Scanner.listaTokens[numPreanalisis];
            }
            catch (Exception e)
            {


            }
        }
     
        public void emparejar(int numToken) {
            if (banderaRecu.Equals(true))
            {
                if (numToken == preanalisis.getNumToken())
                {
                    // si se esperaba eso, esta bien, no se hace nada
                }
                else
                {
                    //error sintactico
                    //MessageBox.Show("Se esperaba: " + tokenTipo + " y viene:" + preanalisis.getTipo() + " en:" + numPreanalisis);

                    // crear error y guardarlo en lista errores
                    MessageBox.Show("Error sintactico, Se esperaba : " + numToken + " vino:" + preanalisis.getNumToken());
                    Objeto.ErrorLS errorLS = new Objeto.ErrorLS();
                    errorLS.setTipo("Sintactico");
                    errorLS.setLexema("No tenia que venir: " + preanalisis.getLexema());
                    errorLS.setLinea(preanalisis.getLinea());
                    errorLS.setColumna(preanalisis.getColumna());
                    Scanner.listaErrores.Add(errorLS);

                    
                    recuperar();
                    banderaRecu = false;
                }

                if (numPreanalisis < Scanner.listaTokens.Count)
                {
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
            else { }
            
        }

    }
}
