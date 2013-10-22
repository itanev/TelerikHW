<?php
	require_once("header.php");
	$booksCatalog = new BooksCatalog("localhost", "root", "", "books_catalog");
?>

<form method="Post" action="AddAuthor.php">
	<a href="/Telerik HW/BooksCatalog/index.php" title="Книги">Книги</a> <br />
	Автор: <input type="text" name="authorName" /> <br />
	<input type="submit" value="Добави" />
</form>

<form method="Post" action="Author.php">
	<table border='1'>
		<th>Автори</th>
		<?php
			$html = "";
			foreach($booksCatalog->GetAuthors() as $author) {
				$html .= "<tr>";
				$html .= "<td><button type='submit' name='author' value = '{$author->id}'>{$author->name}</button></td>";
				$html .= "</tr>";
			}
			
			echo $html;
		?>
	</table>
</form>

<?php
	if(!empty($_POST)) {
		$authorName = $_POST['authorName'];
		if(strlen($authorName) <= 3) {
			echo "The author name must be more than three characters!";
		}
		else {
			$author = new Author($authorName, Array());
			$booksCatalog->AddAuthor($author);
			echo "Author added.";
		}
	}
	
	require_once("footer.php");
?>