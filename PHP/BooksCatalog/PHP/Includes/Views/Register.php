<?php 
	require_once("header.php"); 
	
	if(isset($_SESSION['user'])) {
		sleep(1);
		header('Location: ../../../index.php'); 
	}
		
	require_once(root. "/PHP/Includes/Common/UserManager.php");
?>
<form method="post" action="Register.php">
	<a href="/Telerik HW/BooksCatalog/index.php" title="Книги">Книги</a> <br />
	Username: <input type="text" name="username" />
	Password: <input type="password" name="pass" />
	
	<input type="submit" value="Register" />
</form>

<?php
	if(!empty($_POST)) {
		$username = addslashes($_POST['username']);
		$pass = addslashes($_POST["pass"]);
		if( strlen($username) <= 3 || 
			strlen($pass) <= 3 ) {
			echo "Your username and password must be more than three characters!";
		}
		else {
			$db = new UserManager("localhost", "root", "", "books_catalog");
			if($db->Register($username, $pass)) {
				echo "Register successfully!";
				$_SESSION['user'] = $username;
				sleep(1);
				header('Location: ../../../index.php'); 
			} 
			else {
				echo "Invalid Login!";
			}
		}
	}
	
	require_once("footer.php");
?>