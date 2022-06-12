
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
      <a class="navigation-link w-nav-link" href="http://version/Blog.php">Блог</a>
      <a class="navigation-link w-nav-link w--current" href="http://version/Help.php">Поддержка/FAQ</a>
      <a class="navigation-link w-nav-link" href="http://version/Contacts.php">Контакты</a>
  </nav>
</div>

<!-- Тут блок с описанием Контактов -->


<div class="section" style="background:url('imgs/Background_for_games.jpg'); background-size: 100%;">



  <h1 class="hero-heading" style="color: black;">Технический раздел</h1>

<?php
include "database_functions.php";
$conn = db_connect();

$result1 = selectAllFAQCOM($conn);
$result2 = selectAllFAQACCESS($conn);
$result3 = selectAllFAQHELP($conn);
?>  <!--Далее отправка маила через форму-->

      

<?php
//проверяем, существуют ли переменные в массиве POST
if(!isset($_POST['userText']) and !isset($_POST['email'])){
 ?> 
 <h5>Не нашли ответа на свой вопрос? Напишите нам!</<h5>
          <form  method="post"  class="myForm">
            <p id="sendEr"></p>
            <input  size="45" required  name="email" class="input" type="text" placeholder="Введите ваш email" required>
            <br>
            <textarea rows="10" cols="45" name="userText" placeholder="Ваше сообщение" required></textarea>
            <br>

            <input type="submit" class="input_form" value="Отправить">
          </form>
<?php
} else {
 //показываем форму
 $userText = $_POST['userText'];
 $email = $_POST['email'];
 $userText = htmlspecialchars($userText);
 $email = htmlspecialchars($email);
 $userText = urldecode($userText);
 $email = urldecode($email);
 $userText = trim($userText);
 $email = trim($email);
 if (mail("antoniy1999@mail.ru", "Технический запрос", "Сообщение:".$userText.". E-mail: ".$email ,"From: example2@mail.ru \r\n")){
 echo "Сообщение успешно отправлено";
 } else {
 echo "При отправке сообщения возникли ошибки";
 }
}
?>

  <div style="
  border: 1px solid black;
  width: 96%;margin:50px; "></div>


  <h1  class="hero-heading" style="color: black;">FAQ</h1>

  <div style="border: 0px solid #f00;padding: 50px ; width:900px;display: inline-table; ">
    <h1  style="color: black;">Сообщество</h1>
    <?php while ($query_row = mysqli_fetch_assoc($result1)) { ?>
       <h1><?php echo $query_row['question']; ?></h1>
       <h5 style="text-align: justify;"><?php echo $query_row['answer']; ?></h5>
    <?php } ?>
  </div>


  <div style="border: 0px solid #f00;padding: 50px ; width:900px;display: inline-table; ">
    <h1  style="color: black;">Доступ к продуктам</h1>
    <?php while ($query_row = mysqli_fetch_assoc($result2)) { ?>
       <h1><?php echo $query_row['question']; ?></h1>
       <h5 style="text-align: justify;"><?php echo $query_row['answer']; ?></h5>
    <?php } ?>
  </div>

  <div style="border: 0px solid #f00;padding: 50px ; width:900px;display: inline-table; ">
    <h1  style="color: black;">Поддержка</h1>
    <?php while ($query_row = mysqli_fetch_assoc($result3)) { ?>
       <h1><?php echo $query_row['question']; ?></h1>
       <h5 style="text-align: justify;"><?php echo $query_row['answer']; ?></h5>
    <?php } ?>
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