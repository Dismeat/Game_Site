
<!DOCTYPE html>
<html lang="ru">
<meta charset="utf-8">

<head>
<meta content="width=device-width, initial-scale=1" name="viewport">
<title>Vecond-MAP</title>
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css">
<link href="css/main.css" rel="stylesheet" type="text/css">
<link href="css/style.css" rel="stylesheet" >
<link href="css/anim.css" rel="stylesheet" type="text/css">

<link href="imgs/favicon.png" rel="shortcut icon" type="image/x-icon">
<script src="js/webfont.js" type="text/javascript"></script>
<script src="js/jquery.min.js" type="text/javascript"></script>
</script>
</head>


<?php
$avatar="<img src='imgs/favicon.png'>";
// $back="<img src='imgs/Снег.png' width:2850px >";
?>

<!-- Тут блок верхнего меню -->
<body>
<div class="w-container">
   <a class="brand-link w-nav-brand" href="http://version">
     <h1 class="brand-text">Vecond-MAP <?php echo $avatar; ?></h1>
   </a>
  <nav class="navigation-menu w-nav-menu" role="navigation">
      <a class="navigation-link w-nav-link" href="http://version" >Главная</a>
      <a class="navigation-link w-nav-link" href="http://Forum">Форум</a>
      <a class="navigation-link w-nav-link w--current" href="http://version/Blog.php">Блог</a>
      <a class="navigation-link w-nav-link" href="http://version/Help.php">Поддержка/FAQ</a>
      <a class="navigation-link w-nav-link" href="http://version/Contacts.php">Контакты</a>
  </nav>
</div>



<!-- Тут блок с играми -->


<div class="section" style="background:url('imgs/Background_for_games.jpg'); background-size: 100%;">




    <div class="jumbotron" style="display: inline-block;">
          <div class="header" >
                   <div class="container">
                     <div class="logo2">Последнии новости разработчиков</div>
                   </div>
          </div>
    </div> 
    
    
    <div style="border: 1px solid black;"></div>

    <div style="border: 1px solid black;"></div>

    <!-- Тут идет двойная таблица после черной прямой -->

    <div style="border: 0px solid #f00;padding: 50px ; width:900px;display: inline-table; ">
    <?php
    include "database_functions.php";
    $conn = db_connect();
    $result = selectALLgames($conn);
    $result1 = selectALLnews($conn);
    ?>
    <div class="container" style="display: inline-block;">
               <a class="button" target="_blank" href="https://discordapp.com/users/274449171711393793/ ">Больше игр</a>
    </div>
    <?php for ($i = 0; $i < mysqli_num_rows($result); $i++) { ?>
    <div class="row">
        <?php while ($product = mysqli_fetch_assoc($result)) { ?>
            <div class="col-md-4" style="margin-bottom: 50px;">
            <h1 class=games-page-title style="color:black"> <?php echo $product['Name']; ?></h1>
                <a href="<?php echo $product['link']; ?>">
                    <img width=300 height=300 src="imgs/<?php echo $product['gif']; ?>">
                </a>
            </div>
            <?php
            $count++;
            if ($count >= 1) {
                $count = 0;
                break;
            }
        } ?>
    </div><?php } ?>
    </div>

    <div style="border: 0px solid #f00;padding: 50px ; width:900px;display: inline-table; ">
    <div class="jumbotron"  >
        <?php for ($i = 0; $i < mysqli_num_rows($result1); $i++) { ?>
        <div class="row">
            <?php while ($product1 = mysqli_fetch_assoc($result1)) { ?>
          <div class="container" style="margin-bottom: 80px;">
            <h3 class=games-page-title style="color:black"> <?php echo $product1['name']; ?></h3>
            <h2></h2>
              <p style="display: inline-table; color:black" ><?php echo $product1['plot']; ?></p>
            <h2></h2>
                <p ><?php echo $product1['data']; ?></p >
          </div>
            <?php
            $count++;
            if ($count >= 1) {
                $count = 0;
                break;
            }
        } ?>
        </div><?php } ?>
    </div>
    </div>

    <div class="container"style="border: 0px solid #f00;padding: 50px ; width:900px;display: inline-table; ">
    <h1 class=games-page-title style="color:black; margin-botom:50px;"> Следите за нами:</h1>
    <table>
      <th width=70 height=70></th>
      <th width=70 height=70></th>
      <th width=70 height=70></th>
      <th width=70 height=70></th>

      <th><a href="#">
          <img  width=70 height=70 src="imgs/discord.png">
      </th></a>
      <th><a href="#">
          <img  width=100 height=70 src="imgs/twitch.jpg">
      </th></a>
      <th><a href="#">
          <img  width=70 height=70 src="imgs/youtube.jpg">
      </th></a>
      <th><a href="#">
          <img  width=70 height=70 src="imgs/vk.jpg">
      </th></a>
    </table>
    </div>
</div>



<!-- Нижний уровень  -->
<div class="footer" style="opacity: 1; transform: translateX(0px) translateY(0px) translateZ(0px); transition: opacity 1000ms ease 0s, transform 1000ms ease 0s;">
   <div class="w-container">

        <div class="spc w-col w-col-4">
         <h5>О команде</h5>
         <p>Разработка игр под разные мобильные операционные системы на Unity.</p>
        </div>
        <div class="rating col-md-6">
<img width=100 height=100 src="imgs/esrb.jpg" >
<img width=100 height=100 src="imgs/Unity.png" >
<img width=100 height=100 src="imgs/IOS.png" >
<img width=100 height=100 src="imgs/Android.png" >	</div>

</div></div>
</body></html>