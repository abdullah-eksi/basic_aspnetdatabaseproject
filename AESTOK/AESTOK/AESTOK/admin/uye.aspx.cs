using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//vt için gerekli
using System.Data;
using System.Data.SqlClient;
//web.config dosyasındaki bilgileri kullanabilmek için
using System.Configuration;

namespace AESTOK.AESTOK.admin
{
    public partial class uye : System.Web.UI.Page
    {
        SqlConnection con;

        string sql;

        SqlCommand cmd;

        SqlDataAdapter da;

        DataSet ds;

        protected void listele(string sorgu)

        {
            {
                string baglanStr = ConfigurationManager.ConnectionStrings["vtbaglan"].ConnectionString;


                if (sorgu == "tümü")
                {
                    sql = "select * from [dbo].[uye]";
                }


                con = new SqlConnection(baglanStr);

                con.Open();

                cmd = new SqlCommand(sql, con);

                da = new SqlDataAdapter(cmd);

                ds = new DataSet();

                da.Fill(ds);

                con.Close();

                Repeater1.DataSource = ds;
                Repeater1.DataBind();
            }

        }
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
            listele("tümü");
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
                            Response.Redirect("index.aspx?durum=yetkisizgiris");
                            Label2.Text = "üye";
                           
                        }
                       
                    }
                    yetkısorgula.Close();
                }
                else
                {
                    Response.Write("sorun oluştu");
                }
                
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

             
            }
           catch (Exception ex)
            {
              Response.Write("SORUN oluştu, arama yapılamadı. Hata Kodu: " + ex.Message);
               
           }
           finally
            {
                baglanti.Close();
           }


        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
        
        }


        protected void Button2_Click1(object sender, EventArgs e)
        {
            Session.RemoveAll();
        }
    }
}