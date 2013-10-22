<?php
	require_once("header.php"); 
	require_once(root. "/PHP/Includes/Common/CommentsManager.php");
	
	$commentsContext = new CommentsManager("localhost", "root", "", "books_catalog");
	$booksContext = new BooksCatalog("localhost", "root", "", "books_catalog");
	
	if(isset($_SESSION['bookId'])) {
		$bookId = $_SESSION['bookId'];

		echo "<h1>" . $booksContext->GetBook($bookId)[0] . "</h1>";
		echo "Authors: " . GenerateAuthorsList($booksContext, $bookId);
		ShowComments($commentsContext->GetComments($bookId));
		
		if(!empty($_POST)) {
			if(isset($_POST['content'])) {
				$commentsContext->AddComment($bookId, $_POST['content'], $_SESSION['user']);
			}
		}
	}
	
	if(isset($_SESSION['user'])) {
		echo GenerateCommentsForm("BookDetails.php");
	}
	
	require_once("footer.php");