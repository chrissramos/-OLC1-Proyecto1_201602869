﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OLC1_Proyecto1_201602869
{
    public partial class Form1 : Form
    {
        static Analizadores.Scanner scan = new Analizadores.Scanner();
        static Analizadores.Parser parser = new Analizadores.Parser();
        ArrayList listaHtml = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }
        String rutaActiva = "";
        int contadorColumna = 0;
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {// abrir archivos
            openFileDialog1.Filter = "CargarTablas (*.sqle)|*.sqle|Consultas (*.rcrs)|*.rcrs";
            openFileDialog1.FilterIndex = 2;

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                rutaActiva = openFileDialog1.FileName;
                
                System.IO.StreamReader sr = new System.IO.StreamReader(rutaActiva, System.Text.Encoding.Default);
                string texto;
                texto = sr.ReadToEnd();
                sr.Close();
                txtArchivo.Text = texto;
                openFileDialog1.Dispose();

            }
            else if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                openFileDialog1.Dispose();
            }
        }

        private void cargarTablasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CargarTablas (*.sqle)|*.sqle";
            openFileDialog1.FilterIndex = 2;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rutaActiva = openFileDialog1.FileName;
                
                System.IO.StreamReader sr = new System.IO.StreamReader(rutaActiva, System.Text.Encoding.Default);
                string texto;
                texto = sr.ReadToEnd();
                sr.Close();
                txtArchivo.Text = texto;
                openFileDialog1.Dispose();

            }
            else if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                openFileDialog1.Dispose();
            }
        }

        private void ejecutarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //analisis lexico

            String textoSeleccionado = txtArchivo.SelectedText;
            MessageBox.Show("Texto Seleccionado: " + textoSeleccionado);

            Analizadores.Scanner.listaTokens.Clear();
            String textoCompleto = textoSeleccionado + " ";
            scan.recibeTexto(textoCompleto);
            
            //////// analisis sintactico
            parser.parsear();

            llenarData();
            if (Analizadores.Parser.listaTablas.Count>0) {
                MessageBox.Show("Cantidad tablas : " + Analizadores.Parser.listaTablas.Count);
            }
            /*
            for (int i = 0; i < Analizadores.Parser.listaTablas.Count; i++)
            {
                Objeto.Tabla tablaRec = (Objeto.Tabla)Analizadores.Parser.listaTablas[i];
                
                listaTablas.Items.Add(tablaRec.getNombre());
            }*/

            // ver columnas

            

            // obtener elemento seleccionado
            
            //String columnaSeleccionada = listBoxColumnas.SelectedItem.ToString();
            
            

        }
        private void btnTabla_Click(object sender, EventArgs e)
        {
            listBoxColumnas.Items.Clear();
            if (listaTablas.Items.Count > 0)
            {
                String tablaSel = listaTablas.SelectedItem.ToString();
               // MessageBox.Show("tabla seleccionada: " + tablaSel);
                for (int i = 0; i < Analizadores.Parser.listaTablas.Count; i++)
                {
                    Objeto.Tabla tablaRec = (Objeto.Tabla)Analizadores.Parser.listaTablas[i];
                    if (tablaRec.getNombre().Equals(tablaSel)) {
                        //MessageBox.Show("Encontramos tabla ");
                        ArrayList listaColumnas = tablaRec.getColumnas();
                        //MessageBox.Show("Tabla tiene columnas " + listaColumnas.Count);
                        for (int j = 0; j < listaColumnas.Count; j++)
                        {
                            Objeto.Columna columna = (Objeto.Columna)listaColumnas[j];
                            listBoxColumnas.Items.Add(columna.getNombreCol());

                        }
                    }
                }
            }
        }
        private void btnTipo_Click(object sender, EventArgs e)
        {
            if (listBoxColumnas.Items.Count>0)
            {
                String tablaSel = listaTablas.SelectedItem.ToString();
                String columnaSel = listBoxColumnas.SelectedItem.ToString();
                for (int i = 0; i < Analizadores.Parser.listaTablas.Count; i++)
                {
                    Objeto.Tabla tablaRec = (Objeto.Tabla)Analizadores.Parser.listaTablas[i];
                    if (tablaRec.getNombre().Equals(tablaSel))
                    {
                        //MessageBox.Show("Encontramos tabla ");
                        ArrayList listaColumnas = tablaRec.getColumnas();
                        //MessageBox.Show("Tabla tiene columnas " + listaColumnas.Count);
                        for (int j = 0; j < listaColumnas.Count; j++)
                        {
                            
                            Objeto.Columna columna = (Objeto.Columna)listaColumnas[j];

                            if (columna.getNombreCol().Equals(columnaSel)) {
                                lblTipo.Text = columna.getTipo();
                                
                            }
                            //MessageBox.Show("Nombre columna: " + columna.getNombreCol());
                            

                        }
                    }
                }


            }
        }

        private void mostrarTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // hacer el html y mostarlo
            StreamWriter ofile;
            ofile = File.CreateText("./Tokens.html");
            ofile.WriteLine("<html>");
            ofile.WriteLine("<head>");
            ofile.WriteLine("<style>");
            ofile.WriteLine("table {");
            ofile.WriteLine("width:50%;");
            ofile.WriteLine("}");
            ofile.WriteLine("table, th, td {");
            ofile.WriteLine("border: 1px solid black;");
            ofile.WriteLine("border-collapse: collapse;");
            ofile.WriteLine("}");
            ofile.WriteLine("th, td {");
            ofile.WriteLine("padding: 5px;");
            ofile.WriteLine("text-align: left;");
            ofile.WriteLine("table#t01 tr:nth-child(even) {");
            ofile.WriteLine(" background-color: #eee;");
            ofile.WriteLine("}");
            ofile.WriteLine("table#t01 tr:nth-child(odd) {");
            ofile.WriteLine("background-color:#fff;");
            ofile.WriteLine("}");
            ofile.WriteLine("table#t01 th {");
            ofile.WriteLine("background-color: black;");
            ofile.WriteLine("color: white;");
            ofile.WriteLine("}");
            ofile.WriteLine("");
            ofile.WriteLine("");
            ofile.WriteLine("");
            ofile.WriteLine("");

            ofile.WriteLine("</style>");
            ofile.WriteLine("</head>");

            ofile.WriteLine("<body bgcolor= '#00CCFF'>");
            ofile.WriteLine("<center>");
            ofile.WriteLine("<h1>Tokens:</h1>");
            ofile.WriteLine("<table>");
            ofile.WriteLine("<tr>");
            ofile.WriteLine("<th>Token</th> ");
            ofile.WriteLine("<th>Tipo</th> ");
            ofile.WriteLine("<th>Lexema</th>");
            ofile.WriteLine("<th>Linea</th>");
            ofile.WriteLine("<th>Columna</th>");
            ofile.WriteLine("</tr>");

            // datos
            
            for (int i = 0; i < Analizadores.Scanner.listaTokens.Count; i++)
            {
                Objeto.Token t = (Objeto.Token)Analizadores.Scanner.listaTokens[i];

                ofile.WriteLine("<tr>");

                ofile.WriteLine("<td>" + t.getNumToken() + "</td>");
                ofile.WriteLine("<td>" + t.getTipo() + "</td>");
                ofile.WriteLine("<td>" + t.getLexema() + "</td>");
                ofile.WriteLine("<td>" + t.getLinea()+ "</td>");
                ofile.WriteLine("<td>" + t.getColumna() + "</td>");

                ofile.WriteLine(" </tr>");
            }


            // fin datos

            ofile.WriteLine("</table>");
            ofile.WriteLine("</center>");
            ofile.WriteLine("<h2 >" + "Cantidad de Tokens: " + Analizadores.Scanner.listaTokens.Count + " </h2>");

            ofile.WriteLine("</body>");
            ofile.WriteLine("</html>");
            ofile.Close();

            //Process.Start(".//Tokens.html");
            String pathTokens = Path.Combine(Application.StartupPath, "Tokens.html");
            Process.Start(pathTokens);
        }

        private void mostrarErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter ofile;
            ofile = File.CreateText("./Errores.html");
            ofile.WriteLine("<html>");
            ofile.WriteLine("<head>");
            ofile.WriteLine("<style>");
            ofile.WriteLine("table {");
            ofile.WriteLine("width:50%;");
            ofile.WriteLine("}");
            ofile.WriteLine("table, th, td {");
            ofile.WriteLine("border: 1px solid black;");
            ofile.WriteLine("border-collapse: collapse;");
            ofile.WriteLine("}");
            ofile.WriteLine("th, td {");
            ofile.WriteLine("padding: 5px;");
            ofile.WriteLine("text-align: left;");
            ofile.WriteLine("table#t01 tr:nth-child(even) {");
            ofile.WriteLine(" background-color: #eee;");
            ofile.WriteLine("}");
            ofile.WriteLine("table#t01 tr:nth-child(odd) {");
            ofile.WriteLine("background-color:#fff;");
            ofile.WriteLine("}");
            ofile.WriteLine("table#t01 th {");
            ofile.WriteLine("background-color: black;");
            ofile.WriteLine("color: white;");
            ofile.WriteLine("}");
            ofile.WriteLine("");
            ofile.WriteLine("");
            ofile.WriteLine("");
            ofile.WriteLine("");

            ofile.WriteLine("</style>");
            ofile.WriteLine("</head>");

            ofile.WriteLine("<body bgcolor= '#00CCFF'>");
            ofile.WriteLine("<center>");
            ofile.WriteLine("<h1>Errores:</h1>");
            ofile.WriteLine("<table>");
            ofile.WriteLine("<tr>");
            ofile.WriteLine("<th>Tipo Error</th> ");
            ofile.WriteLine("<th>Descripcion</th>");
            ofile.WriteLine("<th>Linea</th>");
            ofile.WriteLine("<th>Columna</th>");
            ofile.WriteLine("</tr>");

            // datos
            for (int i = 0; i < Analizadores.Scanner.listaErrores.Count; i++)
            {
                Objeto.ErrorLS t = (Objeto.ErrorLS)Analizadores.Scanner.listaErrores[i];

                ofile.WriteLine("<tr>");
                
                ofile.WriteLine("<td>" + t.getTipo() + "</td>");
                ofile.WriteLine("<td>" + t.getLexema() + "</td>");
                ofile.WriteLine("<td>" + t.getLinea() + "</td>");
                ofile.WriteLine("<td>" + t.getColumna() + "</td>");

                ofile.WriteLine(" </tr>");
            }


            // fin datos

            ofile.WriteLine("</table>");
            ofile.WriteLine("</center>");

            ofile.WriteLine("<h2 >" + "Cantidad de Errores: " + Analizadores.Scanner.listaErrores.Count + " </h2>");
            ofile.WriteLine("</body>");
            ofile.WriteLine("</html>");
            ofile.Close();

            String pathErrores = Path.Combine(Application.StartupPath, "Errores.html");
            Process.Start(pathErrores);
        }

        public String obtenerObjeto(ArrayList lista, int posicion) {
            String objeto = lista[posicion].ToString();
            return objeto;

        }

        private void verTablasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter ofile;
            ofile = File.CreateText("./Tablas.html");
            ofile.WriteLine("<html>");
            ofile.WriteLine("<head>");
            ofile.WriteLine("<style>");
            ofile.WriteLine("table {");
            ofile.WriteLine("width:50%;");
            ofile.WriteLine("}");
            ofile.WriteLine("table, th, td {");
            ofile.WriteLine("border: 1px solid black;");
            ofile.WriteLine("border-collapse: collapse;");
            ofile.WriteLine("}");
            ofile.WriteLine("th, td {");
            ofile.WriteLine("padding: 5px;");
            ofile.WriteLine("text-align: left;");
            ofile.WriteLine("table#t01 tr:nth-child(even) {");
            ofile.WriteLine(" background-color: #eee;");
            ofile.WriteLine("}");
            ofile.WriteLine("table#t01 tr:nth-child(odd) {");
            ofile.WriteLine("background-color:#fff;");
            ofile.WriteLine("}");
            ofile.WriteLine("table#t01 th {");
            ofile.WriteLine("background-color: black;");
            ofile.WriteLine("color: white;");
            ofile.WriteLine("}");
            ofile.WriteLine("");
            ofile.WriteLine("");
            ofile.WriteLine("");
            ofile.WriteLine("");

            ofile.WriteLine("</style>");
            ofile.WriteLine("</head>");

            ofile.WriteLine("<body bgcolor= '#00CCFF'>");
            ofile.WriteLine("<center>");
            ofile.WriteLine("<h1>Tablas:</h1>");
            ofile.WriteLine("</br>");
            //las tablas es por cantidad de elementos en listaTablas
            for (int i = 0; i < Analizadores.Parser.listaTablas.Count; i++)
            {
                Objeto.Tabla tablaActual = (Objeto.Tabla)Analizadores.Parser.listaTablas[i];
                ofile.WriteLine("<h1>Tablas " + tablaActual.getNombre()  +" </h1>");
                ofile.WriteLine("<table>");
                ofile.WriteLine("<tr>");
                // los th son las columnas
                ArrayList listaColumnas = tablaActual.getColumnas();
                //MessageBox.Show("Tabla tiene columnas " + listaColumnas.Count);
                for (int j = 0; j < listaColumnas.Count; j++)
                {
                    Objeto.Columna columna = (Objeto.Columna)listaColumnas[j];
                    ofile.WriteLine("<th> " + columna.getNombreCol()+  "</th> ");
                    
                }


                //MessageBox.Show("cantidad de columnas " + listaColumnas.Count);
                if (listaColumnas.Count>0) {
                    int contadorAux = 0;
                    for (int k = 0; k < listaColumnas.Count; k++)
                    {
                       // Console.WriteLine("Valor de K " + k);
                        Objeto.Columna columnaA = (Objeto.Columna)listaColumnas[k];
                        ArrayList listaDatoCol = columnaA.getValores();
                     
                        
                        for (int l = 0; l < listaDatoCol.Count; l++)
                        {

                            String contenido = listaDatoCol[l].ToString();
                            if (!contenido.Equals(""))
                            {
                                listaHtml.Add(contenido);
                            }
                            //Console.WriteLine("Dato sacado: " + contenido);
                            

                        }


                    }
                    //contadorAux++;
                    //contadorAux = 0;
                    

                }
                //Console.WriteLine("Cantidad en arrayHtml " + listaHtml.Count);
                //recorrer listahtml
                for (int o = 0; o < listaHtml.Count; o++)
                {
                   // Console.WriteLine("Dato ordenado: " + listaHtml[o].ToString());
                }


                //OPERACION
                // cantidad registros / cantidad de datos en una columna
                if (listaHtml.Count>0) {
                    int contadorColumnasss = listaColumnas.Count - 1;
                    int operacion = listaHtml.Count / listaColumnas.Count;
                    int contadorTok = 0;
                    //MessageBox.Show("Tabla: " + tablaActual.getNombre() + " Cantidad Registros: " + listaHtml.Count + " Cantidad Datos en 1 columna: " + listaColumnas.Count );
                    //MessageBox.Show("Datos por Linea : " + listaHtml.Count + " / " + contadorColumnasss + " = " + operacion);
                   // MessageBox.Show("Se creara matriz de " + listaColumnas.Count + "x" + operacion);
                    String[,] matrix = new String[listaColumnas.Count,operacion];
                    for (int p = 0; p < listaColumnas.Count; p++)
                    {
                        for (int u = 0; u < operacion; u++)
                        {
                            matrix[p,u] = listaHtml[contadorTok].ToString();
                           // Console.WriteLine("Se agrego a pos: " + u + "," +p + " :" + listaHtml[contadorTok].ToString());
                            contadorTok++;
                        }
                    }
                    // recorrer matrix

                    for (int t = 0; t < operacion; t++)
                    {
                        ofile.WriteLine("<tr>");
                        for (int y = 0; y < listaColumnas.Count; y++)
                        {
                            //matrix[p, u] = listaHtml[contadorTok].ToString();
                           // Console.WriteLine("Tenemos : " + matrix[y,t]);
                            ofile.WriteLine("<td>" + matrix[y,t] + "</td>");
                            //contadorTok++;
                        }
                        ofile.WriteLine(" </tr>");
                    }
                    

                }

                listaHtml.Clear();
                
                // fin th columnas
                ofile.WriteLine("</tr>");
            

                // fin datos

                ofile.WriteLine("</table>");
                // fin tabla 
            }



            ofile.WriteLine("</center>");

            
            ofile.WriteLine("</body>");
            ofile.WriteLine("</html>");
            ofile.Close();

            String pathErrores = Path.Combine(Application.StartupPath, "Tablas.html");
            Process.Start(pathErrores);
        }

        public  void llenarData() {
            ArrayList listaHTML = new ArrayList();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            int cantidadFilas = 0;
            if (Analizadores.Parser.comandoSeleccionar.Equals(true))
            {
                if (Analizadores.Parser.todaTabla.Equals(true))
                {
                    //MessageBox.Show("Vamos a seleccionar toda la tabla: " + Analizadores.Parser.tablaSeleccionar );
                    String nombreTablaS = Analizadores.Parser.tablaSeleccionar;
                    for (int i = 0; i < Analizadores.Parser.listaTablas.Count; i++) {
                        Objeto.Tabla tablaActual = (Objeto.Tabla)Analizadores.Parser.listaTablas[i];

                        if (tablaActual.getNombre().Equals(nombreTablaS))
                        {
                            MessageBox.Show("Vamos a seleccionar toda la tabla: " + Analizadores.Parser.tablaSeleccionar);
                            ArrayList listaColumnas = tablaActual.getColumnas();
                           // dataGridView1.ColumnCount = listaColumnas.Count;
                            dataGridView1.ColumnHeadersVisible = true;
                            AdjustDataGridViewSizing();
                            //DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

                            //columnHeaderStyle.BackColor = Color.Aqua;
                            //columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
                            //dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;


                            //MessageBox.Show("Tabla tiene columnas " + listaColumnas.Count);

                            for (int j = 0; j < listaColumnas.Count; j++)
                            {
                                Objeto.Columna columna = (Objeto.Columna)listaColumnas[j];
                                cantidadFilas = columna.getValores().Count;
                                dataGridView1.Columns.Add(columna.getNombreCol(), columna.getNombreCol());
                                // j = numero de columna 
                                ArrayList listaFilas = columna.getValores(); /// count lista filas es numero de fila
                                //////////
                                ///
                                if (listaFilas.Count>0)
                                {
                                    for (int p = 0; p < listaFilas.Count; p++)
                                    {
                                       // dataGridView1[j, p].Value = listaFilas[p].ToString();
                                    }
                                }
                                

                            }

                            dataGridView1.Rows.Add(cantidadFilas);

                            // aqui agrego filas
                            for (int q = 0; q < listaColumnas.Count; q++)
                            {
                                Objeto.Columna columna = (Objeto.Columna)listaColumnas[q];
                                cantidadFilas = columna.getValores().Count;
                                //dataGridView1.Columns.Add(columna.getNombreCol(), columna.getNombreCol());
                                // j = numero de columna 
                                ArrayList listaFilas = columna.getValores(); /// count lista filas es numero de fila
                                //////////
                                ///
                                if (listaFilas.Count > 0)
                                {
                                    for (int w = 0; w < listaFilas.Count; w++)
                                    {
                                         dataGridView1[q, w].Value = listaFilas[w].ToString();
                                    }
                                }


                            }

                        }

                    }

                    //MessageBox.Show("Columnassss: " + dataGridView1.ColumnCount);
                    
                }
            }
        }
        private void AdjustDataGridViewSizing()
        {
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //dataGridView1.Columns[ratingColumn].Width = 50;

        }

        private void txtArchivo_TextChanged(object sender, EventArgs e)
        {
            this.CheckKeyword("TABLA", Color.Purple, 0);
            this.CheckKeyword("INSERTAR", Color.Purple, 0);
            this.CheckKeyword("ELIMINAR", Color.Purple, 0);
            this.CheckKeyword("MODIFICAR", Color.Purple, 0);

            this.CheckKeyword(">", Color.Red, 0);
            this.CheckKeyword("<", Color.Red, 0);
            this.CheckKeyword(">=", Color.Red, 0);
            this.CheckKeyword("<=", Color.Red, 0);
            this.CheckKeyword("=", Color.Red, 0);
            this.CheckKeyword("!=", Color.Red, 0);

            //this.CheckKeyword("0", Color.Blue, 0);
            

            for (int i = 0; i < Analizadores.Scanner.listaTokens.Count; i++)
            {
                Objeto.Token tok = (Objeto.Token)Analizadores.Scanner.listaTokens[i];
                String tipoLex = tok.getTipo();
                int numToken = tok.getNumToken();
                switch (numToken)
                {
                    case 15:
                        this.CheckKeyword(tok.getLexema(), Color.Orange, 0);
                        break;
                    case 12:
                        this.CheckKeyword(tok.getLexema(), Color.Blue, 0);
                        break;
                    case 14:
                        this.CheckKeyword(tok.getLexema(), Color.Blue, 0);
                        break;
                    case 17:
                        this.CheckKeyword(tok.getLexema(), Color.Green, 0);
                        break;
                    case 13:
                        this.CheckKeyword(tok.getLexema(), Color.Gray, 0);
                        break;
                    case 16:
                        this.CheckKeyword(tok.getLexema(), Color.Gray, 0);
                        break;
                    case 18:
                        this.CheckKeyword(tok.getLexema(), Color.Brown, 0);
                        break;
                    default:
                        break;
                }
            }
            

        }
        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.txtArchivo.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.txtArchivo.SelectionStart;

                while ((index = this.txtArchivo.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.txtArchivo.Select((index + startIndex), word.Length);
                    this.txtArchivo.SelectionColor = color;
                    this.txtArchivo.Select(selectStart, 0);
                    this.txtArchivo.SelectionColor = Color.Black;
                }
            }
        }

        private void manualUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String pathErrores = Path.Combine(Application.StartupPath, "ManualUsuario.pdf");
            Process.Start(pathErrores);
        }

        private void manualTecnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String pathErrores = Path.Combine(Application.StartupPath, "ManualTecnico.pdf");
            Process.Start(pathErrores);
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Realizado por: Randall Chriss Ramos Saucedo / 201602869");
        }
    }
}
