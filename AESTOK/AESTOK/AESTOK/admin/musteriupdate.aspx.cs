using System;
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
    public partial class musteriupdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti;
            SqlCommand komut, komut2, komut4;
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
                        TextBox4.Text = yetkısorgula["Id"].ToString();
                        //id alıor
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
            
            
            if (!IsPostBack)
            {


                try
                {
                    //sql komutunu oluştur
                    komut4 = new SqlCommand("select * from musteri where id=@id", baglanti);
                    //sql komutuna parametre tanımla
                    komut4.Parameters.AddWithValue("@id", HttpUtility.UrlDecode(Request.QueryString["Id"].ToString()));
                    baglanti.Open(); //Bağlantıyı aç
                                     // SQL komutunu çalıştır ve bulduğun kaydı arabul isimli datasete yükle
                    SqlDataReader arabul = komut4.ExecuteReader();
                    if (arabul.HasRows) //Kayıt bulunduysa
                    {
                        while (arabul.Read()) //Kaydı oku
                        {
                            TextBox3.Text = arabul["ad"].ToString();
                            TextBox2.Text = arabul["yas"].ToString();
                            TextBox1.Text = arabul["tel"].ToString();
                            TextBox5.Text = arabul["adres"].ToString();
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
            }

                SqlCommand komut3;

             

                    try
                    {

                        //sql komutunu oluştur
                        komut3 = new SqlCommand("select * from musteri where id=@id", baglanti);
                        //sql komutuna parametre tanımla
                        komut3.Parameters.AddWithValue("@id", HttpUtility.UrlDecode(Request.QueryString["Id"].ToString()));
                        baglanti.Open(); //Bağlantıyı aç
                                         // SQL komutunu çalıştır ve bulduğun kaydı arabul isimli datasete yükle
                        SqlDataReader arabul = komut3.ExecuteReader();
                        if (arabul.HasRows) //Kayıt bulunduysa
                        {
                            while (arabul.Read()) //Kaydı oku
                            {
                                Label3.Text = arabul["userid"].ToString();
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
        
            }
        

    

        protected void Button1_Click1(object sender, EventArgs e)
        {


            if (TextBox4.Text==Label3.Text)
            {
                SqlConnection baglanti;

                SqlCommand dd;
                string baglanStr = ConfigurationManager.ConnectionStrings["vtbaglan"].ConnectionString;
                baglanti = new SqlConnection(baglanStr);

                try
                {
                    dd = new SqlCommand("update musteri set ad=@ad, yas=@yas, tel=@tel ,adres=@adres  where id=@id", baglanti);
                    dd.Parameters.AddWithValue("@id", HttpUtility.UrlDecode(Request.QueryString["Id"].ToString()));
                    dd.Parameters.AddWithValue("@ad", TextBox3.Text);
                    dd.Parameters.AddWithValue("@yas", TextBox2.Text);
                    dd.Parameters.AddWithValue("@tel", TextBox1.Text);
                    dd.Parameters.AddWithValue("@adres", TextBox5.Text);
                    baglanti.Open();
                    dd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Response.Write("Hata oluştu, güncellenemedi. Hata Kodu: " + ex.Message);
                }
                finally
                {
                    baglanti.Close();
                }







            }
            else
            {
                Response.Write("ekleyen kullanıcı tarafından guncellenebılır");
            }

        }
    }
}