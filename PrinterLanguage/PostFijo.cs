using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterLanguage
{
    
    class PostFijo
    {
        [DebuggerHidden]
        public string TransformarPostfijo(string infijo)
        {
            Stack<string> Operadores = new Stack<string>();
            string postfijo = "";
            string parametro = "";
            bool parametroActivo = false;

            for (int x = 0; x < infijo.Length; x++)
            {
                if (parametroActivo)
                {
                    if (AnalizarCaracter(infijo[x].ToString()) == 4 && (DetectarPosicionUltimaParentesis(infijo) == x))
                    {
                        postfijo += TransformarPostfijo(parametro);
                        parametroActivo = false;
                        parametro = "";
                        while (Operadores.Count > 0)
                        {
                            postfijo += Operadores.Pop();
                            postfijo += " ";
                        }
                    }
                    else
                    {
                        parametro += infijo[x].ToString();
                    }
                }
                else
                {
                    if (AnalizarCaracter(infijo[x].ToString()) > 0)
                    {
                        if (AnalizarCaracter(infijo[x].ToString()) == 5)
                        {
                            parametroActivo = true;
                        }
                        else
                        {
                            postfijo += " ";
                            if (Operadores.Count == 0)
                            {
                                Operadores.Push(infijo[x].ToString());
                            }
                            else
                            {
                                if (AnalizarCaracter(infijo[x].ToString()) > AnalizarCaracter(Operadores.Peek()))
                                {
                                    Operadores.Push(infijo[x].ToString());
                                }
                                else if (AnalizarCaracter(infijo[x].ToString()) < AnalizarCaracter(Operadores.Peek()))
                                {
                                    while (Operadores.Count > 0)
                                    {
                                        postfijo += Operadores.Pop();
                                        postfijo += " ";
                                    }
                                    Operadores.Push(infijo[x].ToString());
                                }
                                else if (AnalizarCaracter(infijo[x].ToString()) == AnalizarCaracter(Operadores.Peek()))
                                {
                                    postfijo += Operadores.Pop();
                                    postfijo += " ";
                                    Operadores.Push(infijo[x].ToString());
                                }
                                else
                                {
                                    MessageBox.Show("oops");
                                }
                            }
                        }
                    }
                    else
                    {
                        postfijo += $"{infijo[x].ToString()}";
                    }
                    if (x == infijo.Length - 1)
                    {
                        while (Operadores.Count > 0)
                        {
                            postfijo += " ";

                            postfijo += Operadores.Pop();

                        }
                    }
                }
            }
            return postfijo;
        }
        [DebuggerHidden]
        public int AnalizarCaracter(string x)
        {
            switch (x)
            {
                case "AND":
                    return 14;
                case "OR":
                    return 13;
                case "NOT":
                    return 12;
                case "<=":
                    return 11;
                case ">":
                    return 10;
                case "<":
                    return 9;
                case "<>":
                    return 8;
                case ">=":
                    return 7;
                case "=":
                    return 6;
                case "(":
                    return 5;
                case ")":
                    return 4;
                case "^":
                    return 3;
                case "*":
                case "/":
                    return 2;
                case "+":
                case "-":
                    return 1;
                default:
                    return 0;
            }
        }
        [DebuggerHidden]
        public int DetectarPosicionUltimaParentesis(string con)
        {
            int result = 0;
            for (int x = 0; x < con.Length; x++)
            {
                if (con[x] == ')')
                {
                    result = x;
                }
            }
            return result;
        }
        [DebuggerHidden]
        public bool DetectarParentesis(string x)
        {
            if (x == "(" || x == ")")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
