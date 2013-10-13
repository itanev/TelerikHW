<?php
	class Book {
		private $title = "";
		private $authors = Array();
		
		public function Book($title, $authors) {
			$this->SetTitle($title);
			$this->SetAuthors($authors);
		}
		
		public function GetTitle() {
			return htmlspecialchars($this->title);
		}
		
		public function SetTitle($title) {
			$this->title = addslashes($title); 
		}
		
		public function GetAuthors() {
			$authors = Array();
			foreach($this->authors as $author) {
				array_push($authors, htmlspecialchars($author));
			}
			
			return $authors;
		}
		
		public function SetAuthors($authors) {
			foreach($authors as $author) {
				if(is_numeric($author)) {
					array_push($this->authors, $author);
				}
			}
		}
	}