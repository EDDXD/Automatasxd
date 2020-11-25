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
using Transitions;
using System.Threading;

namespace PrinterLanguage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvTripleta.Columns[0].Width = 35;
            dgvTrue.Columns[0].Width = 35;
            dgvFalse.Columns[0].Width = 35;
            dgvLoop.Columns[0].Width = 35;

            dgvTripleta.Columns[1].Width = 121;
            dgvTrue.Columns[1].Width = 121;
            dgvFalse.Columns[1].Width = 121;
            dgvLoop.Columns[1].Width = 121;

            dgvTripleta.Columns[2].Width = 121;
            dgvTrue.Columns[2].Width = 121;
            dgvFalse.Columns[2].Width = 121;
            dgvLoop.Columns[2].Width = 121;
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
                    if ((palabra.Contains('#') && linea.Split(' ').Length - 1 >= intNumeroPalabraActual + 3 && !blnSI && !palabra.Contains("HASTA")) || palabra.Equals("CAPTURAR"))
                    {
                        string strPalabraSiguiente = linea.Split(' ')[intNumeroPalabraActual + 2];
                        string strContenido = strPalabraSiguiente;
                        int intContadorAux = intNumeroPalabraActual + 2;
                        if (linea.Split(' ')[intNumeroPalabraActual + 1].Equals("=") && ((intNumeroPalabraActual > 0) ? !linea.Split(' ')[intNumeroPalabraActual - 1].Equals("HASTA") : true) || palabra.Equals("CAPTURAR"))
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
                                } while (strPalabraSiguiente != "");

                                if (blnRepetido)
                                {
                                    misIden[intRepetido].Contenido = strContenido;
                                    intRepetido = 0;
                                }
                                else
                                {
                                    misIden.Add(new Identificador("IDE" + (intContarIdens + 1), palabra, "Cadena", strContenido));
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
            dgvTripleta.Rows.Clear();
            dgvLoop.Rows.Clear();
            dgvTrue.Rows.Clear();
            dgvFalse.Rows.Clear();
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
                                try
                                {
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
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Variable no declarada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
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
            LlenarListaCadenas();
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
                try
                {
                    if (miIden.Tipo.Equals("Entero"))
                    {
                        updateCN(con);
                    }
                    qryActualizarTablas = new MySqlCommand("INSERT INTO Identificador (TOKEN, NOMBRE, TIPO, CONTENIDO) VALUES ( '" + miIden.Token + "', '" + miIden.Nombre + "', '" + miIden.Tipo + "', '" + miIden.Contenido + "' )", con);
                    qryActualizarTablas.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Variable no declarada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            con.Close();
            mostrarDatosEnTablas();
        }
        Dictionary<string, int> listaConstantesNumerica = new Dictionary<string, int>();
        public void updateCN(MySqlConnection connection)
        {
            listaConstantesNumerica = new Dictionary<string, int>();
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
                            listaConstantesNumerica.Add("CNU" + aux, int.Parse(palabra));
                            aux++;
                            qry.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        Dictionary<string, string> listaCadenas = new Dictionary<string, string>();

        public void LlenarListaCadenas()
        {
            MySqlConnection con = new MySqlConnection(cadenaConexion);
            MySqlCommand qry = new MySqlCommand("DELETE FROM Cadena", con);
            if (!con.State.ToString().Equals("Open"))
            {
                con.Open();
            }
            qry.ExecuteNonQuery();
            string strCadena = "";
            int intNumCadena = 1;
            listaCadenas = new Dictionary<string, string>();
            for (int i = 0; i < rtxtCodigo.Lines.Count(); i++)
            {
                for (int j = 0; j < rtxtCodigo.Lines[i].Split(' ').Count(); j++)
                {
                    if (rtxtCodigo.Lines[i].Split(' ')[j].Contains("["))
                    {
                        strCadena = "";
                        for (int k = j; k < rtxtCodigo.Lines[i].Split(' ').Count(); k++)
                        {
                            if (!rtxtCodigo.Lines[i].Split(' ')[k].Contains(" "))
                            {
                                if (k >= rtxtCodigo.Lines[i].Split(' ').Count() - 2)
                                {
                                    strCadena += rtxtCodigo.Lines[i].Split(' ')[k];
                                }
                                else
                                {
                                    strCadena += rtxtCodigo.Lines[i].Split(' ')[k] + " ";
                                }
                            }
                        }
                        if (!listaCadenas.ContainsValue(strCadena))
                        {
                            listaCadenas.Add("CADE" + intNumCadena, strCadena);
                            qry = new MySqlCommand("INSERT INTO Cadena (TOKEN, CONTENIDO) VALUES ( 'CADE" + intNumCadena + "', '" + strCadena + "' )", con);
                            qry.ExecuteNonQuery();
                            intNumCadena++;
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

            mySQLCon.Open();
            MySqlDataAdapter myDtAd3 = new MySqlDataAdapter("SELECT * FROM Cadena", mySQLCon);
            DataTable myDtTb3 = new DataTable();
            myDtAd3.Fill(myDtTb3);
            dgvCadenas.DataSource = myDtTb3;
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

            mySQLCon.Open();
            MySqlDataReader myDtRd3;
            MySqlCommand myQuery3 = new MySqlCommand("SELECT COUNT(*) FROM Cadena", mySQLCon);
            myDtRd3 = myQuery3.ExecuteReader();
            int cade = 0;
            while (myDtRd3.Read())
            {
                cade = myDtRd3.GetInt32(0);
            }
            mySQLCon.Close();

            if (id > 0)
            {
                mySQLCon.Open();
                MySqlCommand myQuery4 = new MySqlCommand("TRUNCATE Identificador", mySQLCon);
                myQuery4.ExecuteNonQuery();
                mySQLCon.Close();
            }

            if (cn > 0)
            {
                mySQLCon.Open();
                MySqlCommand myQuery5 = new MySqlCommand("TRUNCATE ConstanteNumerica", mySQLCon);
                myQuery5.ExecuteNonQuery();
                mySQLCon.Close();
            }

            if (cade > 0)
            {
                mySQLCon.Open();
                MySqlCommand myQuery6 = new MySqlCommand("TRUNCATE Cadena", mySQLCon);
                myQuery6.ExecuteNonQuery();
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
            {
                blnError = true;
                if (misInstrComp["SI"] > misInstrComp["FINSI"])
                    MessageBox.Show("Se esperaban " + (misInstrComp["SI"] - misInstrComp["FINSI"]) + " instrucciones de cierre <FINSI> para instrucciones <SI>", "Se ha detectado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Se esperaban " + (misInstrComp["FINSI"] - misInstrComp["SI"]) + " instrucciones de apertura <SI> para instrucciones <FINSI>", "Se ha detectado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (misInstrComp["INICIO"] != misInstrComp["FIN"])
            {
                blnError = true;
                if (misInstrComp["INICIO"] > misInstrComp["FIN"])
                    MessageBox.Show("Se esperaba una instrucción de cierre <FIN> para la instrucción <INICIO>", "Se ha detectado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Se esperaba una instrucción de apertura <INICIO> para la instrucción <FIN>", "Se ha detectado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (misInstrComp["EMPIEZA"] != misInstrComp["FINEMPIEZA"])
            {
                blnError = true;
                if (misInstrComp["EMPIEZA"] > misInstrComp["FINEMPIEZA"])
                    MessageBox.Show("Se esperaban " + (misInstrComp["EMPIEZA"] - misInstrComp["FINEMPIEZA"]) + " instrucciones de cierre <FINEMPIEZA> para instrucciones <EMPIEZA>", "Se ha detectado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Se esperaban " + (misInstrComp["FINEMPIEZA"] - misInstrComp["EMPIEZA"]) + " instrucciones de apertura <EMPIEZA> para instrucciones <FINEMPIEZA>", "Se ha detectado un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool blnError = false;
        private void btnSemantica_Click(object sender, EventArgs e)
        {
            dgvTripleta.Rows.Clear();
            dgvLoop.Rows.Clear();
            dgvTrue.Rows.Clear();
            dgvFalse.Rows.Clear();
            blnError = false;
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
                        if (intCortadorCiclo >= 15)
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
                    blnError = true;
                }
            }
            EvaluarInstrCompuestas();
            if (!blnError)
            {
                RellenarTripleta();
                //Animar();
            }
            else
            {
                MessageBox.Show("Existen errores semánticos por resolver.", "No se puede rellenar la tripleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EncenderImpresora();
                InterrumpirImpresora();
                ApagarImpresora();
            }
        }

        Dictionary<string, List<string>> dctTripleta = new Dictionary<string, List<string>>();  //contiene todas las listas para la tripleta
        List<string> lstInstruccionActual = new List<string>();                                 //la lista de la instruc actual

        Dictionary<string, int> dctContadorTripleta = new Dictionary<string, int>();            //cuenta el tipo de instr
        Dictionary<string, List<List<string>>> dctTrues = new Dictionary<string, List<List<string>>>();     //guarda las tripletas true
        Dictionary<string, List<List<string>>> dctFalses = new Dictionary<string, List<List<string>>>();    //guarda las tripletas false
        Dictionary<string, List<List<string>>> dctLoops = new Dictionary<string, List<List<string>>>();     //guarda las tripletas loop
        Dictionary<string, int> dctPosicionInstruccion = new Dictionary<string, int>();

        List<List<string>> lstTempLoop = new List<List<string>>();
        List<List<string>> lstTempTrue = new List<List<string>>();
        List<List<string>> lstTempFalse = new List<List<string>>();

        public string DetectarMejorRango(string strMejorRango, string strTipo)
        {
            foreach (KeyValuePair<string, string> rangos in dctRangosNoPermitidos)
            {
                if ((dctPosicionInstruccion[strTipo] > int.Parse(rangos.Value.Split(' ')[0]) && (dctPosicionInstruccion[strTipo] < int.Parse(rangos.Value.Split(' ')[1]))))
                {
                    if ((int.Parse(rangos.Value.Split(' ')[0]) > int.Parse(strMejorRango.Split(' ')[1])))
                    {
                        strMejorRango = rangos.Key + " " + rangos.Value;
                    }
                    blnPermitido = false;
                }
            }
            return strMejorRango;
        }

        bool blnHalladoGlobal = false;
        Dictionary<string, string> dctRangosNoPermitidos = new Dictionary<string, string>();
        bool blnPermitido = true;
        public void RellenarTripleta()
        {
            dctRangosNoPermitidos = new Dictionary<string, string>();
            dctPosicionInstruccion = new Dictionary<string, int>();
            dctTripleta = new Dictionary<string, List<string>>();
            lstInstruccionActual = new List<string>();
            dctTrues = new Dictionary<string, List<List<string>>>();
            dctFalses = new Dictionary<string, List<List<string>>>();
            dctLoops = new Dictionary<string, List<List<string>>>();
            string strMejorRango = "";

            dgvTripleta.Rows.Clear();

            dctContadorTripleta = new Dictionary<string, int>();
            dctContadorTripleta.Add("MOSTRAR", 0);
            dctContadorTripleta.Add("CAPTURAR", 0);
            dctContadorTripleta.Add("IMPRIMIR", 0);
            dctContadorTripleta.Add("SI", 0);
            dctContadorTripleta.Add("EMPIEZA", 0);
            dctContadorTripleta.Add("ASIGOPAR", 0);
            dctContadorTripleta.Add("ASIG", 0);

            string strLinea = "";
            string strToken = "";

            //Primero rellenamos la lista de instrucciones válidas
            for (int i = 0; i < rtxPostfijo.Lines.Count(); i++) //recorremos la lista de instr de rtx postfijo
            {
                strLinea = rtxPostfijo.Lines[i]; //guardamos la linea actual
                if (strLinea != "" && strLinea != " ") //evitamos ciclar con vacios
                {
                    //Si existe cualquiera de las siguientes, entonces no evalues la linea
                    //PR01 = INICIO
                    //PR02 = FIN
                    //PR08 = SINO
                    //PR09 = FINSI
                    //PR12 = FINEMPIEZA
                    if (!strLinea.Contains("PR01") && !strLinea.Contains("PR02"))
                    {
                        for (int j = 0; j < strLinea.Split(' ').Count(); j++)
                        {
                            strToken = strLinea.Split(' ')[j]; //guardamos el token actual

                            if (strToken.Contains("PR10"))                  //Si contiene EMPIEZA, entonces enciende la bandera blnTRLOOP para que todo lo que haya a continuacion se anada a la tripleta TRLOOP
                            {
                                //blnTRLOOP = true;
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, "****", "TRLOOP" + dctContadorTripleta["EMPIEZA"], "****");
                                dctRangosNoPermitidos.Add("TRLOOP" + dctContadorTripleta["EMPIEZA"], i.ToString());
                            }
                            else if (strToken.Contains("PR12"))             //Si contiene FINEMPIEZA, entonces se apaga la bandera blnTRLOOP
                            {
                                dctLoops.Add("TRLOOP" + (dctContadorTripleta["EMPIEZA"] - 1).ToString(), lstTempLoop);
                                dctRangosNoPermitidos["TRLOOP" + (dctContadorTripleta["EMPIEZA"] - 1).ToString()] += " " + i;
                                lstTempLoop = new List<List<string>>();
                                //blnTRLOOP = false;
                            }
                            else if (strToken.Contains("PR06"))             //Si contiene SI, entonces enciende la bandera blnTRTRUE para que todo lo que haya a continuacion se anada a la tripleta TRTRUE
                            {
                                //blnTRTRUE = true;
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, "****", "TRTRUE" + dctContadorTripleta["SI"], "****");
                                dctRangosNoPermitidos.Add("TRTRUE" + dctContadorTripleta["SI"], i.ToString());
                            }
                            else if (strToken.Contains("PR08"))             //Si contiene SINO, entonces se apaga la bandera blnTRTRUE y se enciende blnTRFALSE para que todo lo que haya a continuacion se anada a la tripleta TRFALSE
                            {
                                //blnTRTRUE = false;
                                //blnTRFALSE = true;
                                dctTrues.Add("TRTRUE" + dctContadorTripleta["SI"], lstTempTrue);
                                dctRangosNoPermitidos["TRTRUE" + (dctContadorTripleta["SI"] - 1).ToString()] += " " + i;
                                dctRangosNoPermitidos.Add("TRFALSE" + (dctContadorTripleta["SI"] - 1).ToString(), (i).ToString());

                                lstTempTrue = new List<List<string>>();
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, "****", "TRFALSE" + (dctContadorTripleta["SI"] - 1).ToString(), "****");
                            }
                            else if (strToken.Contains("PR09"))             //Si contiene FINSI, entonces se apaga la bandera blnTRTRUE y blnTRFALSE
                            {
                                dctFalses.Add("TRFALSE" + (dctContadorTripleta["SI"] - 1).ToString(), lstTempFalse);
                                if (dctRangosNoPermitidos.ContainsKey("TRFALSE" + (dctContadorTripleta["SI"] - 1).ToString()))
                                {
                                    dctRangosNoPermitidos["TRFALSE" + (dctContadorTripleta["SI"] - 1).ToString()] += " " + i;
                                }
                                else
                                {
                                    dctRangosNoPermitidos["TRTRUE" + (dctContadorTripleta["SI"] - 1).ToString()] += " " + i;
                                }

                                lstTempFalse = new List<List<string>>();
                                //blnTRTRUE = false;
                                //blnTRFALSE = false;
                            }

                            DetectarInstruccion(strToken, strLinea, i);
                            if (blnHalladoGlobal)
                                break;
                        }
                    }
                }
            }
            //Aqui se le da estructura a la TRIPLETA
            string strTipo = "";
            if (dctRangosNoPermitidos.Count() > 0)
            {
                strMejorRango = dctRangosNoPermitidos.ElementAt(0).Key + " " + dctRangosNoPermitidos.ElementAt(0).Value;
            }

            for (int i = 0; i < dctTripleta.Count(); i++)
            {
                lstInstruccionActual = dctTripleta.ElementAt(i).Value;
                strTipo = dctTripleta.ElementAt(i).Key;

                for (int j = 0; j < lstInstruccionActual.Count(); j++)
                {
                    if (strTipo.Contains("MOSTRAR"))
                    {
                        strMejorRango = DetectarMejorRango(strMejorRango, strTipo);

                        if (!blnPermitido)
                        {
                            if (strMejorRango.Contains("TRLOOP"))
                            {
                                lstTempLoop.Add(lstInstruccionActual);
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, "----", strTipo, "----");
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, "", string.Join(" ", lstInstruccionActual.Skip(1)), "PR03");
                            }
                            else if (strMejorRango.Contains("TRTRUE"))
                            {
                                lstTempTrue.Add(lstInstruccionActual);
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, "----", strTipo, "----");
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, "", string.Join(" ", lstInstruccionActual.Skip(1)), "PR03");
                            }
                            else if (strMejorRango.Contains("TRFALSE"))
                            {
                                lstTempFalse.Add(lstInstruccionActual);
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, "----", strTipo, "----");
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, "", string.Join(" ", lstInstruccionActual.Skip(1)), "PR03");
                            }
                        }
                        else
                        {
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "----", strTipo, "----");
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "", string.Join(" ", lstInstruccionActual.Skip(1)), "PR03");
                        }
                        blnPermitido = true;
                        break;
                    }
                    else if (strTipo.Contains("CAPTURAR"))
                    {
                        strMejorRango = DetectarMejorRango(strMejorRango, strTipo);

                        if (!blnPermitido)
                        {
                            if (strMejorRango.Contains("TRLOOP"))  //Si la bandera blnTRLOOP esta encendida, entonces se anade a la TRLOOP
                            {
                                lstTempLoop.Add(lstInstruccionActual);
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, "----", strTipo, "----");
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, string.Join(" ", lstInstruccionActual.Skip(1)), "Leer del teclado", "OPR5");
                            }
                            else if (strMejorRango.Contains("TRTRUE"))  //Si la bandera blnTRTRUE esta encendida, entonces se anade a la TRTRUE
                            {
                                lstTempTrue.Add(lstInstruccionActual);
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, "----", strTipo, "----");
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, string.Join(" ", lstInstruccionActual.Skip(1)), "Leer del teclado", "OPR5");
                            }
                            else if (strMejorRango.Contains("TRFALSE"))  //Si la bandera blnTRFALSE esta encendida, entonces se anade a la TRFALSE
                            {
                                lstTempFalse.Add(lstInstruccionActual);
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, "----", strTipo, "----");
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, string.Join(" ", lstInstruccionActual.Skip(1)), "Leer del teclado", "OPR5");
                            }
                        }
                        else
                        {
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "----", strTipo, "----");
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, string.Join(" ", lstInstruccionActual.Skip(1)), "Leer del teclado", "OPR5");
                        }
                        blnPermitido = true;
                        break;
                    }
                    else if (strTipo.Contains("IMPRIMIR"))
                    {
                        strMejorRango = DetectarMejorRango(strMejorRango, strTipo);

                        if (!blnPermitido)
                        {
                            if (strMejorRango.Contains("TRLOOP"))  //Si la bandera blnTRLOOP esta encendida, entonces se anade a la TRLOOP
                            {
                                lstTempLoop.Add(lstInstruccionActual);
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, "----", strTipo, "----");
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, "", string.Join(" ", lstInstruccionActual.Skip(1)), "PR05");
                            }
                            else if (strMejorRango.Contains("TRTRUE"))  //Si la bandera blnTRTRUE esta encendida, entonces se anade a la TRTRUE
                            {
                                lstTempTrue.Add(lstInstruccionActual);
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, "----", strTipo, "----");
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, "", string.Join(" ", lstInstruccionActual.Skip(1)), "PR05");
                            }
                            else if (strMejorRango.Contains("TRFALSE")) //Si la bandera blnTRFALSE esta encendida, entonces se anade a la TRFALSE
                            {
                                lstTempFalse.Add(lstInstruccionActual);
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, "----", strTipo, "----");
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, "", string.Join(" ", lstInstruccionActual.Skip(1)), "PR05");
                            }
                        }
                        else
                        {
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "----", strTipo, "----");
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "", string.Join(" ", lstInstruccionActual.Skip(1)), "PR05");
                        }
                        blnPermitido = true;
                        break;
                    }
                    else if (strTipo.Contains("EMPIEZA"))
                    {
                        strMejorRango = DetectarMejorRango(strMejorRango, strTipo);

                        if (!blnPermitido)
                        {
                            if (strMejorRango.Contains("TRLOOP"))  //Si la bandera blnTRLOOP esta encendida, entonces se anade a la TRLOOP
                            {
                                lstTempLoop.Add(lstInstruccionActual);
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, "----", strTipo, "----");
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, lstInstruccionActual[1], lstInstruccionActual[2], lstInstruccionActual[3]);
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, lstInstruccionActual[5], lstInstruccionActual[6], lstInstruccionActual[7]);
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, "SALTO", "true", dgvLoop.Rows.Count + 5);
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, "SALTO", "false", dgvLoop.Rows.Count + 1);
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, "SALTO", "TRLOOP" + strTipo.Substring(7), "");
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, lstInstruccionActual[1], 1, "OPA1");
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, "SALTO", "", dgvLoop.Rows.Count - 5);
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, "FIN", "", "");
                            }
                            else if (strMejorRango.Contains("TRTRUE"))  //Si la bandera blnTRTRUE esta encendida, entonces se anade a la TRTRUE
                            {
                                lstTempTrue.Add(lstInstruccionActual);
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, "----", strTipo, "----");
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, lstInstruccionActual[1], lstInstruccionActual[2], lstInstruccionActual[3]);
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, lstInstruccionActual[5], lstInstruccionActual[6], lstInstruccionActual[7]);
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, "SALTO", "true", dgvTrue.Rows.Count + 5);
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, "SALTO", "false", dgvTrue.Rows.Count + 1);
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, "SALTO", "TRLOOP" + strTipo.Substring(7), "");
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, lstInstruccionActual[1], 1, "OPA1");
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, "SALTO", "", dgvTrue.Rows.Count - 5);
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, "FIN", "", "");
                            }
                            else if (strMejorRango.Contains("TRFALSE")) //Si la bandera blnTRFALSE esta encendida, entonces se anade a la TRFALSE
                            {
                                lstTempFalse.Add(lstInstruccionActual);
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, "----", strTipo, "----");
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, lstInstruccionActual[1], lstInstruccionActual[2], lstInstruccionActual[3]);
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, lstInstruccionActual[5], lstInstruccionActual[6], lstInstruccionActual[7]);
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, "SALTO", "true", dgvFalse.Rows.Count + 5);
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, "SALTO", "false", dgvFalse.Rows.Count + 1);
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, "SALTO", "TRLOOP" + strTipo.Substring(7), "");
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, lstInstruccionActual[1], 1, "OPA1");
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, "SALTO", "", dgvFalse.Rows.Count - 5);
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, "FIN", "", "");
                            }
                        }
                        else
                        {
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "----", strTipo, "----");
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, lstInstruccionActual[1], lstInstruccionActual[2], lstInstruccionActual[3]);
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, lstInstruccionActual[5], lstInstruccionActual[6], lstInstruccionActual[7]);
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "SALTO", "true", dgvTripleta.Rows.Count + 5);
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "SALTO", "false", dgvTripleta.Rows.Count + 1);
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "SALTO", "TRLOOP" + strTipo.Substring(7), "");
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, lstInstruccionActual[1], 1, "OPA1");
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "SALTO", "", dgvTripleta.Rows.Count - 5);
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "FIN", "", "");
                        }
                        blnPermitido = true;
                        break;
                    }
                    else if (strTipo.Contains("ASIGOPAR"))
                    {
                        switch (lstInstruccionActual[j])
                        {
                            case "OPA1": // +
                            case "OPA2": // -
                            case "OPA3": // *
                            case "OPA4": // /
                            case "OPA5": // ^
                            case "OPR5": // =
                                string strAnterior = lstInstruccionActual[j - 1];                                                              //Se guarda el operando anterior
                                string strAnteriorAnterior = lstInstruccionActual[j - 2];                                                      //Se guarda el operando ant anterior (el que recibe los cambios)
                                string strOperando = lstInstruccionActual[j];

                                strMejorRango = DetectarMejorRango(strMejorRango, strTipo);

                                if (!blnPermitido)
                                {
                                    if (strMejorRango.Contains("TRLOOP"))  //Si la bandera blnTRLOOP esta encendida, entonces se anade a la TRLOOP
                                    {
                                        lstTempLoop.Add(lstInstruccionActual);
                                        dgvLoop.Rows.Add(dgvLoop.Rows.Count, "----", strTipo, "----");
                                        dgvLoop.Rows.Add(dgvLoop.Rows.Count, strAnteriorAnterior, strAnterior, strOperando);
                                    }
                                    else if (strMejorRango.Contains("TRTRUE"))  //Si la bandera blnTRTRUE esta encendida, entonces se anade a la TRTRUE
                                    {
                                        lstTempTrue.Add(lstInstruccionActual);
                                        dgvTrue.Rows.Add(dgvTrue.Rows.Count, "----", strTipo, "----");
                                        dgvTrue.Rows.Add(dgvTrue.Rows.Count, strAnteriorAnterior, strAnterior, strOperando);
                                    }
                                    else if (strMejorRango.Contains("TRFALSE"))  //Si la bandera blnTRFALSE esta encendida, entonces se anade a la TRFALSE
                                    {
                                        lstTempFalse.Add(lstInstruccionActual);
                                        dgvFalse.Rows.Add(dgvFalse.Rows.Count, "----", strTipo, "----");
                                        dgvFalse.Rows.Add(dgvFalse.Rows.Count, strAnteriorAnterior, strAnterior, strOperando);
                                    }
                                }
                                else
                                {
                                    dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "----", strTipo, "----");
                                    dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "", string.Join(" ", lstInstruccionActual.Skip(1)), "PR05");
                                }
                                lstInstruccionActual.Remove(strAnterior);
                                lstInstruccionActual.Remove(strOperando);
                                j = -1;
                                blnPermitido = true;
                                break;
                        }
                    }
                    else if (strTipo.Contains("ASIG"))
                    {
                        strMejorRango = DetectarMejorRango(strMejorRango, strTipo);

                        if (!blnPermitido)
                        {
                            if (strMejorRango.Contains("TRLOOP"))  //Si la bandera blnTRLOOP esta encendida, entonces se anade a la TRLOOP
                            {
                                lstTempLoop.Add(lstInstruccionActual);
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, "----", strTipo, "----");
                                dgvLoop.Rows.Add(dgvLoop.Rows.Count, lstInstruccionActual[0], string.Join(" ", lstInstruccionActual.Skip(1).Take(1)), "OPR5");
                            }
                            else if (strMejorRango.Contains("TRTRUE"))  //Si la bandera blnTRTRUE esta encendida, entonces se anade a la TRTRUE
                            {
                                lstTempTrue.Add(lstInstruccionActual);
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, "----", strTipo, "----");
                                dgvTrue.Rows.Add(dgvTrue.Rows.Count, lstInstruccionActual[0], string.Join(" ", lstInstruccionActual.Skip(1).Take(1)), "OPR5");
                            }
                            else if (strMejorRango.Contains("TRFALSE")) //Si la bandera blnTRFALSE esta encendida, entonces se anade a la TRFALSE
                            {
                                lstTempFalse.Add(lstInstruccionActual);
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, "----", strTipo, "----");
                                dgvFalse.Rows.Add(dgvFalse.Rows.Count, lstInstruccionActual[0], string.Join(" ", lstInstruccionActual.Skip(1).Take(1)), "OPR5");
                            }
                        }
                        else
                        {
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "----", strTipo, "----");
                            dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, lstInstruccionActual[0], string.Join(" ", lstInstruccionActual.Skip(1).Take(1)), "OPR5");
                        }
                        blnPermitido = true;
                        break;
                    }
                    else if (strTipo.Contains("SI"))
                    {
                        strMejorRango = DetectarMejorRango(strMejorRango, strTipo);

                        if (!blnPermitido)
                        {
                            if (strMejorRango.Contains("TRLOOP"))  //Si la bandera blnTRLOOP esta encendida, entonces se anade a la TRLOOP
                            {
                                lstTempLoop.Add(lstInstruccionActual);
                                if (!(lstInstruccionActual.Contains("OPL1") || lstInstruccionActual.Contains("OPL2") || lstInstruccionActual.Contains("OPL3")))
                                {
                                    dgvLoop.Rows.Add(dgvLoop.Rows.Count, "----", strTipo, "----");
                                    if (!lstInstruccionActual.Contains("CES1"))
                                    {
                                        dgvLoop.Rows.Add(dgvLoop.Rows.Count, lstInstruccionActual[1], lstInstruccionActual[2], lstInstruccionActual[3]);
                                    }
                                    else
                                    {
                                        dgvLoop.Rows.Add(dgvLoop.Rows.Count, lstInstruccionActual[2], lstInstruccionActual[3], lstInstruccionActual[4]);
                                    }
                                    dgvLoop.Rows.Add(dgvLoop.Rows.Count, "SALTO", "true", dgvLoop.Rows.Count + 2);
                                    dgvLoop.Rows.Add(dgvLoop.Rows.Count, "SALTO", "false", dgvLoop.Rows.Count + 3);
                                    dgvLoop.Rows.Add(dgvLoop.Rows.Count, "SALTO", "TRTRUE" + strTipo.Substring(2), "");
                                    dgvLoop.Rows.Add(dgvLoop.Rows.Count, "SALTO", "", dgvLoop.Rows.Count + 2);
                                    dgvLoop.Rows.Add(dgvLoop.Rows.Count, "SALTO", "TRFALSE" + strTipo.Substring(2), "");
                                    dgvLoop.Rows.Add(dgvLoop.Rows.Count, "FIN", "", "");
                                }
                            }
                            else if (strMejorRango.Contains("TRTRUE"))  //Si la bandera blnTRTRUE esta encendida, entonces se anade a la TRTRUE
                            {
                                lstTempTrue.Add(lstInstruccionActual);
                                if (!(lstInstruccionActual.Contains("OPL1") || lstInstruccionActual.Contains("OPL2") || lstInstruccionActual.Contains("OPL3")))
                                {
                                    dgvTrue.Rows.Add(dgvTrue.Rows.Count, "----", strTipo, "----");
                                    if (!lstInstruccionActual.Contains("CES1"))
                                    {
                                        dgvTrue.Rows.Add(dgvTrue.Rows.Count, lstInstruccionActual[1], lstInstruccionActual[2], lstInstruccionActual[3]);
                                    }
                                    else
                                    {
                                        dgvTrue.Rows.Add(dgvTrue.Rows.Count, lstInstruccionActual[2], lstInstruccionActual[3], lstInstruccionActual[4]);
                                    }
                                    dgvTrue.Rows.Add(dgvTrue.Rows.Count, "SALTO", "true", dgvTrue.Rows.Count + 2);
                                    dgvTrue.Rows.Add(dgvTrue.Rows.Count, "SALTO", "false", dgvTrue.Rows.Count + 3);
                                    dgvTrue.Rows.Add(dgvTrue.Rows.Count, "SALTO", "TRTRUE" + strTipo.Substring(2), "");
                                    dgvTrue.Rows.Add(dgvTrue.Rows.Count, "SALTO", "", dgvTrue.Rows.Count + 2);
                                    dgvTrue.Rows.Add(dgvTrue.Rows.Count, "SALTO", "TRFALSE" + strTipo.Substring(2), "");
                                    dgvTrue.Rows.Add(dgvTrue.Rows.Count, "FIN", "", "");
                                }
                            }
                            else if (strMejorRango.Contains("TRFALSE"))  //Si la bandera blnTRFALSE esta encendida, entonces se anade a la TRFALSE
                            {
                                lstTempFalse.Add(lstInstruccionActual);
                                if (!(lstInstruccionActual.Contains("OPL1") || lstInstruccionActual.Contains("OPL2") || lstInstruccionActual.Contains("OPL3")))
                                {
                                    dgvFalse.Rows.Add(dgvFalse.Rows.Count, "----", strTipo, "----");
                                    if (!lstInstruccionActual.Contains("CES1"))
                                    {
                                        dgvFalse.Rows.Add(dgvFalse.Rows.Count, lstInstruccionActual[1], lstInstruccionActual[2], lstInstruccionActual[3]);
                                    }
                                    else
                                    {
                                        dgvFalse.Rows.Add(dgvFalse.Rows.Count, lstInstruccionActual[2], lstInstruccionActual[3], lstInstruccionActual[4]);
                                    }
                                    dgvFalse.Rows.Add(dgvFalse.Rows.Count, "SALTO", "true", dgvFalse.Rows.Count + 2);
                                    dgvFalse.Rows.Add(dgvFalse.Rows.Count, "SALTO", "false", dgvFalse.Rows.Count + 3);
                                    dgvFalse.Rows.Add(dgvFalse.Rows.Count, "SALTO", "TRTRUE" + strTipo.Substring(2), "");
                                    dgvFalse.Rows.Add(dgvFalse.Rows.Count, "SALTO", "", dgvFalse.Rows.Count + 2);
                                    dgvFalse.Rows.Add(dgvFalse.Rows.Count, "SALTO", "TRFALSE" + strTipo.Substring(2), "");
                                    dgvFalse.Rows.Add(dgvFalse.Rows.Count, "FIN", "", "");
                                }
                            }
                        }
                        else
                        {
                            if (!(lstInstruccionActual.Contains("OPL1") || lstInstruccionActual.Contains("OPL2") || lstInstruccionActual.Contains("OPL3")))
                            {
                                dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "----", strTipo, "----");
                                if (!lstInstruccionActual.Contains("CES1"))
                                {
                                    dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, lstInstruccionActual[1], lstInstruccionActual[2], lstInstruccionActual[3]);
                                }
                                else
                                {
                                    dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, lstInstruccionActual[2], lstInstruccionActual[3], lstInstruccionActual[4]);
                                }
                                dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "SALTO", "true", dgvTripleta.Rows.Count + 2);
                                dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "SALTO", "false", dgvTripleta.Rows.Count + 3);
                                dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "SALTO", "TRTRUE" + strTipo.Substring(2), "");
                                dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "SALTO", "", dgvTripleta.Rows.Count + 2);
                                dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "SALTO", "TRFALSE" + strTipo.Substring(2), "");
                                dgvTripleta.Rows.Add(dgvTripleta.Rows.Count, "FIN", "", "");
                            }
                        }
                        blnPermitido = true;
                        break;
                    }
                }
            }
        }

        public void AgregarListaInstruccionActual(string linea, string tipo)
        {
            foreach (string tokenActual in linea.Split(' '))
            {
                if (tokenActual != " " && tokenActual != "")
                {
                    lstInstruccionActual.Add(tokenActual);
                }
            }
            dctTripleta.Add(tipo, lstInstruccionActual);
            lstInstruccionActual = new List<string>();
        }

        public void DetectarInstruccion(string strToken, string strLinea, int intLinea)
        {
            bool blnHalladoLocal = false;
            blnHalladoGlobal = false;
            string strTipoInstr = "";
            if (strToken != "" && strToken != " ") //evitamos iteraciones innecesarias
            {
                switch (strToken)
                {
                    case "PR03": // MOSTRAR
                        strTipoInstr = "MOSTRAR" + dctContadorTripleta["MOSTRAR"];
                        dctContadorTripleta["MOSTRAR"]++;
                        blnHalladoLocal = true;
                        break;

                    case "PR04": // CAPTURAR
                        strTipoInstr = "CAPTURAR" + dctContadorTripleta["CAPTURAR"];
                        dctContadorTripleta["CAPTURAR"]++;
                        blnHalladoLocal = true;
                        break;

                    case "PR05": // IMPRIMIR
                        strTipoInstr = "IMPRIMIR" + dctContadorTripleta["IMPRIMIR"];
                        dctContadorTripleta["IMPRIMIR"]++;
                        blnHalladoLocal = true;
                        break;

                    case "PR10": // EMPIEZA
                        strTipoInstr = "EMPIEZA" + dctContadorTripleta["EMPIEZA"];
                        dctContadorTripleta["EMPIEZA"]++;
                        blnHalladoLocal = true;
                        break;

                    case "OPA1": // +
                    case "OPA2": // -
                    case "OPA3": // *
                    case "OPA4": // /
                    case "OPA5": // ^
                        strTipoInstr = "ASIGOPAR" + dctContadorTripleta["ASIGOPAR"];
                        dctContadorTripleta["ASIGOPAR"]++;
                        blnHalladoLocal = true;
                        break;

                    case "PR06": // SI
                        strTipoInstr = "SI" + dctContadorTripleta["SI"];
                        dctContadorTripleta["SI"]++;
                        blnHalladoLocal = true;
                        break;
                }
                if (strLinea.Split(' ')[0].Contains("IDE") && !strLinea.Contains("OPA"))
                {
                    strTipoInstr = "ASIG" + dctContadorTripleta["ASIG"];
                    dctContadorTripleta["ASIG"]++;
                    blnHalladoLocal = true;
                }
                if (blnHalladoLocal)
                {
                    AgregarListaInstruccionActual(strLinea, strTipoInstr);
                    dctPosicionInstruccion.Add(strTipoInstr, intLinea);
                    blnHalladoGlobal = true;
                }
            }
        }

        PostFijo miPostifjo = new PostFijo();
        public void AjustarInfijoPostfijo()
        {
            //infijo y postfijo
            rtxInfijo.Text = "";
            rtxPostfijo.Text = "";
            string strAux = "";
            string strCadeAux = "";
            int intContCnue = 0, intContCade = 0;
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
                else if (rtxttokens.Lines[i].Contains("CADE"))
                {
                    foreach (string item in rtxttokens.Lines[i].Split(' '))
                    {
                        if (item.Equals("CADE"))
                        {
                            intContCade++;
                        }
                    }
                    for (int j = 0; j < rtxttokens.Lines[i].Split(' ').Count(); j++)
                    {
                        if (rtxttokens.Lines[i].Split(' ')[j].Equals("CADE"))
                        {
                            for (int k = j; k < rtxtCodigo.Lines[i].Split(' ').Count(); k++)
                            {
                                if (rtxtCodigo.Lines[i].Split(' ')[k] != "]")
                                {
                                    strCadeAux += rtxtCodigo.Lines[i].Split(' ')[k] + " ";
                                }
                                else
                                {
                                    strCadeAux += rtxtCodigo.Lines[i].Split(' ')[k];
                                    break;
                                }
                            }
                            foreach (DataGridViewRow row in dgvCadenas.Rows)
                            {
                                if (row.Cells["Contenido"].Value.ToString().Equals(strCadeAux))
                                {
                                    strAux += row.Cells["Token"].Value.ToString() + " ";
                                    strCadeAux = "";
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
                                    strPostfijo += (!listaLineas[i].Split(' ')[j - 2].Contains("PR11") ? listaLineas[i].Split(' ')[j - 2] : ""); //se le agrega el ces1
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
                                    strPostfijo = "";
                                    j += 1;
                                }
                                break;

                            default:
                                //MessageBox.Show(listaLineas[i].Split(' ')[j]);
                                if (!listaLineas[i].Split(' ')[j].Contains("IDE") && !listaLineas[i].Split(' ')[j].Contains("CES1") && !listaLineas[i].Split(' ')[j].Contains("CES2") && !listaLineas[i].Split(' ')[j].Contains("CNU") && !listaLineas[i].Split(' ')[j].Contains("CADE"))
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
            string[] lineasCorregidas = rtxPostfijo.Lines;
            rtxPostfijo.Text = "";
            for (int i = 0; i < lineasCorregidas.Count(); i++)
            {
                lineasCorregidas[i] = lineasCorregidas[i].Replace("  ", " ");
                rtxPostfijo.Text += lineasCorregidas[i] + "\n";
            }
        }

        //métodos para animaciones
        public void ImprimirImpresora()
        {
            hoja.Location = new Point(1637, 84);
            btnVerde.Visible = true;
            label13.Text = "IMPRIMIENDO";
            label13.Location = new Point(1686, 256);
            Transition.run(label13, "BackColor", Color.LawnGreen, new TransitionType_Linear(2000));
            Transition t = new Transition(new TransitionType_EaseInEaseOut(2000));
            Transition.run(label13, "BackColor", Color.Black, new TransitionType_Linear(2000));
            t.add(hoja, "Top", 350);
            t.run();
            label13.ForeColor = Color.Black;
            Transition.run(label13, "ForeColor", Color.White, new TransitionType_Linear(2000));
        }

        public void InterrumpirImpresora()
        {

            label13.BackColor = Color.Black;
            label13.ForeColor = Color.Black;
            hoja.Location = new Point(1637, 84);
            btnAmarillo.Visible = true;
            label13.Text = "Interrumpida";
            label13.Location = new Point(1686, 256);
            Transition.run(label13, "BackColor", Color.Yellow, new TransitionType_Linear(2000));
            Transition t = new Transition(new TransitionType_EaseInEaseOut(1500));
            t.add(hoja, "Top", 120);
            t.run();
            Transition t2 = new Transition(new TransitionType_EaseInEaseOut(3000));
            t2.add(hojaEscaner, "Left", 1600);
            t2.run();
        }

        public void ApagarImpresora()
        {
            label13.ForeColor = Color.White;
            btnAmarillo.BackgroundImage = null;
            btnAmarillo.Visible = true;
            btnRojo.BackgroundImage = null;
            btnRojo.Visible = true;
            label13.Text = "APAGANDO";
            label13.Location = new Point(1686, 256);
            Transition.run(btnAmarillo, "BackColor", Color.Black, new TransitionType_Linear(2000));
            Transition.run(btnRojo, "BackColor", Color.Black, new TransitionType_Linear(2000));
            Transition.run(label13, "ForeColor", Color.Black, new TransitionType_Linear(2000));
            label13.ForeColor = Color.White;
            label13.BackColor = Color.Black;
        }

        public void EncenderImpresora()
        {
            btnAmarillo.BackgroundImage = null;
            btnAmarillo.Visible = true;
            btnRojo.BackgroundImage = null;
            btnRojo.Visible = true;
            btnVerde.BackgroundImage = null;
            btnVerde.Visible = true;
            btnAmarillo.BackColor = Color.Black;
            btnRojo.BackColor = Color.Black;
            label13.Text = "ENCENDIENDO";
            label13.ForeColor = Color.Black;
            label13.BackColor = Color.Black;
            label13.Location = new Point(1686, 256);
            Transition.run(btnVerde, "BackColor", Color.Green, new TransitionType_Linear(2000));
            Transition.run(btnAmarillo, "BackColor", Color.Yellow, new TransitionType_Linear(2000));
            Transition.run(btnRojo, "BackColor", Color.Red, new TransitionType_Linear(2000));
            Transition.run(label13, "ForeColor", Color.White, new TransitionType_Linear(2000));
            label13.ForeColor = Color.White;
        }

        public void EscanearImpresora()
        {
            hojaEscaner.Location = new Point(1859, 212);
            hojaEscaner.Visible = true;
            btnVerde.Visible = true;
            label13.Text = "ESCANEANDO";
            label13.Location = new Point(1686, 256);
            Transition.run(label13, "BackColor", Color.LawnGreen, new TransitionType_Linear(2000));
            Transition t = new Transition(new TransitionType_EaseInEaseOut(3000));
            t.add(hojaEscaner, "Left", 1300);
            t.run();
            label13.ForeColor = Color.Black;
        }

        public void MensajeImpresora(string mensaje)
        {
            label13.ForeColor = Color.Black;
            label13.BackColor = Color.Black;
            hoja.Location = new Point(1637, 84);
            btnAmarillo.Visible = true;
            label13.Text = mensaje;
            label13.Location = new Point(1686, 256);
            Transition.run(label13, "BackColor", Color.Yellow, new TransitionType_Linear(2000));
        }

        private void btnAnimar_Click(object sender, EventArgs e)
        {

        }
    }
}
