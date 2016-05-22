using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Proxar.Modele
{
    class BDDUserManagement
    {

        private string rq_sql;                              //Objet string qui contiendra les requêtes SQL
        private string cnx;                                 //Object string qui contiendra la clé de connection a la BDD
        private SqlConnection sCNX;                         //Objet Connection de BDD
        private SqlCommand sCMD;                            //Objet Command qui executera une requête SQL
        private SqlDataReader sDR;                         //Objet DataReader qui fait le lien entre l'application et la BDD
        //private System.Data.DataSet oDS;                    //Objet qui stock en local les informations de la BDD

        public BDDUserManagement()
        {
            this.rq_sql = null;
            this.sCNX = null;  
            this.sCMD = null;
            this.cnx = @"Data Source=db-proxar.database.windows.net;Initial Catalog=db_proxar;Persist Security Info=True;User ID=rootProxar;Password=@PR0xAR@";
            this.sDR = null;
            //this.oCMD = null;
            //this.oDA = null;
            //this.oDS = new DataSet();

        }



        public void SelectStudent()
        {
            
            this.rq_sql= "Select * FROM Etudiant;";
            this.sCNX = new SqlConnection(this.cnx);
            try
            {
                this.sCNX.Open();
                this.sCMD = new SqlCommand(this.rq_sql, this.sCNX);
                this.sDR = this.sCMD.ExecuteReader();
                if (this.sDR.FieldCount != 0)
                {


                    while (this.sDR.Read())
                    {
                        MessageBox.Show(this.sDR.GetValue(0) + " - " + this.sDR.GetValue(1) + " - " + this.sDR.GetValue(2) + " - " + this.sDR.GetValue(3));
                    }
                    this.sDR.Close();
                    this.sCMD.Dispose();
                    this.sCNX.Close();
                }
                else
                {
                    MessageBox.Show("Field < 0");
                        this.sDR.Close();
                        this.sCMD.Dispose();
                        this.sCNX.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }
          
    }
}
