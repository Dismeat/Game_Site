
<!DOCTYPE html>
<html lang="ru">
<meta charset="utf-8">

<head>
<meta content="width=device-width, initial-scale=1" name="viewport">
<title>Vecond-MAP</title>


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
<body style="cursor:img src='../imgs/Кнопка.jpg';">
<div class="w-container">
   <a class="brand-link w-nav-brand " href="http://version">
     <h1 class="brand-text">Vecond-MAP <?php echo $avatar; ?></h1>
   </a>
  <nav class="navigation-menu w-nav-menu" role="navigation">
      <a class="navigation-link w-nav-link w--current" href="http://version" >Главная</a>
      <a class="navigation-link w-nav-link" href="http://Forum">Форум</a>
      <a class="navigation-link w-nav-link" href="http://version/Blog.php">Блог</a>
      <a class="navigation-link w-nav-link" href="http://version/Help.php">Поддержка/FAQ</a>
      <a class="navigation-link w-nav-link" href="http://version/Contacts.php">Контакты</a>
  </nav>
</div>

<!-- Тут блок с описанием Дса -->
<div class="centered hero-section">
  <header class="w-container" > <!-- свойство появления внес в аниматион ксс -->
    <h1 class="hero-heading" style="opacity: 1; transform: translateX(0px) translateY(0px) translateZ(0px); transition: opacity 100ms ease 0s, transform 100ms ease 0s;">Discord</h1>
    <div class="hero-subheading" style=" color: rgb(201, 123, 34); opacity: 1; transform: translateX(0px) translateY(0px) translateZ(0px); transition: opacity 1000ms ease 0s, transform 1000ms ease 0s;">Присоединяйтесь к нам через Discord для более удобного общения!
    </div>
    <div class="hero-subheading" style="opacity: 1; transform: translateX(0px) translateY(0px) translateZ(0px); transition: opacity 1000ms ease 0s, transform 1000ms ease 0s;">
       <a class="button" target="_blank" href="https://discordapp.com/users/274449171711393793/ ">Присоединиться</a>
    </div>
    <div class="hero-subheading"  style=" color: rgb(201, 123, 34); opacity: 1; transform: translateX(0px) translateY(0px) translateZ(0px); transition: opacity 1000ms ease 0s, transform 1000ms ease 0s;">Мы создаём игры для мобильных платформ ios и android на Unity. Ниже представлен список разработок в виде играбельных веб-версий с управлением под мышь и клавиатуру.
    </div>
    
  </header>
</div>
<!-- Блок трех игр -->
<div class="section" style="background:url('imgs/трава.jpg'); background-size: 100%;">

<?php
include "database_functions.php";
$conn = db_connect();
$row = select3LatestGames($conn);
?> 
  
     <div class="row" >
        <?php foreach ($row as $product) { ?>
            <div class="col-md-4" style="margin:50px;display:inline-block;">
            <h1 class=games-page-title style="color: rgb(201, 123, 34);"> <?php echo $product['Name']; ?></h1>
                <a href="<?php echo $product['link']; ?>">
                    <img  style="border : 3px solid orange;" width=783 height=824 src="imgs/<?php echo $product['gif']; ?>">
                </a>
            </div>
        <?php } ?>
     </div>

</div>


<!-- Нижний уровень  -->
<div class="footer" style="opacity: 1; transform: translateX(0px) translateY(0px) translateZ(0px); transition: opacity 1000ms ease 0s, transform 1000ms ease 0s;">
   <div class="w-container">
     <div class="w-row">
        <div class="spc w-col w-col-4">
         <h5>О команде</h5>
         <p>Разработка игр под разные мобильные операционные системы на Unity.</p>
        </div>
        <div class="rating col-md-6">
<img width=100 height=100 src="imgs/esrb.jpg" >
<img width=100 height=100 src="imgs/Unity.png" >
<img width=100 height=100 src="imgs/IOS.png" >
<img width=100 height=100 src="imgs/Android.png" >	</div>
      <div class="spc w-col w-col-4">
    </div>
  <div class="w-col w-col-4">
</div>
</div></div></div>
</body></html>