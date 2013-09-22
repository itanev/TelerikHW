<?php
	$pageTitle = "Home";
	
	require_once("PHP/view/header.php");
	require_once("PHP/view/form.php");
	require_once("PHP/view/filterForTable.php");
	
	echo putSelectBoxInContainer("expensesSelectField", $expenses);
	
	$errors = false;
	$filter = false;
	
	if(!empty($_POST['addExpense']))
	{
		$selectedIndex = $_POST['expenses'];
		$expenseAmount = trim($_POST['expense']);
		
		$errors .= validateSelectedIndex($expenses, $selectedIndex);
		$errors .= validateExpenseAmount($expenseAmount);
		
		if(!$errors)
		{
			$expenseAmount = (int)$expenseAmount;
			$selectedExpense = $expenses[$selectedIndex];
			$date = date("d.m.y");
			
			$result = $date . '!' . $selectedExpense . '!' . $expenseAmount . "\n";
			if(file_put_contents('data.txt', $result, FILE_APPEND))
			{
				echo "<p class='success'>Записа е успешен.</p>";
			}
		}
		else
		{
			echo "<p class='error'>" . $errors . "</p>";
		}
	}
	else if (!empty($_POST['filterTable']))
	{
		$selectedIndex = $_POST['filter'];
		
		$errors .= validateSelectedIndex($expenses, $selectedIndex);
		
		if(!$errors)
		{
			$filter = $expenses[$selectedIndex];
		}
		else
		{
			echo "<p class='error'>" . $errors . "</p>";
		}
	}
	
	require_once("PHP/view/tableWithExpenses.php");
	require_once("PHP/view/footer.php");