<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="AESTOK.AESTOK.register"  UnobtrusiveValidationMode="None"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>AESTOK</title>
<!-- favicon -->		
		<link rel="shortcut icon" type="image/x-icon" href="img/logo/favicon.ico">

		<!-- all css here -->

		<!-- bootstrap v3.3.6 css -->
		<link rel="stylesheet" href="css/bootstrap.min.css">
		<!-- owl.carousel css -->
		<link rel="stylesheet" href="css/owl.carousel.css">
		<link rel="stylesheet" href="css/owl.transitions.css">
       <!-- Animate css -->
        <link rel="stylesheet" href="css/animate.css">
        <!-- meanmenu css -->
        <link rel="stylesheet" href="css/meanmenu.min.css">
		<!-- font-awesome css -->
		<link rel="stylesheet" href="css/font-awesome.min.css">
		<link rel="stylesheet" href="css/themify-icons.css">
		<link rel="stylesheet" href="css/flaticon.css">
		<!-- magnific css -->
        <link rel="stylesheet" href="css/magnific.min.css">
		<!-- style css -->
		<link rel="stylesheet" href="style.css">
		<!-- responsive css -->
		<link rel="stylesheet" href="css/responsive.css">

		<!-- modernizr css -->
		<script src="js/vendor/modernizr-2.8.3.min.js"></script>
	</head>
		<body>

		<!--[if lt IE 8]>
			<p class="browserupgrade">You are using an <strong>outdated</strong> browser. Please <a href="http://browsehappy.com/">upgrade your browser</a> to improve your experience.</p>
		<![endif]-->

   <div id="preloader"></div>
        <header class="header-one">
            <!-- Start top bar -->
            <div class="topbar-area fix hidden-xs">
                <div class="container">
                    <div class="row">
                          <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate></HeaderTemplate>
                        <ItemTemplate>
                       <div class="col-md-6 col-sm-6">
                           <div class="topbar-left">
                                <ul>
                                    <li><a href="#"><i class="fa fa-envelope"></i> <%#Eval("ayar_mail").ToString()%></a></li>
                                    <li><a href="#"><i class="fa fa-phone"></i> <%#Eval("ayar_tel").ToString()%></a></li>
                                </ul>
							</div>
                        </div>
                        <div class=" col-md-6 col-sm-6">
                            <div class="topbar-right">
                                <div class="top-social">
                                    <ul>
                                         <li><a href="<%#Eval("ayar_youtube").ToString()%>"><i class="fa fa-youtube"></i></a></li>
                                        <li><a href="<%#Eval("ayar_insta").ToString()%>"><i class="fa fa-instagram"></i></a></li>
                                        <li><a href="<%#Eval("ayar_google").ToString()%>"><i class="fa fa-google"></i></a></li>
                                        <li><a href="<%#Eval("ayar_twitter").ToString()%>"><i class="fa fa-twitter"></i></a></li>
                                        
                                       
                                    </ul> 
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End top bar -->
            <!-- header-area start -->
            <div id="sticker" class="header-area hidden-xs">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12 col-sm-12">
                            <div class="row">
                                <!-- logo start -->
                                <div class="col-md-3 col-sm-3">
                                    <div class="logo">
                                        <!-- Brand -->
                                        <a class="navbar-brand page-scroll white-logo" href="index.aspx">
                                           <img src="img/logo/<%#Eval("ayar_resimbir").ToString()%>" alt="">
                                        </a>
                                        <a class="navbar-brand page-scroll black-logo" href="index.aspx">
                                            <img src="img/logo/<%#Eval("ayar_resimiki").ToString()%>" alt="">
                                        </a>
                                    </div>
                                    <!-- logo end -->
                                </div>
                                <div class="col-md-9 col-sm-9">
                                    <div class="header-right-link">
                                        <!-- search option end -->
                                     <a href="login.aspx" class="s-menu">LOGİN</a>
                                    </div>
                                    <!-- mainmenu start -->
                                    <nav class="navbar navbar-default">
                                        <div class="collapse navbar-collapse" id="navbar-example">
                                            <div class="main-menu">
                                                <ul class="nav navbar-nav navbar-right">
                                                                           
                                                      <li><a href="index.aspx">ANA SAYFA</a></li>                                                                                        
                                                    
                                                    <li><a href="iletisim.aspx">İLETİŞİM</a></li>                                                                                                      
                                                </ul>
                                            </div>
                                        </div>
                                    </nav>
                                    <!-- mainmenu end -->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- header-area end -->
            <!-- mobile-menu-area start -->
            <div class="mobile-menu-area hidden-lg hidden-md hidden-sm">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="mobile-menu">
                                <div class="logo">
                                   <img src="img/logo/<%#Eval("ayar_resimbir").ToString()%>" alt="">
                                </div>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                      </FooterTemplate>
                                </asp:Repeater>
                                <nav id="dropdown">
                                    <ul>
                                        
                                        <li><a href="index.aspx">ANA SAYFA</a></li>                                                                                        
                                                    
                                                    <li><a href="iletisim.aspx">İLETİŞİM</a></li>     
                                    </ul>
                                </nav>
                            </div>					
                        </div>
                    </div>
                </div>
            </div>
            <!-- mobile-menu-area end -->		
        </header>
        <!-- header end -->
        <!-- Start breadcumb Area -->
        <div class="page-area">
            <div class="breadcumb-overlay"></div>
            <div class="container">
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="breadcrumb text-center">
                            <div class="section-headline white-headline">
                                <h3>KAYIT OL</h3>
                            </div>
                            <ul class="breadcrumb-bg">
                                <li class="home-bread">ANASAYFA</li>
                                <li>KAYIT OL</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- End breadcumb Area -->
        <!-- Start Slider Area -->
        <div class="signup-area page-padding">
            <div class="container">
                <div class="row">
                    <div class=" col-md-12 col-sm-12 col-xs-12">
                        <div class="login-page signup-page">
                            <div class="login-form signup-form">
                                <h4 class="login-title ">KAYIT OL</h4>
                                <div class="row">
                                    <form runat="server">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Username" required data-error="Please enter your name"></asp:TextBox>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="MAİL" required data-error="Please enter your name"></asp:TextBox>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="TextBox3" runat="server" class="form-control" placeholder="SİFRENİZİ GİRİNİZ" required data-error="Please enter your name" TextMode="Password"></asp:TextBox>
                                        </div>
                                         <div class="col-md-12 col-sm-12 col-xs-12">
                                            <asp:TextBox ID="TextBox4" runat="server" class="form-control" placeholder="TEKRAR ŞİFRE GİRİNİZ" required data-error="Please enter your name" TextMode="Password"></asp:TextBox>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12 ">
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox3" ControlToValidate="TextBox4" ErrorMessage="ŞİFRELER AYNI DEĞİL"></asp:CompareValidator><br /><asp:Label ID="Label1" runat="server" ForeColor="#FF9900"></asp:Label>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <asp:Button ID="Button1" runat="server" class="login-btn" Text="KAYIT OL" OnClick="Button1_Click" />
                                            <div id="msgSubmit" class="h3 hidden"></div> 
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="clear"></div>
                                           
                                            <div class="sign-icon">
                                                
                                                <div class="acc-not">zaten bir hesabın varmı?  <a href="login.aspx">Login</a></div>
                                            </div>
                                        </div>
                                    </form> 
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
             </div>
        </div>
          <!-- Start Footer Area -->

              <asp:Repeater ID="Repeater2" runat="server">
                                                <HeaderTemplate>
                                                                 </HeaderTemplate>
                                                <ItemTemplate>
        <footer class="footer1">
            <div class="footer-area">
                <div class="container">
                    <div class="row">
                        <div class="col-md-5 col-sm-5 col-xs-12">
                            <div class="footer-content logo-footer">
                                <div class="footer-head">
                                    <div class="footer-logo">
                                    	<a class="footer-black-logo" href="#"><img src="img/logo/<%#Eval("ayar_resimiki").ToString()%>" alt=""></a>
                                    </div>
                                   
                                  
                                </div>
                            </div>
                        </div>
                        <!-- end single footer -->
                        <div class="col-md-4 col-sm-3 col-xs-12">
                            <div class="footer-content">
                                <div class="footer-head">
                                    
                                    <ul class="footer-list">
                                         <li><a href="index.aspx">ANA SAYFA</a></li>
                                        
                                        <li><a href="iletisim.aspx">İLETİŞİM </a></li>
                                        <li><a href="register.aspx">KAYIT</a></li>                                      
                                    </ul>
                                    
                                </div>
                            </div>
                        </div>
                        <!-- end single footer -->
                        <div class="col-md-3 col-sm-4 col-xs-12">
                            <div class="footer-content last-content">
                                <div class="footer-head">
                                    <h4>İLETİŞİM</h4> 
                                    <div class="footer-contacts">
												<p><span>Tel :</span><%#Eval("ayar_tel").ToString()%></p>
										<p><span>Email :</span><%#Eval("ayar_mail").ToString()%></p>
										<p><span>konum :</span><%#Eval("ayar_konum").ToString()%></p>
									</div> 
                                     <div class="footer-icons">
                                        <ul>
                                            <li>
                                                <a href="<%#Eval("ayar_youtube").ToString()%>">
                                                    <i class="fa fa-youtube"></i>
                                                </a>
                                            </li>
                                            <li>
                                                <a href="<%#Eval("ayar_insta").ToString()%>">
                                                    <i class="fa fa-instagram"></i>
                                                </a>
                                            </li>
                                            <li>
                                                <a href="<%#Eval("ayar_google").ToString()%>">
                                                    <i class="fa fa-google"></i>
                                                </a>
                                            </li>
                                           
                                            <li>
                                                <a href="<%#Eval("ayar_twitter").ToString()%>">
                                                    <i class="fa fa-twitter"></i>
                                                </a>
                                            </li>
                                        </ul>
                                      
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer-area-bottom">
                <div class="container">
                    <div class="row">
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <div class="copyright">
                                <p>
                                    Copyright © 2022
                                    <a href="#"><%#Eval("ayar_author").ToString()%></a> All Rights Reserved
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
                                                    
                                                    </ItemTemplate>
                                              
            </asp:Repeater>
           
        <!-- End Footer area -->
		
		<!-- all js here -->

		<!-- jquery latest version -->
		<script src="js/vendor/jquery-1.12.4.min.js"></script>
		<!-- bootstrap js -->
		<script src="js/bootstrap.min.js"></script>
		<!-- owl.carousel js -->
		<script src="js/owl.carousel.min.js"></script>
		  <!-- stellar js -->
        <script src="js/jquery.stellar.min.js"></script>
		<!-- magnific js -->
        <script src="js/magnific.min.js"></script>
        <!-- wow js -->
        <script src="js/wow.min.js"></script>
        <!-- meanmenu js -->
        <script src="js/jquery.meanmenu.js"></script>
		<!-- Form validator js -->
		<script src="js/form-validator.min.js"></script>
		<!-- plugins js -->
		<script src="js/plugins.js"></script>
		<!-- main js -->
		<script src="js/main.js"></script>
	</body>

<!-- Mirrored from rockstheme.com/rocks/aievari-live/signup.html by HTTrack Website Copier/3.x [XR&CO'2014], Tue, 03 Mar 2020 08:28:23 GMT -->
</html>