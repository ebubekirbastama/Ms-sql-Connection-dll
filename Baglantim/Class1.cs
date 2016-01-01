using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;;


namespace Baglantim
{
    public class Class1
    {
        string server_name;
        StreamReader sr;
        string s;
        public void ayr()
        {
         
            sr = File.OpenText(@"C:\ayar.txt");
            s = sr.ReadLine();
            server_name = s;
            sr.Close();
        }
        public  System.Data.SqlClient.SqlConnection baglantim()
        {
           //ebubekirbastama
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Server=" + server_name + "; Integrated Security=true; Database=Uyelik_Basvuru_Kayit_Formu");

            if (con.State ==  ConnectionState.Closed) // System.Data.SqlClient.ConnectionState using System.Data; kütüphanesinden gelir
            {
                con.Open();
            }
            return con;
        }
        public  System.Data.SqlClient.SqlConnection baglantim_kapat()
        {
         
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(@"Server="+server_name+"; Integrated Security=true; Database=kutuphane");

            if (con.State ==  ConnectionState.Open) // System.Data.SqlClient.ConnectionState using System.Data; kütüphanesinden gelir
            {
                con.Close();
            }
            return con;
        }
        /// <summary>
        /// Burdaki yapıda 2 tane değer bulunmaktadır.
        /// 1.değer (sqlcumlem="Buraya veritabanınızdan getireceğiniz tabloların Sql Cümlesini yazacaksınız.")
        /// örnk cümle:"select * from tablo ismi"
        /// 2. ise Datagridview Compotenti'dir.
        /// kullanımı ise şu şekildedir.
        /// "datagridview"soldaki örnekdeki gördüğünüz üzere sadebir şekilde yazılmaktadır.
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable Tablo(string sqlCumlem, System.Windows.Forms.DataGridView veridatagrid)
        {
            SqlDataAdapter adap = new SqlDataAdapter(sqlCumlem, baglantim());
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                baglantim();
                adap.Fill(dt);
                veridatagrid.DataSource = dt;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ebubekir Ototmasyon");
            }
            adap.Dispose();
            baglantim_kapat();
            return dt;
        }
        public System.Data.SqlClient.SqlDataReader Reader1(string sqlcumle, System.Windows.Forms.ComboBox kombo)
        {
            baglantim();
            System.Data.SqlClient.SqlCommand komut = new System.Data.SqlClient.SqlCommand("" + sqlcumle + "", baglantim());
            System.Data.SqlClient.SqlDataReader rdr = komut.ExecuteReader();
            kombo.Items.Clear();
            try
            {
                while (rdr.Read())
                {
                    kombo.Items.Add(rdr["grp_ismi"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Stok Takip otomasyonu Otomasyon");
            }
            rdr.Dispose();
            baglantim_kapat();
            return rdr;
        }
        //public void temizle(DevComponents.DotNetBar.Controls.GroupPanel grup_panel)
        //{
        //    foreach (System.Windows.Forms.Control ktn in grup_panel.Controls)
        //    {
        //        if (ktn is System.Windows.Forms.TextBox)
        //        {
        //            ktn.Text = "";
        //        }
        //        else if (ktn is DevComponents.DotNetBar.Controls.ComboBoxEx)
        //        {
        //            ktn.Text = "";
        //        }
        //    }
        //}
        public string sayi;
        public bool kontrol = false;
        public System.Data.SqlClient.SqlDataReader Reader2(string sqlcumle, System.Windows.Forms.TextBox t1, System.Windows.Forms.TextBox t2, DevComponents.DotNetBar.Controls.ComboBoxEx t3, string s1, string s2, string s3, string s4)
        {
            baglantim();
            System.Data.SqlClient.SqlCommand komut = new System.Data.SqlClient.SqlCommand("" + sqlcumle + "", baglantim());
            System.Data.SqlClient.SqlDataReader rdr = komut.ExecuteReader();

            try
            {
                while (rdr.Read())
                {
                    t1.Text = rdr[s1].ToString();
                    t2.Text = rdr[s2].ToString();
                    t3.Text = rdr[s3].ToString();
                    sayi = rdr[s4].ToString();
                    if (sayi == "0")
                    {
                        kontrol = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Stok Takip otomasyonu Otomasyon");
            }
            rdr.Dispose();
            baglantim_kapat();
            return rdr;
        }
        public SqlDataReader Reader3(string sqlcumle, System.Windows.Forms.TextBox t1, System.Windows.Forms.TextBox t2, System.Windows.Forms.TextBox t3, string s1, string s2, string s3)
        {
            baglantim();
            SqlCommand komut = new SqlCommand("" + sqlcumle + "", baglantim());
            SqlDataReader rdr = komut.ExecuteReader();

            try
            {
                while (rdr.Read())
                {
                    t1.Text = rdr[s1].ToString();
                    t2.Text = rdr[s2].ToString();
                    t3.Text = rdr[s3].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Stok Takip otomasyonu Otomasyon");
            }
            rdr.Dispose();
            baglantim_kapat();
            return rdr;
        }
        public string yetki;
        public SqlDataReader Reader4(string sqlcumle, string s1)
        {
            baglantim();
            SqlCommand komut = new SqlCommand("" + sqlcumle + "", baglantim());
            SqlDataReader rdr = komut.ExecuteReader();

            try
            {
                while (rdr.Read())
                {
                    yetki = rdr[s1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ebubekir Stok Takip otomasyonu Otomasyon");
            }
            rdr.Dispose();
            baglantim_kapat();
            return rdr;
        }
        public string negatif;
        public string negatif1;
        //public void grp_ekle_kontrol(DevComponents.DotNetBar.Controls.TextBoxX t1, DevComponents.DotNetBar.Controls.TextBoxX t2, System.Windows.Forms.DataGridView d1)
        //{

        //    for (int i = 0; i < d1.RowCount; i++)
        //    {
        //        if (t1.Text != d1.Rows[i].Cells[1].Value.ToString())
        //        { negatif = "1"; }
        //        else
        //        { negatif = "0"; return; }
        //        if (t2.Text != d1.Rows[i].Cells[2].Value.ToString())
        //        { negatif1 = "1"; }
        //        else
        //        { negatif1 = "0"; return; }
        //    }
        //}
        //public void user_ekle_kontrol(DevComponents.DotNetBar.Controls.TextBoxX t1, DevComponents.DotNetBar.Controls.TextBoxX t2, System.Windows.Forms.DataGridView d1)
        //{

        //    for (int i = 0; i < d1.RowCount; i++)
        //    {
        //        if (t1.Text != d1.Rows[i].Cells[0].Value.ToString())
        //        { negatif = "1"; }
        //        else
        //        { negatif = "0"; return; }
        //        if (t2.Text != d1.Rows[i].Cells[1].Value.ToString())
        //        { negatif1 = "1"; }
        //        else
        //        { negatif1 = "0"; return; }
        //    }
        //}
    }
}
