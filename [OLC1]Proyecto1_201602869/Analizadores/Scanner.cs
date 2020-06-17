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
        ArrayList listaTokens = new ArrayList();
        ArrayList listaErrores = new ArrayList();


        public void recibeTexto(String texto) {
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
                        else if (letra == ' ') {

                        }
                        break;
                    case 1:
                        // aqui acepto varios
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
                        break;
                    case 4:
                        if (letra == '=')
                        {
                            estado = 1;
                            lexema = lexema + letra;
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
                        break;
                    case 27:
                        //acepto comentario multi
                        break;
                    case 28:
                        //acepto cadenas 
                        break;
                                   
                    default:
                        break;
                }
            }
        }
    }
}
