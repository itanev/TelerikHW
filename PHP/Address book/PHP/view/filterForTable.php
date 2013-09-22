<form method = "POST">
	<input type="submit" value="Филтрирай" name="filterTable"/>
	<?php echo generateSelectField($expenses, "filter"); ?>
</form>
