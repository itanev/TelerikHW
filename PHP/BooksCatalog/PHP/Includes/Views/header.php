<?php
	mb_internal_encoding('UTF-8');
	define('root', $_SERVER['DOCUMENT_ROOT'] . "/Telerik HW/BooksCatalog");
	
	require_once(root. "/PHP/Includes/Common/functions.php");
	require_once(root. "/PHP/Includes/Common/BooksCatalogDb.php");
	require_once(root. "/PHP/Includes/Common/Book.php");
	require_once(root. "/PHP/Includes/Common/Author.php");
	
	$pageTitle = "Books catalog";
?>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title><?php echo $pageTitle; ?></title>
	<meta charset="UTF-8"> 
	<link rel="stylesheet" type="text/css" href="styles/style.css" />
</head>
<body>


