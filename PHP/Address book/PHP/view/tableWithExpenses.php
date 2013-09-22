<?php
	if(file_exists( root . '/data.txt' ))
	{
		$lines = file(root. '/data.txt');
	}
	else
	{
		return;
	}
	
	if($filter)
	{
		$lines = filter($lines, $filter);
	}
?>
<table>
	<tr>
		<th>Дата</th>
		<th>Разход</th>
		<th>Сума</th>
	</tr>
<?php
	foreach ($lines as $line) 
	{
		echo "<tr>";
		$currLine = explode('!', $line);
		
		foreach($currLine as $cellVal)
		{
			echo "<td>";
			echo $cellVal;
			echo "</td>";
		}
		
		echo "</tr>";
	}
?>
</table>