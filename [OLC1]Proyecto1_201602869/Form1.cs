using System;
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
        Analizadores.Scanner scan = new Analizadores.Scanner();
        public Form1()
        {
            InitializeComponent();
        }
        String rutaActiva = "";
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
            
            scan.recibeTexto(txtArchivo.Text);
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
            for (int i = 0; i < scan.listaTokens.Count; i++)
            {
                Objeto.Token t = (Objeto.Token)scan.listaTokens[i];

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
            ofile.WriteLine("<h2 >" + "Cantidad de Tokens: " + scan.listaTokens.Count + " </h2>");

            ofile.WriteLine("</body>");
            ofile.WriteLine("</html>");
            ofile.Close();
            
            //Process.Start(".//Tokens.html");

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
            for (int i = 0; i < scan.listaErrores.Count; i++)
            {
                Objeto.ErrorLS t = (Objeto.ErrorLS)scan.listaErrores[i];

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

            ofile.WriteLine("<h2 >" + "Cantidad de Errores: " + scan.listaErrores.Count + " </h2>");
            ofile.WriteLine("</body>");
            ofile.WriteLine("</html>");
            ofile.Close();
        }
    }
}
