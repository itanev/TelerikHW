<?php
	mb_internal_encoding('UTF-8');
	define('root', $_SERVER['DOCUMENT_ROOT'] . "/Telerik HW/Address book");
	
	require_once(root . "/PHP/common/constants.php");
	require_once(root. "/PHP/common/functions.php");
?>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title><?php $pageTitle; ?></title>
	<meta charset="UTF-8"> 
	<link rel="stylesheet" type="text/css" href="styles/style.css" />
</head>
<body>


