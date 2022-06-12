
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
<body>
<div class="w-container">
   <a class="brand-link w-nav-brand" href="http://version">
     <h1 class="brand-text">Vecond-MAP <?php echo $avatar; ?></h1>
   </a>
  <nav class="navigation-menu w-nav-menu" role="navigation">
      <a class="navigation-link w-nav-link" href="http://version" >Главная</a>
      <a class="navigation-link w-nav-link" href="http://Forum">Форум</a>
      <a class="navigation-link w-nav-link" href="http://version/Blog.php">Блог</a>
      <a class="navigation-link w-nav-link" href="http://version/Help.php">Поддержка/FAQ</a>
      <a class="navigation-link w-nav-link w--current" href="http://version/Contacts.php">Контакты</a>
  </nav>
</div>

<!-- Тут блок с описанием Контактов -->


<div class="centered hero-section">

<h1 class="hero-heading">Контакты</h1>
<?php
include "database_functions.php";
$conn = db_connect();

$result = selectAllContacts($conn);
?>



    <div class="row">
        <?php while ($query_row = mysqli_fetch_assoc($result)) { ?>
                    <p><h5 style="color:rgb(201, 123, 34);">Юридический адрес:</h5>
                    <?php echo $query_row['geo']; ?><p>
                    <?php echo $query_row['adr']; ?><p>
                    <p><h5 style="color:rgb(201, 123, 34);">Телефон(Россия):</h5>
                    <p><?php echo $query_row['tel']; ?><p>
                    <p><h5 style="color:rgb(201, 123, 34);">Почта для предложений:</h5>                 
                    <p><?php echo $query_row['mail']; ?></p>
            <?php
        } ?>
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