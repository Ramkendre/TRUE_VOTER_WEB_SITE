<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="TrueVoter.Homepage" %>


    <html>
<head>
    <meta charset="utf-8">
    <title>True Voter</title>
    <link rel="shortcut icon" type="image/png" href="img/favicon.png" />

    <!-- Web Fonts  -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,500,600,700,800" rel="stylesheet" type="text/css">
    <link href="http://fonts.googleapis.com/css?family=Raleway:100,200,300,400,500,700,800,900" rel="stylesheet" type="text/css">

    <!-- Libs CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/v-nav-menu.css" rel="stylesheet" />
    <link href="css/v-animation.css" rel="stylesheet" />
    <link href="css/v-bg-stylish.css" rel="stylesheet" />
    <link href="css/v-shortcodes.css" rel="stylesheet" />
    <link href="css/theme-responsive.css" rel="stylesheet" />
    <link href="plugins/owl-carousel/owl.theme.css" rel="stylesheet" />
    <link href="plugins/owl-carousel/owl.carousel.css" rel="stylesheet" />

    <!-- Current Page CSS -->
    <link href="plugins/rs-plugin/css/settings.css" rel="stylesheet" />
    <link href="plugins/rs-plugin/css/custom-captions.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link rel="stylesheet" href="css/custom.css">
    <link href="css/styleLogin.css" rel="stylesheet" />
</head>

