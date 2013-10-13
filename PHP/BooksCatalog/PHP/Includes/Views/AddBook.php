<?php 
	require_once("header.php"); 
	$booksCatalog = new BooksCatalog("localhost", "root", "", "books_catalog");
?>
<form method="post" action="AddBook.php">
	<a href="/Telerik HW/BooksCatalog/index.php" title="Книги">Книги</a> <br />
	Име на книгата: <input type="text" name="bookTitle" /> <br />
	<select multiple name="bookAuthors[]">
		<?php
			foreach($booksCatalog->GetAuthors() as $author) {
				echo "<option value='{$author->id}'>{$author->name}</option>";
			}
		?>
	</select>
	<br />
	<input type="submit" value="Добави" />
</form>

<?php
	if(!empty($_POST)) {
		$bookTitle = $_POST['bookTitle'];
		$bookAuthors = $_POST["bookAuthors"];
		if(strlen($bookTitle) <= 3) {
			echo "The book title must be more than three characters!";
		}
		else if(count($bookAuthors) == 0) {
			echo "The book must have author/s!";
		}
		else {
			$book = new Book($bookTitle, $bookAuthors);
			$booksCatalog->AddBook($book);
			echo "Book added.";
		}
	}
?>