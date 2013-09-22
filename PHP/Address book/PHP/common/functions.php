<?php
	// Scripts generating functions
	function generateSelectField($values, $name)
	{
		$html = "<select name='" . $name. "'>";
		
		foreach($values as $key => $val)
		{
			$html .= "<option value='" . $key . "'>";
			$html .= $val;
			$html .= "</option>";
		}
		
		$html .= "</select>";
		
		return $html;
	}
	
	function putSelectBoxInContainer($containerId, $valuesForSelectedField)
	{
		$js = "<script>";
		$js .= 'document.getElementById("' . $containerId . '").innerHTML=';
		$js .= '"' . generateSelectField($valuesForSelectedField, "expenses") . '";';
		$js .= "</script>";
		
		return $js;
	}
	
	function filter($arr, $val)
	{
		$result = array();
		foreach($arr as $item)
		{
			$currItem = explode('!', $item);
			
			if(in_array($val, $currItem))
			{
				array_push($result, $item);
			}
		}
		
		return $result;
	}
	
	// Validation functions
	function validateSelectedIndex($group, $selectedIndex)
	{
		$errMsg = false;
		if(!array_key_exists($selectedIndex, $group))
		{
			$errMsg .= "Невалиден вид разход!<br />";
		}
		
		return $errMsg;
	}
	
	function validateExpenseAmount($expenseAmount)
	{
		$errMsg = false;
		if(!is_numeric($expenseAmount))
		{
			$errMsg .= "Разхода трябва да е положително число!<br />";
		}
		
		if($expenseAmount < 0)
		{
			$errMsg .= "Разхода не може да бъде отрицателен!<br />";
		}
		
		return $errMsg;
	}