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
    public partial class genelayar : System.Web.UI.Page
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
            if (Session["kullaniciad"]==null)
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
                            
                            TextBox1.Text = arabul["ayar_tittle"].ToString();
                            TextBox2.Text = arabul["ayar_description"].ToString();
                            TextBox3.Text = arabul["ayar_keywords"].ToString();
                            TextBox4.Text = arabul["ayar_author"].ToString();
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
                       yetki=yetkısorgula["uye_yetki"].ToString();
                            if (yetki== "1905")
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
       
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("../img/logo/" + FileUpload1.FileName));
            }
            else
            {
                Response.Write(  "Lütfen resim seçiniz.");
                return;
            }
            if (FileUpload2.HasFile)
            {
                FileUpload2.SaveAs(Server.MapPath("../img/logo/" + FileUpload2.FileName));
            }
            else
            {
                Response.Write("Lütfen resim seçiniz.");
                return;
            }
            SqlConnection baglanti;
            SqlCommand komut;

            string baglanStr = ConfigurationManager.ConnectionStrings["vtbaglan"].ConnectionString;
            baglanti = new SqlConnection(baglanStr);
            try
            {
                komut = new SqlCommand("update ayar set ayar_tittle=@tittle, ayar_description=@acıklama, ayar_keywords=@keywords ,ayar_author=@author,ayar_resimbir=@resimbir,ayar_resimiki=@resimiki where id=1905", baglanti);
                komut.Parameters.AddWithValue("@tittle", TextBox1.Text);
                komut.Parameters.AddWithValue("@acıklama", TextBox2.Text);
                komut.Parameters.AddWithValue("@keywords", TextBox3.Text);
                komut.Parameters.AddWithValue("@author", TextBox4.Text);
                komut.Parameters.AddWithValue("@resimbir", FileUpload1.FileName);
                komut.Parameters.AddWithValue("@resimiki", FileUpload2.FileName);
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