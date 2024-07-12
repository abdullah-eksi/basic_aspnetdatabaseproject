using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AESTOK.AESTOK
{
    public partial class login : System.Web.UI.Page
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
                    sql = "select * from [dbo].[ayar]";
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
                Repeater2.DataSource = ds;
                Repeater2.DataBind();
            }
        }
            protected void Page_Load(object sender, EventArgs e)
        {
            listele("tümü");

            SqlConnection baglanti;
            SqlCommand  komut2;
           
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
                
            }
            else
            {
                Response.Redirect("index.aspx");
            }

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti;
            SqlCommand komut;
            string kuladi, sifre;

            string baglanStr = ConfigurationManager.ConnectionStrings["vtbaglan"].ConnectionString;
            baglanti = new SqlConnection(baglanStr);

            try
            {
                //sql komutunu oluştur
                komut = new SqlCommand("select * from uye ", baglanti);
                //sql komutuna parametre tanımla

                baglanti.Open(); //Bağlantıyı aç
                                 // SQL komutunu çalıştır ve bulduğun kaydı arabul isimli datasete yükle
                SqlDataReader arabul = komut.ExecuteReader();
                if (arabul.HasRows) //Kayıt bulunduysa
                {
                    while (arabul.Read()) //Kaydı oku
                    {
                        kuladi = arabul["kullanici_adi"].ToString();
                        sifre = arabul["uye_password"].ToString();
                        if (kuladi==TextBox1.Text&&sifre==TextBox2.Text)
                        {
                            Session.Add("kullaniciad", TextBox1.Text);
                            Response.Redirect("admin/index.aspx");
                        }
                        else
                        {
                            Response.Write("basarısız giriş");
                        }
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["kullaniciad"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Response.Redirect("admin/index.aspx");
            }
        }
    }
}