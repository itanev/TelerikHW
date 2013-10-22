<?php
	require_once("header.php");
	if(!empty($_POST)) {
		if(isset($_POST['book'])) {
			$_SESSION['bookId'] = $_POST['book'];
			
			header("Location: BookDetails.php");
		}
		
		if(isset($_POST['author'])) {
			$currAuthorId = $_POST['author'];
			$booksCatalog = new BooksCatalog("localhost", "root", "", "books_catalog");
			
			echo "<h1>{$booksCatalog->GetAuthor($currAuthorId)[0]} books</h1>";
			echo GenerateTableForBooksOfAuthor($booksCatalog, $currAuthorId);
		}
	}