<?php
	require_once("PHP/Includes/Views/header.php");
	$booksCatalog = new BooksCatalog("localhost", "root", "", "books_catalog");
	
	$allBooks = $booksCatalog->GetBooks();
	$pathToViews = "/Telerik HW/BooksCatalog/PHP/Includes/Views/";
?>
	<form method="Post" action="<?php echo $pathToViews . "Author.php"; ?>" id="content">
		<a href="<?php echo $pathToViews . "AddBook.php"; ?>" title="Add New Book">Нова книга</a>
		<a href="<?php echo $pathToViews . "AddAuthor.php"; ?>" title="Add New Author">Нов Автор</a>
		<?php echo GenerateTable($booksCatalog); ?>
	</form>
<?php
	require_once("PHP/Includes/Views/footer.php");
?>