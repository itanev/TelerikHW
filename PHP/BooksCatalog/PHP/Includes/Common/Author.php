<?php
	class Author {
		private $name = "";
		private $books = Array();
		
		public function Author($name, $books) {
			$this->SetName($name);
			$this->SetBooks($books);
		}
		
		public function GetName() {
			return htmlspecialchars($this->name);
		}
		
		public function SetName($name) {
			$this->name = addslashes($name); 
		}
		
		public function GetBooks() {
			$books = Array();
			foreach($this->books as $book) {
				array_push($books, htmlspecialchars($book));
			}
			
			return $books;
		}
		
		public function SetBooks($books) {
			foreach($books as $book) {
				if(is_numeric($book)) {
					array_push($this->books, $book);
				}
			}
		}
	}