<?php
	require_once("header.php"); 
	session_destroy();
	sleep(1);
	header('Location: /Telerik HW/BooksCatalog/index.php'); 
	require_once("footer.php");