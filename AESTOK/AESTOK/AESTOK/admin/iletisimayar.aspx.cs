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
    public partial class iletisimayar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti;
            SqlCommand komut,komut2;
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

            if (!IsPostBack)
            {
                

                try
                {
                    //sql komutunu oluştur
                    komut = new SqlCommand("select * from ayar where id=1905", baglanti);
                    //sql komutuna parametre tanımla

                    baglanti.Open(); //Bağlantıyı aç
                                     // SQL komutunu çalıştır ve bulduğun kaydı arabul isimli datasete yükle
                    SqlDataReader arabul = komut.ExecuteReader();
                    if (arabul.HasRows) //Kayıt bulunduysa
                    {
                        while (arabul.Read()) //Kaydı oku
                        {
                            TextBox1.Text = arabul["ayar_mail"].ToString();
                            TextBox2.Text = arabul["ayar_tel"].ToString();
                            TextBox3.Text = arabul["ayar_konum"].ToString();

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
                                Response.Redirect("index.aspx?durum=yetkisizgiris");
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection baglanti;
            SqlCommand komut;

            string baglanStr = ConfigurationManager.ConnectionStrings["vtbaglan"].ConnectionString;
            baglanti = new SqlConnection(baglanStr);
            try
            {
                komut = new SqlCommand("update ayar set ayar_mail=@tittle, ayar_tel=@acıklama, ayar_konum=@keywords  where id=1905", baglanti);
                komut.Parameters.AddWithValue("@tittle", TextBox1.Text);
                komut.Parameters.AddWithValue("@acıklama", TextBox2.Text);
                komut.Parameters.AddWithValue("@keywords", TextBox3.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();

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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
        }
    }
}
    
        
        