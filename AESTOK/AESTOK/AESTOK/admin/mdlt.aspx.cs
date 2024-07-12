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
    public partial class mdlt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["kullaniciad"] == null)
            {
                Response.Redirect("../register.aspx");
            }
            SqlConnection baglanti;
            SqlCommand komut;

            string baglanStr = ConfigurationManager.ConnectionStrings["vtbaglan"].ConnectionString;
            baglanti = new SqlConnection(baglanStr);
            string id ,id2;
            id = HttpUtility.UrlDecode(Request.QueryString["Id"]);
            try
            {
                komut = new SqlCommand("select * from uye where kullanici_adi=@ad2", baglanti);
                komut.Parameters.AddWithValue("ad2", Session["kullaniciad"]);
                baglanti.Open(); //Bağlantıyı aç
                                 // SQL komutunu çalıştır ve bulduğun kaydı arabul isimli datasete yükle
                SqlDataReader arabul = komut.ExecuteReader();
                if (arabul.HasRows) //Kayıt bulunduysa
                {
                    while (arabul.Read()) //Kaydı oku
                    {
                        Label1.Text = arabul["Id"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("başarısız" + ex.Message);

            }
            finally
            {
                baglanti.Close();
            }


            try
            {
                komut = new SqlCommand("select * from musteri where Id=@id2", baglanti);
                komut.Parameters.AddWithValue("id2", HttpUtility.UrlDecode(Request.QueryString["Id"]));
                baglanti.Open(); //Bağlantıyı aç
                                 // SQL komutunu çalıştır ve bulduğun kaydı arabul isimli datasete yükle
                SqlDataReader arabul = komut.ExecuteReader();
                if (arabul.HasRows) //Kayıt bulunduysa
                {
                    while (arabul.Read()) //Kaydı oku
                    {
                      
                        Label2.Text = arabul["userid"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("başarısız" + ex.Message);

            }
            finally
            {
                baglanti.Close();
            }





            if (Label1.Text==Label2.Text)
            {
                try
                {
                    komut = new SqlCommand("delete from musteri where id=@id2", baglanti);
                    komut.Parameters.AddWithValue("@id2", id);

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    Response.Redirect("musteri.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("başarısız" + ex.Message);
                }
                finally
                {
                    baglanti.Close();

                }
            }
            else
            {
                Response.Redirect("musteri.aspx?durum=yetkisiz silme işlemi");
            }
        }
    }
}