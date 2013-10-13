<?php
	require_once("header.php");
	$currAuthorId = $_POST['author'];
	$booksCatalog = new BooksCatalog("localhost", "root", "", "books_catalog");
	
	echo "<h1>{$booksCatalog->GetAuthor($currAuthorId)[0]} books</h1>";
	echo GenerateTableForBooksOfAuthor($booksCatalog, $currAuthorId);