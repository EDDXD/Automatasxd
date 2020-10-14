using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace PrinterLanguage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string servidor = "192.185.131.135";
        static string puerto = "3306";
        static string usuario = "javierc1_Javier";
        static string contrasena = "12345";
        static string cadenaConexion = "SERVER=" + servidor + "; PORT=" + puerto + ";Database=javierc1_Printer" + ";UID=" + usuario +
                ";PASSWORD=" + contrasena + ";";
        static string cadenaConexiong = "SERVER=" + servidor + "; PORT=" + puerto + ";Database=javierc1_Printer_V3" + ";UID=" + usuario +
                ";PASSWORD=" + contrasena + ";";


        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text Documents|*.txt";
            open.Title = "Open";
            open.FileName = "";
            var o = open.ShowDialog();

            if (o == DialogResult.OK)
            {
                StreamReader read = new StreamReader(open.FileName);
                rtxtCodigo.Text = read.ReadToEnd();
                read.Close();
            }
        }

        List<Identificador> misIden = new List<Identificador>();
        int intIdenActual = 0, intContarIdens = 1, intLineaCodigoIntermedio = 0;

        private void DetectarTipos()
        {
            intContarIdens = 0;
            int intNumeroPalabraActual = 0;
            misIden = new List<Identificador>();
            Identificador miIdeTemp = new Identificador();
            bool blnRepetido = false;
            int intRepetido = 0;
            bool blnSI = false;
            foreach (string linea in rtxtCodigo.Lines) //POR CADA LINEA
            {
                intRepetido = 0;
                intNumeroPalabraActual = 0;

                foreach (string palabra in linea.Split(' ')) //RECORRE CADA PALABRA
                {
                    blnSI = false;
                    if (intNumeroPalabraActual >= 2)
                    {
                        if (linea.Split(' ')[intNumeroPalabraActual - 2].Contains("SI"))
                        {
                            blnSI = true;
                        }
                    }
                    if ((palabra.Contains('#') && linea.Split(' ').Length - 1 >= intNumeroPalabraActual + 3 && !blnSI) || palabra.Equals("CAPTURAR"))
                    {
                        string strPalabraSiguiente = linea.Split(' ')[intNumeroPalabraActual + 2];
                        string strContenido = strPalabraSiguiente;
                        int intContadorAux = intNumeroPalabraActual + 2;
                        if (linea.Split(' ')[intNumeroPalabraActual + 1].Equals("=") || palabra.Equals("CAPTURAR"))
                        {

                            if (palabra.Equals("CAPTURAR"))
                            {
                                strPalabraSiguiente = linea.Split(' ')[intNumeroPalabraActual + 1];
                                intContadorAux = intNumeroPalabraActual + 1;
                            }

                            foreach (Identificador id in misIden)
                            {
                                if (palabra.Equals("CAPTURAR"))
                                {
                                    if (id.Nombre.Equals(strPalabraSiguiente))
                                    {
                                        blnRepetido = true;
                                        intRepetido++;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (id.Nombre.Equals(palabra))
                                    {
                                        blnRepetido = true;
                                        intRepetido++;
                                        break;
                                    }
                                }
                                intRepetido++;
                            }

                            if (strPalabraSiguiente.Equals("["))
                            {
                                strContenido = "";
                                do
                                {
                                    strContenido += " " + strPalabraSiguiente;
                                    intContadorAux++;
                                    strPalabraSiguiente = linea.Split(' ')[intContadorAux];
                                } while (strPalabraSiguiente != "]");

                                if (blnRepetido)
                                {
                                    misIden[intRepetido].Contenido = strContenido + " ]";
                                    intRepetido = 0;
                                }
                                else
                                {
                                    misIden.Add(new Identificador("IDE" + (intContarIdens + 1), palabra, "Cadena", strContenido + " ]"));
                                    intContarIdens++;
                                }
                                blnRepetido = false;
                            }
                            else if (palabra != "CAPTURAR")
                            {
                                string strPalabraSiguienteSiguiente = linea.Split(' ')[intNumeroPalabraActual + 3];
                                Regex regexp = new Regex(@"^\d+|/+|/-|/*|//|^|#\w+$");

                                if (strPalabraSiguienteSiguiente.Contains("+") || strPalabraSiguienteSiguiente.Contains("-") ||
                                    strPalabraSiguienteSiguiente.Contains("-") || strPalabraSiguienteSiguiente.Contains("*") ||
                                    strPalabraSiguienteSiguiente.Contains("^"))
                                {
                                    while (regexp.IsMatch(strPalabraSiguienteSiguiente) && strPalabraSiguienteSiguiente != "")
                                    {
                                        intContadorAux++;
                                        strContenido += " " + strPalabraSiguienteSiguiente;
                                        strPalabraSiguienteSiguiente = linea.Split(' ')[intContadorAux + 1];
                                    }
                                }

                                if (blnRepetido)
                                {
                                    misIden[intRepetido - 1].Contenido = strContenido;
                                }
                                else
                                {
                                    misIden.Add(new Identificador("IDE" + (intContarIdens + 1), palabra, "Entero", strContenido));
                                    intContarIdens++;
                                }
                                blnRepetido = false;
                                intRepetido = 0;
                            }
                            else
                            {
                                if (blnRepetido)
                                {
                                    misIden[intRepetido - 1].Contenido = strContenido;
                                }
                                else
                                {
                                    misIden.Add(new Identificador("IDE" + (intContarIdens + 1), strPalabraSiguiente, "Cadena", "null"));
                                    intContarIdens++;
                                }
                                intRepetido = 0;
                                blnRepetido = false;
                            }
                        }
                    }
                    intNumeroPalabraActual++;
                }
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            rtxInfijo.Text = "";
            rtxPostfijo.Text = "";
            rtxtGramatica.Clear();
            rtxtSemantica.Clear();
            DetectarTipos();
            intIdenActual = 0;
            rtxttokens.Text = "";
            rtxTipos.Text = "";
            intLineaCodigoIntermedio = 0;

            string aux1 = "";
            string aux2 = "";
            bool bandera = false;
            borrarDatosEnTablas();
            rtxtCodigoIntermedio.Clear();
            string cadena = "";
            string subcadena = "";
            string apuntador = "0";
            string token = "";
            bool esp = false;

            for (int x = 0; x < rtxtCodigo.Lines.Count(); x++)
            {
                txtNumRenglon.Text = (x + 1).ToString();
                cadena = rtxtCodigo.Lines[x];
                txtSubCadenaAEvaluar.Text = cadena;

                for (int y = 0; y < cadena.Length; y++)
                {
                    if (cadena[y].ToString() == "[" || cadena[y].ToString() == "\\")
                    {
                        if (cadena[y].ToString() == "\\" && cadena[y + 1].ToString() == " ")
                        {
                            esp = false;
                        }
                        else
                        {
                            esp = true;
                        }
                    }
                    else if (cadena[y].ToString() == "]")
                    {
                        esp = false;
                    }

                    if (cadena[y].ToString() == " ")
                    {
                        if (!esp)
                        {
                            apuntador = Recorrer(apuntador, "DEL");
                            token = Recorrer(apuntador, "TOKEN");
                            Identificador ideTemporal = new Identificador();
                            if (token == "IDE")
                            {
                                //
                                int intIdAux = 0;
                                bool blnRepetido = false;
                                foreach (Identificador identificador in misIden)
                                {
                                    if (identificador.Nombre.Equals(subcadena))
                                    {
                                        blnRepetido = true;
                                        break;
                                    }
                                    intIdAux++;
                                }
                                if (blnRepetido)
                                {
                                    ideTemporal = new Identificador(misIden.ElementAt(intIdAux).Token, misIden.ElementAt(intIdAux).Nombre,
                                                                    misIden.ElementAt(intIdAux).Tipo, misIden.ElementAt(intIdAux).Contenido);
                                }
                                else
                                {
                                    ideTemporal = new Identificador(misIden.ElementAt(intIdenActual).Token, misIden.ElementAt(intIdenActual).Nombre,
                                                                    misIden.ElementAt(intIdenActual).Tipo, misIden.ElementAt(intIdenActual).Contenido);
                                }

                                actualizarTablaSimbolos(ideTemporal);
                                aux1 = ideTemporal.Token;
                                bandera = true;
                                intIdenActual++;
                            }
                            else if (token == "CNU")
                            {
                                //MessageBox.Show("token: " + token + "\ncadena: " + cadena + "\nsubcadena: " + subcadena);
                                aux1 = "CNUE";
                                bandera = true;
                            }

                            if (bandera)
                            {
                                aux2 = aux2 + aux1 + " ";
                                bandera = false;
                            }
                            else
                            {
                                aux2 = aux2 + token + " ";
                            }

                            txtCadenaDeTokens.Text = txtCadenaDeTokens.Text + (token.Equals("IDE") ? token += "N" : (token.Equals("CNU") ? token += "E" : token)) + " ";
                            apuntador = "0";
                            subcadena = "";
                        }
                    }
                    else
                    {
                        apuntador = Recorrer(apuntador, "`A" + cadena[y].ToString() + "`");
                        subcadena = subcadena + cadena[y].ToString();
                    }
                }
                MessageBox.Show("¡Subcadena evaluada con éxito!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtxtCodigoIntermedio.Text += txtCadenaDeTokens.Text + "\n";
                txtSubCadenaAEvaluar.Clear();
                txtCadenaDeTokens.Clear();
                rtxttokens.Text += aux2 + "\n";
                rtxTipos.Text += GenerarTokensTipos() + "\n";
                aux2 = "";
            }
            txtNumRenglon.Clear();
            MessageBox.Show("¡Cadena totalmente evaluada con éxito!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            updateCN(new MySqlConnection(cadenaConexion));
            mostrarDatosEnTablas();
            AjustarInfijoPostfijo();
        }
        public string GenerarTokensTipos()
        {
            string strAux = "";
            string[] strLinea = rtxttokens.Lines.ToArray()[intLineaCodigoIntermedio].Split(' ');
            foreach (string s in strLinea)
            {
                if (s.Equals("CNUE"))
                {
                    strAux += "entero ";
                }
                else if (s.Contains("IDE"))
                {
                    foreach (Identificador i in misIden)
                    {
                        if (i.Token.Equals(s))
                        {
                            strAux += i.Tipo.ToLower() + " ";
                        }
                    }
                }
                else if (s.Equals("CADE"))
                {
                    strAux += "cadena ";
                }
                else
                {
                    strAux += s + " ";
                }
            }
            intLineaCodigoIntermedio++;
            return strAux;
        }

        public string Recorrer(string apuntador, string caracter)
        {
            MySqlConnection mySQLCon = new MySqlConnection(cadenaConexion);

            mySQLCon.Open();
            MySqlDataReader myDtRd;
            MySqlCommand myQuery = new MySqlCommand("SELECT " + caracter + " FROM M WHERE ID = " + apuntador, mySQLCon);
            myDtRd = myQuery.ExecuteReader();
            string token = "";
            string nomCol = "";
            string a = "";
            while (myDtRd.Read())
            {
                if (myDtRd.GetName(0) == "TOKEN")
                {
                    nomCol = myDtRd.GetName(0);
                    token = myDtRd.GetString(0);
                    mySQLCon.Close();
                    return token;
                }
                else
                {
                    nomCol = myDtRd.GetName(0);
                    a = myDtRd.GetString(0);
                }
            }
            mySQLCon.Close();
            return a;
        }

        public void actualizarTablaSimbolos(Identificador miIden)
        {
            MySqlConnection con = new MySqlConnection(cadenaConexion);
            con.Open();

            MySqlCommand qryActualizarTablas;

            qryActualizarTablas = new MySqlCommand("SELECT COUNT(*) FROM Identificador WHERE NOMBRE = '" + miIden.Nombre + "'", con);
            if (int.Parse(qryActualizarTablas.ExecuteScalar().ToString()) > 0)
            {
                qryActualizarTablas = new MySqlCommand("UPDATE Identificador SET CONTENIDO = '" + miIden.Contenido + "', " +
                                                        "TIPO = '" + (miIden.Tipo) + "' " +
                                                        "WHERE NOMBRE = '" + miIden.Nombre + "'", con);
                qryActualizarTablas.ExecuteNonQuery();
                if (!miIden.Contenido.Contains("["))
                {
                    updateCN(con);
                }
            }
            else
            {
                if (miIden.Tipo.Equals("Entero"))
                {
                    updateCN(con);
                }
                qryActualizarTablas = new MySqlCommand("INSERT INTO Identificador (TOKEN, NOMBRE, TIPO, CONTENIDO) VALUES ( '" + miIden.Token + "', '" + miIden.Nombre + "', '" + miIden.Tipo + "', '" + miIden.Contenido + "' )", con);
                qryActualizarTablas.ExecuteNonQuery();
            }

            con.Close();
            mostrarDatosEnTablas();
        }

        public void updateCN(MySqlConnection connection)
        {
            MySqlCommand qry = new MySqlCommand("DELETE FROM ConstanteNumerica", connection);
            if (!connection.State.ToString().Equals("Open"))
            {
                connection.Open();
            }
            qry.ExecuteNonQuery();
            int aux = 1;
            List<string> listaConstantes = new List<string>();

            Regex regexp = new Regex(@"^[0-9]+$");

            foreach (string linea in rtxtCodigo.Lines)
            {
                foreach (string palabra in linea.Split(' '))
                {
                    if (regexp.IsMatch(palabra))
                    {
                        if (!listaConstantes.Contains(palabra))
                        {
                            qry = new MySqlCommand("INSERT INTO ConstanteNumerica (TOKEN, CONTENIDO) VALUES ( 'CNU" + aux + "', '" + palabra + "' )", connection);
                            listaConstantes.Add(palabra);
                            aux++;
                            qry.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public string agregarDatosEnTablas(string tabla, string token, string nombre, string tipo, string contenido)
        {
            MySqlConnection mySQLCon = new MySqlConnection(cadenaConexion);

            mySQLCon.Open();
            MySqlDataReader myDtRd1;
            MySqlCommand myQuery1 = new MySqlCommand("SELECT COUNT(*) FROM " + tabla, mySQLCon);
            myDtRd1 = myQuery1.ExecuteReader();
            int filas = 0;
            while (myDtRd1.Read())
            {
                filas = myDtRd1.GetInt32(0);
            }
            mySQLCon.Close();

            if (filas == 0)
            {
                MySqlCommand myQuery2;
                mySQLCon.Open();
                if (tabla.Equals("Identificador"))
                {
                    myQuery2 = new MySqlCommand("INSERT INTO " + tabla + " (TOKEN, NOMBRE, TIPO, CONTENIDO) VALUES ( '" + token + "', '" + nombre + "', '" + tipo + "', '" + contenido + "')", mySQLCon);
                }
                else
                {
                    myQuery2 = new MySqlCommand("INSERT INTO " + tabla + " (TOKEN, CONTENIDO) VALUES ( '" + token + "1', '" + contenido + "')", mySQLCon);
                }

                myQuery2.ExecuteNonQuery();
                mySQLCon.Close();
                return token + 1;
            }
            else
            {
                mySQLCon.Open();
                MySqlDataReader myDtRd2;
                MySqlCommand myQuery3 = new MySqlCommand("SELECT * FROM " + tabla + " WHERE CONTENIDO = '" + contenido + "'", mySQLCon);
                myDtRd2 = myQuery3.ExecuteReader();
                string t = "";
                string c = "";
                while (myDtRd2.Read())
                {
                    t = myDtRd2.GetString(0);
                    c = myDtRd2.GetString(1);
                }
                mySQLCon.Close();

                if (c == contenido)
                {
                    return t;
                }
                else
                {
                    mySQLCon.Open();
                    MySqlCommand myQuery4 = new MySqlCommand("INSERT INTO " + tabla + " (TOKEN, CONTENIDO) VALUES ( '" + (token + (filas + 1)) + "', '" + contenido + "')", mySQLCon);
                    myQuery4.ExecuteNonQuery();
                    mySQLCon.Close();
                    return token + (filas + 1);
                }
            }
        }

        public void mostrarDatosEnTablas()
        {
            MySqlConnection mySQLCon = new MySqlConnection(cadenaConexion);

            mySQLCon.Open();
            MySqlDataAdapter myDtAd1 = new MySqlDataAdapter("SELECT * FROM Identificador", mySQLCon);
            DataTable myDtTb1 = new DataTable();
            myDtAd1.Fill(myDtTb1);
            dgvIdentificadores.DataSource = myDtTb1;
            mySQLCon.Close();

            mySQLCon.Open();
            MySqlDataAdapter myDtAd2 = new MySqlDataAdapter("SELECT * FROM ConstanteNumerica", mySQLCon);
            DataTable myDtTb2 = new DataTable();
            myDtAd2.Fill(myDtTb2);
            dgvConstantesNumericas.DataSource = myDtTb2;
            mySQLCon.Close();
        }

        public void borrarDatosEnTablas()
        {
            MySqlConnection mySQLCon = new MySqlConnection(cadenaConexion);

            mySQLCon.Open();
            MySqlDataReader myDtRd1;
            MySqlCommand myQuery1 = new MySqlCommand("SELECT COUNT(*) FROM Identificador", mySQLCon);
            myDtRd1 = myQuery1.ExecuteReader();
            int id = 0;
            while (myDtRd1.Read())
            {
                id = myDtRd1.GetInt32(0);
            }
            mySQLCon.Close();

            mySQLCon.Open();
            MySqlDataReader myDtRd2;
            MySqlCommand myQuery2 = new MySqlCommand("SELECT COUNT(*) FROM ConstanteNumerica", mySQLCon);
            myDtRd2 = myQuery2.ExecuteReader();
            int cn = 0;
            while (myDtRd2.Read())
            {
                cn = myDtRd2.GetInt32(0);
            }
            mySQLCon.Close();

            if (id > 0)
            {
                mySQLCon.Open();
                MySqlCommand myQuery3 = new MySqlCommand("TRUNCATE Identificador", mySQLCon);
                myQuery3.ExecuteNonQuery();
                mySQLCon.Close();
            }

            if (cn > 0)
            {
                mySQLCon.Open();
                MySqlCommand myQuery4 = new MySqlCommand("TRUNCATE ConstanteNumerica", mySQLCon);
                myQuery4.ExecuteNonQuery();
                mySQLCon.Close();
            }
            mostrarDatosEnTablas();
        }

        private void btnGramatica_Click(object sender, EventArgs e)
        {
            rtxtGramatica.Text = "";
            MySqlConnection mySQLCon = new MySqlConnection(cadenaConexiong);

            string primeraCadena = "";
            string segundaCadena = "";
            bool bandera = true;

            List<int> listaErrores = new List<int>();
            int intCortadorCiclo = 0;

            for (int x = 0; x < rtxtCodigoIntermedio.Lines.Count(); x++)
            {
                intCortadorCiclo = 0;
                primeraCadena = rtxtCodigoIntermedio.Lines[x];
                segundaCadena = rtxtCodigoIntermedio.Lines[x];
                bandera = true;

                do
                {
                    mySQLCon.Open();
                    MySqlDataReader myDtRd;
                    MySqlCommand myQuery = new MySqlCommand("SELECT PRODUCTO, INSTRUCCION, LENGTH(INSTRUCCION) FROM GG ORDER BY LENGTH(INSTRUCCION) DESC", mySQLCon);
                    myDtRd = myQuery.ExecuteReader();

                    while (myDtRd.Read())
                    {
                        if (primeraCadena.Length >= myDtRd.GetInt32(2))
                        {
                            if (primeraCadena.Replace(myDtRd.GetString(1), myDtRd.GetString(0)) != segundaCadena)
                            {
                                MessageBox.Show("Cadena Principal: " + primeraCadena + "\nSe cambio: " + myDtRd.GetString(1) + "\nPor: " + myDtRd.GetString(0));
                                segundaCadena = primeraCadena.Replace(myDtRd.GetString(1), myDtRd.GetString(0));
                                primeraCadena = segundaCadena;
                                rtxtGramatica.Text += segundaCadena + "\n";
                                break;
                            }
                        }
                    }
                    mySQLCon.Close();
                    intCortadorCiclo++;
                    if (primeraCadena == "S" || primeraCadena == "S " || primeraCadena == "" || intCortadorCiclo >= 10)
                    {
                        bandera = false;
                        if (intCortadorCiclo >= 10)
                        {
                            listaErrores.Add(x);
                        }
                    }
                } while (bandera);
            }
            if (listaErrores != null)
            {
                foreach (int item in listaErrores)
                {
                    MessageBox.Show("Error de sintaxis en la línea: " + (item + 1), "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        Dictionary<string, int> misInstrComp = new Dictionary<string, int>();

        public void EvaluarInstrCompuestas()
        {
            misInstrComp.Clear();
            misInstrComp.Add("SI", 0);
            misInstrComp.Add("FINSI", 0);
            misInstrComp.Add("INICIO", 0);
            misInstrComp.Add("FIN", 0);
            misInstrComp.Add("EMPIEZA", 0);
            misInstrComp.Add("FINEMPIEZA", 0);
            foreach (string item in rtxtCodigo.Lines)
            {
                foreach (string palabra in item.Split(' '))
                {
                    if (misInstrComp.ContainsKey(palabra))
                    {
                        misInstrComp[palabra]++;
                    }
                }
            }

            if (misInstrComp["SI"] != misInstrComp["FINSI"])
                if (misInstrComp["SI"] > misInstrComp["FINSI"])
                    MessageBox.Show("Se esperaban " + (misInstrComp["SI"] - misInstrComp["FINSI"]) + " instrucciones de cierre <FINSI> para instrucciones <SI>", "Se ha detectado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Se esperaban " + (misInstrComp["FINSI"] - misInstrComp["SI"]) + " instrucciones de apertura <SI> para instrucciones <FINSI>", "Se ha detectado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (misInstrComp["INICIO"] != misInstrComp["FIN"])
                if (misInstrComp["INICIO"] > misInstrComp["FIN"])
                    MessageBox.Show("Se esperaba una instrucción de cierre <FIN> para la instrucción <INICIO>", "Se ha detectado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Se esperaba una instrucción de apertura <INICIO> para la instrucción <FIN>", "Se ha detectado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (misInstrComp["EMPIEZA"] != misInstrComp["FINEMPIEZA"])
                if (misInstrComp["EMPIEZA"] > misInstrComp["FINEMPIEZA"])
                    MessageBox.Show("Se esperaban " + (misInstrComp["EMPIEZA"] - misInstrComp["FINEMPIEZA"]) + " instrucciones de cierre <FINEMPIEZA> para instrucciones <EMPIEZA>", "Se ha detectado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Se esperaban " + (misInstrComp["FINEMPIEZA"] - misInstrComp["EMPIEZA"]) + " instrucciones de apertura <EMPIEZA> para instrucciones <FINEMPIEZA>", "Se ha detectado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSemantica_Click(object sender, EventArgs e)
        {
            rtxtSemantica.Text = "";
            MySqlConnection conect = new MySqlConnection(cadenaConexiong);
            string strFirst = "", strSecond = "";
            bool blnBandera = true;

            List<int> listaErrores = new List<int>();
            int intCortadorCiclo = 0;

            for (int i = 0; i < rtxTipos.Lines.Count(); i++)
            {
                intCortadorCiclo = 0;
                strFirst = rtxTipos.Lines[i];
                strSecond = rtxTipos.Lines[i];
                blnBandera = true;
                MySqlDataReader myDtRd1;
                MySqlCommand myQuery = new MySqlCommand("SELECT PRODUCTO, INSTRUCCION, LENGTH(INSTRUCCION) FROM SG ORDER BY LENGTH(INSTRUCCION) DESC", conect);
                do
                {
                    conect.Open();
                    myDtRd1 = myQuery.ExecuteReader();
                    while (myDtRd1.Read())
                    {
                        if (strFirst.Length >= myDtRd1.GetInt32(2))
                        {
                            if (strFirst.Replace(myDtRd1.GetString(1), myDtRd1.GetString(0)) != strSecond)
                            {
                                MessageBox.Show("Cadena Principal: " + strFirst + "\nSe cambio: " + myDtRd1.GetString(1) + "\nPor: " + myDtRd1.GetString(0));
                                strSecond = strFirst.Replace(myDtRd1.GetString(1), myDtRd1.GetString(0));
                                strFirst = strSecond;
                                rtxtSemantica.Text += strSecond + "\n";
                            }
                        }
                    }
                    conect.Close();
                    intCortadorCiclo++;
                    if (strFirst.Contains("S ") || strFirst.Equals("") || intCortadorCiclo >= 10)
                    {
                        blnBandera = false;
                        if (intCortadorCiclo >= 10)
                        {
                            listaErrores.Add(i);
                        }
                    }
                } while (blnBandera);
            }
            if (listaErrores != null)
            {
                foreach (int item in listaErrores)
                {
                    MessageBox.Show("Error de semántica en la línea: " + (item + 1), "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            EvaluarInstrCompuestas();
        }

        PostFijo miPostifjo = new PostFijo();
        public void AjustarInfijoPostfijo()
        {
            //infijo y postfijo
            rtxInfijo.Text = "";
            rtxPostfijo.Text = "";
            string strAux = "";
            int intContCnue = 0;
            for (int i = 0; i < rtxttokens.Lines.Count(); i++)
            {
                if (rtxttokens.Lines[i].Contains("CNUE"))
                {
                    foreach (string item in rtxttokens.Lines[i].Split(' '))
                    {
                        if (item.Equals("CNUE"))
                        {
                            intContCnue++;
                        }
                    }
                    for (int j = 0; j < rtxttokens.Lines[i].Split(' ').Count(); j++)
                    {
                        if (rtxttokens.Lines[i].Split(' ')[j].Equals("CNUE"))
                        {
                            foreach (DataGridViewRow row in dgvConstantesNumericas.Rows)
                            {
                                if (row.Cells["Contenido"].Value.ToString().Equals(rtxtCodigo.Lines[i].Split(' ')[j]))
                                {
                                    strAux += row.Cells["Token"].Value.ToString() + " ";
                                    break;
                                }
                            }
                        }
                        else
                        {
                            strAux += rtxttokens.Lines[i].Split(' ')[j] + " ";
                        }
                    }
                }
                else
                {
                    strAux += rtxttokens.Lines[i];
                }
                strAux += "\n";
                rtxInfijo.Text += strAux;
                strAux = "";
            }
            strAux = "";
            string strPostfijo = "";
            int intInfijoPalabra = 0;
            Regex regOp = new Regex(@"^OPA[1-5]|IDE[0-9]+|CNU[0-9]+$");
            Regex regArg8 = new Regex(@"^IDE[0-9]+|CNU[0-9]|CADE+$");

            List<string> listaLineas = rtxInfijo.Lines.ToList();
            listaLineas.Remove("");
            listaLineas.Remove("");
            for (int i = 0; i < (listaLineas.Count()); i++)
            {
                if (listaLineas[i].Contains("OPR5") || listaLineas[i].Contains("PR06") || listaLineas[i].Contains("PR10"))
                {
                    for (int j = 0; j < listaLineas[i].Split(' ').Count(); j++)
                    {
                        switch (listaLineas[i].Split(' ')[j])
                        {
                            case "OPR5": //=
                                strPostfijo += listaLineas[i].Split(' ')[j - 1]; //se le agrega el iden
                                strPostfijo += listaLineas[i].Split(' ')[j];     //se le agrega el =
                                intInfijoPalabra = j + 1; //se empieza del siguiente del =
                                for (int k = intInfijoPalabra; k < listaLineas[i].Split(' ').Count(); k++)
                                {
                                    if (regOp.IsMatch(listaLineas[i].Split(' ')[k]))
                                    {
                                        strPostfijo += listaLineas[i].Split(' ')[k];
                                    }
                                    else
                                    {
                                        strPostfijo = strPostfijo.Replace("OPR5", "=");
                                        strPostfijo = strPostfijo.Replace("OPA1", "+");
                                        strPostfijo = strPostfijo.Replace("OPA2", "-");
                                        strPostfijo = strPostfijo.Replace("OPA3", "*");
                                        strPostfijo = strPostfijo.Replace("OPA4", "/");
                                        strPostfijo = strPostfijo.Replace("OPA5", "^");
                                        //MessageBox.Show(strPostfijo);
                                        strAux += miPostifjo.TransformarPostfijo(strPostfijo) + " ";
                                        strPostfijo = "";
                                        j = k - 1;
                                        break;
                                    }
                                }
                                break;

                            case "OPR1":
                            case "OPR2":
                            case "OPR3":
                            case "OPR4":
                            case "OPR6":
                            case "OPL1":
                            case "OPL2":
                            case "OPL3":
                                if (regArg8.IsMatch(listaLineas[i].Split(' ')[j - 1]) && regArg8.IsMatch(listaLineas[i].Split(' ')[j + 1])) //si lo anterior y lo siguiente es un arg8
                                {
                                    strPostfijo += listaLineas[i].Split(' ')[j - 2]; //se le agrega el ces1
                                    strPostfijo += listaLineas[i].Split(' ')[j - 1]; //se le agrega el arg8
                                    strPostfijo += listaLineas[i].Split(' ')[j];     //se le agrega el opr / opl
                                    strPostfijo += listaLineas[i].Split(' ')[j + 1]; //se le agrega el arg8
                                    strPostfijo += listaLineas[i].Split(' ')[j + 2]; //se le agrega el ces2

                                    strPostfijo = strPostfijo.Replace("OPR1", ">");
                                    strPostfijo = strPostfijo.Replace("OPR2", "<");
                                    strPostfijo = strPostfijo.Replace("OPR3", ">=");
                                    strPostfijo = strPostfijo.Replace("OPR4", "<=");
                                    strPostfijo = strPostfijo.Replace("OPR6", "<>");
                                    strPostfijo = strPostfijo.Replace("CES1", "(");
                                    strPostfijo = strPostfijo.Replace("CES2", ")");

                                    strPostfijo = strPostfijo.Replace("AND", "OPL1");
                                    strPostfijo = strPostfijo.Replace("OR", "OPL2");
                                    strPostfijo = strPostfijo.Replace("NOT", "OPL3");
                                    strAux += miPostifjo.TransformarPostfijo(strPostfijo) + " ";
                                    MessageBox.Show("Infijo: " + strPostfijo + "\nPostfijo: " + strAux);
                                    strPostfijo = "";
                                    j += 1;
                                }
                                break;

                            default:
                                //MessageBox.Show(listaLineas[i].Split(' ')[j]);
                                if (!listaLineas[i].Split(' ')[j].Contains("IDE") && !listaLineas[i].Split(' ')[j].Contains("CES1") && !listaLineas[i].Split(' ')[j].Contains("CES2"))
                                {
                                    strAux += listaLineas[i].Split(' ')[j] + " ";
                                }
                                break;
                        }
                    }
                    strAux = strAux.Replace("+", "OPA1");
                    strAux = strAux.Replace("-", "OPA2");
                    strAux = strAux.Replace("*", "OPA3");
                    strAux = strAux.Replace("/", "OPA4");
                    strAux = strAux.Replace("^", "OPA5");

                    strAux = strAux.Replace(">", "OPR1");
                    strAux = strAux.Replace("<", "OPR2");
                    strAux = strAux.Replace(">=", "OPR3");
                    strAux = strAux.Replace("<=", "OPR4");
                    strAux = strAux.Replace("=", "OPR5");
                    strAux = strAux.Replace("<>", "OPR6");

                    strAux = strAux.Replace("AND", "OPL1");
                    strAux = strAux.Replace("OR", "OPL2");
                    strAux = strAux.Replace("NOT", "OPL3");
                    strAux += "\n";
                }
                else
                {
                    strAux += listaLineas[i];
                    strAux += "\n";
                }
            }
            rtxPostfijo.Text = strAux;
        }
    }
}
