<?php
function db_connect()
{
    $conn = mysqli_connect("localhost", "root", "root", "GamesSite");
    if (!$conn) {
        echo "Can't connect database " . mysqli_connect_error();
        exit;
    }
    return $conn;
}

function select3LatestGames($conn)
{
    $row = array();
    $query = "SELECT * FROM `Games` ORDER BY `nomer` DESC";
    $result = mysqli_query($conn, $query);
    if (!$result) {
        echo "Can't retrieve data " . mysqli_error($conn);
        exit;
    }
    for ($i = 0; $i < 3; $i++) {
        array_push($row, mysqli_fetch_assoc($result));
    }
    return $row;
}

function selectALLgames($conn)
{
    $row = array();
    $query = "SELECT * FROM `Games` ORDER BY `nomer` DESC";
    $result = mysqli_query($conn, $query);
    if (!$result) {
        echo "Can't retrieve data " . mysqli_error($conn);
        exit;
    }
    return $result;
}

function selectALLnews($conn)
{
    $row = array();
    $query = "SELECT * FROM `news` ORDER BY `nomer` DESC";
    $result = mysqli_query($conn, $query);
    if (!$result) {
        echo "Can't retrieve data " . mysqli_error($conn);
        exit;
    }
    return $result;
}

function selectAllContacts($conn)
{
    $row = array();
    $query = "SELECT * FROM `contacts`";
    $result = mysqli_query($conn, $query);
    if (!$result) {
        echo "Can't retrieve data " . mysqli_error($conn);
        exit;
    }
    return $result;
}

function selectAllFAQCOM($conn)
{
    $row = array();
    $query = "SELECT * FROM `faqCommunity`";
    $result = mysqli_query($conn, $query);
    if (!$result) {
        echo "Can't retrieve data " . mysqli_error($conn);
        exit;
    }
    return $result;
}
function selectAllFAQACCESS($conn)
{
    $row = array();
    $query = "SELECT * FROM `faqAccess`";
    $result = mysqli_query($conn, $query);
    if (!$result) {
        echo "Can't retrieve data " . mysqli_error($conn);
        exit;
    }
    return $result;
}
function selectAllFAQHELP($conn)
{
    $row = array();
    $query = "SELECT * FROM `faqHelp`";
    $result = mysqli_query($conn, $query);
    if (!$result) {
        echo "Can't retrieve data " . mysqli_error($conn);
        exit;
    }
    return $result;
}





function getProductById($conn, $productid)
{
    $query = "SELECT `????????????????`, `????????` FROM `??????????` WHERE `??????????_????????????` = '$productid'";
    $result = mysqli_query($conn, $query);
    if (!$result) {
        echo "Can't retrieve data " . mysqli_error($conn);
        exit;
    }
    return $result;
}


function insertIntoOrder($conn, $customerid, $productid, $date, $qty)
{
    $query = "INSERT INTO `????????????????` (`??????????_??????????????`, `??????????_????????????`, `????????`, `????????????????????`) VALUES
		('" . $customerid . "', '" . $productid . "', '" . $date . "', '" . $qty . "')";
    $result = mysqli_query($conn, $query);
    if (!$result) {
        echo "Insert orders failed " . mysqli_error($conn);
        exit;
    }
    return mysqli_insert_id($conn);
}

function insertIntoCustomers($conn, $email, $phone, $password)
{
    $query = "INSERT INTO `??????????????` (`e-mail`, `??????????????`, `????????????`, `??????????`) VALUES
		('" . $email . "', '" . $phone . "', '" . $password . "', '5%')";
    $result = mysqli_query($conn, $query);
    if (!$result) {
        echo "Insert customers failed " . mysqli_error($conn);
        exit;
    }
    return mysqli_insert_id($conn);
}

function getProductPrice($productid)
{
    $conn = db_connect();
    $query = "SELECT `????????` FROM `??????????` WHERE `??????????_????????????` = '$productid'";
    $result = mysqli_query($conn, $query);
    if (!$result) {
        echo "get product price failed! " . mysqli_error($conn);
        exit;
    }
    $row = mysqli_fetch_assoc($result);
    return $row['????????'];
}

function getOrdersByCustomerId($conn, $customerid)
{
    $query = "SELECT * from `????????????????` WHERE `??????????_??????????????` = '$customerid' ORDER BY '????????' DESC";
    $result = mysqli_query($conn, $query);
    if (mysqli_num_rows($result) == 0) {
        return null;
    } else {
        return $result;
    }
}


function getAllTypes($conn)
{
    $query = "SELECT * FROM `?????? ????????????`";
    $result = mysqli_query($conn, $query);
    if (!$result) {
        echo "Can't retrieve data " . mysqli_error($conn);
        exit;
    } else {
        $types = array();
        while ($row = mysqli_fetch_assoc($result)) {
            $types[] = $row;
        }
        return $types;
    }
}

function getTypeById($conn, $id)
{
    $query = "SELECT * FROM `?????? ????????????` WHERE `??????????_????????`='$id'";
    $result = mysqli_query($conn, $query);
    if (!$result) {
        echo "Can't retrieve data " . mysqli_error($conn);
        exit;
    } else {
        $row = mysqli_fetch_assoc($result);
        $type = $row['????????????????'];
        return $type;
    }
}

function getUserByEmailAndPassword($conn, $email, $password)
{
    $query = "SELECT * FROM `??????????????` WHERE `e-mail`='$email' AND `????????????`='$password' LIMIT 1";
    return mysqli_query($conn, $query);
}

function getAdminByEmailAndPassword($conn, $email, $password)
{
    $query = "SELECT * FROM `admin` WHERE `e-mail`='$email' AND `????????????`='$password' LIMIT 1";
    return mysqli_query($conn, $query);
}

function getUserInfo($conn, $customerid)
{
    $query = "SELECT `??????????????`, `e-mail` FROM `??????????????` WHERE `??????????_??????????????` = '$customerid'";
    $result = mysqli_query($conn, $query);
    if (!$result) {
        echo "Can't retrieve data " . mysqli_error($conn);
        exit;
    }
    return $result;
}

function selectCakeById($conn, $id)
{
    $query = "SELECT * FROM `??????????` WHERE `??????????_????????????`='$id'";
    return mysqli_query($conn, $query);
}
?>