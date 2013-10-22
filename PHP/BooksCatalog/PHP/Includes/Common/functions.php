<?php
	function ShowComments($comments) {
		foreach($comments as $comment) {
			$html = "<div>";
			$html .= "Author: " . $comment['username'] . "<br />";
			$html .= "Published on: " . $comment['date'] . "<br />";
			$html .= "<p>" . $comment['content'] . "</p><br />";
			$html .= "</div>";
			
			echo $html;
		}
	}

	function GenerateCommentsForm($actionLink) {
		$html = "<form method='POST' action='{$actionLink}'>";
		$html .= "Comment: <textarea name='content'></textarea>";
		$html .= "<input type='hidden' value='{$_SESSION['user']}' name='username' />";
		$html .= "<input type='submit' value='Comment' />";
		$html .= "</form>";
		
		return $html;
	}
	
	function GenerateAuthorsList($booksCatalog, $bookId) {
		$bookAuthors = $booksCatalog->GetBookAuthors($bookId);

		$authorsList = "";
		foreach($bookAuthors as $author) {
			$authorsList .= "<button type='submit' name='author' value = '{$author->id}'>{$author->name}</button>";
		}
		
		return $authorsList;
	}

	function GenerateTable($booksCatalog) {
		$allBooks = $booksCatalog->GetBooks();
		$table = "<table border='1'>";
		foreach($allBooks as $book) {
			$table .= "<tr>";
			$table .= "<td><button type='submit' name='book' value='{$book->id}'>{$book->title}</button></td>";
			$table .= "<td>" . GenerateAuthorsList($booksCatalog, $book->id) . "</td>";
			$table .= "<tr>";
		}
		
		$table .= "</table>";
		return $table;
	}
	
	function GenerateTableForBooksOfAuthor($booksCatalog, $authorId) {
		$currAuthorBooks = $booksCatalog->GetAuthorBooks($authorId);
		
		$table = "<table border='1'>";
		foreach($currAuthorBooks as $book) {
			$table .= "<tr>";
			$table .= "<td>" . $book->title . "</td>";
			$table .= "<tr>";
		}
		
		$table .= "</table>";
		return $table;
	}