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
            intContarIdens = 1;
            int intNumeroPalabraActual = 0;
            misIden = new List<Identificador>();
            Identificador miIdeTemp = new Identificador();
            bool blnRepetido = false;
            int intRepetido = 0;

            foreach (string linea in rtxtCodigo.Lines) //POR CADA LINEA
            {
                intRepetido = 0;
                intNumeroPalabraActual = 0;
                foreach (string palabra in linea.Split(' ')) //RECORRE CADA PALABRA
                {
                    if ((palabra.Contains('#') && linea.Split(' ').Length - 1 >= intNumeroPalabraActual + 3) || palabra.Equals("CAPTURAR"))
                    {
                        if (linea.Split(' ')[intNumeroPalabraActual + 1].Equals("=") || palabra.Equals("CAPTURAR"))
                        {
                            string strPalabraSiguiente = linea.Split(' ')[intNumeroPalabraActual + 2];
                            string strContenido = strPalabraSiguiente;
                            int intContadorAux = intNumeroPalabraActual + 2;

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
                                        break;
                                    }
                                }
                                else
                                {
                                    if (id.Nombre.Equals(palabra))
                                    {
                                        blnRepetido = true;
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
                                    misIden.Add(new Identificador("IDE" + intContarIdens, palabra, "Cadena", strContenido + " ]"));
                                    intContarIdens++;
                                }
                                blnRepetido = false;
                            }
                            else if (palabra != "CAPTURAR")
                            {
                                if (blnRepetido)
                                {
                                    misIden[intRepetido].Contenido = strContenido;
                                    intRepetido = 0;
                                }
                                else
                                {
                                    misIden.Add(new Identificador("IDE" + intContarIdens, palabra, "Entero", strContenido));
                                    intContarIdens++;
                                }
                                blnRepetido = false;
                            }
                            else
                            {
                                if (blnRepetido)
                                {
                                    misIden[intRepetido].Contenido = strContenido;
                                    misIden[intRepetido].Tipo = (strContenido.Contains("[")) ? "Cadena" : "Entero";
                                    intRepetido = 0;
                                }
                                else
                                {
                                    misIden.Add(new Identificador("IDE" + intContarIdens, strPalabraSiguiente, "No definido", "null"));
                                    intContarIdens++;
                                }
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
                        if (esp)
                        {
                            //MessageBox.Show("ESPACIO \n Apuntador: " + apuntador, "Datos del recorrido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            apuntador = Recorrer(apuntador, "DEL");
                            token = Recorrer(apuntador, "TOKEN");
                            Identificador ideTemporal;
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
                                //token = agregarDatosEnTablas("Identificador", ideTemporal.Token, ideTemporal.Nombre, ideTemporal.Tipo, ideTemporal.Contenido);
                                //mostrarDatosEnTablas();
                                aux1 = ideTemporal.Token;
                                bandera = true;
                                intIdenActual++;
                            }
                            else if (token == "CNU")
                            {
                                //ideTemporal = new Identificador("CNU"+intContarEnteros, "", "", misIden.ElementAt(intIdenActual-1).Contenido);

                                //token = agregarDatosEnTablas("ConstanteNumerica", token, subcadena, subcadena, subcadena);
                                //mostrarDatosEnTablas();
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

                            txtCadenaDeTokens.Text = txtCadenaDeTokens.Text + (token.Equals("IDE")?token+="N":(token.Equals("CNU")?token+="E":token)) + " ";
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

            //string str = "";
            //foreach (Identificador idee in misIden)
            //{
            //    str += idee.Token;
            //}
            //MessageBox.Show(str);
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
                            strAux += i.Tipo.ToLower()+" ";
                        }
                    }
                }
                else if (s.Equals("CADE"))
                {
                    strAux += "cadena";
                }
                else
                {
                    strAux += s+" ";
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
                    //MessageBox.Show("Columna: " + nomCol + "\n Token: " + token, "Datos del recorrido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return token;
                }
                else
                {
                    nomCol = myDtRd.GetName(0);
                    a = myDtRd.GetString(0);
                    //MessageBox.Show("Columna: " + nomCol + "\n Apuntador: " + a, "Datos del recorrido", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                                        "TIPO = '" + (miIden.Contenido.Contains("[") ? "Cadena" : "Entero") + "' " +
                                                        "WHERE NOMBRE = '" + miIden.Nombre + "'", con);
                qryActualizarTablas.ExecuteNonQuery();
                if (!miIden.Contenido.Contains("["))
                {
                    //qryActualizarTablas = new MySqlCommand("UPDATE ConstanteNumerica SET CONTENIDO = '" + miIden.Contenido + "' WHERE TOKEN = 'CNU" + (intIdenActual-1) + "'", con);
                    //qryActualizarTablas.ExecuteNonQuery();
                    //intContarEnteros++;
                    updateCN(con);
                }
            }
            else
            {
                if (miIden.Tipo.Equals("Entero"))
                {
                    //qryActualizarTablas = new MySqlCommand("INSERT INTO ConstanteNumerica (TOKEN, CONTENIDO) VALUES ( 'CNU" + intContarEnteros + "', '" + miIden.Contenido + "' )", con);
                    //intContarEnteros++;
                    //qryActualizarTablas.ExecuteNonQuery();
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

            foreach (DataGridViewRow row in dgvIdentificadores.Rows)
            {
                if (row.Cells["TIPO"].Value.ToString().Equals("Entero"))
                {
                    qry = new MySqlCommand("INSERT INTO ConstanteNumerica (TOKEN, CONTENIDO) VALUES ( 'CNU" + aux + "', '" + row.Cells["CONTENIDO"].Value.ToString() + "' )", connection);
                    qry.ExecuteNonQuery();
                    aux++;
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
            MySqlConnection mySQLCon = new MySqlConnection(cadenaConexiong);

            string primeraCadena = "";
            string segundaCadena = "";

            for (int x = 0; x < rtxttokens.Lines.Count(); x++)
            {
                primeraCadena = rtxttokens.Lines[x];
                segundaCadena = rtxttokens.Lines[x];
                bool bandera = true;

                do
                {
                    mySQLCon.Open();
                    MySqlDataReader myDtRd;
                    MySqlCommand myQuery = new MySqlCommand("SELECT PRODUCTO, INSTRUCCION, LENGTH(INSTRUCCION) FROM G ORDER BY PRODUCTO ASC, LENGTH(INSTRUCCION) DESC", mySQLCon);
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
                                //MessageBox.Show(primeraCadena + "\n" + segundaCadena);
                                rtxtGramatica.Text += segundaCadena + "\n";
                                break;
                            }
                            else
                            {
                                //MessageBox.Show("no hubo cambios");
                            }
                        }
                    }
                    mySQLCon.Close();

                    if (primeraCadena == "S" || primeraCadena == "S ")
                    {
                        bandera = false;
                        //rtxtGramatica.Text += primeraCadena + "\n";
                        //MessageBox.Show("ya hay una S, el recorrido termino");
                    }

                } while (bandera);
                //MessageBox.Show("ya salio del dowhile");
            }
        }

        private void rtxttokens_TextChanged(object sender, EventArgs e)
        {


        }

        private void btnconvertir_Click(object sender, EventArgs e)
        {
        }
    }
}
