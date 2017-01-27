<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!-- Favicon -->
    <link rel="icon" href="favicon.ico" type="image/x-icon" />

    <!--Bootstrap Framework Version 3.3.7-->
    <link href="Content/bootstrap.min.css" type="text/css" rel="stylesheet" />

    <!--Font Awesome Version 4.6.3 -->
    <link href="Content/font-awesome.min.css" type="text/css" rel="stylesheet" />

    <!-- Medical Icons -->
    <link href="Content/medical-icons.css" type="text/css" rel="stylesheet" />

    <!-- Stylesheets -->
    <link href="Content/vendors.css" type="text/css" rel="stylesheet" />
    <link href="Content/style.css" type="text/css" rel="stylesheet" id="style" />
    <link href="Content/components.css" type="text/css" rel="stylesheet" id="components" />

    <!--Slider Revolution -->
    <link href="Scripts/slider-revolution/css/settings.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Scripts/slider-revolution/css/layers.css" />
    <link rel="stylesheet" type="text/css" href="Scripts/slider-revolution/css/navigation.css" />

    <!--Google Fonts-->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,700" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Volkhov:400,400i" rel="stylesheet" />

    <!-- Respond.js and HTML shiv provide HTML5 support in older browsers like IE9 and 8 -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <div class="loader-backdrop">
        <!-- Loader -->
        <div class="loader">
        </div>
    </div>
    <header class="header-2">
        <!-- Header Style 2 -->
        <div class="topbar">
            <!-- Topbar -->
            <div class="container">
                <div class="row">
                    <div class="col-sm-6">
                        <ul class="social">
                            <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                            <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                            <%--                            <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                            <li><a href="#"><i class="fa fa-vimeo"></i></a></li>--%>
                        </ul>
                    </div>
                    <div class="col-md-6">
                        <ul class="contact">
                            <li><span>Escríbenos : </span>info@jlorclinic.com.sv</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <nav class="navbar navbar-default">
            <!-- Navigation Bar -->
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#main-navigation" aria-expanded="false">
                        <span class="sr-only">Toggle Menu</span>
                        <i class="fa fa-bars"></i>
                    </button>
                    <a class="navbar-brand" href="home-version-1.html">
                        <img src="Img/logo_peq.png" alt="">
                        <!-- Replace with your Logo -->
                    </a>
                </div>

                <div class="collapse navbar-collapse" id="main-navigation">
                    <!-- Main Menu -->
                    <ul class="nav navbar-nav navbar-right">
                        <li>
                            <a href="Formularios/AgendaCita.aspx"><i class="fa fa-calendar-plus-o"></i>                                
                                Agenda
                            </a>
                        </li>
                        <li><a href="#services"><i class="fa fa-cogs"></i> Servicios</a></li>
                        <li><a href="#medics"><i class="fa  fa-user-md"></i> Medicos</a></li>
                        <li><a href="#contacts"><i class="fa fa-phone-square"></i> Contactos</a></li>
                        <li>
                            <a href="Login.aspx" class="btn-emergency"><i class="fa fa-unlock-alt"></i>
                                Iniciar sesión
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>

    <!-- Bootstrap Carousel -->
    <div class="container mt-80">
        <div class="row">
            <div class="col-sm-12">
                <hr>
            </div>
            <div class="col-sm-10 col-sm-offset-1 mt-20">
                <div class="carousel slide" id="carousel" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li class="active" data-slide-to="0" data-target="#carousel"></li>
                        <li data-slide-to="1" data-target="#carousel"></li>
                        <li data-slide-to="2" data-target="#carousel"></li>
                        <li data-slide-to="3" data-target="#carousel"></li>
                        <li data-slide-to="4" data-target="#carousel"></li>
                    </ol>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner">
                        <div class="item active">
                            <img src="Img/03.jpg" alt="Slide 1" />
                        </div>
                        <div class="item">
                            <img src="Img/04.jpg" alt="Slide 2" />
                        </div>
                        <div class="item">
                            <img src="Img/05.jpg" alt="Slide 3" />
                        </div>
                        <div class="item">
                            <img src="Img/06.jpg" alt="Slide 4" />
                        </div>
                        <div class="item">
                            <img src="Img/07.jpg" alt="Slide 5" />
                        </div>
                    </div>

                    <!-- Controls -->
                    <a class="left carousel-control" data-slide="prev" href="#carousel">
                        <i class="fa fa-angle-left"></i>
                    </a>
                    <a class="right carousel-control" data-slide="next" href="#carousel">
                        <i class="fa fa-angle-right"></i>
                    </a>
                </div>
            </div>
        </div>
    </div>
    <br />
    <!-- Bootstrap Carousel Ends -->

    <div class="bgcolor1 pt-60 pb-60">
        <div class="container">
            <div class="row">
                <div class="col-sm-4">
                    <div class="iconbox-4">
                        <i class="med-icon icon-i-anesthesia"></i>
                        <br />
                        <br />
                        <h4 class="heading">Proporcionamos la mejor atención al paciente</h4>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="iconbox-4">
                        <i class="med-icon icon-i-dental"></i>
                        <br />
                        <br />
                        <h4 class="heading">Equipo médico formado por varios especialistas</h4>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="iconbox-4">
                        <i class="med-icon icon-family-practice"></i>
                        <br />
                        <br />
                        <h4 class="heading">Evaluación y alternativas</h4>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="container mt-80" id="medics">
        <div class="row">
            <div class="col-sm-12">
                <div class="heading-block">
                    <h2 class="heading">Nuestro <span class="color1">equipo</span> de médicos</h2>
                    <p class="sub-heading">Acérquese y compruebe de primera mano que el miedo al dentista ya quedó en el pasado.</p>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="doctor-box-1">
                    <img src="Img/doc-1.png" class="img-responsive" alt="">
                    <div class="doctor-details">
                        <h5 class="doctor-name">Dr. Roberto Blackwell</h5>
                        <span class="doctor-desig">Cirugía Oral y Maxilofacial</span>
                    </div>
                    <div class="doctor-social">
                        <ul class="social">
                            <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                            <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                            <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                        </ul>
                        <br />
                        <a href="doctor-single-sidebar.html" class="btn btn-primary btn-sm">Ver perfil</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="doctor-box-1">
                    <img src="Img/doc-2.png" class="img-responsive" alt="">
                    <div class="doctor-details">
                        <h5 class="doctor-name">Dra. Claudia Arias</h5>
                        <span class="doctor-desig">Odontología Pediatrica</span>
                    </div>
                    <div class="doctor-social">
                        <ul class="social">
                            <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                            <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                            <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                        </ul>
                        <br />
                        <a href="doctor-single-sidebar.html" class="btn btn-primary btn-sm">Ver perfil</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="doctor-box-1">
                    <img src="Img/doc-3.png" class="img-responsive" alt="">
                    <div class="doctor-details">
                        <h5 class="doctor-name">Dra. Elizabeth Bautista</h5>
                        <span class="doctor-desig">Salud Pública Dental</span>
                    </div>
                    <div class="doctor-social">
                        <ul class="social">
                            <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                            <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                            <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                        </ul>
                        <br />
                        <a href="doctor-single-sidebar.html" class="btn btn-primary btn-sm">Ver perfil</a>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="container mt-80" id="services">
        <div class="row">
            <div class="col-sm-12">
                <div class="heading-block">
                    <h2 class="heading">Servicios <span class="color1">Odontológicos</span></h2>
                    <p class="sub-heading">En nuestra consulta podrá encontrar un ambiente confortable y renovado, dónde será atendido con confianza y cercanía.</p>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="department-box-2">
                    <div class="head">
                        <i class="med-icon icon-i-dental"></i>
                        <h3 class="heading">DISEÑO DE SONRISA</h3>
                    </div>
                    <div class="body">
                        <p style="text-align: justify">El diseño de sonrisa es un conjunto de procedimientos y técnicas como modificación de forma , tamaño, color, posición d los dientes de acuerdo al tipo de sonrisa, rostro e incluso del tipo de personalidad de la persona.</p>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="department-box-2">
                    <div class="head">
                        <i class="med-icon icon-i-dental"></i>
                        <h3 class="heading">ESTÉTICA DENTAL</h3>
                    </div>
                    <div class="body">
                        <p style="text-align: justify">Restauración con resinas de fotocurado del mismo color de los dientes  en reemplazo de los calces de amalgamas (platinos), blanqueamiento dental en casa o consultorio, profilaxis, técnica del cepillado, etc.</p>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="department-box-2">
                    <div class="head">
                        <i class="med-icon icon-i-dental"></i>
                        <h3 class="heading">ODONTOLOGÍA PEDIÁTRICA</h3>
                    </div>
                    <div class="body">
                        <p style="text-align: justify">Fluorizaciones, sellantes en fosas y fisuras, pulpotomías, uso del cepillo y seda dental, revelador de placa bacteriana, restauración de dientes cariados con resinas del mismo color de los dientes, etc. Y todo lo relacionado con la odontología preventiva.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <%--<div class="container mt-80" id="ofertas">
        <div class="row">
            <div class="col-sm-12">
                <div class="heading-block">
                    <h2 class="heading">New <span class="color1">Trending</span> Offers</h2>
                    <p class="sub-heading">Behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics.</p>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="offer-box">
                    <div class="offer-header">
                        <h4 class="heading">50% Off</h4>
                        <span>on Full Body Checkup </span>
                    </div>
                    <div class="offer-body">
                        <p>Behind the word mountains, far from the countries Vokalia and Consonantia.</p>
                        <a href="book-appointment-form.html" class="btn btn-primary btn-sm">Avail Offer</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="offer-box">
                    <div class="offer-header">
                        <h4 class="heading">Free BMI</h4>
                        <span>on Full Body Checkup </span>
                    </div>
                    <div class="offer-body">
                        <p>Behind the word mountains, far from the countries Vokalia and Consonantia.</p>
                        <a href="book-appointment-form.html" class="btn btn-primary btn-sm">Avail Offer</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="offer-box">
                    <div class="offer-header">
                        <h4 class="heading">10% Cashback</h4>
                        <span>on Full Body Checkup </span>
                    </div>
                    <div class="offer-body">
                        <p>Behind the word mountains, far from the countries Vokalia and Consonantia.</p>
                        <a href="book-appointment-form.html" class="btn btn-primary btn-sm">Avail Offer</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="offer-box">
                    <div class="offer-header">
                        <h4 class="heading">10% Cashback</h4>
                        <span>on Full Body Checkup </span>
                    </div>
                    <div class="offer-body">
                        <p>Behind the word mountains, far from the countries Vokalia and Consonantia.</p>
                        <a href="book-appointment-form.html" class="btn btn-primary btn-sm">Avail Offer</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="offer-box">
                    <div class="offer-header">
                        <h4 class="heading">50% Off</h4>
                        <span>on Full Body Checkup </span>
                    </div>
                    <div class="offer-body">
                        <p>Behind the word mountains, far from the countries Vokalia and Consonantia.</p>
                        <a href="book-appointment-form.html" class="btn btn-primary btn-sm">Avail Offer</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="offer-box">
                    <div class="offer-header">
                        <h4 class="heading">Free BMI</h4>
                        <span>on Full Body Checkup </span>
                    </div>
                    <div class="offer-body">
                        <p>Behind the word mountains, far from the countries Vokalia and Consonantia.</p>
                        <a href="book-appointment-form.html" class="btn btn-primary btn-sm">Avail Offer</a>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>


    <footer class="footer-2" id="contacts">
        <!-- footer Style 2  -->
        <div class="footer-pri">
            <!-- Primary Footer -->
            <div class="bgcolor1 pt-20 pb-20 mb-40">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-4 no-gutter">
                            <div class="widget widget-icon">
                                <strong>Llámanos </strong>
                                <i class="fa fa-phone"></i>
                                <span>(503) 5555-8888</span>
                            </div>
                        </div>
                        <div class="col-sm-4 no-gutter">
                            <div class="widget widget-icon">
                                <strong>Escríbenos </strong>
                                <i class="fa fa-envelope-o"></i>
                                <span>info@jlorclinicadental.com.sv</span>
                            </div>
                        </div>
                        <div class="col-sm-4 no-gutter">
                            <div class="widget widget-icon">
                                <strong>Redes Sociales</strong>
                                <i class="fa fa-comment-o"></i>
                                <span>@jlorClinicaDental</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-sm-3">
                        <div class="widget widget-about">
                            <a href="home-version-1.html">
                                <img src="Img/logo_peq.png" alt="" /></a>
                            <br />
                            <br />
                            <p>Acérquese y compruebe de primera mano que el miedo al dentista ya quedó en el pasado.</p>
                            <hr />
                            <ul class="contact">
                                <li><i class="fa fa-phone"></i>(503) 5555-8888</li>
                                <li><i class="fa fa-envelope"></i>info@jlorclinic.com.sv</li>
                            </ul>
                            <hr />
                            <ul class="social">
                                <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                <%--<li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                <li><a href="#"><i class="fa fa-vimeo"></i></a></li>--%>
                            </ul>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="widget widget-links">
                            <h4 class="heading">Enlaces Útiles</h4>
                            <ul>
                                <li><a href="Formularios/AgendaCita.aspx">Agenda de citas</a></li>
                                <li><a href="#servicios">Servicios</a></li>
                                <li><a href="#medics">Médicos</a></li>
                                <li><a href="#contacts">Contactos</a></li>
                            </ul>
                        </div>
                    </div>
                    <%--<div class="col-sm-3">
                        <div class="widget widget-flickr">
                            <h4 class="heading">Flickr Stream</h4>
                            <ul>
                                <li>
                                    <img src="Img/flickr-1.jpg" alt=""></li>
                                <li>
                                    <img src="Img/flickr-2.jpg" alt=""></li>
                                <li>
                                    <img src="Img/flickr-3.jpg" alt=""></li>
                                <li>
                                    <img src="Img/flickr-3.jpg" alt=""></li>
                                <li>
                                    <img src="Img/flickr-1.jpg" alt=""></li>
                                <li>
                                    <img src="Img/flickr-2.jpg" alt=""></li>
                                <li>
                                    <img src="Img/flickr-1.jpg" alt=""></li>
                                <li>
                                    <img src="Img/flickr-2.jpg" alt=""></li>
                                <li>
                                    <img src="Img/flickr-3.jpg" alt=""></li>
                            </ul>
                        </div>
                    </div>--%>
                    <%--                    <div class="col-sm-3">
                        <div class="widget widget-subscribe">
                            <h4 class="heading">Subscribe to blog</h4>
                            <p>Be the first to know what's new at MedWise!</p>
                            <form>
                                <div class="input-group">
                                    <input type="text" class="form-control">
                                    <span class="input-group-btn">
                                        <button class="btn btn-primary" type="button">Go</button>
                                    </span>
                                </div>
                            </form>
                        </div>
                        <hr />
                        <div class="widget widget-twitter">
                            <h4 class="heading">Latest Tweet</h4>
                            <p><a href="#">#medwise_template</a> the most amazing template for medical use has been released.</p>
                        </div>
                    </div>--%>
                </div>
            </div>
        </div>
        <div class="footer-sec">
            <!-- Secondary Footer -->
            <div class="container">
                <div class="row">
                    <div class="col-sm-12">
                        <span>&copy; 2017 All rights Reserved. <a target="_Blank" href="http://www.jlor.com.sv/">JLOR</a></span>
                    </div>
                </div>
            </div>
        </div>
    </footer>

    <div id="back"><i class="fa fa-angle-up"></i></div>

    <!-- Permission for Setting Cookies -->
    <div class="alert alert-dismissible alert-cookies">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    JLORClinic. Para continuar usando este sitio, debes aceptar nuestros términos.
                    &nbsp;&nbsp;
                   
                    <button class="btn btn-primary btn-sm" data-dismiss="alert" type="button">Acepto</button>
                </div>
            </div>
        </div>
    </div>

    <!-- JQuery Version 3.1.0 -->
    <script src="Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>

    <!-- Bootstrap Version 3.3.7 -->
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>

    <!-- Owl Carousel 2.0.0 -->
    <script src="Scripts/owl.carousel.min.js" type="text/javascript"></script>

    <!-- Bootstrap Select (Dropdown Styling) -->
    <script src="Scripts/bootstrap-select.min.js" type="text/javascript"></script>

    <!-- jQuery UI (Date Picker) -->
    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>

    <!-- Custom JS -->
    <script src="Scripts/script.js" type="text/javascript"></script>
</body>
</html>
