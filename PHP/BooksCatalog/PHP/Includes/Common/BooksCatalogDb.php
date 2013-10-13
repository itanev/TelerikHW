<?php
	class BooksCatalog {
		private $conn;
		
		public function BooksCatalog($host, $username, $password, $dbname) {
			if( !$this->IsValidConnectionProperty($host) || 
				!$this->IsValidConnectionProperty($username) ||
				!$this->IsValidConnectionProperty($password) || 
				!$this->IsValidConnectionProperty($dbname)) {
				
				echo "Invalid connection properies!";
				return;
			}
			
			$this->conn = mysqli_connect($host, $username, $password, $dbname);

			if (mysqli_connect_errno($this->conn)){
				echo "Failed to connect to MySQL: " . mysqli_connect_error();
			}			
		}
		
		public function AddBook($book) {
			if($this->IsValidBook($book)) {
				$query = "INSERT INTO books VALUES(NULL, '{$book->GetTitle()}')";
				$this->conn->query($query);
				$currBookId = $this->conn->insert_id;
				
				foreach($book->GetAuthors() as $authorId) {
					$booksAuthorsQuery = "INSERT INTO books_authors (`author_id`, `books_id`) 
							  VALUES ('{$authorId}', '{$currBookId}')";
					
					$this->conn->query($booksAuthorsQuery);
				}
			}
		}
		
		public function AddAuthor($author) {
			if($this->IsValidAuthor($author)) {
				$query = "INSERT INTO authors VALUES(NULL, '{$author->GetName()}')";
				$this->conn->query($query);
				$currAuthorId = $this->conn->insert_id;
				
				foreach($author->GetBooks() as $bookId) {
					$booksAuthorsQuery = "INSERT INTO books_authors (`author_id`, `books_id`) 
							  VALUES ('{$currAuthorId}', '{$bookId}')";
					
					$this->conn->query($booksAuthorsQuery);
				}
			}
		}
		
		public function GetBooks() {
			return $this->GetAllFromTable("books", "id, title");
		}
		
		public function GetBook($id) {
			if($this->IsValidId($id)) {
				return $this->GetByIdFromTable("books", "title", $id);
			}
		}
		
		public function GetBookAuthors($id) {
			if($this->IsValidId($id)) {
				return $this->JoinTables("id, name", "authors", "author_id", "books_id", $id);
			}
		}
		
		public function GetAuthors() {
			return $this->GetAllFromTable("authors", "id, name");
		}
		
		public function GetAuthor($id) {
			if($this->IsValidId($id)) {
				return $this->GetByIdFromTable("authors", "name", $id);
			}
		}
		
		public function GetAuthorBooks($id) {
			if($this->IsValidId($id)) {
				return $this->JoinTables("id, title", "books", "books_id", "author_id", $id);
			}
		}
		
		private function JoinTables($fieldsToSelect, $data, $joinBy, $filterBy, $id) {
			$query = "SELECT {$fieldsToSelect} FROM {$data}
					  JOIN books_authors ON {$data}.id = books_authors.{$joinBy}
					  WHERE books_authors.{$filterBy} = {$id}";
			
			$all = Array();
			if ($items = $this->conn->query($query)) {
				while($currItem = $items->fetch_object()) {
					array_push($all, $currItem);
				}

				$items->close();
			}
			
			return $all;
		}
		
		private function GetByIdFromTable($tableName, $tableField, $id) {
			$result;
			if ($item = $this->conn->query("SELECT {$tableField} FROM {$tableName} WHERE id = {$id}")) {
				$result = $item->fetch_row();
				$item->close();
			}
			
			return $result;
		}
		
		private function GetAllFromTable($tableName, $tableField) {
			$all = Array();
			if ($items = $this->conn->query("SELECT {$tableField} FROM {$tableName}")) {
				while($currItem = $items->fetch_object()) {
					array_push($all, $currItem);
				}

				$items->close();
			}
			
			return $all;
		}
		
		private function IsValidBook($book) {
			if(!isset($book)) {
				return false;
			}
			
			$bookTitle = $book->GetTitle();
			if(!isset($bookTitle)) {
				return false;
			}
			
			return true;
		}
		
		private function IsValidAuthor($author) {
			if(!isset($author)) {
				return false;
			}
			
			$authorName = $author->GetName();
			if(!isset($authorName)) {
				return false;
			}
			
			return true;
		}
		
		private function IsValidId($id) {
			if(!isset($id)) {
				return false;
			}
		
			if(!is_numeric($id)) {
				return false;
			}
			
			if($id < 0) {
				return false;
			}
			
			return true;
		}

		private function IsValidConnectionProperty($prop) {
			if(!isset($prop)) {
				return false;
			}
			
			return true;
		}
		
		function __destruct() {
			mysqli_close($this->conn);
		}
	}