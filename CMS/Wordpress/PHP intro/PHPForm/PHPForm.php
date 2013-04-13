<?php
	$firstNumber = $_GET['firstNumber'];
	$secondNumber = $_GET['secondNumber'];
	$sign = $_GET['sign'];
	
	if(isValid($firstNumber) && isValid($secondNumber)) {
		switch($sign) {
			case '+':
				echo $firstNumber . ' + ' . $secondNumber . ' = ' . $firstNumber + $secondNumber;
				break;
			case '-':
				echo $firstNumber . ' - ' . $secondNumber . ' = ' . $firstNumber - $secondNumber;
				break;
			case '*':
				echo $firstNumber . ' * ' . $secondNumber . ' = ' . $firstNumber * $secondNumber;
				break;
			case '/':
				if($secondNumber == 0) echo 'Can\'t devide by zero!';
				else
					echo $firstNumber . ' / ' . $secondNumber . ' = ' . $firstNumber / $secondNumber;
				break;
			case '%':
				echo $firstNumber . ' % ' . $secondNumber . ' = ' . $firstNumber % $secondNumber;
				break;
			default:
				echo 'Invalid sign!';
				break;
		}
	}
	else echo 'Invalid numbers!';
	
	function isValid($number) {
		if($number != null && !is_nan($number)) {
			return true;
		}
		
		return false;
	}