<?php
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
			$table .= "<td>" . $book->title . "</td>";
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