<body class="no-page-top">

    <!--Header-->
    <!--Set your own background color to the header-->
    <header class="semi-transparent-header" data-bg-color="rgba(9, 103, 139, 0.36)" data-font-color="#fff">
        <div class="container">

            <!--Site Logo-->
            <div class="logo" data-sticky-logo="img/true-voters.jpg" data-normal-logo="img/true-voters.jpg">
                <a href="Homepage.aspx">
                    <img alt="Venue" src="img/true-voters.jpg" data-logo-height="35">
                </a>
            </div>
            <!--End Site Logo-->

            <div class="navbar-collapse nav-main-collapse collapse">

                <!--Header Search-->
                <!-- <div class="search" id="headerSearch">
                    <a href="#" id="headerSearchOpen"><i class="fa fa-search"></i></a>
                    <div class="search-input">
                        <form id="headerSearchForm" action="#" method="get">
                            <div class="input-group">
                                <input type="text" class="form-control search" name="q" id="q" placeholder="Search...">
                                <span class="input-group-btn">
                                    <button class="btn btn-primary" type="button"><i class="fa fa-search"></i></button>
                                </span>
                            </div>
                        </form>
                        <span class="v-arrow-wrap"><span class="v-arrow-inner"></span></span>
                    </div>
                </div>
                -->
                <!--End Header Search-->

                <!--Main Menu-->
                <nav class="nav-main mega-menu one-page-menu">
                    <ul class="nav nav-pills nav-main" id="mainMenu">
                        <li class="active">
                            <a data-hash href="#home"><i class="fa fa-home"></i>Home</a>
                        </li>
                        <li>
                            <a data-hash href="#features"><i class="fa fa-fire"></i>Features</a>
                        </li>
                        <li>
                            <a data-hash href="#describe"><i class="fa fa-flash"></i>Describe</a>
                        </li>
                        <li>
                            <a data-hash href="#services"><i class="fa fa-umbrella"></i>Services</a>
                        </li>
                        <li>
                            <a data-hash href="#screenshots"><i class="fa fa-laptop"></i>Screenshots</a>
                        </li>
                        <li>
                            <a data-hash href="#download"><i class="fa fa-download"></i>Download</a>
                        </li>
                       <li>
                           <a href="Admin/Login.aspx"><i class="fa fa-Login"></i>Login</a>
                       </li>
                        <!--<li class="dropdown">
                            <a class="dropdown-toggle menu-icon" href="#"><i class="fa fa-umbrella"></i>Menu <i class="fa fa-caret-down"></i></a>
                            <ul class="dropdown-menu">
                                <li><a href="#">Blog - Standard</a></li>
                                <li><a href="#">Blog - Small</a></li>
                                <li><a href="#">Blog - Masonry</a></li>
                                <li><a href="#">Blog – Fullwidth Masonry</a></li>
                                <li class="dropdown-submenu">
                                    <a href="#">Blog Posts</a>
                                    <ul class="dropdown-menu">
                                        <li><a href="#">Standard Post</a></li>
                                        <li><a href="#">Slideshow Post</a></li>
                                        <li><a href="#">Full Width Post</a></li> 
                                    </ul>
                                </li> -->
                            </ul>
                        </li>
                    </ul>
                </nav>
                <!--End Main Menu-->
            </div>
            <button class="btn btn-responsive-nav btn-inverse" data-toggle="collapse" data-target=".nav-main-collapse">
                <i class="fa fa-bars"></i>
            </button>
        </div>
    </header>
    <!--End Header-->    
    <div id="container">

        <!--Set your own slider options. Look at the v_RevolutionSlider() function in 'theme-core.js' file to see options-->
        <div class="home-slider-wrap fullwidthbanner-container" id="home">
            <div class="v-rev-slider" data-slider-options='{ "startheight": 700 }'>

                <ul>

                    <li data-transition="fade" data-slotamount="7" data-masterspeed="600">

                        <img src="img/slider/image2.png" data-bgposition="center top" data-bgfit="cover" data-bgrepeat="no-repeat">

                        <div class="tp-caption v-caption-big-white sfl stl"
                            data-x="450"
                            data-y="245"
                            data-speed="600"
                            data-start="600"
                            data-easing="Power1.easeInOut"
                            data-splitin="none"
                            data-splitout="none"
                            data-elementdelay="0"
                            data-endelementdelay="0"
                            data-endspeed="300">
                           'TRUE VOTER' . . .  
                            <br />
                          <h1 style="font-size:x-large">To Strengthen the Democracy</h1> 
                        </div>

                        <div class="tp-caption v-caption-h1 sfl stl"
                            data-x="450"
                            data-y="360"
                            data-speed="700"
                            data-start="1200"
                            data-easing="Power1.easeInOut"
                            data-splitin="none"
                            data-splitout="none"
                            data-elementdelay="0"
                            data-endelementdelay="0"
                            data-endspeed="300">
                            Developed and Dedicated ,<br>
                            for public good, as a social service <br>
                            and as duty towards nation.<br><br />
                            A Helping Tool for True, Fair and <br />
                            Transperent Election Process <br />
                            <br />
                            <br><br>
                        </div>

                        <div class="tp-caption sfl stl"
                            data-x="450"
                            data-y="450"
                            data-speed="600"
                            data-start="1800"
                            data-easing="Power1.easeInOut"
                            data-splitin="none"
                            data-splitout="none"
                            data-elementdelay="0"
                            data-endelementdelay="0"
                            data-endspeed="300">
                            <br /><br /><br /><br />
                            <br />
                            <a href='https://play.google.com/store/apps/details?id=sec.maharashtra.truevoter.activity' class="btn v-btn v-second-light"><font color="#01573E">GET IT NOW!</font></a>
                        </div>

                       <div class="tp-caption sfl stl"
                            data-x="605"
                            data-y="450"
                            data-speed="600"
                            data-start="2200"
                            data-easing="Power1.easeInOut"
                            data-splitin="none"
                            data-splitout="none"
                            data-elementdelay="0"
                            data-endelementdelay="0"
                            data-endspeed="300">
                           <br /><br /><br /><br /><br />
                            <a data-hash href='#features' class="btn v-btn v-second-light"><font color="#01573E">FIND OUT MORE</font></a>
                        </div>

                        <div class="tp-caption sfl stl"
                            data-x="110"
                            data-y="130"
                            data-speed="600"
                            data-start="1800"
                            data-easing="Power1.easeInOut"
                            data-splitin="none"
                            data-splitout="none"
                            data-elementdelay="0"
                            data-endelementdelay="0"
                            data-endspeed="300">
                            <!--<a href='#' class="btn v-btn v-third-light">GET IT NOW!</a>-->
                            <img src="img/iphone2.png" />
                        </div>

                        <!--<div class="v-slider-overlay overlay-colored"></div>-->
                    </li>
                </ul>
            </div>

            <div class="shadow-right"></div>
        </div>

        <div class="v-page-wrap no-bottom-spacing">

            <div class="container">
                <div class="v-spacer col-sm-12 v-height-small"></div>
            </div>

            <!--Features For Voter-->
            <div class="container" id="features">

                <div class="row center">

                    <div class="col-sm-12">
                        <p class="v-smash-text-large-2x">
                            <span>Features For Voter</span>
                        </p>
                        <div class="horizontal-break"></div>
                        <p class="lead" style="color: #999;">
                            Take your Voice up to all Contesting Candidates.
                        </p>
                    </div>
                    <div class="v-spacer col-sm-12 v-height-standard"></div>
                </div>

                <div class="row features">

                    <div class="col-md-4 col-sm-4">
                        <div class="feature-box left-icon v-animation pull-top" data-animation="fade-from-left" data-delay="300">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-laptop v-icon"></i>-->
                            </div>
                            <div class="feature-box-text">
                                <h3>Voter List Search</h3>
                                <div class="feature-box-text-inner">
                                    Voter’s List Search showing his Assembly, Part, Serial, Local Body Ward, Polling Booth and Booth Address.
                                </div>
                            </div>
                        </div>

                        <div class="v-spacer col-sm-12 v-height-standard"></div>

                        <div class="feature-box left-icon v-animation" data-animation="fade-from-left" data-delay="600">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-vimeo-square v-icon"></i>-->
                            </div>
                            <div class="feature-box-text">
                                <h3>Polling Booth Address</h3>
                                <div class="feature-box-text-inner">
                                    Navigation via Google maps to the Polling Booth Address.
                                </div>
                            </div>
                        </div>

                        <div class="v-spacer col-sm-12 v-height-standard"></div>

                        <div class="feature-box left-icon v-animation" data-animation="fade-from-left" data-delay="900">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-cloud-download v-icon"></i>-->
                            </div>
                            <div class="feature-box-text">
                                <h3>Know Your Candidates(KYC)</h3>
                                <div class="feature-box-text-inner">
                                   KYC (Know Your Candidates): To get profile of contesting candidates.
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4 col-sm-4">
                        <img class="img-responsive phone-image v-animation" data-animation="fade-from-bottom" data-delay="250" src="img/Voter.png" />
                    </div>

                    <div class="col-md-4 col-sm-4">
                        <div class="feature-box left-icon v-animation pull-top" data-animation="fade-from-right" data-delay="300">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-tablet v-icon"></i>-->
                            </div>
                            <div class="feature-box-text">
                                <h3>Voter’s Voice</h3>
                                <div class="feature-box-text-inner">
                                    Voter’s Voice: To share expectation & problem of ward with the contesting candidate’s. 

                                </div>
                            </div>
                        </div>

                        <div class="v-spacer col-sm-12 v-height-standard"></div>

                        <div class="feature-box left-icon v-animation" data-animation="fade-from-right" data-delay="600">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-lightbulb-o v-icon"></i>-->
                            </div>
                            <div class="feature-box-text">
                                <h3>create profile</h3>
                                <div class="feature-box-text-inner">
                                    To create updated profile with photo.
                                <br />
                                    
                                </div>
                            </div>
                            <br />
                        </div>

                        <div class="v-spacer col-sm-12 v-height-standard"></div>

                        <div class="feature-box left-icon v-animation" data-animation="fade-from-right" data-delay="900">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-youtube v-icon"></i>-->                                
                            </div>
                            <div class="feature-box-text">
                                <h3>Election Results</h3>
                                <div class="feature-box-text-inner">
                                   To get the election results.
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--End Features For Voter-->
           <br /><br />


            <!--Features For Candidate-->
            <div class="container" id="Div1">

                <div class="row center">

                    <div class="col-sm-12">
                        <p class="v-smash-text-large-2x">
                            <span>Features For Candidate</span>
                        </p>
                        <div class="horizontal-break"></div>
                        <p class="lead" style="color: #999;">
                            Get Connected with all Voters of your Area.
                        </p>
                    </div>
                    <div class="v-spacer col-sm-12 v-height-standard"></div>
                </div>

                <div class="row features">

                    <div class="col-md-4 col-sm-4">
                        <div class="feature-box left-icon v-animation pull-top" data-animation="fade-from-left" data-delay="300">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-laptop v-icon"></i>-->
                            </div>
                            <div class="feature-box-text">
                                <h3>Feed Daily Expenses</h3>
                                <div class="feature-box-text-inner">
                                    Submission of Election Expense online and getting the Daily Report and Total Report and Affidavit.

                                </div>
                            </div>
                        </div>

                        <div class="v-spacer col-sm-12 v-height-standard"></div>

                        <div class="feature-box left-icon v-animation" data-animation="fade-from-left" data-delay="600">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-vimeo-square v-icon"></i>-->
                            </div>
                            <div class="feature-box-text">
                                <h3>Candidate Vision </h3>
                                <div class="feature-box-text-inner">
                                    Create profile and achievements with his Vision for the ward and local body.
