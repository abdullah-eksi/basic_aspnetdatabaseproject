using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//vt için gerekli
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AESTOK.AESTOK.admin
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection co;
            SqlCommand komut2;
            string baglanStr = ConfigurationManager.ConnectionStrings["vtbaglan"].ConnectionString;
            co = new SqlConnection(baglanStr);
            try
            {
                //sql komutunu oluştur
                komut2 = new SqlCommand("select * from ayar where id=1905", co);
                //sql komutuna parametre tanımla

                co.Open(); //Bağlantıyı aç
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
                co.Close();
            }

    
            string yetki;
            if (Session["kullaniciad"] == null)
            {
                Response.Redirect("../register.aspx");
            }
            else
            {
               Label1.Text  = Session["kullaniciad"].ToString();
            }

          
            SqlCommand komut;
            SqlCommand komutsay1;
            SqlCommand komutsay2;
            SqlCommand komutsay3;
            SqlCommand komutsay4;
            SqlCommand komutsay5;
            SqlCommand komutsay6;
            int kayitSayisi = 0, kayitSayisi2 = 0, kayitSayisi3 = 0, kayitSayisi4 = 0, kayitSayisi5 = 0, kayitSayisi6 = 0;
            try
            {
                 komutsay1 = new SqlCommand("select count(*) from uye", co);
                komutsay2 = new SqlCommand("select count(*) from musteri", co);
                komutsay3 = new SqlCommand("select count(*) from urun", co);
                komutsay4 = new SqlCommand("select count(*) from uye where uye_yetki=0", co);
                komutsay5 = new SqlCommand("select count(*) from uye where uye_yetki=1905", co);
                komutsay6 = new SqlCommand("select count(*) from uye where uye_yetki=2022", co);

                co.Open();
                kayitSayisi = Convert.ToInt32(komutsay1.ExecuteScalar());
                kayitSayisi2 = Convert.ToInt32(komutsay2.ExecuteScalar());
                kayitSayisi3 = Convert.ToInt32(komutsay3.ExecuteScalar());
                kayitSayisi4 = Convert.ToInt32(komutsay4.ExecuteScalar());
                kayitSayisi5 = Convert.ToInt32(komutsay5.ExecuteScalar());
                kayitSayisi6 = Convert.ToInt32(komutsay5.ExecuteScalar());
                Label3.Text = kayitSayisi.ToString();
                Label7.Text = kayitSayisi2.ToString();
               Label8.Text= kayitSayisi3.ToString();
                Label6.Text = kayitSayisi4.ToString();
                Label4.Text = kayitSayisi5.ToString();
                Label5.Text = kayitSayisi6.ToString();
            }
            catch (Exception ex)
            {
                Label3.Text = "hata" + ex.Message;
                
            }
            finally
            {
                co.Close();
            }
            try
            {
                //sql komutunu oluştur
                komut = new SqlCommand("select * from uye where kullanici_adi=@ad ", co);
                //sql komutuna parametre tanımla
                komut.Parameters.AddWithValue("@ad", Session["kullaniciad"].ToString());
                co.Open(); //Bağlantıyı aç
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
                co.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
          
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
        }
    }
}