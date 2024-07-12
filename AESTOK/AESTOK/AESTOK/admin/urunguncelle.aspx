﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="urunguncelle.aspx.cs" Inherits="AESTOK.AESTOK.admin.urunguncelle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="robots" content="all,follow">
    <title>AESTOK|DASHBOARD</title>
    <!-- Bootstrap CSS-->
    <link rel="stylesheet" href="vendor/bootstrap/css/bootstrap.min.css">
    <!-- Font Awesome CSS-->
    <link rel="stylesheet" href="vendor/font-awesome/css/font-awesome.min.css">
    <!-- Custom Font Icons CSS-->
    <link rel="stylesheet" href="css/font.css">
    <!-- Google fonts - Muli-->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Muli:300,400,700">
    <!-- theme stylesheet-->
    <link rel="stylesheet" href="css/style.default.css" >
    <!-- Custom stylesheet - for your changes-->
    <link rel="stylesheet" href="css/custom.css">
    <!-- Favicon-->
    <link rel="shortcut icon" href="img/favicon.ico">
    
  </head>
  <body>
    <header class="header">   
      <nav class="navbar navbar-expand-lg">
        <div class="search-panel">
          <div class="search-inner d-flex align-items-center justify-content-center">
            <div class="close-btn">Close <i class="fa fa-close"></i></div>
            <form id="searchForm" action="#">
              <div class="form-group">
                <input type="search" name="search" placeholder="What are you searching for...">
                <button type="submit" class="submit">Search</button>
              </div>
            </form>
          </div>
        </div>
        <div class="container-fluid d-flex align-items-center justify-content-between">
          <div class="navbar-header">
            <!-- Navbar Header--><a href="index.aspx" class="navbar-brand">
              <div class="brand-text brand-big visible text-uppercase"><strong class="text-primary">AESTOK</strong><strong>DASHBOARD</strong></div>
              <div class="brand-text brand-sm"><strong class="text-primary">AE</strong><strong>STOK</strong></div></a>
            <!-- Sidebar Toggle Btn-->
   
           
        
    

      </nav>
    </header>
      <div class="d-flex align-items-stretch">
      <!-- Sidebar Navigation-->
      <nav id="sidebar">
        <!-- Sidebar Header-->
        <div class="sidebar-header d-flex align-items-center">
          <div class="avatar"><img src="img/avatar-6.jpg" alt="..." class="img-fluid rounded-circle"></div>
          <div class="title">
              <asp:Label ID="Label1" runat="server" Text="" class="h5"></asp:Label>
             <p>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></p>
          </div>
        </div>
        <!-- Sidebar Navidation Menus-->
        <ul class="list-unstyled">
                <li class=""><a href="index.aspx"> <i class="icon-home"></i>ANASAYFA </a></li>
            <li><a href="#exampledropdownDropdown" aria-expanded="false" data-toggle="collapse"> <i class="fa fa-cogs"></i>SİTE AYARLARI </a>
                  <ul id="exampledropdownDropdown" class="collapse list-unstyled ">
                    <li><a href="genelayar.aspx">GENEL AYARLAR</a></li>
                    <li><a href="iletisimayar.aspx">İLETİŞİM AYARLARI</a></li>
                    <li><a href="sosyalayar.aspx">SOSYALMEDYA AYARLARI</a></li>
                  </ul>
                </li>
              <li class=""><a href="uye.aspx"> <i class="fa fa-user"></i>ÜYE</a></li>
            <li class=""><a href="musteri.aspx"> <i class="fa fa-user-plus"></i>MUSTERİ</a></li>
            <li class=""><a href="urun.aspx"> <i class="fa fa-shopping-basket"></i>URUN</a></li>
                
     
                
      </nav>
      <!-- Sidebar Navigation end-->
     <div class="page-content">
        <div class="page-header">
          <div class="container-fluid">
           
          </div>
        </div>
<section class="no-padding-top">

          <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
           <div class="block">
                  <div class="title"><strong class="d-block">URUN GÜNCELLE</strong><span class="d-block"></span></div>
                  <div class="block-body">
                    <form runat="server">
                      <div class="form-group">
                        <label class="form-control-label">URUN AD</label>
                       <asp:TextBox  class="form-control" ID="TextBox3" runat="server"></asp:TextBox>
                      </div>
                          <div class="form-group">
                        <label class="form-control-label">URUN KODU</label>
                         <asp:TextBox  class="form-control" ID="TextBox2" runat="server"></asp:TextBox>
                      </div>
                      <div class="form-group">       
                        <label class="form-control-label">URUN MARKA</label>
                        <asp:TextBox  class="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                      </div>
                           <div class="form-group">       
                        <label class="form-control-label">URUN FIYAT</label>
                        <asp:TextBox  class="form-control" ID="TextBox5" runat="server"></asp:TextBox>
                      </div>
                          <div class="form-group">       
                        <label class="form-control-label">URUN DETAY</label>
                        <asp:TextBox  class="form-control" ID="TextBox6" runat="server"></asp:TextBox>
                      </div>
                          <div class="form-group">       
                        <label class="form-control-label">URUN ADET</label>
                        <asp:TextBox  class="form-control" ID="TextBox7" runat="server"></asp:TextBox>
                      </div>
                      <div class="form-group">       
                        <asp:TextBox  class="form-control" ID="TextBox4" runat="server" Visible="true"></asp:TextBox>
                          <asp:TextBox  class="form-control" ID="TextBox8" runat="server" Visible="true"></asp:TextBox>
                      </div>
                        <div class="form-group">  
<asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="kaydet" OnClick="Button1_Click1" />
                            <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
                                </div>
                    </form>
                  </div>
                </div>
              </div>
       
        <footer class="footer">
          <div class="footer__block block no-margin-bottom">
            <div class="container-fluid text-center">
             
               <p class="no-margin-bottom">2022 &copy; ABDULLAH EKŞİ<a target="_blank" href=""> AESTOK</a>.</p>
            </div>
          </div>
        </footer>
      </div>
    </div>
    <!-- JavaScript files-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/popper.js/umd/popper.min.js"> </script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="vendor/jquery.cookie/jquery.cookie.js"> </script>
    <script src="vendor/chart.js/Chart.min.js"></script>
    <script src="vendor/jquery-validation/jquery.validate.min.js"></script>
    <script src="js/charts-home.js"></script>
    <script src="js/front.js"></script>
  </body>