.
                                </div>
                            </div>
                        </div>

                        <div class="v-spacer col-sm-12 v-height-standard"></div>

                        <div class="feature-box left-icon v-animation" data-animation="fade-from-left" data-delay="900">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-cloud-download v-icon"></i>-->
                            </div>
                            <div class="feature-box-text">
                                <h3>Booth Wise Voter List</h3>
                                <div class="feature-box-text-inner">
                                  Get polling booth list.
.
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4 col-sm-4">
                        <img class="img-responsive phone-image v-animation" data-animation="fade-from-bottom" data-delay="250" src="img/candidate.png" />
                    </div>

                    <div class="col-md-4 col-sm-4">
                        <div class="feature-box left-icon v-animation pull-top" data-animation="fade-from-right" data-delay="300">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-tablet v-icon"></i>-->
                            </div>
                            <div class="feature-box-text">
                                <h3>Communication with Voters</h3>
                                <div class="feature-box-text-inner">
                                    Communication with Election personnel and registered voters.

                                </div>
                            </div>
                        </div>

                        <div class="v-spacer col-sm-12 v-height-standard"></div>

                        <div class="feature-box left-icon v-animation" data-animation="fade-from-right" data-delay="600">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-lightbulb-o v-icon"></i>-->
                            </div>
                            <div class="feature-box-text">
                                <h3>Voters Analysis</h3>
                                <div class="feature-box-text-inner">
                                    To create updated profile with photo.
                                <br />
                                    
                                </div>
                            </div>
                            <br />
                        </div>

                        <div class="v-spacer col-sm-12 v-height-standard"></div>

                        <div class="feature-box left-icon v-animation" data-animation="fade-from-right" data-delay="900">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-youtube v-icon"></i> -->                               
                            </div>
                            <div class="feature-box-text">
                                <h3>Get Voter's View</h3>
                                <div class="feature-box-text-inner">
                                   To get the election results.
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--End Features For Candidate-->
            <br /><br />
            <!--Features For Officer-->
            <div class="container" id="Div2">

                <div class="row center">

                    <div class="col-sm-12">
                        <p class="v-smash-text-large-2x">
                            <span>Features For Officer</span>
                        </p>
                        <div class="horizontal-break"></div>
                        <p class="lead" style="color: #999;">
                            Direct Relation and Connectivity <br /> from Top to Bottom between All Officers.
                        </p>
                    </div>
                    <div class="v-spacer col-sm-12 v-height-standard"></div>
                </div>

                <div class="row features">

                    <div class="col-md-4 col-sm-4">
                        <div class="feature-box left-icon v-animation pull-top" data-animation="fade-from-left" data-delay="300">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-laptop v-icon"></i>-->
                            </div>
                            <div class="feature-box-text">
                                <h3>Booth Wise Voter List</h3>
                                <div class="feature-box-text-inner">
                                    Voter’s List Search showing his Assembly, Part, Serial, Local Body Ward, Polling Booth and Booth Address.
                                </div>
                            </div>
                        </div>

                        <div class="v-spacer col-sm-12 v-height-standard"></div>

                        <div class="feature-box left-icon v-animation" data-animation="fade-from-left" data-delay="600">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-vimeo-square v-icon"></i>-->
                            </div>
                            <div class="feature-box-text">
                                <h3>Control Chart</h3>
                                <div class="feature-box-text-inner">
                                    Navigation via Google maps to the Polling Booth Address.
                                </div>
                            </div>
                        </div>

                        <div class="v-spacer col-sm-12 v-height-standard"></div>

                        <div class="feature-box left-icon v-animation" data-animation="fade-from-left" data-delay="900">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-cloud-download v-icon"></i>-->
                            </div>
                            <div class="feature-box-text">
                                <h3>Standard Rates</h3>
                                <div class="feature-box-text-inner">
                                   KYC (Know Your Candidates): To get profile of contesting candidates.
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4 col-sm-4">
                        <img class="img-responsive phone-image v-animation" data-animation="fade-from-bottom" data-delay="250" src="img/Officer.png" />
                    </div>

                    <div class="col-md-4 col-sm-4">
                        <div class="feature-box left-icon v-animation pull-top" data-animation="fade-from-right" data-delay="300">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-tablet v-icon"></i>-->
                            </div>
                            <div class="feature-box-text">
                                <h3>Officers Tree</h3>
                                <div class="feature-box-text-inner">
                                    Voter’s Voice: To share expectation & problem of ward with the contesting candidate’s. 

                                </div>
                            </div>
                        </div>

                        <div class="v-spacer col-sm-12 v-height-standard"></div>

                        <div class="feature-box left-icon v-animation" data-animation="fade-from-right" data-delay="600">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-lightbulb-o v-icon"></i>-->
                            </div>
                            <div class="feature-box-text">
                                <h3>Polling Data</h3>
                                <div class="feature-box-text-inner">
                                    To create updated profile with photo.
                                <br />
                                    
                                </div>
                            </div>
                            <br />
                        </div>

                        <div class="v-spacer col-sm-12 v-height-standard"></div>

                        <div class="feature-box left-icon v-animation" data-animation="fade-from-right" data-delay="900">
                            <div class="feature-box-icon small">
                                <!--<i class="fa fa-youtube v-icon"></i>-->                                
                            </div>
                            <div class="feature-box-text">
                                <h3>All Reports</h3>
                                <div class="feature-box-text-inner">
                                   To get the election results.
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--End Features For Officer-->
            <div class="container">
                <div class="v-spacer col-sm-12 v-height-standard"></div>
            </div>


            <!--Describe-->
            <div class="v-parallax v-bg-stylish" id="describe">
                <div class="container">
                    <div class="row app-brief">
                        <div class="col-sm-6">
                            <p class="v-smash-text-large-2x pull-top">
                                <span>Building Transparency And Strengthening Democracy.</span>
                            </p>
                            <div class="horizontal-break left"></div>
                            <p class="v-lead">
                                   True Voter is a tool to share your demands, suggestions, problem with all contesting candidates of your Area/Ward through “Voter’s Voice”. It’s useful to get Vision and Mission of all Candidates; it’s useful to get Past Work done details of all candidates. It’s useful to get Notifications from all the candidates and State Election Commission. It’s now easy to navigate your Booth Location. Now you can search any voter in the voter list, no need to have voter slip now as everything is in TRUE VOTER app. Main communication tool in between Voters and Candidates.
                            </p>

                            <p class="v-lead">
                               
                            </p>
                        </div>

                        <div class="col-sm-6">
                            <img class="img-responsive phone-image v-animation" data-animation="fade-from-right" data-delay="300" src="img/Truvoter.png" />
                        </div>
                    </div>
                </div>
            </div>
            <!--End Describe-->

            <!--Services-->
            <div class="v-parallax v-parallax-video v-bg-stylish" id="services" style="background-image: url(img/slider/slider4.jpg);">
                <div class="container">
                    <div class="row">

                        <div class="col-sm-4">
                            <div class="feature-box feature-box-secundary-one v-animation" data-animation="grow" data-delay="0">
                                <div class="feature-box-icon small">
                                    <!--<i class="fa fa-laptop v-icon"></i>-->
                                </div>
                                <div class="feature-box-text clearfix">
                                    <h3> A Voter’s Voice</h3>
                                    <div class="feature-box-text-inner">
                                        <p>
                                           A Voter’s Voice:To share expectation & problem of ward with the contesting candidate’s.
                                        </p>

                                        <a href="#" class="read-more">Read More</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="feature-box feature-box-secundary-one v-animation" data-animation="grow" data-delay="200">
                                <div class="feature-box-icon small">
                                    <!--<i class="fa fa-leaf v-icon"></i>-->
                                </div>
                                <div class="feature-box-text">
                                    <h3>Candidate and Voter’s Communication Tool</h3>
                                    <div class="feature-box-text-inner">
                                        <p>
                                            Communication with Election personnel and registered voters.<br />
                                        </p>
                                        <a href="#" class="read-more">Read More</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="feature-box feature-box-secundary-one v-animation" data-animation="grow" data-delay="400">
                                <div class="feature-box-icon small">
                                    <!--<i class="fa fa-scissors v-icon"></i>-->
                                </div>
                                <div class="feature-box-text">
                                    <h3>Officers Choice for Election Monitoring </h3>
                                    <div class="feature-box-text-inner">
                                        <p>
                                            To share expectation & problem of ward with the contesting candidate’s.<br />
                                        </p>
                                        <a href="#" class="read-more">Read More</a>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="v-bg-overlay overlay-colored"></div>
                    </div>
                </div>
            </div>
            <!--End Services-->

          <!--  <div class="container">
                <div class="v-spacer col-sm-12 v-height-big"></div>
            </div>-->

            <!--<div class="container">
                <div class="row center v-counter-wrap">
                    <div class="col-sm-3">
                        <i class="fa fa-building v-icon icn-holder"></i>
                        <div class="v-counter">
                            <div class="count-number" data-from="0" data-to="6218" data-speed="1000" data-refresh-interval="25"></div>
                            <div class="count-divider"><span></span></div>
                            <h6 class="v-counter-text">Line Of Code Written</h6>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <i class="fa fa-flash v-icon icn-holder"></i>
                        <div class="v-counter">
                            <div class="count-number" data-from="0" data-to="1448" data-speed="1500" data-refresh-interval="25"></div>
                            <div class="count-divider"><span></span></div>
                            <h6 class="v-counter-text">Cups Of Coffee</h6>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <i class="fa fa-laptop v-icon icn-holder"></i>
                        <div class="v-counter">
                            <div class="count-number" data-from="0" data-to="2650" data-speed="2000" data-refresh-interval="25"></div>
                            <div class="count-divider"><span></span></div>
                            <h6 class="v-counter-text">Fineshed Projects</h6>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <i class="fa fa-umbrella v-icon icn-holder"></i>
                        <div class="v-counter">
                            <div class="count-number" data-from="0" data-to="5265" data-speed="2500" data-refresh-interval="25"></div>
                            <div class="count-divider"><span></span></div>
                            <h6 class="v-counter-text">Lorem Input Amet</h6>
                        </div>
                    </div>
                </div>
            </div>-->

            <!--<div class="container">
                <div class="v-spacer col-sm-12 v-height-standard"></div>
            </div>-->

            <!--Screenshots-->
            <div class="v-parallax v-bg-stylish v-bg-stylish-v4 no-shadow" id="screenshots">
                <div class="container">
                    <div class="row center">
                        <div class="col-sm-12">
                            <p class="v-smash-text-large-2x">
                                <span>Screenshots</span>
                            </p>
                            <div class="horizontal-break"></div>
                            <p class="lead" style="color: #999;">
                                A single tool joining all & fulfilling need of every stake holders of election system.

                            </p>
                        </div>
                        <div class="v-spacer col-sm-12 v-height-standard"></div>
                    </div>

                    <div class="row">
                        <div class="col-sm-12">

                            <div class="carousel-wrap">

                                <div class="owl-carousel" data-plugin-options='{"items": 4, "singleItem": false, "pagination": true}'>
                                    <div class="item">
                                        <figure class="lightbox animated-overlay overlay-alt clearfix">
                                            <img src="img/2.png" class="attachment-full">
                                            <a class="view" href="img/2.png" rel="image-gallery"></a>
                                            <figcaption>
                                                <div class="thumb-info">
                                                   <!-- <h4>Lorem ipsum dolor sit amet.</h4>-->
                                                    <i class="fa fa-eye"></i>
                                                </div>
                                            </figcaption>
                                        </figure>
                                    </div>

                                    <div class="item">
                                        <figure class="lightbox animated-overlay overlay-alt clearfix">
                                            <img src="img/Truvoter.png" class="attachment-full">
                                            <a class="view" href="img/Truvoter.png" rel="image-gallery"></a>
                                            <figcaption>
                                                <div class="thumb-info">
                                                    <!--<h4>Lorem ipsum dolor sit amet.</h4>-->
                                                    <i class="fa fa-eye"></i>
                                                </div>
                                            </figcaption>
                                        </figure>
                                    </div>

                                    <div class="item">
                                        <figure class="lightbox animated-overlay overlay-alt clearfix">
                                            <img src="img/1.png" class="attachment-full">
                                            <a class="view" href="img/1.png" rel="image-gallery"></a>
                                            <figcaption>
                                                <div class="thumb-info">
                                                    <!--<h4>Lorem ipsum dolor sit amet.</h4>-->
                                                    <i class="fa fa-eye"></i>
                                                </div>
                                            </figcaption>
                                        </figure>
                                    </div>

                                   <!-- <div class="item">
                                        <figure class="lightbox animated-overlay overlay-alt clearfix">
                                            <img src="img/profile.jpg" class="attachment-full">
                                            <a class="view" href="img/profile.jpg" rel="image-gallery"></a>
                                            <figcaption>
                                                <div class="thumb-info">
                                                    <h4>Lorem ipsum dolor sit amet.</h4>
                                                    <i class="fa fa-eye"></i>
                                                </div>
                                            </figcaption>
                                        </figure>
                                    </div>-->

                                    <div class="item">
                                        <figure class="lightbox animated-overlay overlay-alt clearfix">
                                            <img src="img/Officer.png" class="attachment-full">
                                            <a class="view" href="img/Officer.png" rel="image-gallery"></a>
                                            <figcaption>
                                                <div class="thumb-info">
                                                    <!--<h4>Lorem ipsum dolor sit amet.</h4>-->
                                                    <i class="fa fa-eye"></i>
                                                </div>
                                            </figcaption>
                                        </figure>
                                    </div>

                                    <div class="item">
                                        <figure class="lightbox animated-overlay overlay-alt clearfix">
                                            <img src="img/candidate.png" class="attachment-full">
                                            <a class="view" href="img/candidate.png" rel="image-gallery"></a>
                                            <figcaption>
                                                <div class="thumb-info">
                                                    <!--<h4>Lorem ipsum dolor sit amet.</h4>-->
                                                    <i class="fa fa-eye"></i>
                                                </div>
                                            </figcaption>
                                        </figure>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--End Screenshots-->

            <!--Download-->
            <div class="v-parallax v-bg-stylish v-bg-stylish-v10" id="download" style="background-image: url(img/slider/slider4.jpg);">

                <div class="container">
                    <div class="row center">

                        <div class="col-sm-12">

                            <div class="v-content-wrapper">
                                <p class="v-smash-text-large-2x">
                                    <span>Download the app on</span>
                                </p>

                                <div class="v-spacer col-sm-12 v-height-standard"></div>

                                <div id="intro_stores"><a href="https://play.google.com/store/apps/details?id=sec.maharashtra.truevoter.activity&hl=en">
                                <img src="img/landing/google.png" alt="google_icon"></a></div>
                                <p class="v-smash-text-large-2x">&nbsp;</p>
                            </div>

                        </div>

                        <div class="v-bg-overlay overlay-colored"></div>
                    </div>
                </div>
            </div>
            <!--End Download-->

            <!--Call Us-->
            <div class="v-parallax v-bg-stylish" id="contact-us">
                <div class="container">
                    <div class="row center"></div>

                    <div class="row">
                      <div class="v-spacer col-sm-12 v-height-small"></div>
                    </div>

                    <div class="row center">
                        <ul class="social-icons large center">
                           <!-- <li class="twitter"><a href="http://www.twitter.com/#" target="_blank"><i class="fa fa-twitter"></i><i class="fa fa-twitter"></i></a></li>
                            <li class="facebook"><a href="#" target="_blank"><i class="fa fa-facebook"></i><i class="fa fa-facebook"></i></a></li>-->
                            <li class="youtube"><a href="#" target="_blank"><i class="fa fa-youtube"></i><i class="fa fa-youtube"></i></a></li>
                           <!-- <li class="linkedin"><a href="#" target="_blank"><i class="fa fa-linkedin"></i><i class="fa fa-linkedin"></i></a></li>
                            <li class="googleplus"><a href="#" target="_blank"><i class="fa fa-google-plus"></i><i class="fa fa-google-plus"></i></a></li>-->
                        </ul>
                    </div>
                </div>
            </div>
            <!--End Call Us-->
        </div>

        <!--Footer-Wrap-->
        <div class="footer-wrap" style="visibility:hidden">
            <footer>
                <div class="container">
                    <div class="row">
                        <div class="col-sm-5">
                            <section class="widget">
                                <img alt="Venue" src="img/true-voters.jpg" style="height: 40px; margin-bottom: 20px;">
                                <p class="pull-bottom-small">
                                    Class aptent taciti sociosqu ad litora torquent per conubia nostra,
                                    per inceptos himenaeos. Nulla nunc dui, tristique in semper vel,
                                    congue sed ligula auctor fringill torquent per conubia nostra.
                                    Class aptent taciti sociosqu ad litora conubia nostra.
                                </p>
                                <p>
                                    <a href="page-about-us-2.html">Read More →</a>
                                </p>
                            </section>
                        </div>
                        <div class="col-sm-3">
                            <section class="widget">
                                <div class="widget-heading">
                                    <h4>Contact Us</h4>
                                </div>
                                <div class="footer-contact-info">
                                    <ul>
                                        <li>
                                            <p><i class="fa fa-building"></i>Abhinav IT Solutions Pvt. Ltd</p>
                                        </li>
                                        <li>
                                            <p><i class="fa fa-map-marker"></i>Office no. 25-31, B-Wing,</p>
                                        </li>
                                        <li>
                                          <p> &nbsp;&nbsp; Bandal Dhankude Plaza, </p>
                                        </li>
                                        <li>
                                          <p>&nbsp;&nbsp; Paud Road, Kothrud, Pune-38                                          </p>
                                          <p><i class="fa fa-envelope"></i><strong>Email:</strong> <a href="mailto:mail@example.com">md@abhinavitsolutions.com</a></p>
                                        </li>
                                        <li>
                                            <p><i class="fa fa-phone"></i><strong>Phone:</strong> (020) - 25286022</p>
                                        </li>
                                    </ul>
                                    <br />

                                    <ul class="social-icons standard">
                                        <!--<li class="twitter"><a href="#" target="_blank"><i class="fa fa-twitter"></i><i class="fa fa-twitter"></i></a></li>
                                        <li class="facebook"><a href="#" target="_blank"><i class="fa fa-facebook"></i><i class="fa fa-facebook"></i></a></li>-->
                                        
                                        <li class="youtube"><a href="#" target="_blank"><i class="fa fa-youtube"></i><i class="fa fa-youtube"></i></a></li>
                                        <!--<li class="googleplus"><a href="#" target="_blank"><i class="fa fa-google-plus"></i><i class="fa fa-google-plus"></i></a></li>-->
                                    </ul>
                              </div>
                            </section>
                        </div>
 
                        <div class="col-sm-3">
                            <section class="widget">
                                <div class="widget-heading">
                                    <h4>Recent Works</h4>
                                </div>
                                <ul class="portfolio-grid">
                                    <li>
                                        <a href="portfolio-single.html" class="grid-img-wrap">
                                            <img src="img/thumbs/project-1.jpg" />
                                            <span class="tooltip">Phasellus enim libero<span class="arrow"></span></span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="portfolio-single.html" class="grid-img-wrap">
                                            <img src="img/thumbs/project-2.jpg" />
                                            <span class="tooltip">Phasellus enim libero<span class="arrow"></span></span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="portfolio-single.html" class="grid-img-wrap">
                                            <img src="img/thumbs/project-3.jpg" />
                                            <span class="tooltip">Phasellus enim<span class="arrow"></span></span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="portfolio-single.html" class="grid-img-wrap">
                                            <img src="img/thumbs/project-4.png" />
                                            <span class="tooltip">Lorem Imput<span class="arrow"></span></span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="portfolio-single.html" class="grid-img-wrap">
                                            <img src="img/thumbs/project-5.jpg" />
                                            <span class="tooltip">Phasellus Enim libero<span class="arrow"></span></span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="portfolio-single.html" class="grid-img-wrap">
                                            <img src="img/thumbs/project-6.jpg" />
                                            <span class="tooltip">Phasellus Enim<span class="arrow"></span></span>
                                        </a>
                                    </li>
                                </ul>
                            </section>
                        </div>
                    </div>
                </div>
            </footer>

            <div class="copyright">
                <div class="container">
                    <p>© Copyright 2016 by Abhinav IT solutions Pvt. Ltd. All Rights Reserved.</p>
                    <nav class="footer-menu std-menu">
                        <ul class="menu">
                            <li><a href="#">About Us</a></li>
                            <li><a href="#">Services</a></li>
                            <li><a href="#">Portfolio</a></li>
                            <li><a href="#">Contact</a></li>
                        </ul>
                    </nav>
                </div>
            </div>
        </div>
        <!--End Footer-Wrap-->
    </div>

    <!--// BACK TO TOP //-->
    <div id="back-to-top" class="animate-top"><i class="fa fa-angle-up"></i></div>

    <!-- Libs -->
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.flexslider-min.js"></script>
    <script src="js/jquery.easing.js"></script>
    <script src="js/jquery.fitvids.js"></script>
    <script src="js/jquery.carouFredSel.min.js"></script>
    <script src="js/theme-plugins.js"></script>
    <script src="js/jquery.isotope.min.js"></script>
    <script src="js/imagesloaded.js"></script>

    <script src="js/view.min.js?auto"></script>

    <script src="plugins/rs-plugin/js/jquery.themepunch.tools.min.js"></script>
    <script src="plugins/rs-plugin/js/jquery.themepunch.revolution.min.js"></script>

    <script src="js/theme-core.js"></script>
</body>
</html>

