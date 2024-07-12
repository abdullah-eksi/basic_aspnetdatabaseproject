﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AESTOK.AESTOK.admin
{
    public partial class urunekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti;
            SqlCommand komut, komut2;
            string yetki;
            string baglanStr = ConfigurationManager.ConnectionStrings["vtbaglan"].ConnectionString;
            baglanti = new SqlConnection(baglanStr);
            try
            {
                //sql komutunu oluştur
                komut2 = new SqlCommand("select * from ayar where id=1905", baglanti);
                //sql komutuna parametre tanımla

                baglanti.Open(); //Bağlantıyı aç
                                 // SQL komutunu çalıştır ve bulduğun kaydı arabul isimli datasete yükle
                SqlDataReader arabul = komut2.ExecuteReader();
                if (arabul.HasRows) //Kayıt bulunduysa
                {
                    while (arabul.Read()) //Kaydı oku
                    {
                        this.Page.Title = arabul["ayar_tittle"].ToString();
                        this.Page.MetaDescription = arabul["ayar_description"].ToString();
                        this.Page.MetaKeywords = arabul["ayar_keywords"].ToString();
                    }
                }
                else
                {
                    Response.Write("sorun oluştu");
                }
                arabul.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Hata oluştu, arama yapılamadı. Hata Kodu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            if (Session["kullaniciad"] == null)
            {
                Response.Redirect("../register.aspx");
            }
            else
            {
                Label1.Text = Session["kullaniciad"].ToString();
            }
            
            try
            {
                //sql komutunu oluştur
                komut = new SqlCommand("select * from uye where kullanici_adi=@ad ", baglanti);
                //sql komutuna parametre tanımla
                komut.Parameters.AddWithValue("@ad", Session["kullaniciad"].ToString());
                baglanti.Open(); //Bağlantıyı aç
                                 // SQL komutunu çalıştır ve bulduğun kaydı arabul isimli datasete yükle
                SqlDataReader yetkısorgula = komut.ExecuteReader();
                if (yetkısorgula.HasRows) //Kayıt bulunduysa
                {
                    while (yetkısorgula.Read()) //Kaydı oku
                    {
                        yetki = yetkısorgula["uye_yetki"].ToString();
                        if (yetki == "1905")
                        {
                            Label2.Text = "admin";
                        }
                        else if (yetki == "2022")
                        {
                            Label2.Text = "yönetici";
                        }
                        else
                        {
                            Label2.Text = "üye";
                        }
                    }
                }
                else
                {
                    Response.Write("sorun oluştu");
                }
                yetkısorgula.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Hata oluştu, arama yapılamadı. Hata Kodu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            SqlConnection co;
            SqlCommand bul;
            SqlCommand ekle;

            string baglanStr = ConfigurationManager.ConnectionStrings["vtbaglan"].ConnectionString;
            co = new SqlConnection(baglanStr);
            try
            {
                bul = new SqlCommand("select * from uye where kullanici_adi=@ad", co);
                //sql komutuna parametre tanımla
                co.Open();
                bul.Parameters.AddWithValue("@ad", Label1.Text);
                SqlDataReader arabul = bul.ExecuteReader();
                if (arabul.HasRows)
                {
                    while (arabul.Read()) //Kaydı oku
                    {
                        TextBox5.Text = arabul["Id"].ToString();
                    }

                    arabul.Close();

                    ekle = new SqlCommand("insert into urun values(@urunad, @urunkodu, @urunmarka, @urunfıyat, @urundetay,@urunadet,@kuladi)", co);

                    ekle.Parameters.AddWithValue("@urunad", TextBox1.Text);
                    ekle.Parameters.AddWithValue("@urunkodu", TextBox2.Text);
                    ekle.Parameters.AddWithValue("@urunmarka", TextBox3.Text);
                    ekle.Parameters.AddWithValue("@urunfıyat", TextBox6.Text);
                    ekle.Parameters.AddWithValue("@urundetay", TextBox7.Text);
                    ekle.Parameters.AddWithValue("@urunadet", TextBox4.Text);
                    ekle.Parameters.AddWithValue("@kuladi", TextBox5.Text);

                    ekle.ExecuteNonQuery();
                    Label3.Text = "işlem başarılı";
                    Response.Redirect("urun.aspx");
                }
                else
                {
                    Label3.Text = "işlem başarısız.";
                }

            }

            catch (Exception ex)
            {
                Response.Write("Hata oluştu,. Hata Kodu: " + ex.Message);

            }
            finally
            {

                co.Close();
            }

        }
    }
}