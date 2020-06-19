using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201602869.Analizadores
{
    class Scanner
    {
        public String lexema = "";
        public int estado = 0;
        public int indice = 0;
        public static ArrayList listaTokens = new ArrayList();
        public ArrayList listaErrores = new ArrayList();
        public ArrayList listaReservadas = new ArrayList();
        public int contadorLinea = 0;
        public int contadorCol = 0;

        public void llenarLista() {
            listaReservadas.Add("CREAR"); //19
            listaReservadas.Add("TABLA"); //20
            listaReservadas.Add("entero");//21
            listaReservadas.Add("cadena");//22
            listaReservadas.Add("fecha");//23
            listaReservadas.Add("flotante");//24
            listaReservadas.Add("INSERTAR");//25
            listaReservadas.Add("EN");      //26
            listaReservadas.Add("VALORES");//27
            listaReservadas.Add("SELECCIONAR");//28
            listaReservadas.Add("COMO");//29
            listaReservadas.Add("DE");//30
            listaReservadas.Add("DONDE");//31
            listaReservadas.Add("Y");//32
            listaReservadas.Add("O");//33
            listaReservadas.Add("ELIMINAR");//34
            listaReservadas.Add("ACTUALIZAR");//35
            listaReservadas.Add("ESTABLECER");//36
        }

        public Boolean esReservada(String lex) {
            Boolean resultado = true;
            int existe = listaReservadas.IndexOf(lex);
            if (existe != -1)
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }
            return resultado;
        }


        public void recibeTexto(String texto) {
            llenarLista();
            String textoLimpio = "";
            for (int i = 0; i < texto.Length; i++)
            {
                char letra = texto[i];
                switch (letra)
                {
                    case '\r':
                    case '\t':
                    case '\b':
                    case '\f':

                        break;
                    default:
                        textoLimpio = textoLimpio + letra;
                        break;
                }
            }

            for (indice = 0; indice < textoLimpio.Length; indice++)
            {
                contadorCol++;
                char letra = textoLimpio[indice];
                int codigoAscii = letra;
                switch (estado)
                {
                    case 0:
                        if (letra == '/')
                        {
                            estado = 10;
                            lexema = "" + letra;
                        }
                        else if (letra == '!')
                        {
                            estado = 2;
                            lexema = "" + letra;
                        }
                        else if (letra == ',')
                        {
                            estado = 1;
                            lexema = "" + letra;
                        }
                        else if (letra == ';')
                        {
                            estado = 1;
                            lexema = "" + letra;
                        }
                        else if (letra == '*')
                        {
                            estado = 1;
                            lexema = "" + letra;
                        }
                        else if (letra == '=')
                        {
                            estado = 1;
                            lexema = "" + letra;
                        }
                        else if (letra == '(')
                        {
                            estado = 1;
                            lexema = "" + letra;
                        }
                        else if (letra == ')')
                        {
                            estado = 1;
                            lexema = "" + letra;
                        }
                        else if (letra == '>')
                        {
                            estado = 3;
                            lexema = "" + letra;
                        }
                        else if (letra == '<')
                        {
                            estado = 4;
                            lexema = "" + letra;
                        }
                        else if (letra == '"')
                        {
                            estado = 5;
                            lexema = "" + letra;
                        }
                        else if (codigoAscii >= 48 && codigoAscii <= 57)
                        {// digito 
                            estado = 6;
                            lexema = "" + letra;
                        }
                        else if ((codigoAscii >= 65 && codigoAscii <= 90) || (codigoAscii >= 97 && codigoAscii <= 122))
                        {//letra
                            estado = 7;
                            lexema = "" + letra;
                        }
                        else if (letra == '\'')
                        {
                            estado = 8;
                            lexema = "" + letra;
                        }
                        else if (letra == '-')
                        {
                            estado = 9;
                            lexema = "" + letra;
                        }
                        else if (letra == ' ')
                        {
                            estado = 0;
                        }
                        else if (letra == '\n')
                        {
                            contadorLinea++;
                            contadorCol = 0;
                            estado = 0;
                        }
                        else {
                            // acepto errores 
                            Objeto.ErrorLS errorLS = new Objeto.ErrorLS();
                            errorLS.setTipo("Lexico");
                            errorLS.setLexema("Caracter " + letra + " no es parte del lenguaje");
                            errorLS.setLinea(contadorLinea);
                            errorLS.setColumna(contadorCol);
                            listaErrores.Add(errorLS);
                        }
                        break;
                    case 1:
                        // aqui acepto varios
                        switch (lexema)
                        {
                            

                            case "(":
                                {
                                    Objeto.Token tok = new Objeto.Token();
                                    tok.setNumToken(1);
                                    tok.setTipo("Parentesis Abierto");
                                    tok.setLexema(lexema);
                                    tok.setLinea(contadorLinea);
                                    tok.setColumna(contadorCol);
                                    listaTokens.Add(tok);
                                }
                                
                                break;
                            case ")":
                                {
                                    Objeto.Token tok = new Objeto.Token();
                                    tok.setNumToken(2);
                                    tok.setTipo("Parentesis Cerrado");
                                    tok.setLexema(lexema);
                                    tok.setLinea(contadorLinea);
                                    tok.setColumna(contadorCol);
                                    listaTokens.Add(tok);
                                }
                                break;
                            case "=":
                                {
                                    Objeto.Token tok = new Objeto.Token();
                                    tok.setNumToken(3);
                                    tok.setTipo("Signo igual");
                                    tok.setLexema(lexema);
                                    tok.setLinea(contadorLinea);
                                    tok.setColumna(contadorCol);
                                    listaTokens.Add(tok);
                                }
                                break;
                            case "*":
                                {
                                    Objeto.Token tok = new Objeto.Token();
                                    tok.setNumToken(4);
                                    tok.setTipo("Signo asterisco");
                                    tok.setLexema(lexema);
                                    tok.setLinea(contadorLinea);
                                    tok.setColumna(contadorCol);
                                    listaTokens.Add(tok);
                                }
                                break;
                            case ";":
                                {
                                    Objeto.Token tok = new Objeto.Token();
                                    tok.setNumToken(5);
                                    tok.setTipo("Punto y coma");
                                    tok.setLexema(lexema);
                                    tok.setLinea(contadorLinea);
                                    tok.setColumna(contadorCol);
                                    listaTokens.Add(tok);
                                }
                                break;
                            case ",":
                                {
                                    Objeto.Token tok = new Objeto.Token();
                                    tok.setNumToken(6);
                                    tok.setTipo("Coma");
                                    tok.setLexema(lexema);
                                    tok.setLinea(contadorLinea);
                                    tok.setColumna(contadorCol);
                                    listaTokens.Add(tok);
                                }
                                break;
                            case "!=":
                                {
                                    Objeto.Token tok = new Objeto.Token();
                                    tok.setNumToken(7);
                                    tok.setTipo("Signo diferente");
                                    tok.setLexema(lexema);
                                    tok.setLinea(contadorLinea);
                                    tok.setColumna(contadorCol);
                                    listaTokens.Add(tok);
                                }
                                break;
                            case ">=":
                                {
                                    Objeto.Token tok = new Objeto.Token();
                                    tok.setNumToken(8);
                                    tok.setTipo("Mayor igual");
                                    tok.setLexema(lexema);
                                    tok.setLinea(contadorLinea);
                                    tok.setColumna(contadorCol);
                                    listaTokens.Add(tok);
                                }
                                break;
                            case "<=":
                                {
                                    Objeto.Token tok = new Objeto.Token();
                                    tok.setNumToken(9);
                                    tok.setTipo("Menor igual");
                                    tok.setLexema(lexema);
                                    tok.setLinea(contadorLinea);
                                    tok.setColumna(contadorCol);
                                    listaTokens.Add(tok);
                                }
                                break;

                            default:
                                break;
                        }
                        lexema = "";
                        estado = 0;
                        indice--;

                        break;
                    case 2:
                        if (letra == '=')
                        {
                            estado = 1;
                            lexema = lexema + letra;
                        }
                        break;
                    case 3:
                        if (letra == '=')
                        {
                            estado = 1;
                            lexema = lexema + letra;
                        }
                        else {
                            //acepto mayor que
                            Objeto.Token tok = new Objeto.Token();
                            tok.setNumToken(10);
                            tok.setTipo("Mayor que ");
                            tok.setLexema(lexema);
                            tok.setLinea(contadorLinea);
                            tok.setColumna(contadorCol);
                            listaTokens.Add(tok);
                            lexema = "";
                            estado = 0;
                            indice--;
                        }
                        break;
                    case 4:
                        if (letra == '=')
                        {
                            estado = 1;
                            lexema = lexema + letra;
                        }
                        else {
                            Objeto.Token tok = new Objeto.Token();
                            tok.setNumToken(11);
                            tok.setTipo("Menor que ");
                            tok.setLexema(lexema);
                            tok.setLinea(contadorLinea);
                            tok.setColumna(contadorCol);
                            listaTokens.Add(tok);
                            lexema = "";
                            estado = 0;
                            indice--;
                        }
                        break;
                    case 5:
                        if (letra == '"')
                        {
                            estado = 28;
                            lexema = lexema + letra;
                        }
                        else {
                            estado = 5;
                            lexema = lexema + letra;
                        }
                        break;
                    case 6:
                        if (codigoAscii >= 48 && codigoAscii <= 57)
                        {// digito 
                            estado = 6;
                            lexema = lexema + letra;
                        }
                        else if (letra == '.')
                        {
                            estado = 11;
                            lexema = lexema + letra;
                        }
                        else {
                            //acepto numeros normales aqui
                            Objeto.Token tok = new Objeto.Token();
                            tok.setNumToken(12);
                            tok.setTipo("Digito sin decimal ");
                            tok.setLexema(lexema);
                            tok.setLinea(contadorLinea);
                            tok.setColumna(contadorCol);
                            listaTokens.Add(tok);
                            lexema = "";
                            estado = 0;
                            indice--;

                        }
                        break;
                    case 7:
                        if ((codigoAscii >= 48 && codigoAscii <= 57) || (codigoAscii >= 65 && codigoAscii <= 90) || (codigoAscii >= 97 && codigoAscii <= 122) || letra == '_')
                        {// digito 
                            estado = 7;
                            lexema = lexema + letra;
                        }
                        else {
                            //acepto identificadores aqui 
                            Objeto.Token tok = new Objeto.Token();
                            // ver si es palabra reservada

                            if (esReservada(lexema).Equals(true))
                            {
                                
                                // si es reservada
                                tok.setTipo("Palabra Reservada");
                                switch (lexema.ToUpper())
                                {
                                    case "CREAR":
                                        tok.setNumToken(19);
                                        break;
                                    case "TABLA":
                                        tok.setNumToken(20);
                                        break;
                                    case "ENTERO":
                                        tok.setNumToken(21);
                                        break;
                                    case "CADENA":
                                        tok.setNumToken(22);
                                        break;
                                    case "FECHA":
                                        tok.setNumToken(23);
                                        break;
                                    case "FLOTANTE":
                                        tok.setNumToken(24);
                                        break;
                                    case "INSERTAR":
                                        tok.setNumToken(25);
                                        break;
                                    case "EN":
                                        tok.setNumToken(26);
                                        break;
                                    case "VALORES":
                                        tok.setNumToken(27);
                                        break;
                                    case "SELECCIONAR":
                                        tok.setNumToken(28);
                                        break;
                                    case "COMO":
                                        tok.setNumToken(29);
                                        break;
                                    case "DE":
                                        tok.setNumToken(30);
                                        break;
                                    case "DONDE":
                                        tok.setNumToken(31);
                                        break;
                                    case "Y":
                                        tok.setNumToken(32);
                                        break;
                                    case "O":
                                        tok.setNumToken(33);
                                        break;
                                    case "ELIMINAR":
                                        tok.setNumToken(34);
                                        break;
                                    case "ACTUALIZAR":
                                        tok.setNumToken(35);
                                        break;
                                    case "ESTABLECER":
                                        tok.setNumToken(36);
                                        break;
                                        
                                    default:
                                        break;
                                }
                                
                            }
                            else {
                                tok.setNumToken(18);
                                tok.setTipo("Identificador");
                            }
                            
                            tok.setLexema(lexema);
                            tok.setLinea(contadorLinea);
                            tok.setColumna(contadorCol);
                            listaTokens.Add(tok);
                            lexema = "";
                            estado = 0;
                            indice--;
                        }
                        break;
                    case 8:
                        if ((codigoAscii >= 48 && codigoAscii <= 57)) {
                            estado = 12;
                            lexema = lexema + letra;
                        }
                        break;
                    case 9:
                        if (letra == '-') {
                            estado = 13;
                            lexema = lexema + letra;
                        }
                        break;
                    case 10:
                        if (letra == '*')
                        {
                            estado = 14;
                            lexema = lexema + letra;
                        }
                        break;
                    case 11:
                        if ((codigoAscii >= 48 && codigoAscii <= 57))
                        {
                            estado = 15;
                            lexema = lexema + letra;
                        }
                        break;
                    case 12:
                        if ((codigoAscii >= 48 && codigoAscii <= 57))
                        {
                            estado = 16;
                            lexema = lexema + letra;
                        }
                        break;
                    case 13:
                        if (letra == '\n')
                        {
                            // aceptp comentario simple
                            Objeto.Token tok = new Objeto.Token();
                            tok.setNumToken(13);
                            tok.setTipo("Comentario Simple");
                            tok.setLexema(lexema);
                            tok.setLinea(contadorLinea);
                            tok.setColumna(contadorCol);
                            listaTokens.Add(tok);
                            lexema = "";
                            estado = 0;
                            indice--;

                        }
                        else {
                            estado = 13;
                            lexema = lexema + letra;
                        }
                        break;
                    case 14:
                        if (letra == '*')
                        {
                            estado = 17;
                            lexema = lexema + letra;
                        }
                        else {
                            estado = 14;
                            lexema = lexema + letra;
                        }
                        break;
                    case 15:
                        if ((codigoAscii >= 48 && codigoAscii <= 57))
                        {
                            estado = 15;
                            lexema = lexema + letra;
                        }
                        else {
                            //acepto digito decimal
                            Objeto.Token tok = new Objeto.Token();
                            tok.setNumToken(14);
                            tok.setTipo("Digito con decimal");
                            tok.setLexema(lexema);
                            tok.setLinea(contadorLinea);
                            tok.setColumna(contadorCol);
                            listaTokens.Add(tok);
                            lexema = "";
                            estado = 0;
                            indice--;
                        }
                        break;
                    case 16:
                        if (letra == '/') {
                            estado = 18;
                            lexema = lexema + letra;
                        }
                        break;
                    case 17:
                        if (letra == '/')
                        {
                            estado = 27;
                            lexema = lexema + letra;
                        }
                        break;
                    case 18:
                        if ((codigoAscii >= 48 && codigoAscii <= 57))
                        {
                            estado = 19;
                            lexema = lexema + letra;
                        }
                        break;
                    case 19:
                        if ((codigoAscii >= 48 && codigoAscii <= 57))
                        {
                            estado = 20;
                            lexema = lexema + letra;
                        }
                        break;
                    case 20:
                        if (letra == '/')
                        {
                            estado = 21;
                            lexema = lexema + letra;
                        }
                        break;
                    case 21:
                        if ((codigoAscii >= 48 && codigoAscii <= 57))
                        {
                            estado = 22;
                            lexema = lexema + letra;
                        }
                        break;
                    case 22:
                        if ((codigoAscii >= 48 && codigoAscii <= 57))
                        {
                            estado = 23;
                            lexema = lexema + letra;
                        }
                        break;
                    case 23:
                        if ((codigoAscii >= 48 && codigoAscii <= 57))
                        {
                            estado = 24;
                            lexema = lexema + letra;
                        }
                        break;
                    case 24:
                        if ((codigoAscii >= 48 && codigoAscii <= 57))
                        {
                            estado = 25;
                            lexema = lexema + letra;
                        }
                        break;
                    case 25:
                        if (letra == '\'')
                        {
                            estado = 26;
                            lexema = lexema + letra;
                        }
                        break;
                    case 26:
                        //acepto fecha 
                        {
                            Objeto.Token tok = new Objeto.Token();
                            tok.setNumToken(15);
                            tok.setTipo("Fecha ");
                            tok.setLexema(lexema);
                            tok.setLinea(contadorLinea);
                            tok.setColumna(contadorCol);
                            listaTokens.Add(tok);
                            lexema = "";
                            estado = 0;
                            indice--;
                        }
                        break;
                    case 27:
                        //acepto comentario multi
                        {
                            Objeto.Token tok = new Objeto.Token();
                            tok.setNumToken(16);
                            tok.setTipo("Comentario Multilinea ");
                            tok.setLexema(lexema);
                            tok.setLinea(contadorLinea);
                            tok.setColumna(contadorCol);
                            listaTokens.Add(tok);
                            lexema = "";
                            estado = 0;
                            indice--;
                        }
                        break;
                    case 28:
                        //acepto cadenas
                        {
                            Objeto.Token tok = new Objeto.Token();
                            tok.setNumToken(17);
                            tok.setTipo("Cadena ");
                            tok.setLexema(lexema);
                            tok.setLinea(contadorLinea);
                            tok.setColumna(contadorCol);
                            listaTokens.Add(tok);
                            lexema = "";
                            estado = 0;
                            indice--;
                        }
                        break;
                                   
                    default:
                        break;
                }
            }
        }
    }
}
